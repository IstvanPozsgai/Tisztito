using System;
using System.Windows.Forms;
using MyEn = Tisztito.Minden.Enumok;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Raktár : Form
    {


        public Ablak_Raktár()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// Betöltjük a comboboxba a listákat
        /// </summary>
        private void Start()
        {
            MozgásokFeltöltése();
        }

        private void Ablak_Raktár_Load(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Feltöltjük a comboboxba enumként tárolt mozgásokat
        /// </summary>
        private void MozgásokFeltöltése()
        {
            try
            {
                foreach (string adat in Enum.GetNames(typeof(MyEn.Mozgás)))
                    Mozgás.Items.Add(adat);
                Mozgás.Text = "Aktív";
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, this.ToString(), ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
