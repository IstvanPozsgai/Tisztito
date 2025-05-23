using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Kezelők;
using Tisztito.Minden;

namespace Tisztito
{

    public partial class Ablak_JogKiosztás : Form
    {
        readonly Kezelők_Oldalok KézOldal = new Kezelők_Oldalok();
        readonly Kezelők_Gombok KézGombok = new Kezelők_Gombok();

        List<Adat_Oldalak> AdatokOldal = new List<Adat_Oldalak>();
        List<Adat_Gombok> AdatokGombok = new List<Adat_Gombok>();

        DataTable AdatTáblaALap = new DataTable();

        public Ablak_JogKiosztás()
        {
            InitializeComponent();
            Start();
        }

        private void Ablak_JogKiosztás_Load(object sender, System.EventArgs e)
        {

        }

        private void Start()
        {
            AdatokOldal = KézOldal.Lista_Adatok().Where(a => a.Törölt == false).ToList();
            AdatokGombok = KézGombok.Lista_Adatok().Where(a => a.Törölt == false).ToList();
            OldalFeltöltés();
        }


        #region Mezők feltöltése

        /// <summary>
        /// Oldalak feltöltése a comboxba.
        /// </summary>
        private void OldalFeltöltés()
        {
            try
            {
                foreach (Adat_Oldalak Elem in AdatokOldal)
                    CmbAblak.Items.Add(Elem.MenuFelirat);
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

        /// <summary>
        /// Ablak gombok feltöltése a comboxba.
        /// </summary>
        private void GombokFeltöltése()
        {
            if (CmbAblak.Text.Trim() == "") return;
            LstChkGombok.Items.Clear();
            Adat_Oldalak oldal = AdatokOldal.FirstOrDefault(a => a.MenuFelirat == CmbAblak.Text.Trim());
            if (oldal == null) return;
            List<Button> gombok = AblakokGombok.FormbanlévőGombok(oldal.FromName);
            if (gombok == null) return;
            foreach (Button item in gombok)
                LstChkGombok.Items.Add(item.Name);
        }

        #endregion


        #region Mezők kijelölése és választása
        private void CmbAblak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CmbAblak.Text = CmbAblak.Items[CmbAblak.SelectedIndex].ToString();
                Adat_Oldalak Ablak = AdatokOldal.FirstOrDefault(a => a.MenuFelirat == CmbAblak.Text);
                GombokFeltöltése();
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