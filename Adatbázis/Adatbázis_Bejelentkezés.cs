using Tisztito.Adatszerkezet;


namespace Tisztito.Adatbázis

{
    public static partial class Adatbázis_Létrehozás
    {
        public static void Adatbázis_Bejelentkezés(string hely)
        {
            string szöveg;
            string jelszó = "lilaakác";
            string táblanév;

            //Létrehozzuk az adatbázist és beállítunk jelszót
            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);

            //string táblanév = "Users";
            //szöveg = $"CREATE TABLE {táblanév} (";
            //szöveg += "[UserId] AUTOINCREMENT PRIMARY KEY,";
            //szöveg += "[OldalId] short,";
            //szöveg += "[UserName] CHAR(25),";
            //szöveg += "[Password] CHAR(50),";
            //szöveg += "[Törölt] yesno)";
            //AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);

            táblanév = "Oldalak";
            szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[OldalId] AUTOINCREMENT PRIMARY KEY,";
            szöveg += "[FromName] CHAR(255),";
            szöveg += "[MenuName] CHAR(255),";
            szöveg += "[MenuFelirat] CHAR(255),";
            szöveg += "[Látható] yesno,";
            szöveg += "[Törölt] yesno)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);

            //táblanév = "Funkciók";
            //szöveg = $"CREATE TABLE {táblanév} (";
            //szöveg += "[FunkciókId] AUTOINCREMENT PRIMARY KEY,";
            //szöveg += "[FunkciókName] CHAR(100),";
            //szöveg += "[FunkciókGombName] CHAR(255),";
            //szöveg += "[Törölt] yesno)";
            //AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);  

            //táblanév = "Jogosultság";
            //szöveg = $"CREATE TABLE {táblanév} (";
            //szöveg += "[JogosultságId] AUTOINCREMENT PRIMARY KEY,";
            //szöveg += "[UserId] short,";
            //szöveg += "[OldalId] short,";
            //szöveg += "[FunkciókId] short,";
            //szöveg += "[FunkciókEnabled] yesno,"; ;
            //szöveg += "[FunkciókGombName] CHAR(255),";
            //szöveg += "[TelephelyId] short,";
            //szöveg += "[Törölt] yesno)";
            //AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }

        public static void Adatbázis_Oldalak(string hely)
        {
            string szöveg;
            string jelszó = "lilaakác";

            //Létrehozzuk az adatbázist és beállítunk jelszót
            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);

            string táblanév = "Tábla_Oldalak";
            szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[OldalId] AUTOINCREMENT PRIMARY KEY,";
            szöveg += "[FromName] CHAR(255),";
            szöveg += "[MenuName] CHAR(255),";
            szöveg += "[MenuFelirat] CHAR(255),";
            szöveg += "[Látható] yesno,";
            szöveg += "[Törölt] yesno)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }

        public static void Adatbázis_Gombok(string hely)
        {
            string szöveg;
            string jelszó = "lilaakác";

            //Létrehozzuk az adatbázist és beállítunk jelszót
            AdatBázis_kezelés.AB_Adat_Bázis_Létrehozás(hely, jelszó);

            string táblanév = "Gombok";
            szöveg = $"CREATE TABLE {táblanév} (";
            szöveg += "[GombokId] AUTOINCREMENT PRIMARY KEY,";
            szöveg += "[FromName] CHAR(255),";
            szöveg += "[GombName] CHAR(255),";
            szöveg += "[GombFelirat] CHAR(255),";
            szöveg += "[Látható] yesno,";
            szöveg += "[Törölt] yesno)";
            AdatBázis_kezelés.AB_Adat_Tábla_Létrehozás(hely, jelszó, szöveg, táblanév);
        }
    }
}

