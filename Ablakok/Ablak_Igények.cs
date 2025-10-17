using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Igények : Form
    {
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        readonly Kezelő_Járandóság KézJár = new Kezelő_Járandóság();
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
        List<Adat_Igény> AdatokIgény = new List<Adat_Igény>();
#pragma warning restore IDE0044

        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Dolgozó> AdatokDolgozó = new List<Adat_Dolgozó>();
        List<Adat_Járandóság> AdatokJárandóság = new List<Adat_Járandóság>();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();

        public Ablak_Igények()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {

            AdatokAnyag = KézAnyag.Lista_Adatok();
            AdatokDolgozó = KézDolgozó.Lista_Adatok();
            AdatokJárandóság = KézJár.Lista_Adatok().Where(a => a.Státus == false).ToList();
            AdatokSzervezet = KézSzervezet.Lista_Adatok();
            MunkakörFeltöltés();
            CikkszámMegnevezésFeltöltés();
            SzervezetFeltöltése();
            GombLathatosagKezelo.Beallit(this);
        }

        private void Ablak_Anyagok_Load(object sender, System.EventArgs e)
        {

        }


        private void MunkakörFeltöltés()
        {
            try
            {
                List<string> Adatok = (from a in AdatokDolgozó
                                       where a.Státus == false
                                       orderby a.Munkakör
                                       select a.Munkakör).Distinct().ToList();
                foreach (string adat in Adatok)
                    Munkakör.Items.Add(adat);

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

        private void CikkszámMegnevezésFeltöltés()
        {
            try
            {
                List<Adat_Anyag> Adatok = (from a in AdatokAnyag
                                           orderby a.Cikkszám
                                           select a).ToList();
                foreach (Adat_Anyag adat in Adatok)
                {
                    Cikkszám.Items.Add(adat.Cikkszám);
                    Megnevezés.Items.Add(adat.Megnevezés);
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

        private void SzervezetFeltöltése()
        {
            List<Adat_Szervezet> Adatok = (from a in AdatokSzervezet
                                           where a.Státus == false
                                           orderby a.Szervezet
                                           select a).ToList();
            foreach (Adat_Szervezet adat in Adatok)
                Szervezet.Items.Add(adat.Szervezet);

        }

        private void BtnFrissít_Click(object sender, EventArgs e)
        {
            AdatokÖsszesítése();
            Alap_tábla_író();
        }

        private void AdatokÖsszesítése()
        {
            try
            {
                AdatokIgény.Clear();
                foreach (Adat_Járandóság Jár in AdatokJárandóság)
                {
                    List<Adat_Dolgozó> SzűrtDolgozó = (from a in AdatokDolgozó
                                                       where a.Munkakör == Jár.Munkakör
                                                       select a).ToList();
                    foreach (Adat_Dolgozó Dolg in SzűrtDolgozó)
                    {
                        Adat_Igény ADAT = new Adat_Igény(
                            Jár.Munkakör,
                            Jár.Cikkszám,
                            Jár.Mennyiség,
                            Dolg.Dolgozószám,
                            Dolg.Szervezet);
                        AdatokIgény.Add(ADAT);
                    }
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

        private void Alap_tábla_író()
        {
            try
            {
                AdatokJárandóság = KézJár.Lista_Adatok();
                Tábla.Visible = false;
                Tábla.CleanFilterAndSort();
                AlapTáblaFejléc();
                AlapTáblaTartalom();
                Tábla.DataSource = AdatTáblaALap;
                AlapTáblaOszlopSzélesség();
                Tábla.Visible = true;
                Tábla.Refresh();
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

        private void AlapTáblaTartalom()
        {
            AdatTáblaALap.Clear();

            foreach (Adat_Igény rekord in AdatokIgény)
            {
                DataRow Soradat = AdatTáblaALap.NewRow();

                Soradat["Munkakör"] = rekord.Munkakör;
                Soradat["Cikkszám"] = rekord.Cikkszám;
                Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == rekord.Cikkszám);
                if (EgyAnyag != null)
                    Soradat["Megnevezés"] = EgyAnyag.Megnevezés;
                else
                    Soradat["Megnevezés"] = "";

                Soradat["Mennyiség"] = rekord.Mennyiség;
                Soradat["Dolgozószám"] = rekord.Dolgozószám;
                Soradat["Szervezet"] = rekord.Szervezet;
                AdatTáblaALap.Rows.Add(Soradat);
            }
        }

        private void AlapTáblaFejléc()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Munkakör");
                AdatTáblaALap.Columns.Add("Cikkszám");
                AdatTáblaALap.Columns.Add("Megnevezés");
                AdatTáblaALap.Columns.Add("Mennyiség");
                AdatTáblaALap.Columns.Add("Dolgozószám");
                AdatTáblaALap.Columns.Add("Szervezet");
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

        private void AlapTáblaOszlopSzélesség()
        {
            Tábla.Columns["Munkakör"].Width = 300;
            Tábla.Columns["Cikkszám"].Width = 130;
            Tábla.Columns["Megnevezés"].Width = 300;
            Tábla.Columns["Mennyiség"].Width = 130;
            Tábla.Columns["Dolgozószám"].Width = 130;
            Tábla.Columns["Szervezet"].Width = 70;
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tábla.Rows.Count <= 0) return;
                string fájlexc;

                // kimeneti fájl helye és neve
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = "MyDocuments",
                    Title = "Listázott tartalom mentése Excel fájlba",
                    FileName = $"Járandóságok_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
                    Filter = "Excel |*.xlsx"
                };
                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (SaveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlexc = SaveFileDialog1.FileName;
                else
                    return;

                fájlexc = fájlexc.Substring(0, fájlexc.Length);
                MyE.DataGridViewToExcel(fájlexc, Tábla, true);
                MessageBox.Show("Elkészült az Excel tábla: " + fájlexc, "Tájékoztatás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyE.Megnyitás(fájlexc);
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

        private void Cikkszám_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Cikkszám.Text.Trim() == "") return;
            Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == Cikkszám.Text.Trim());
            if (EgyAnyag != null)
                Megnevezés.Text = EgyAnyag.Megnevezés;
            else
                Megnevezés.Text = "";
        }

        private void Megnevezés_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Megnevezés.Text.Trim() == "") return;
            Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Megnevezés == Megnevezés.Text.Trim());
            if (EgyAnyag != null)
                Cikkszám.Text = EgyAnyag.Cikkszám;
            else
                Cikkszám.Text = "";
        }
    }
}
