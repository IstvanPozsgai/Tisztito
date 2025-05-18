using System;

namespace Tisztito.Adatszerkezet
{
    public class Adat_KészletNaplóRaktár
    {
        public string Cikkszám { get; private set; }
        public int Mennyiség { get; private set; }
        public string SzervezetHonnan { get; private set; }
        public string SzervezetHova { get; private set; }
        public string Bizonylat { get; private set; }
        public string Rögzítő { get; private set; }
        public DateTime Dátum { get; private set; }
        public string Pdf { get; private set; }
        public bool Storno { get; private set; }
        public string Storno_Rögzítő { get; private set; }
        public DateTime Storno_Dátum { get; private set; }

        public Adat_KészletNaplóRaktár(string cikkszám, int mennyiség, string szervezetHonnan, string szervezetHova, string bizonylat, string rögzítő, DateTime dátum, string pdf, bool storno, string storno_Rögzítő, DateTime storno_Dátum)
        {
            Cikkszám = cikkszám;
            Mennyiség = mennyiség;
            SzervezetHonnan = szervezetHonnan;
            SzervezetHova = szervezetHova;
            Bizonylat = bizonylat;
            Rögzítő = rögzítő;
            Dátum = dátum;
            Pdf = pdf;
            Storno = storno;
            Storno_Rögzítő = storno_Rögzítő;
            Storno_Dátum = storno_Dátum;
        }

        public Adat_KészletNaplóRaktár(string cikkszám, int mennyiség, string szervezetHonnan, string szervezetHova, bool storno, string storno_Rögzítő, DateTime storno_Dátum)
        {
            Cikkszám = cikkszám;
            Mennyiség = mennyiség;
            SzervezetHonnan = szervezetHonnan;
            SzervezetHova = szervezetHova;
            Storno = storno;
            Storno_Rögzítő = storno_Rögzítő;
            Storno_Dátum = storno_Dátum;
        }
    }
}
