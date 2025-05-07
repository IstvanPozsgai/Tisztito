namespace Tisztito.Adatszerkezet
{
    public class Adat_Anyag
    {
        public string Cikkszám { get; private set; }
        public string Megnevezés { get; private set; }
        public string Rajzszám { get; private set; }
        public string MennyiségEgység { get; private set; }
        public bool Státus { get; private set; }

        public Adat_Anyag(string cikkszám, string megnevezés, string rajzszám, string mennyiségEgység, bool státus)
        {
            Cikkszám = cikkszám;
            Megnevezés = megnevezés;
            Rajzszám = rajzszám;
            MennyiségEgység = mennyiségEgység;
            Státus = státus;
        }
    }
}
