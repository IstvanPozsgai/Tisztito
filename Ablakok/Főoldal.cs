using System;
using System.Windows.Forms;
using Tisztito.Ablakok;


namespace Tisztito
{
    public partial class Főoldal : Form
    {
        public Főoldal()
        {
            InitializeComponent();
        }

        #region Alap
        private void Főoldal_Load(object sender, EventArgs e)
        {

        }

        private void Főoldal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Menük
        /// <summary>
        /// Ablakokat nyitja meg és kezeli a bezárást
        /// <summary>
        #region Anyag
        /// <summary>
        /// Az Anyagtörzs karbantartásának ablakát nyitja meg.
        /// </summary>
        Ablak_Anyagok Új_Ablak_Anyagok;
        private void ToolStripMenuItem_Anyag_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Anyagok == null)
            {
                Új_Ablak_Anyagok = new Ablak_Anyagok();
                Új_Ablak_Anyagok.FormClosed += Új_Ablak_Anyagok_FormClosed;
                Új_Ablak_Anyagok.Show();
            }
            else
            {
                Új_Ablak_Anyagok.Activate();
                Új_Ablak_Anyagok.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Anyagok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Anyagok = null;
        }
        #endregion


        #region Dolgozó
        Ablak_Dolgozók Új_Ablak_Dolgozók;
        private void ToolStripMenuItem_Dolgozó_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Dolgozók == null)
            {
                Új_Ablak_Dolgozók = new Ablak_Dolgozók();
                Új_Ablak_Dolgozók.FormClosed += Új_Ablak_Dolgozók_FormClosed;
                Új_Ablak_Dolgozók.Show();
            }
            else
            {
                Új_Ablak_Dolgozók.Activate();
                Új_Ablak_Dolgozók.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Dolgozók_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Dolgozók = null;
        }
        #endregion


        #region Működési adatok
        Ablak_Beállítások Új_Ablak_Beállítások;
        private void működésiAdatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Beállítások == null)
            {
                Új_Ablak_Beállítások = new Ablak_Beállítások();
                Új_Ablak_Beállítások.FormClosed += Új_Ablak_Beállítások_FormClosed;
                Új_Ablak_Beállítások.Show();
            }
            else
            {
                Új_Ablak_Beállítások.Activate();
                Új_Ablak_Beállítások.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Beállítások_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Beállítások = null;
        }
        #endregion
        #endregion
    }
}
