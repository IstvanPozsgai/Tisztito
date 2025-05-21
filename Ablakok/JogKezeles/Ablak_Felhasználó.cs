using System;
using System.Windows.Forms;
using MyE = Tisztito.Module_Excel;

namespace Tisztito
{

    public partial class AblakFelhasználó : Form
    {
        string Másolnadó = "VENDÉG";

        public AblakFelhasználó()
        {
            InitializeComponent();
        }

        private void AblakFelhasználó_Load(object sender, EventArgs e)
        {
            try
            {
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



        #region Alap
        private void BtnSugó_Click(object sender, EventArgs e)
        {
            try
            {
                string hely = $@"{Application.StartupPath}\Súgó\VillamosLapok\felhasználó.html";
                MyE.Megnyitás(hely);
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
        #endregion

    }
}