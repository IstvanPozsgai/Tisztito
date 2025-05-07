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
    public partial class Ablak_Dolgozók : Form
    {
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        DataTable AdatTáblaALap = new DataTable();
        List<Adat_Dolgozó> Adatok = new List<Adat_Dolgozó>();

        public Ablak_Dolgozók()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            StátusokFeltöltése();
            Adatok = KézDolgozó.Lista_Adatok();
            SzervezetekFeltöltése();
            MunkakörökFeltöltése();
        }

        private void MunkakörökFeltöltése()
        {
            try
            {
                if (Adatok.Count == 0) return;
                List<string> szövegek = (from a in Adatok
                                         orderby a.Munkakör
                                         select a.Munkakör).Distinct().ToList();
                foreach (string Elem in szövegek)
                    Munkakör.Items.Add(Elem);

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

        private void SzervezetekFeltöltése()
        {
            try
            {
                if (Adatok.Count == 0) return;
                List<string> szövegek = (from a in Adatok
                                         orderby a.Szervezet
                                         select a.Szervezet).Distinct().ToList();
                foreach (string Elem in szövegek)
                    Szervezet.Items.Add(Elem);

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

        private void Ablak_Dolgozók_Load(object sender, System.EventArgs e)
        {

        }

        private void Új_adat_Click(object sender, System.EventArgs e)
        {
            Dolgozószám.Text = "";
            Dolgozónév.Text = "";
            Szervezet.Text = "";
            Munkakör.Text = "";
            CmbStátus.Text = "Aktív";
        }

        private void StátusokFeltöltése()
        {
            try
            {
                foreach (string adat in Enum.GetNames(typeof(MyEn.Státus)))
                    CmbStátus.Items.Add(adat);
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
                Adat_Dolgozó ADAT = new Adat_Dolgozó(
                       MyF.Szöveg_Tisztítás(Dolgozószám.Text),
                       MyF.Szöveg_Tisztítás(Dolgozónév.Text),
                       MyF.Szöveg_Tisztítás(Munkakör.Text),
                       MyF.Szöveg_Tisztítás(Szervezet.Text),
                       CmbStátus.Text != "Aktív");
                KézDolgozó.Döntés(ADAT);
                Adatok = KézDolgozó.Lista_Adatok();
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
                Adatok = KézDolgozó.Lista_Adatok();
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

            foreach (Adat_Dolgozó rekord in Adatok)
            {
                DataRow Soradat = AdatTáblaALap.NewRow();

                Soradat["Dolgozószám"] = rekord.Dolgozószám;
                Soradat["Dolgozónév"] = rekord.Dolgozónév;
                Soradat["Munkakör"] = rekord.Munkakör;
                Soradat["Szervezet"] = rekord.Szervezet;
                Soradat["Státus"] = rekord.Státus == true ? "Törölt" : "Aktív";
                AdatTáblaALap.Rows.Add(Soradat);
            }


        }

        private void AlapTáblaFejléc()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Dolgozószám");
                AdatTáblaALap.Columns.Add("Dolgozónév");
                AdatTáblaALap.Columns.Add("Munkakör");
                AdatTáblaALap.Columns.Add("Szervezet");
                AdatTáblaALap.Columns.Add("státus");
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
            Tábla.Columns["Dolgozószám"].Width = 130;
            Tábla.Columns["Dolgozónév"].Width = 400;
            Tábla.Columns["Munkakör"].Width = 300;
            Tábla.Columns["Szervezet"].Width = 300;
            Tábla.Columns["státus"].Width = 70;

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
                    FileName = "Dolgozó_" + Program.PostásNév + "-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
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
            string dolgozószám = Tábla.Rows[e.RowIndex].Cells[0].Value.ToStrTrim();
            Adatokkiírása(dolgozószám);

        }

        private void Adatokkiírása(string dolgozószám)
        {
            try
            {
                Adat_Dolgozó adat = (from a in Adatok
                                     where a.Dolgozószám == dolgozószám
                                     select a).FirstOrDefault();
                if (adat == null) return;
                Dolgozószám.Text = adat.Dolgozószám;
                Dolgozónév.Text = adat.Dolgozónév;
                Szervezet.Text = adat.Szervezet;
                Munkakör.Text = adat.Munkakör;
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

        private void BtnIDM_Click(object sender, EventArgs e)
        {
            try
            {
                // megpróbáljuk megnyitni az excel táblát.
                OpenFileDialog OpenFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = "MyDocuments",
                    Title = "IDM-s Adatok betöltése",
                    FileName = "",
                    Filter = "Excel |*.xlsx"
                };
                string fájlexc;

                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (OpenFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlexc = OpenFileDialog1.FileName;
                else
                    return;

                IDM_Dolgozó.Védő_beolvasás(fájlexc);

                MessageBox.Show("Az adat konvertálás befejeződött!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
