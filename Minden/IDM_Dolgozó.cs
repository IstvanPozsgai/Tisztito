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
                             orderby a.Oszlop
                             select a).ToList();

                MyE.ExcelMegnyitás(Excel_hely);

                // Minden dolgozót feltöltünk
                List<Adat_Dolgozó> Dolgozók = KézDolgozó.Lista_Adatok();

                int sor = 2;
                List<Adat_Dolgozó> AdatokGy = new List<Adat_Dolgozó>();
                while (MyE.Beolvas("A" + sor) != "_")
                {
                    // beolvassuk az adatokat
                    string sztsz = MyE.Beolvas($"B{sor}");
                    //Ha csak számot tartalmaz akkor foglalkozunk tovább vele
                    Regex vizsgál = new Regex(@"[0-9]", RegexOptions.Compiled);
                    if (vizsgál.IsMatch(sztsz))
                    {
                        sztsz = MyF.Szöveg_Tisztítás(MyF.Eleje_kihagy(sztsz, "0"), 0, 8);
                        string családnévutónév = MyF.Szöveg_Tisztítás((MyE.Beolvas($"E{sor}")), 0, 250);
                        string munkakör = MyF.Szöveg_Tisztítás(MyE.Beolvas($"K{sor}"), 0, 250);
                        string státussz = MyE.Beolvas($"J{sor}");
                        string szervezet = MyF.Szöveg_Tisztítás(MyE.Beolvas($"P{sor}"), 0, 200);

                        Adat_Dolgozó ADAT = new Adat_Dolgozó(
                            sztsz.Trim(),
                            családnévutónév.Trim(),
                            munkakör.Trim(),
                            szervezet,
                            false);
                        AdatokGy.Add(ADAT);
                    }
                    sor++;
                }
                if (AdatokGy.Count > 0) KézDolgozó.IDMBeolvasás(AdatokGy);
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
