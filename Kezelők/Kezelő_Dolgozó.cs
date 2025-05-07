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
    public class Kezelő_Dolgozó
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Alapadatok.mdb";
        readonly string jelszó = "csavarhúzó";
        readonly string táblanév = "Tábla_Dolgozó";

        public Kezelő_Dolgozó()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Anyag(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.Dolgozó(hely);
        }

        public List<Adat_Dolgozó> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM {táblanév} ORDER BY Dolgozónév";
            List<Adat_Dolgozó> Adatok = new List<Adat_Dolgozó>();
            Adat_Dolgozó Adat;

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
                                Adat = new Adat_Dolgozó(
                                        rekord["Dolgozószám"].ToStrTrim(),
                                        rekord["Dolgozónév"].ToStrTrim(),
                                        rekord["Munkakör"].ToStrTrim(),
                                        rekord["Szervezet"].ToStrTrim(),
                                        rekord["Státus"].ToÉrt_Bool());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }


        public void Döntés(Adat_Dolgozó Adat)
        {
            try
            {
                List<Adat_Dolgozó> Adatok = Lista_Adatok();
                if (!Adatok.Any(a => a.Dolgozószám == Adat.Dolgozószám))
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

        public void Rögzítés(Adat_Dolgozó Adat)
        {
            try
            {
                string szöveg = $"INSERT INTO {táblanév} ( Dolgozószám, Dolgozónév, Munkakör, Szervezet, státus) VALUES ";
                szöveg += $"('{Adat.Dolgozószám}', '{Adat.Dolgozónév}', '{Adat.Munkakör}', '{Adat.Szervezet}', {Adat.Státus})";
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

        public void Módosítás(Adat_Dolgozó Adat)
        {
            try
            {

                string szöveg = $"UPDATE {táblanév} SET ";
                szöveg += $"Dolgozónév='{Adat.Dolgozónév}', ";
                szöveg += $"Szervezet='{Adat.Szervezet}', ";
                szöveg += $"Munkakör='{Adat.Munkakör}', ";
                szöveg += $"Státus={Adat.Státus}";
                szöveg += $" WHERE Dolgozószám='{Adat.Dolgozószám}'";
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
