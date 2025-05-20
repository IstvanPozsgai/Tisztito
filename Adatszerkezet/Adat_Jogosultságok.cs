namespace Bejelentkezés.Adatszerkezet
{
    public class Adat_Jogosultságok
    {
        public int JogosultságId { get; private set; }
        public int UserId { get; private set; }
        public string JogosultságName { get; private set; }
        public bool JogosultságVisible { get; private set; }
        public bool JogosultságEnabled { get; private set; }
        public string JogosultságGombName { get; private set; }
        public bool Törölt { get; private set; }
        public Adat_Jogosultságok(int jogosultságId, int userId, string jogosultságName, bool jogosultságVisible, bool jogosultságEnabled, string jogosultságGombName, bool törölt)
        {
            JogosultságId = jogosultságId;
            UserId = userId;
            JogosultságName = jogosultságName;
            JogosultságVisible = jogosultságVisible;
            JogosultságEnabled = jogosultságEnabled;
            JogosultságGombName = jogosultságGombName;
            Törölt = törölt;
        }
    }
}
