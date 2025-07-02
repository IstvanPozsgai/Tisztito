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

namespace Tisztito.Minden
{
    public class SAP_Raktár
    {
        readonly static Kezelő_Alap_Beolvasás KézBeolvasás = new Kezelő_Alap_Beolvasás();
        readonly static Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly static Kezelő_KészletNaplóRaktár KézNaplóRaktár = new Kezelő_KészletNaplóRaktár();

        public static void Raktár_beolvasás(string Excel_hely)
        {
            try
            {

                //beolvassuk az excel táblát és megnézzük, hogy megegyezik-e a két fejléc
                DataTable Tábla = MyF.Excel_Tábla_Beolvas(Excel_hely);
                if (!MyF.Betöltéshelyes("SAPBeérkez", Tábla)) throw new HibásBevittAdat("Nem megfelelő a betölteni kívánt adatok formátuma ! ");

                // Beolvasni kívánt oszlopok
                List<Adat_Alap_Beolvasás> oszlopnév = KézBeolvasás.Lista_Adatok();
                // Anyagok listája
                List<Adat_Anyag> AnyagokGY = KézAnyag.Lista_Adatok();

                //Meghatározzuk a beolvasó tábla elnevezéseit
                string OAnyag = (from a in oszlopnév where a.Csoport == "SAPBeérkez" && a.Státusz == false && a.Változónév == "Anyag" select a.Fejléc).FirstOrDefault();
                string OE_MENNYIS = (from a in oszlopnév where a.Csoport == "SAPBeérkez" && a.Státusz == false && a.Változónév == "Mennyiség" select a.Fejléc).FirstOrDefault();
                string OKönyvdát = (from a in oszlopnév where a.Csoport == "SAPBeérkez" && a.Státusz == false && a.Változónév == "KönyvDátum" select a.Fejléc).FirstOrDefault();
                string OBizonylat = (from a in oszlopnév where a.Csoport == "SAPBeérkez" && a.Státusz == false && a.Változónév == "Bizonylat" select a.Fejléc).FirstOrDefault();
                if (OAnyag == null || OE_MENNYIS == null || OKönyvdát == null || OBizonylat == null) throw new HibásBevittAdat("Nincs helyesen beállítva a beolvasótábla! ");

                // Minden anyagot feltöltünk
                List<Adat_KészletNaplóRaktár> AdatokGY = new List<Adat_KészletNaplóRaktár>();
                foreach (DataRow sor in Tábla.Rows)
                {
                    // beolvassuk az adatokat
                    string Anyag = sor[OAnyag].ToString();
                    //Ha csak számot tartalmaz akkor foglalkozunk tovább vele
                    Regex vizsgál = new Regex(@"[0-9]", RegexOptions.Compiled);
                    if (vizsgál.IsMatch(Anyag))
                    {
                        Anyag = MyF.Szöveg_Tisztítás(MyF.Eleje_kihagy(Anyag, "0"), 0, 10);
                        //ha van ilyen anyag akkor rögzítjük
                        if (AnyagokGY.Where(a => a.Cikkszám == Anyag && !a.Státus).FirstOrDefault() != null)
                        {
                            DateTime KönyvDátum = sor[OKönyvdát].ToÉrt_DaTeTime();
                            int Mennyiség = sor[OE_MENNYIS].ToÉrt_Int();
                            string Bizonylat = MyF.Szöveg_Tisztítás(sor[OBizonylat].ToString(), 0, 15);

                            Adat_KészletNaplóRaktár ADAT = new Adat_KészletNaplóRaktár(
                                    Anyag,
                                    Mennyiség,
                                    "Érkeztetés",
                                    "Központi raktár",
                                    Bizonylat,
                                    Program.PostásNév,
                                    KönyvDátum,
                                    false,
                                    "",
                                    new DateTime(1900, 1, 1));
                            AdatokGY.Add(ADAT);
                        }
                    }
                }
                if (AdatokGY.Count > 0) KézNaplóRaktár.Rögzítés(DateTime.Now.Year, AdatokGY);
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
