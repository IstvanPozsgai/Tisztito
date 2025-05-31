using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;
using MyEn = Tisztito.Minden.Enumok;
using MyF = Függvénygyűjtemény;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Szervezet : Form
    {
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044
        List<Adat_Szervezet> Adatok = new List<Adat_Szervezet>();

        public Ablak_Szervezet()
        {
            InitializeComponent();
            Start();
        }

        private void Ablak_Szervezet_Load(object sender, System.EventArgs e)
        {

        }

        private void Start()
        {
            StátusokFeltöltése();
            Alap_tábla_író();
            GombLathatosagKezelo.Beallit(this);
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

        private void Új_adat_Click(object sender, EventArgs e)
        {
            Id.Text = "";
            Szervezet.Text = "";
            CmbStátus.Text = "Aktív";
        }

        private void Alap_Rögzít_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Id.Text, out int id)) id = 0;
                if (MyF.Szöveg_Tisztítás(Szervezet.Text, 0, 200).Trim() == "") throw new HibásBevittAdat("Szervezet mezőt ki kell tölteni.");
                if (CmbStátus.Text != "Aktív" || CmbStátus.Text == "Törölt") throw new HibásBevittAdat("Státus mezőben csak Aktív/Törölt értékeket vehetnek fel.");
                Adat_Szervezet ADAT = new Adat_Szervezet(
                    id,
                    MyF.Szöveg_Tisztítás(Szervezet.Text, 0, 200),
                    CmbStátus.Text != "Aktív");
                KézSzervezet.Döntés(ADAT);
                Adatok = KézSzervezet.Lista_Adatok();
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
                    FileName = "Szervezet" + Program.PostásNév + "-" + DateTime.Now.ToString("yyyyMMddHHmmss"),
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

        private void Alap_tábla_író()
        {
            try
            {
                Adatok = KézSzervezet.Lista_Adatok();
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

            foreach (Adat_Szervezet rekord in Adatok)
            {
                DataRow Soradat = AdatTáblaALap.NewRow();

                Soradat["Id"] = rekord.Id;
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
                AdatTáblaALap.Columns.Add("Id");
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
            Tábla.Columns["Id"].Width = 80;
            Tábla.Columns["Szervezet"].Width = 300;
            Tábla.Columns["státus"].Width = 70;
        }
    }
}
