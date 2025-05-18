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
    public class Kezelő_KészletNaplóRaktár
    {
        string hely;
        readonly string jelszó = "napló";
        readonly string táblanév = "Tábla_Készlet_Napló_Raktár";
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();

        private void FájlBeállítás(int Év)
        {
            hely = $@"{Application.StartupPath}\Adatok\Naplózás_{Év}.mdb";
            if (!File.Exists(hely)) Adatbázis_Létrehozás.KészletNaplóRaktár(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.KészletNaplóRaktár(hely);

        }

        public List<Adat_KészletNaplóRaktár> Lista_Adatok(int Év)
        {
            FájlBeállítás(Év);
            List<Adat_KészletNaplóRaktár> Adatok = new List<Adat_KészletNaplóRaktár>();
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
                                Adat_KészletNaplóRaktár Adat = new Adat_KészletNaplóRaktár(
                                        rekord["Cikkszám"].ToStrTrim(),
                                         rekord["Mennyiség"].ToÉrt_Int(),
                                         rekord["SzervezetHonnan"].ToStrTrim(),
                                         rekord["SzervezetHova"].ToStrTrim(),
                                         rekord["Bizonylatszám"].ToStrTrim(),
                                         rekord["Rögzítő"].ToStrTrim(),
                                         rekord["Dátum"].ToÉrt_DaTeTime(),
                                         rekord["Pdf"].ToStrTrim(),
                                         rekord["Storno"].ToÉrt_Bool(),
                                         rekord["Storno_Rögzítő"].ToStrTrim(),
                                         rekord["Storno_Dátum"].ToÉrt_DaTeTime());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

        public void Rögzítés(int Év, Adat_KészletNaplóRaktár Adat)
        {
            try
            {
                FájlBeállítás(Év);
                string szöveg = $"INSERT INTO {táblanév} (Cikkszám, Mennyiség, SzervezetHonnan, SzervezetHova, Bizonylatszám, Rögzítő, Dátum, Pdf, Storno, Storno_Rögzítő, Storno_Dátum) VALUES ";
                szöveg += $"('{Adat.Cikkszám}', ";
                szöveg += $"{Adat.Mennyiség}, ";
                szöveg += $"'{Adat.SzervezetHonnan}', ";
                szöveg += $"'{Adat.SzervezetHova}', ";
                szöveg += $"'{Adat.Bizonylat}', ";
                szöveg += $"'{Adat.Rögzítő}', ";
                szöveg += $"'{Adat.Dátum}', ";
                szöveg += $"'{Adat.Pdf}', ";
                szöveg += $"{Adat.Storno}, ";
                szöveg += $"'{Adat.Storno_Rögzítő}', ";
                szöveg += $"'{Adat.Storno_Dátum}') ";
                MyA.ABMódosítás(hely, jelszó, szöveg);

                //Ahova könyvelünk
                Adat_Raktár ADAT = new Adat_Raktár(
                    Adat.Cikkszám,
                    Adat.SzervezetHova,
                    Adat.Mennyiség);
                KézRaktár.Döntés(ADAT);

                if (Adat.SzervezetHonnan != "Érkeztetés")
                {
                    //Ahonnan könyvelünk de csak akkor ha nem beérkezés
                    ADAT = new Adat_Raktár(
                           Adat.Cikkszám,
                           Adat.SzervezetHonnan,
                           -1 * Adat.Mennyiség);
                    KézRaktár.Döntés(ADAT);
                }
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

        public void Módosítás(int Év, Adat_KészletNaplóRaktár Adat)
        {
            try
            {
                FájlBeállítás(Év);
                string szöveg = $"UPDATE {táblanév} SET ";
                szöveg += $"Storno={true}, ";
                szöveg += $"Storno_Rögzítő='{Adat.Storno_Rögzítő}', ";
                szöveg += $"Storno_Dátum='{Adat.Storno_Dátum}' ";
                szöveg += $" WHERE ";
                szöveg += $"Cikkszám='{Adat.Cikkszám}' AND ";
                szöveg += $"SzervezetHonnan='{Adat.SzervezetHonnan}' AND ";
                szöveg += $"SzervezetHova='{Adat.SzervezetHova}' AND ";
                szöveg += $"Mennyiség={Adat.Mennyiség} AND ";
                szöveg += $"Storno={false}";
                MyA.ABMódosítás(hely, jelszó, szöveg);

                //Ahova könyveltünk
                Adat_Raktár ADAT = new Adat_Raktár(
                    Adat.Cikkszám,
                    Adat.SzervezetHova,
                    -1 * Adat.Mennyiség);
                KézRaktár.Döntés(ADAT);

                if (Adat.SzervezetHonnan != "Érkeztetés")
                {
                    //Ahonnan könyveltünk de csak akkor ha nem beérkezés
                    ADAT = new Adat_Raktár(
                           Adat.Cikkszám,
                           Adat.SzervezetHonnan,
                           Adat.Mennyiség);
                    KézRaktár.Döntés(ADAT);
                }

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
