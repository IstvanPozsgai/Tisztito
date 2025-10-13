using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;

namespace Tisztito.Ablakok.Lekérdezés
{
    public partial class Ablak_Lekérdezés : Form
    {
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();
        readonly Kezelő_KészletNaplóRaktár KézNaplóRaktár = new Kezelő_KészletNaplóRaktár();

        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Raktár> AdatokRaktár = new List<Adat_Raktár>();

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        #region Alap    
        public Ablak_Lekérdezés()
        {
            InitializeComponent();
     
        }

        private void Start()
        {
            AdatokSzervezet = KézSzervezet.Lista_Adatok();
            AdatokAnyag = KézAnyag.Lista_Adatok().Where(a => a.Státus == false).ToList();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            CikkszámokFeltöltése();
            SzervezetFeltöltés();
        }

        /// <summary>
        /// Feltöltjük a Cikkszám és Megnevezés comboboxokat
        /// </summary>
        private void CikkszámokFeltöltése()
        {
            try
            {
                Cikkszámok.Items.Add("");
                Megnevezések.Items.Add("");
                foreach (Adat_Anyag Elem in AdatokAnyag.OrderBy(a => a.Cikkszám).ToList())
                    Cikkszámok.Items.Add(Elem.Cikkszám);


                foreach (Adat_Anyag Elem in AdatokAnyag.OrderBy(a => a.Megnevezés).ToList())
                    Megnevezések.Items.Add(Elem.Megnevezés);

                if (Cikkszámok.Items.Count > 0) Cikkszámok.SelectedIndex = 0;
                if (Megnevezések.Items.Count > 0) Megnevezések.SelectedIndex = 0;

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

        private void Cikkszámok_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Cikkszámok.SelectedIndex < 1)
                {
                    Megnevezések.Text = "";
                    return;
                }
                Cikkszámok.Text = Cikkszámok.Items[Cikkszámok.SelectedIndex].ToString();
                Megnevezések.Text = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == Cikkszámok.Text).Megnevezés;
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

        private void Megnevezések_SelectionChangeCommitted(object sender, EventArgs e)
        {

            try
            {
                if (Megnevezések.SelectedIndex < 1)
                {
                    Cikkszámok.Text = "";
                    return;
                }
                Megnevezések.Text = Megnevezések.Items[Megnevezések.SelectedIndex].ToString();
                Cikkszámok.Text = AdatokAnyag.FirstOrDefault(a => a.Megnevezés == Megnevezések.Text).Cikkszám;
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
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {

                AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();
                // OldalId lekkérdezése
                Adat_Oldalak oldalId = (from a in Program.PostásOldalak
                                        where a.FromName == this.Name
                                        select a).FirstOrDefault() ?? throw new HibásBevittAdat("Az oldal nem található a jogosultságok között!");
                //Felhasználó jogosultságok lekérése
                List<int> ÜzemekId = (from a in Program.PostásJogosultságok
                                      where a.OldalId == oldalId.OldalId
                                      select a.SzervezetId).Distinct().ToList();

                Szervezet.Items.Clear();
                Szervezet.Items.Add("");
                for (int i = 0; i < ÜzemekId.Count; i++)
                {
                    Adat_Szervezet szervezet = AdatokSzervezet.FirstOrDefault(s => s.Id == ÜzemekId[i]);
                    if (szervezet != null) Szervezet.Items.Add(szervezet.Szervezet);
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

        private void Ablak_Lekérdezés_Load(object sender, EventArgs e)
        {
            Start();
        }
        #endregion


        #region Lekérdezés
        /// <summary>
        ///  Táblázat adatainak kiírása
        /// </summary>
        private void Táblázat()
        {
            try
            {
                AdatokRaktár.Clear();
                AdatokRaktár = KézRaktár.Lista_Adatok();
                Tábla.Visible = false;
                Tábla.CleanFilterAndSort();
                TáblaFejléc();
                AlapTáblaTartalom();
                Tábla.DataSource = AdatTáblaALap;
                TáblaOszlopSzélesség();
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

        /// <summary>
        /// Táblázat adat oszlopainak beállítása
        /// </summary>
        private void TáblaFejléc()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Szervezet");
                AdatTáblaALap.Columns.Add("Cikkszám");
                AdatTáblaALap.Columns.Add("Megnevezés");
                AdatTáblaALap.Columns.Add("Mennyiség");
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
        /// A táblázat oszlop szélességének beállítása
        /// </summary>
        private void TáblaOszlopSzélesség()
        {
            Tábla.Columns["Szervezet"].Width = 400;
            Tábla.Columns["Cikkszám"].Width = 130;
            Tábla.Columns["Megnevezés"].Width = 300;
            Tábla.Columns["Mennyiség"].Width = 130;
        }

        /// <summary>
        /// A táblázat tartalmának feltöltése
        /// </summary>
        private void AlapTáblaTartalom()
        {
            try
            {
                List<Adat_Raktár> Adatok = KézRaktár.Lista_Adatok();
                if (Szervezet.Text.Trim() != "") Adatok = Adatok.Where(a => a.Szervezet == Szervezet.Text.Trim()).ToList();
                if (Cikkszámok.Text.Trim() != "") Adatok = Adatok.Where(a => a.Cikkszám == Cikkszámok.Text.Trim()).ToList();
                Adatok = Adatok.OrderBy(a => a.Cikkszám).ToList();
                AdatTáblaALap.Clear();

                foreach (Adat_Raktár rekord in Adatok)
                {
                    DataRow Soradat = AdatTáblaALap.NewRow();

                    Soradat["Cikkszám"] = rekord.Cikkszám;
                    Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == rekord.Cikkszám);
                    if (EgyAnyag != null)
                        Soradat["Megnevezés"] = EgyAnyag.Megnevezés;
                    else
                        Soradat["Megnevezés"] = "";

                    Soradat["Mennyiség"] = rekord.Mennyiség;
                    Soradat["Szervezet"] = rekord.Szervezet;
                    AdatTáblaALap.Rows.Add(Soradat);
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



        #endregion


        #region Gombok
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
                    FileName = $"Raktárak_Között_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
                    Filter = "Excel |*.xlsx"
                };
                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (SaveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlexc = SaveFileDialog1.FileName;
                else
                    return;

                fájlexc = fájlexc.Substring(0, fájlexc.Length - 5);
                MyE.DataGridViewToExcel(fájlexc, Tábla);
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

        private void MezőkÜrítése_Click(object sender, EventArgs e)
        {
            Cikkszámok.Text = "";
            Megnevezések.Text = "";
            Szervezet.Text = "";
        }

        private void Frissít_Click(object sender, EventArgs e)
        {
            Táblázat();
        }

        private void Súgó_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
