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

        public List<Adat_KészletNaplóRaktár> Lista_Adatok(int Év, bool stornóval=true  )
        {
            FájlBeállítás(Év);
            List<Adat_KészletNaplóRaktár> Adatok = new List<Adat_KészletNaplóRaktár>();
            string szöveg = $"SELECT * FROM {táblanév}";
            if (!stornóval) szöveg += " WHERE Storno=False";

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
                                         rekord["Storno"].ToÉrt_Bool(),
                                         rekord["Storno_Rögzítő"].ToStrTrim(),
                                         rekord["Storno_Dátum"].ToÉrt_DaTeTime(),
                                         rekord["Dolgozószám"].ToStrTrim());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

        /// <summary>
        /// Ez a változat akkor használatos, ha raktárak között történik a rögzítés, 
        /// mint például a raktárak közötti átadás, vagy a raktárak közötti áthelyezés.
        /// </summary>
        /// <param name="Év"></param>
        /// <param name="Adat"></param>
        public void Rögzítés(int Év, Adat_KészletNaplóRaktár Adat)
        {
            try
            {
                FájlBeállítás(Év);
                string szöveg = $"INSERT INTO {táblanév} (Cikkszám, Mennyiség, SzervezetHonnan, SzervezetHova, Bizonylatszám, Rögzítő, Dátum, Storno, Storno_Rögzítő, Storno_Dátum, Dolgozószám) VALUES ";
                szöveg += $"('{Adat.Cikkszám}', ";
                szöveg += $"{Adat.Mennyiség}, ";
                szöveg += $"'{Adat.SzervezetHonnan}', ";
                szöveg += $"'{Adat.SzervezetHova}', ";
                szöveg += $"'{Adat.Bizonylat}', ";
                szöveg += $"'{Adat.Rögzítő}', ";
                szöveg += $"'{Adat.Dátum}', ";
                szöveg += $"{Adat.Storno}, ";
                szöveg += $"'{Adat.Storno_Rögzítő}', ";
                szöveg += $"'{Adat.Storno_Dátum}', ";
                szöveg += $"'')";
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

        /// <summary>
        /// Ez a változat akkor használatos, ha raktárak között történik a rögzítés és SAPBól jön az adat.
        /// </summary>
        /// <param name="Adatok"></param>
        /// <param name="Év"></param>
        public void Rögzítés(List<Adat_KészletNaplóRaktár> Adatok, int Év)
        {
            try
            {
                FájlBeállítás(Év);
                List<string> SzövegGy = new List<string>();
                List<Adat_Raktár> AdatKészlet = new List<Adat_Raktár>();
                foreach (Adat_KészletNaplóRaktár Adat in Adatok)
                {
                    string szöveg = $"INSERT INTO {táblanév} (Cikkszám, Mennyiség, SzervezetHonnan, SzervezetHova, Bizonylatszám, Rögzítő, Dátum, Storno, Storno_Rögzítő, Storno_Dátum, Dolgozószám) VALUES ";
                    szöveg += $"('{Adat.Cikkszám}', ";
                    szöveg += $"{Adat.Mennyiség}, ";
                    szöveg += $"'{Adat.SzervezetHonnan}', ";
                    szöveg += $"'{Adat.SzervezetHova}', ";
                    szöveg += $"'{Adat.Bizonylat}', ";
                    szöveg += $"'{Adat.Rögzítő}', ";
                    szöveg += $"'{Adat.Dátum}', ";
                    szöveg += $"{Adat.Storno}, ";
                    szöveg += $"'{Adat.Storno_Rögzítő}', ";
                    szöveg += $"'{Adat.Storno_Dátum}', ";
                    szöveg += $"'')";
                    SzövegGy.Add(szöveg);

                    //Ahova könyvelünk
                    Adat_Raktár ADAT = new Adat_Raktár(
                        Adat.Cikkszám,
                        Adat.SzervezetHova,
                        Adat.Mennyiség);
                    AdatKészlet.Add(ADAT);
                }
                MyA.ABMódosítás(hely, jelszó, SzövegGy);
                if (AdatKészlet.Count > 0) KézRaktár.Döntés(AdatKészlet);

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

        /// <summary>
        /// Ez a változat akkor használatos, ha a rögzítés nem raktárak között történik, tehát a dolgozóknak kerül kiosztásra
        /// </summary>
        /// <param name="Év"></param>
        /// <param name="Adat"></param>
        public void Rögzítés(int Év, List<Adat_KészletNaplóRaktár> Adatok)
        {
            try
            {
                FájlBeállítás(Év);

                List<string> SzövegGy = new List<string>();
                int mennyiség = 0;
                foreach (Adat_KészletNaplóRaktár Adat in Adatok)
                {
                    string szöveg = $"INSERT INTO {táblanév} (Cikkszám, Mennyiség, SzervezetHonnan, SzervezetHova, Bizonylatszám, Rögzítő, Dátum, Storno, Storno_Rögzítő, Storno_Dátum, Dolgozószám) VALUES ";
                    szöveg += $"('{Adat.Cikkszám}', ";
                    szöveg += $"{Adat.Mennyiség}, ";
                    szöveg += $"'{Adat.SzervezetHonnan}', ";
                    szöveg += $"'{Adat.SzervezetHova}', ";
                    szöveg += $"'{Adat.Bizonylat}', ";
                    szöveg += $"'{Adat.Rögzítő}', ";
                    szöveg += $"'{Adat.Dátum:yyyy.MM.dd}', ";
                    szöveg += $"{Adat.Storno}, ";
                    szöveg += $"'{Adat.Storno_Rögzítő}', ";
                    szöveg += $"'{Adat.Storno_Dátum:yyyy.MM.dd}', ";
                    szöveg += $"'{Adat.Dolgozószám}')";

                    SzövegGy.Add(szöveg);
                    mennyiség += Adat.Mennyiség;
                }
                MyA.ABMódosítás(hely, jelszó, SzövegGy);

                //Ahova könyvelünk
                Adat_Raktár ADAT = new Adat_Raktár(
                    Adatok[0].Cikkszám,
                    Adatok[0].SzervezetHonnan,
                    -1 * mennyiség);
                KézRaktár.Döntés(ADAT);
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

        /// <summary>
        /// Raktátak közötti mozgásokat egyenként lehet stornózni
        /// </summary>
        /// <param name="Év"></param>
        /// <param name="Adat"></param>
        public void Módosítás(int Év, Adat_KészletNaplóRaktár Adat)
        {
            try
            {
                FájlBeállítás(Év);
                string szöveg = $"UPDATE {táblanév} SET ";
                szöveg += $"Bizonylatszám='{Adat.Bizonylat}', ";
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

        /// <summary>
        /// A dolgozóknak történő kiadások stornózását listában végzi el.
        /// </summary>
        /// <param name="Év"></param>
        /// <param name="Adat"></param>
        public void Módosítás(int Év, List<Adat_KészletNaplóRaktár> Adatok)
        {
            try
            {
                FájlBeállítás(Év);
                List<string> SzövegGy = new List<string>();
                foreach (Adat_KészletNaplóRaktár Adat in Adatok)
                {
                    string szöveg = $"UPDATE {táblanév} SET ";
                    szöveg += $"Bizonylatszám='{Adat.Bizonylat}', ";
                    szöveg += $"Storno={true}, ";
                    szöveg += $"Storno_Rögzítő='{Adat.Storno_Rögzítő}', ";
                    szöveg += $"Storno_Dátum='{Adat.Storno_Dátum}' ";
                    szöveg += $" WHERE ";
                    szöveg += $"Cikkszám='{Adat.Cikkszám}' AND ";
                    szöveg += $"SzervezetHonnan='{Adat.SzervezetHonnan}' AND ";
                    szöveg += $"Dolgozószám='{Adat.Dolgozószám}' AND ";
                    szöveg += $"Mennyiség={Adat.Mennyiség} AND ";
                    szöveg += $"Dátum=#{Adat.Dátum:MM-dd-yyyy}# AND ";
                    szöveg += $"Storno={false}";
                    SzövegGy.Add(szöveg);

                    //Ahonnan könyveltünk de csak akkor ha nem beérkezés
                    Adat_Raktár ADAT = new Adat_Raktár(
                           Adat.Cikkszám,
                           Adat.SzervezetHonnan,
                           Adat.Mennyiség);
                    KézRaktár.Döntés(ADAT);
                }
                MyA.ABMódosítás(hely, jelszó, SzövegGy);
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

        /// <summary>
        /// Bizonylatszámot ad vissza amihez lehet rögzíteni az adott tételeket.
        /// </summary>
        /// <param name="Betűjel"></param>
        /// <returns></returns>
        public string Bizonylat(string Betűjel)
        {
            string Válasz = $"{Betűjel}_{DateTime.Today.Year}_";
            try
            {
                FájlBeállítás(DateTime.Today.Year);
                List<Adat_KészletNaplóRaktár> Adatok = Lista_Adatok(DateTime.Today.Year);
                Adatok = (from a in Adatok
                          where a.Bizonylat.Contains(Válasz)
                          orderby a.Bizonylat
                          select a).ToList();
                if (Adatok == null || Adatok.Count == 0)
                    Válasz += "1";
                else
                {
                    int maximum = 1;
                    foreach (Adat_KészletNaplóRaktár item in Adatok)
                    {
                        string[] darabol = item.Bizonylat.Split('_');
                        int érték = darabol[2].ToÉrt_Int();
                        if (érték < maximum) érték = maximum;
                    }
                    maximum++;   // beállítjuk a következő értéket
                    Válasz += $"{maximum}";
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
            return Válasz;
        }
    }
}
