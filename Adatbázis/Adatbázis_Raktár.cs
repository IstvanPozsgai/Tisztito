using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void RaktárKészlet(string hely)
        {
            string jelszó = "csavarhúzó";
            string táblanév = "Tábla_Raktár_Készlet";

            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);
            string szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[Cikkszám]  char (10),";
            szöveg += "[Mennyiség]  Short,";
            szöveg += "[Szervezet]  char (200),";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }
    }
}
