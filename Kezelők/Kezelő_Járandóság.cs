using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatbázis;
using Tisztito.Adatszerkezet;
using MyA = Adatbázis;


namespace Tisztito.Kezelők
{
    public class Kezelő_Járandóság
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Alapadatok.mdb";
        readonly string jelszó = "csavarhúzó";
        readonly string táblanév = "Tábla_Járandóság";

        public Kezelő_Járandóság()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Járandóság(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.Járandóság(hely);
        }

        public List<Adat_Járandóság> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM {táblanév}";
            List<Adat_Járandóság> Adatok = new List<Adat_Járandóság>();


            string kapcsolatiszöveg = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszó}";

            using (OleDbConnection Kapcsolat = new OleDbConnection(kapcsolatiszöveg))
            {
                using (OleDbCommand Parancs = new OleDbCommand(szöveg, Kapcsolat))
                {
                    Kapcsolat.Open();
                    using (OleDbDataReader rekord = Parancs.ExecuteReader())
                    {
                        if (rekord.HasRows)
                        {
                            while (rekord.Read())
                            {
                                Adat_Járandóság Adat = new Adat_Járandóság(
                                        rekord["Munkakör"].ToStrTrim(),
                                        rekord["Cikkszám"].ToStrTrim(),
                                        rekord["Mennyiség"].ToÉrt_Int(),
                                        rekord["Gyakoriság"].ToÉrt_Int(),
                                        rekord["Státus"].ToÉrt_Bool());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

        public void Döntés(Adat_Járandóság Adat)
        {
            try
            {
                List<Adat_Járandóság> Adatok = Lista_Adatok();
                if (!Adatok.Any(a => a.Munkakör == Adat.Munkakör && a.Cikkszám == Adat.Cikkszám))
                    Rögzítés(Adat);
                else
                    Módosítás(Adat);

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

        public void Rögzítés(Adat_Járandóság Adat)
        {
            try
            {
                string szöveg = $"INSERT INTO {táblanév} ( Munkakör, Cikkszám, Mennyiség, Gyakoriság, státus) VALUES ";
                szöveg += $"('{Adat.Munkakör}', '{Adat.Cikkszám}', {Adat.Mennyiség}, {Adat.Gyakoriság}, {Adat.Státus})";
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

        public void Módosítás(Adat_Járandóság Adat)
        {
            try
            {

                string szöveg = $"UPDATE {táblanév} SET ";
                szöveg += $"Mennyiség={Adat.Mennyiség}, ";
                szöveg += $"Gyakoriság={Adat.Gyakoriság}, ";
                szöveg += $"Státus={Adat.Státus}";
                szöveg += $" WHERE Munkakör='{Adat.Munkakör}' AND";
                szöveg += $" Cikkszám='{Adat.Cikkszám}' ";
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
