namespace Tisztito.Adatszerkezet
{
    public class Adat_Raktár
    {
        public string Cikkszám { get; private set; }
        public string Szervezet { get; private set; }
        public int Mennyiség { get; private set; }


        public Adat_Raktár(string cikkszám, string szervezet, int mennyiség)
        {
            Cikkszám = cikkszám;
            Szervezet = szervezet;
            Mennyiség = mennyiség;
        }
    }
}
