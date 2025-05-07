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
        /// Az Anyagtörzs karbantartásának ablakát nyitja meg.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Anyag_Click(object sender, EventArgs e)
        {
            using (Ablak_Anyagok anyagtörzs = new Ablak_Anyagok())
            {
                anyagtörzs.ShowDialog();
            }
        }

        #endregion
    }
}
