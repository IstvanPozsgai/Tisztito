using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;
using MyF = Függvénygyűjtemény;

namespace Tisztito
{
    public class IDM_Dolgozó
    {
        readonly static Kezelő_Alap_Beolvasás KézBeolvasás = new Kezelő_Alap_Beolvasás();
        readonly static Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();


        public static void Védő_beolvasás(string Excel_hely)
        {
            try
            {
                //beolvassuk az excel táblát és megnézzük, hogy megegyezik-e a két fejléc
                DataTable Tábla = MyF.Excel_Tábla_Beolvas(Excel_hely);
                if (!MyF.Betöltéshelyes("Dolgozó", Tábla)) throw new HibásBevittAdat("Nem megfelelő a betölteni kívánt adatok formátuma ! ");

                // Beolvasni kívánt oszlopok
                List<Adat_Alap_Beolvasás> oszlopnév = KézBeolvasás.Lista_Adatok();
                oszlopnév = (from a in oszlopnév
                             where a.Csoport == "Dolgozó"
                             && a.Törölt == "0"
                             select a).ToList();

                MyE.ExcelMegnyitás(Excel_hely);

                // Minden dolgozót feltöltünk
                List<Adat_Dolgozó> Dolgozók = KézDolgozó.Lista_Adatok();

                int sor = 2;
                while (MyE.Beolvas("A" + sor) != "_")
                {
                    // beolvassuk az adatokat
                    string sztsz = MyE.Beolvas(MyE.Oszlopnév(1) + sor);
                    //Ha csak számot tartalmaz akkor foglalkozunk tovább vele
                    Regex vizsgál = new Regex(@"[0-9]", RegexOptions.Compiled);
                    if (vizsgál.IsMatch(sztsz))
                    {
                        sztsz = MyF.Szöveg_Tisztítás(MyF.Eleje_kihagy(sztsz, "0"), 0, 8);
                        string családnévutónév = MyF.Szöveg_Tisztítás((MyE.Beolvas(MyE.Oszlopnév(7) + sor) + " " + MyE.Beolvas(MyE.Oszlopnév(8) + sor)), 0, 50);
                        string munkakör = MyF.Szöveg_Tisztítás(MyE.Beolvas(MyE.Oszlopnév(9) + sor), 0, 50);
                        string státussz = MyE.Beolvas(MyE.Oszlopnév(4) + sor);

                        Adat_Dolgozó ADAT = new Adat_Dolgozó(
                            sztsz.Trim(),
                            családnévutónév.Trim(),
                            DateTime.Today,
                            new DateTime(1900, 1, 1),
                            munkakör.Trim());


                        // meg nézzük, hogy van-e már ilyen adat
                        if (!DolgozóVan(Dolgozók, sztsz))
                            KézDolgozó.Rögzítés_IDM(Cmbtelephely.Trim(), ADAT);
                        else
                           if (státussz.Trim() == "ACTIVE") KézDolgozó.Módosítás_IDM(ADAT);
                    }
                    sor++;
                }
                // az excel tábla bezárása
                MyE.ExcelBezárás();
                // kitöröljük a betöltött fájlt
                File.Delete(Excel_hely);
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, "Behajtási_beolvasás", ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static bool DolgozóVan(List<Adat_Dolgozó> Dolgozók, string HRazonosító)
        {
            bool válasz = false;
            if (Dolgozók.Any(d => d.Dolgozószám.Trim() == HRazonosító.Trim())) válasz = true;
            return válasz;
        }
    }
}
