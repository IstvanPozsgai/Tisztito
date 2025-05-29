using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;

namespace Tisztito.Ablakok
{
    public partial class Ablak_KiOszt : Form
    {
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();

        public Ablak_KiOszt()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// Betöltjük a comboboxba a listákat
        /// </summary>
        private void Start()
        {
            SzervezetFeltöltés();
        }

        private void Ablak_Raktár_Load(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {

                AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();

                //Felhasználó jogosultságok lekérése
                List<int> ÜzemekId = Program.PostásJogosultságok.Select(j => j.SzervezetId).Distinct().ToList();
                CmbSzervezet.Items.Clear();
                CmbSzervezet.Items.Add("");
                for (int i = 0; i < ÜzemekId.Count; i++)
                {
                    Adat_Szervezet szervezet = AdatokSzervezet.FirstOrDefault(s => s.Id == ÜzemekId[i]);
                    if (szervezet != null) CmbSzervezet.Items.Add(szervezet.Szervezet);
                }

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
