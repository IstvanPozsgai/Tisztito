using System;

namespace Tisztito.Adatszerkezet
{
    public class Adat_KészletRaktKönyvelés
    {
        public string Cikkszám { get; private set; }
        public int Mennyiség { get; private set; }
        public string SzervezetHonnan { get; private set; }
        public string SzervezetHova { get; private set; }
        public string Bizonylat { get; private set; }
        public string Rögzítő { get; private set; }
        public DateTime Dátum { get; private set; }
        public string Pdf { get; private set; }

        public Adat_KészletRaktKönyvelés(string cikkszám, int mennyiség, string szervezetHonnan, string szervezetHova, string bizonylat, string rögzítő, DateTime dátum, string pdf)
        {
            Cikkszám = cikkszám;
            Mennyiség = mennyiség;
            SzervezetHonnan = szervezetHonnan;
            SzervezetHova = szervezetHova;
            Bizonylat = bizonylat;
            Rögzítő = rögzítő;
            Dátum = dátum;
            Pdf = pdf;
        }
    }
}
