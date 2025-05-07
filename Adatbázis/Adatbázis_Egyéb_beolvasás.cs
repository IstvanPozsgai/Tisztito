using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void Egyéb_beolvasás(string hely)
        {
            string jelszó = "sajátmagam";
            string táblanév = "Tábla_Beolvasás";

            //Létrehozzuk az adatbázist és beállítunk jelszót
            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);

            string szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += " [csoport] CHAR(10), ";
            szöveg += " [oszlop] short,";
            szöveg += " [fejléc] CHAR(255),";
            szöveg += " [törölt] CHAR(1),";
            szöveg += " [kell] long)";

            //Létrehozzuk az adattáblát
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }

    }
}
