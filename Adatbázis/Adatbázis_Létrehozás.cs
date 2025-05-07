using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void Anyag(string hely)
        {
            string szöveg;
            string jelszó = "csavarhúzó";

            AdatBázis_kezelés ADAT = new AdatBázis_kezelés();
            ADAT.AB_Adatbázis_Létrehozás(hely, jelszó);

            szöveg = "CREATE TABLE Tábla_Anyag (";
            szöveg += "[Cikkszám]  char (10),";
            szöveg += "[Megnevezés]  char (250),";
            szöveg += "[Rajzszám]  char (50),";
            szöveg += "[MennyiségEgység]  char (10),";
            szöveg += "[státus]  yesno)";
            ADAT.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg);

        }

    }
}
