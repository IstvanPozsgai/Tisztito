

using Bejelentkezés.Adatszerkezet;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Tisztito;
using Tisztito.Adatbázis;

namespace Bejelentkezés.Kezelők
{
    public class Kezelők_Users
    {
        readonly string hely = $@"{Application.StartupPath}\Adatok\Belépés.mdb";
        readonly string jelszó = "csavarhúzó";
        readonly string táblanév = "Users";

        public Kezelők_Users()
        {
            if (!File.Exists(hely)) Adatbázis_Létrehozás.Adatbázis_Bejelentkezés(hely.KönyvSzerk());
        }

        public List<Adat_Users> Lista_Adatok()
        {
            List<Adat_Users> Adatok = new List<Adat_Users>();
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
                                Adat_Users Adat = new Adat_Users(
                                        rekord["UserId"].ToÉrt_Int(),
                                        rekord["OldalId"].ToÉrt_Int(),
                                        rekord["UserName"].ToStrTrim(),
                                        rekord["Password"].ToStrTrim(),
                                        rekord["Törölt"].ToÉrt_Bool());

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
