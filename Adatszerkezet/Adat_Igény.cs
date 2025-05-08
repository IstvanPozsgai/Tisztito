namespace Tisztito.Adatszerkezet
{
    public class Adat_Igény
    {
        public string Munkakör { get; private set; }
        public string Cikkszám { get; private set; }
        public int Mennyiség { get; private set; }

        public string Dolgozószám { get; private set; }
        public string Szervezet { get; private set; }

        public Adat_Igény(string munkakör, string cikkszám, int mennyiség, string dolgozószám, string szervezet)
        {
            Munkakör = munkakör;
            Cikkszám = cikkszám;
            Mennyiség = mennyiség;
            Dolgozószám = dolgozószám;
            Szervezet = szervezet;
        }
    }
}
