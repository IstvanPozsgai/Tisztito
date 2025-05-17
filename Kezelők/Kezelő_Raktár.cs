using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Tisztito.Adatbázis;
using Tisztito.Adatszerkezet;

namespace Tisztito.Kezelők
{
    public class Kezelő_Raktár
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Alapadatok.mdb";
        readonly string jelszó = "csavarhúzó";
        readonly string táblanév = "Tábla_Raktár_Készlet";

        public Kezelő_Raktár()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.RaktárKészlet(hely.KönyvSzerk());
            if (!AdatBázis_kezelés.TáblaEllenőrzés(hely, jelszó, táblanév)) Adatbázis_Létrehozás.RaktárKészlet(hely);

        }

        public List<Adat_Raktár> Lista_Adatok()
        {
            string szöveg = $"SELECT * FROM {táblanév}";
            List<Adat_Raktár> Adatok = new List<Adat_Raktár>();


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
                                        rekord["Szervezet"].ToStrTrim(),
                                        rekord["Cikkszám"].ToStrTrim(),
                                        rekord["Mennyiség"].ToÉrt_Int());
                                Adatok.Add(Adat);
                            }
                        }
                    }
                }
            }
            return Adatok;
        }

    }
}
