using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void Dolgozó(string hely)
        {
            string jelszó = "csavarhúzó";
            string táblanév = "Tábla_Dolgozó";

            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);
            string szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[Dolgozószám]  char (8),";
            szöveg += "[Dolgozónév]  char (250),";
            szöveg += "[Munkakör]  char (250),";
            szöveg += "[Szervezet]  char (200),";
            szöveg += "[státus]  yesno)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }
    }
}
