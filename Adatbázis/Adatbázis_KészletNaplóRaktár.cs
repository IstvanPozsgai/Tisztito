using Tisztito.Adatszerkezet;

namespace Tisztito.Adatbázis
{
    public static partial class Adatbázis_Létrehozás
    {
        public static void KészletNaplóRaktár(string hely)
        {
            string jelszó = "napló";
            string táblanév = "Tábla_Készlet_Napló_Raktár";

            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);
            string szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[Cikkszám]  char (10),";
            szöveg += "[Mennyiség]  Short,";
            szöveg += "[SzervezetHonnan]  char (200),";
            szöveg += "[SzervezetHova]  char (200),";
            szöveg += "[Bizonylatszám]  char (15),";
            szöveg += "[Rögzítő]  char (50),";
            szöveg += "[Dátum]  Date,";
            szöveg += "[Pdf]  char (250),";
            szöveg += "[Storno] yesno,";
            szöveg += "[Storno_Rögzítő]  char (50),";
            szöveg += "[Storno_Dátum]  Date)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }
    }
}