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
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();
        readonly Kezelő_Járandóság KézJárandóság = new Kezelő_Járandóság();

        List<Adat_Raktár> AdatokRaktár = new List<Adat_Raktár>();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Anyag> AdatokAnyagok = new List<Adat_Anyag>();
        List<Adat_Járandóság> AdatokJárandóság = new List<Adat_Járandóság>();

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
            AdatokAnyagok = KézAnyag.Lista_Adatok();
            CikkszámokFeltöltése();
            MegnevezésekFeltöltése();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            AdatokJárandóság = KézJárandóság.Lista_Adatok();
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

        /// <summary>
        /// Szervezethez tartozó munkakörök feltöltése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSzervezet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbSzervezet.Text = CmbSzervezet.Items[CmbSzervezet.SelectedIndex].ToString();
            string szervezet = CmbSzervezet.Text.Trim();
            CmbMunkakör.Text = "";
            CmbMunkakör.Items.Clear();
            ChkDolgozók.Items.Clear();
            if (string.IsNullOrEmpty(szervezet)) return;

            try
            {
                // Munkakörök feltöltése
                List<string> munkakörök = KézDolgozó.Lista_Adatok()
                     .Where(d => d.Szervezet == szervezet && d.Státus == false)
                     .OrderBy(d => d.Munkakör)
                     .Select(d => d.Munkakör)
                     .Distinct()
                     .ToList();

                foreach (var munkakör in munkakörök)
                    CmbMunkakör.Items.Add(munkakör);

                int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
                RaktárKészlet.Text = készlet.ToString();
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
        /// Szervezethez és munkakörköz tartotó dolgozók feltöltése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbMunkakör_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbMunkakör.Text = CmbMunkakör.Items[CmbMunkakör.SelectedIndex].ToString();
            string szervezet = CmbSzervezet.Text.Trim();
            string munkakör = CmbMunkakör.Text.Trim();
            ChkDolgozók.Items.Clear();

            if (string.IsNullOrEmpty(szervezet) || string.IsNullOrEmpty(munkakör)) return;

            try
            {
                List<Adat_Dolgozó> dolgozók = KézDolgozó.Lista_Adatok()
                    .Where(d => d.Szervezet == szervezet && d.Munkakör == munkakör && d.Státus == false)
                    .OrderBy(d => d.Dolgozónév)
                    .ToList();

                foreach (Adat_Dolgozó dolgozó in dolgozók)
                    ChkDolgozók.Items.Add($"{dolgozó.Dolgozószám} - {dolgozó.Dolgozónév}");

                FrissítJárandóság();
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
        /// Cikkszámok feltöltése
        /// </summary>
        private void CikkszámokFeltöltése()
        {
            try
            {
                List<Adat_Anyag> anyagok = AdatokAnyagok
                    .Where(a => a.Státus == false) // Csak aktívak
                    .OrderBy(a => a.Cikkszám)
                    .ToList();

                CmbCikkszámok.Items.Clear();
                CmbCikkszámok.Items.Add(""); // Üres elem az elejére

                foreach (var anyag in anyagok)
                    CmbCikkszámok.Items.Add(anyag.Cikkszám);
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

        private void CmbCikkszámok_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbCikkszámok.Text = CmbCikkszámok.Items[CmbCikkszámok.SelectedIndex].ToString();
            if (string.IsNullOrEmpty(CmbCikkszámok.Text.Trim()))
            {
                CmbMegnevezés.Text = "";
                RaktárKészlet.Text = "";
                return;
            }

            // Megnevezés beállítása
            Adat_Anyag anyag = AdatokAnyagok.FirstOrDefault(a => a.Cikkszám == CmbCikkszámok.Text.Trim() && a.Státus == false);
            if (anyag != null)
                CmbMegnevezés.Text = anyag.Megnevezés;
            else
                CmbMegnevezés.Text = "";

            int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
            RaktárKészlet.Text = készlet.ToString();
            FrissítJárandóság();
        }

        /// <summary>
        /// Megnevezések feltöltése a kiválasztott cikkszámhoz
        /// </summary>
        private void MegnevezésekFeltöltése()
        {
            try
            {
                List<Adat_Anyag> anyagok = AdatokAnyagok
                    .Where(a => a.Státus == false) // Csak aktívak
                    .OrderBy(a => a.Megnevezés)
                    .ToList();

                CmbMegnevezés.Items.Clear();
                CmbMegnevezés.Items.Add(""); // Üres elem az elejére

                foreach (Adat_Anyag anyag in anyagok)
                    CmbMegnevezés.Items.Add(anyag.Megnevezés);
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

        private void CmbMegnevezés_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbMegnevezés.Text = CmbMegnevezés.Items[CmbMegnevezés.SelectedIndex].ToString();
            if (string.IsNullOrEmpty(CmbMegnevezés.Text.Trim()))
            {
                CmbMegnevezés.Text = "";
                RaktárKészlet.Text = "";
                return;
            }

            // Megnevezés beállítása
            Adat_Anyag anyag = AdatokAnyagok.FirstOrDefault(a => a.Megnevezés == CmbMegnevezés.Text.Trim() && a.Státus == false);
            if (anyag != null)
                CmbCikkszámok.Text = anyag.Cikkszám;
            else
                CmbCikkszámok.Text = "";

            int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
            RaktárKészlet.Text = készlet.ToString();
            FrissítJárandóság();
        }


        /// <summary>
        /// Szervezetnél fellelhető készlet lekérdezése
        /// </summary>
        /// <param name="cikkszám"></param>
        /// <param name="szervezet"></param>
        /// <returns></returns>
        private int Készlet(string cikkszám, string szervezet)
        {
            int válasz = 0;
            try
            {
                if (cikkszám.Trim() != "" && szervezet.Trim() != "")
                {
                    Adat_Raktár Adat = (from a in AdatokRaktár
                                        where a.Cikkszám == cikkszám
                                        && a.Szervezet == szervezet
                                        select a).FirstOrDefault();
                    if (Adat != null) válasz = Adat.Mennyiség;
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
            return válasz;
        }


        /// <summary>
        /// Kiírja a járandóságokat
        /// </summary>
        private void FrissítJárandóság()
        {
            string cikkszám = CmbCikkszámok.Text.Trim();
            string munkakör = CmbMunkakör.Text.Trim();

            if (string.IsNullOrEmpty(cikkszám) || string.IsNullOrEmpty(munkakör))
            {
                LblJárandóság.Text = "0";
                return;
            }

            Adat_Járandóság járandóság = AdatokJárandóság
                .FirstOrDefault(j => j.Cikkszám == cikkszám && j.Munkakör == munkakör);

            if (járandóság != null)
                LblJárandóság.Text = járandóság.Mennyiség.ToString();
            else
                LblJárandóság.Text = "0";
        }

        /// <summary>
        /// Minden dolgozó kiválasztása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GombokMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Minden dolgozó törlése a listából
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GombokSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, false);
            }
        }
    }
}
