using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void Járandóság(string hely)
        {
            string jelszó = "csavarhúzó";
            string táblanév = "Tábla_Járandóság";

            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);
            string szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[Munkakör]  char (250),";
            szöveg += "[Cikkszám]  char (10),";
            szöveg += "[Mennyiség]  Short,";
            szöveg += "[Gyakoriság]  Short,";
            szöveg += "[státus]  yesno)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }
    }
}
