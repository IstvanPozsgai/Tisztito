using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Tisztito.Adatbázis;
using Tisztito.Adatszerkezet;
using MyA = Adatbázis;


namespace Tisztito.Kezelők
{
    public class Kezelő_Alap_Beolvasás
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Beolvasás.mdb";
        readonly string jelszó = "sajátmagam";
        readonly string táblanév = "Tábla_Beolvasás";

        public Kezelő_Alap_Beolvasás()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Egyéb_beolvasás(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.Egyéb_beolvasás(hely);
        }

        public List<Adat_Alap_Beolvasás> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM {táblanév}";
            List<Adat_Alap_Beolvasás> Adatok = new List<Adat_Alap_Beolvasás>();
            Adat_Alap_Beolvasás Adat;

            string kapcsolatiszöveg = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszó}";
            using (OleDbConnection Kapcsolat = new OleDbConnection(kapcsolatiszöveg))
            {
                Kapcsolat.Open();
                using (OleDbCommand Parancs = new OleDbCommand(szöveg, Kapcsolat))
                {
                    using (OleDbDataReader rekord = Parancs.ExecuteReader())
                    {
                        if (rekord.HasRows)
                        {
                            while (rekord.Read())
                            {
                                Adat = new Adat_Alap_Beolvasás(
                                        rekord["csoport"].ToStrTrim(),
                                        rekord["oszlop"].ToÉrt_Int(),
                                        rekord["fejléc"].ToStrTrim(),
                                        rekord["státus"].ToÉrt_Bool(),
                                        rekord["Változónév"].ToStrTrim()
                                     );
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

        public void Rögzítés(Adat_Alap_Beolvasás Adat)
        {
            string szöveg = $"INSERT INTO {táblanév} ";
            szöveg += " ( csoport, oszlop, fejléc, státus, Változónév)";
            szöveg += " VALUES ";
            szöveg += $" ('{Adat.Csoport}', {Adat.Oszlop}, '{Adat.Fejléc}', {Adat.Státusz}, '{Adat.Változónév}')";
            MyA.ABMódosítás(hely, jelszó, szöveg);
        }

        public void Rögzítés(List<Adat_Alap_Beolvasás> Adatok)
        {
            List<string> szövegek = new List<string>();
            foreach (Adat_Alap_Beolvasás Adat in Adatok)
            {
                string szöveg = $"INSERT INTO {táblanév} ";
                szöveg += " ( csoport, oszlop, fejléc, státus , Változónév )";
                szöveg += " VALUES ";
                szöveg += $" ('{Adat.Csoport}', {Adat.Oszlop}, '{Adat.Fejléc}', {Adat.Státusz}, '{Adat.Változónév}')";
                szövegek.Add(szöveg);
            }
            MyA.ABMódosítás(hely, jelszó, szövegek);
        }


        public void Módosítás(Adat_Alap_Beolvasás Adat)
        {
            try
            {
                string szöveg = $"UPDATE  {táblanév} SET ";
                szöveg += $" fejléc='{Adat.Fejléc}', ";
                szöveg += $" Változónév='{Adat.Változónév}'";
                szöveg += $" WHERE [csoport]= '{Adat.Csoport}' and [oszlop]={Adat.Oszlop}";
                szöveg += $" and [státus]={Adat.Státusz}";
                MyA.ABMódosítás(hely, jelszó, szöveg);
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, this.ToString(), ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Törlés(Adat_Alap_Beolvasás Adat)
        {
            try
            {
                string szöveg = "UPDATE  {táblanév} SET ";
                szöveg += $" törölt=true ";
                szöveg += $" WHERE [csoport]= '{Adat.Csoport}'  and [oszlop]={Adat.Oszlop}";
                szöveg += $" and [strátus]={Adat.Státusz}";
                MyA.ABMódosítás(hely, jelszó, szöveg);
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, this.ToString(), ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
