namespace Tisztito.Adatszerkezet
{
    public class Adat_Járandóság
    {
        public string Munkakör { get; private set; }
        public string Cikkszám { get; private set; }
        public int Mennyiség { get; private set; }
        public int Gyakoriság { get; private set; }
        public bool Státus { get; private set; }

        public Adat_Járandóság(string munkakör, string cikkszám, int mennyiség, int gyakoriság, bool státus)
        {
            Munkakör = munkakör;
            Cikkszám = cikkszám;
            Mennyiség = mennyiség;
            Gyakoriság = gyakoriság;
            Státus = státus;
        }
    }
}
