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
    public class Kezelő_Anyag
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Alapadatok.accdb";
        readonly string jelszó = "csavarhúzó";

        public Kezelő_Anyag()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Anyag(hely.KönyvSzerk());
        }

        public List<Adat_Anyag> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM Tábla_Anyag ORDER BY Cikkszám";
            List<Adat_Anyag> Adatok = new List<Adat_Anyag>();
            Adat_Anyag Adat;

            //   string kapcsolatiszöveg = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{hely}'; Jet Oledb:Database Password={jelszó}";
            string kapcsolatiszöveg = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={hely};Jet OLEDB:Database Password={jelszó};";
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
                                Adat = new Adat_Anyag(
                                        rekord["Cikkszám"].ToStrTrim(),
                                        rekord["Megnevezés"].ToStrTrim(),
                                        rekord["Rajzszám"].ToStrTrim(),
                                        rekord["MennyiségEgység"].ToStrTrim(),
                                        rekord["Státus"].ToÉrt_Bool());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }


        public void Döntés(Adat_Anyag Adat)
        {
            try
            {
                List<Adat_Anyag> Adatok = Lista_Adatok();
                if (!Adatok.Any(a => a.Cikkszám == Adat.Cikkszám))
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

        public void Rögzítés(Adat_Anyag Adat)
        {
            try
            {
                string szöveg = $"INSERT INTO Tábla_Anyag (Cikkszám, Megnevezés, Rajzszám, MennyiségEgység, Státus) VALUES ";
                szöveg += $"('{Adat.Cikkszám}', '{Adat.Megnevezés}', '{Adat.Rajzszám}', '{Adat.MennyiségEgység}', {Adat.Státus})";
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

        public void Módosítás(Adat_Anyag Adat)
        {
            try
            {
                string szöveg = "UPDATE Tábla_Anyag SET ";
                szöveg += $"Megnevezés='{Adat.Megnevezés}', ";
                szöveg += $"Rajzszám='{Adat.Rajzszám}', ";
                szöveg += $"MennyiségEgység='{Adat.MennyiségEgység}', ";
                szöveg += $"Státus={Adat.Státus}";
                szöveg += $" WHERE Cikkszám='{Adat.Cikkszám}'";
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
