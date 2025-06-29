using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;
using MyEn = Tisztito.Minden.Enumok;
using MyF = Függvénygyűjtemény;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Járandóság : Form
    {
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        readonly Kezelő_Járandóság KézJár = new Kezelő_Járandóság();
#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Dolgozó> AdatokDolgozó = new List<Adat_Dolgozó>();
        List<Adat_Járandóság> AdatokJárandóság = new List<Adat_Járandóság>();

        public Ablak_Járandóság()
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
            AdatokJárandóság = KézJár.Lista_Adatok();
            StátusokFeltöltése();
            MunkakörFeltöltés();
            CikkszámMegnevezésFeltöltés();
            Alap_tábla_író();
            GombLathatosagKezelo.Beallit(this);
        }

        private void Ablak_Anyagok_Load(object sender, System.EventArgs e)
        {

        }

        private void Új_adat_Click(object sender, System.EventArgs e)
        {
            Munkakör.Text = "";
            Cikkszám.Text = "";
            Megnevezés.Text = "";
            Mennyiség.Text = "0";
            Gyakoriság.Text = "0";
            CmbStátus.Text = "Aktív";
        }

        private void StátusokFeltöltése()
        {
            try
            {
                foreach (string adat in Enum.GetNames(typeof(MyEn.Státus)))
                    CmbStátus.Items.Add(adat);
                CmbStátus.Text = "Aktív";
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

        private void Alap_Rögzít_Click(object sender, EventArgs e)
        {
            try
            {
                if (MyF.Szöveg_Tisztítás(Cikkszám.Text, 0, 10).Trim() == "") throw new HibásBevittAdat("Cikkszám mezőt ki kell tölteni.");
                if (MyF.Szöveg_Tisztítás(Munkakör.Text, 0, 250).Trim() == "") throw new HibásBevittAdat("Munkakör mezőt ki kell tölteni.");
                if (!(CmbStátus.Text.Trim() == "Aktív" || CmbStátus.Text.Trim() == "Törölt")) throw new HibásBevittAdat("Státus mezőben csak Aktív/Törölt értékeket vehetnek fel.");
                if (!int.TryParse(Mennyiség.Text.Trim(), out int mennyiség)) throw new HibásBevittAdat("Mennyiség mező egész számot lehet csak írni");
                if (!int.TryParse(Gyakoriság.Text.Trim(), out int gyakoriság)) throw new HibásBevittAdat("Gyakoriság mező egész számot lehet csak írni");

                Adat_Járandóság ADAT = new Adat_Járandóság(
                       MyF.Szöveg_Tisztítás(Munkakör.Text),
                       MyF.Szöveg_Tisztítás(Cikkszám.Text),
                       mennyiség,
                       gyakoriság,
                       CmbStátus.Text != "Aktív");
                KézJár.Döntés(ADAT);

                Alap_tábla_író();
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

        private void BtnFrissít_Click(object sender, EventArgs e)
        {
            Alap_tábla_író();
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


            foreach (Adat_Járandóság rekord in AdatokJárandóság)
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
                Soradat["Esedékesség gyakorisága (hó):"] = rekord.Gyakoriság;
                Soradat["Státus"] = rekord.Státus == true ? "Törölt" : "Aktív";
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
                AdatTáblaALap.Columns.Add("Esedékesség gyakorisága (hó):");
                AdatTáblaALap.Columns.Add("Státus");
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
            Tábla.Columns["Esedékesség gyakorisága (hó):"].Width = 130;
            Tábla.Columns["Státus"].Width = 70;
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

                fájlexc = fájlexc.Substring(0, fájlexc.Length - 5);
                MyE.EXCELtábla(fájlexc, Tábla, true);
                MessageBox.Show("Elkészült az Excel tábla: " + fájlexc, "Tájékoztatás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyE.Megnyitás(fájlexc + ".xlsx");
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

        private void Tábla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string Cikkszám = Tábla.Rows[e.RowIndex].Cells[1].Value.ToStrTrim();
            string munkakör = Tábla.Rows[e.RowIndex].Cells[0].Value.ToStrTrim();
            Adatokkiírása(Cikkszám, munkakör);

        }

        private void Adatokkiírása(string cikkszám, string munkakör)
        {
            try
            {
                Adat_Járandóság adat = (from a in AdatokJárandóság
                                        where a.Cikkszám == cikkszám
                                        && a.Munkakör == munkakör
                                        select a).FirstOrDefault();
                if (adat == null) return;
                Munkakör.Text = munkakör;
                Cikkszám.Text = adat.Cikkszám;
                Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == adat.Cikkszám);
                if (EgyAnyag != null)
                    Megnevezés.Text = EgyAnyag.Megnevezés;
                else
                    Megnevezés.Text = "";
                Mennyiség.Text = adat.Mennyiség.ToString();
                Gyakoriság.Text = adat.Gyakoriság.ToString();
                CmbStátus.Text = adat.Státus == true ? "Törölt" : "Aktív";

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
