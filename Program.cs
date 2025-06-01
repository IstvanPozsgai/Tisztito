using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tisztito
{
    public static class Program
    {
        /// <summary>
        /// Aki bejelentkezett
        /// </summary>
        public static string PostásNév = "admin";
        public static int PostásNévId = 1;
        public static List<ToolStripMenuItem> PostásMenü = new List<ToolStripMenuItem>();
        public static List<Adat_Jogosultságok> PostásJogosultságok = new List<Adat_Jogosultságok>();
        public static List<Adat_Oldalak> PostásOldalak = new List<Adat_Oldalak>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Főoldal());
            Application.Run(new Ablak_Login());
        }
    }
}
