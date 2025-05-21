namespace Bejelentkezés.Adatszerkezet
{
    public class Adat_Users
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string WinUserName { get; private set; }
        public string Password { get; private set; }
        public bool Törölt { get; private set; }

        public Adat_Users(int userId, string userName, string winUserName, string password, bool törölt)
        {
            UserId = userId;
            UserName = userName;
            WinUserName = winUserName;
            Password = password;
            Törölt = törölt;
        }
    }
}
