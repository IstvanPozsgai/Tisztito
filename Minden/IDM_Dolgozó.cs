using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
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

                //Meghatározzuk a beolvasó tábla elnevezéseit
                string oszlopHR = (from a in oszlopnév where a.Csoport == "Dolgozó" && a.Törölt == false && a.Kell == "Dolgozószám" select a.Fejléc).FirstOrDefault();
                string oszlopMunka = (from a in oszlopnév where a.Csoport == "Dolgozó" && a.Törölt == false && a.Kell == "Munkakör" select a.Fejléc).FirstOrDefault();
                string oszlopNév = (from a in oszlopnév where a.Csoport == "Dolgozó" && a.Törölt == false && a.Kell == "Dolgozónév" select a.Fejléc).FirstOrDefault();
                string oszlopStátus = (from a in oszlopnév where a.Csoport == "Dolgozó" && a.Törölt == false && a.Kell == "Státusz" select a.Fejléc).FirstOrDefault();
                string oszlopSzerv = (from a in oszlopnév where a.Csoport == "Dolgozó" && a.Törölt == false && a.Kell == "Szervezet" select a.Fejléc).FirstOrDefault();
                if (oszlopHR == null || oszlopMunka == null || oszlopNév == null || oszlopStátus == null || oszlopSzerv == null) throw new HibásBevittAdat("Nincs helyesen beállítva a beolvasótábla! ");

                // Minden dolgozót feltöltünk
                List<Adat_Dolgozó> Dolgozók = KézDolgozó.Lista_Adatok();
                List<Adat_Dolgozó> DolgozókGY = new List<Adat_Dolgozó>();
                foreach (DataRow sor in Tábla.Rows)
                {
                    // beolvassuk az adatokat
                    string sztsz = sor[oszlopHR].ToString();
                    //Ha csak számot tartalmaz akkor foglalkozunk tovább vele
                    Regex vizsgál = new Regex(@"[0-9]", RegexOptions.Compiled);
                    if (vizsgál.IsMatch(sztsz))
                    {
                        sztsz = MyF.Szöveg_Tisztítás(MyF.Eleje_kihagy(sztsz, "0"), 0, 8);
                        string családnévutónév = MyF.Szöveg_Tisztítás(sor[oszlopNév].ToString(), 0, 50);
                        string munkakör = MyF.Szöveg_Tisztítás(sor[oszlopMunka].ToString(), 0, 50);
                        string szervezet = MyF.Szöveg_Tisztítás(sor[oszlopSzerv].ToString(), 0, 50);
                        string státussz = sor[oszlopStátus].ToStrTrim().ToUpper();

                        Adat_Dolgozó ADAT = new Adat_Dolgozó(
                            sztsz.Trim(),
                            családnévutónév.Trim(),
                            munkakör,
                            szervezet,
                            státussz != "ACTIVE");
                        DolgozókGY.Add(ADAT);
                    }
                }
                KézDolgozó.IDMBeolvasás(DolgozókGY);
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
    }
}
