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
    public class Kezelő_Raktár
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Alapadatok.mdb";
        readonly string jelszó = "csavarhúzó";
        readonly string táblanév = "Tábla_Raktár_Készlet";
        List<Adat_Raktár> Adatok = new List<Adat_Raktár>();

        public Kezelő_Raktár()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Adatbázis_Oldalak(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.Adatbázis_Oldalak(hely);

        }

        public List<Adat_Raktár> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM {táblanév}";
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
                                Adat_Raktár Adat = new Adat_Raktár(
                                        rekord["Cikkszám"].ToStrTrim(),
                                        rekord["Szervezet"].ToStrTrim(),
                                        rekord["Mennyiség"].ToÉrt_Int());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

        public void Döntés(Adat_Raktár Adat)
        {
            try
            {
                Adatok.Clear();
                Adatok = Lista_Adatok();
                Adat_Raktár Készlet = Adatok.FirstOrDefault(a => a.Cikkszám == Adat.Cikkszám && a.Szervezet == Adat.Szervezet);
                if (Készlet == null)
                    Rögzítés(Adat);
                else
                    Módosítás(Adat, Készlet.Mennyiség);

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

        public void Rögzítés(Adat_Raktár Adat)
        {
            try
            {
                string szöveg = $"INSERT INTO {táblanév} (Cikkszám, Szervezet, Mennyiség) VALUES ";
                szöveg += $"('{Adat.Cikkszám}', '{Adat.Szervezet}', {Adat.Mennyiség})";
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


        public void Módosítás(Adat_Raktár Adat, int készlet)
        {
            try
            {
                string szöveg = $"UPDATE {táblanév} SET ";
                szöveg += $"Mennyiség={Adat.Mennyiség + készlet}";
                szöveg += $" WHERE ";
                szöveg += $"Cikkszám='{Adat.Cikkszám}' AND ";
                szöveg += $"Szervezet='{Adat.Szervezet}' ";
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
