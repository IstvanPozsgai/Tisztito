using System;
using System.Windows.Forms;

namespace Tisztito
{
    public static class Program
    {
        /// <summary>
        /// Aki bejelentkezett
        /// </summary>
        public static string PostásNév = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Főoldal());
        }
    }
}
