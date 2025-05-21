namespace Bejelentkezés.Adatszerkezet
{
    public class Adat_Users
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Törölt { get; private set; }

        public Adat_Users(int userId, string userName, string password, bool törölt)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Törölt = törölt;
        }
    }
}
