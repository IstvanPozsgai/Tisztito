using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;
using MyF = Függvénygyűjtemény;

namespace Tisztito.Ablakok.Lekérdezés
{
    public partial class Ablak_Dolgozói_Lekérdezés : Form
    {
        #region Alap
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();
        readonly Kezelő_Járandóság KézJárandóság = new Kezelő_Járandóság();
        readonly Kezelő_KészletNaplóRaktár KézNaplóRaktár = new Kezelő_KészletNaplóRaktár();

        List<Adat_Raktár> AdatokRaktár = new List<Adat_Raktár>();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Járandóság> AdatokJárandóság = new List<Adat_Járandóság>();
        List<Adat_Dolgozó> AdatokDolgozók = new List<Adat_Dolgozó>();

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        public Ablak_Dolgozói_Lekérdezés()
        {
            InitializeComponent();
            Start();
        }

        private void Ablak_Dolgozói_Lekérdezés_Load(object sender, EventArgs e)
        {

        }

        private void Start()
        {
            SzervezetFeltöltés();

            AdatokDolgozók = KézDolgozó.Lista_Adatok();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            AdatokJárandóság = KézJárandóság.Lista_Adatok();
            AdatokAnyag = KézAnyag.Lista_Adatok();
            GombLathatosagKezelo.Beallit(this);
        }
        #endregion


        #region Listák
        /// <summary>
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {
                CmbDolgozó.Items.Clear();
                AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();
                // OldalId lekkérdezése
                Adat_Oldalak oldalId = (from a in Program.PostásOldalak
                                        where a.FromName == this.Name
                                        select a).FirstOrDefault() ?? throw new HibásBevittAdat("Az oldal nem található a jogosultságok között!");
                //Felhasználó jogosultságok lekérése
                List<int> ÜzemekId = (from a in Program.PostásJogosultságok
                                      where a.OldalId == oldalId.OldalId
                                      select a.SzervezetId).Distinct().ToList();

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

        private void CmbSzervezet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbSzervezet.Text = CmbSzervezet.Items[CmbSzervezet.SelectedIndex].ToString();
            DolgozóFeltöltés();
        }


        /// <summary>
        /// Szervezethez tartozó dolgozók feltöltése
        /// </summary>
        private void DolgozóFeltöltés()
        {
            try
            {
                // Dolgozók feltöltése
                List<Adat_Dolgozó> dolgozók = AdatokDolgozók
                    .Where(d => d.Státus == false)
                    .OrderBy(d => d.Dolgozónév)
                    .ToList();
                if (CmbSzervezet.Text.Trim() != "")
                    dolgozók = dolgozók
                     .Where(d => d.Szervezet == CmbSzervezet.Text.Trim())
                     .ToList();
                CmbDolgozó.Items.Clear();
                CmbDolgozó.Items.Add(""); // Üres elem az elejére
                foreach (Adat_Dolgozó dolgozó in dolgozók)
                    CmbDolgozó.Items.Add($"{dolgozó.Dolgozónév} = {dolgozó.Dolgozószám}");
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
        #endregion


        #region Táblázat
        private void Frissít_Click(object sender, EventArgs e)
        {
            TáblázatKiírás();
        }

        private void TáblázatKiírás()
        {
            try
            {
                AdatokRaktár.Clear();
                AdatTáblaALap.Clear();
                AdatokRaktár = KézRaktár.Lista_Adatok();
                Tábla.Visible = false;
                Tábla.CleanFilterAndSort();
                TáblaFejléc();
                AlapTáblaTartalom();
                Tábla.DataSource = AdatTáblaALap;
                TáblaOszlopSzélesség();
                Tábla.Visible = true;
                Tábla.Refresh();
                SzínezdStornoSorokat();
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
        /// Könyvelési tábla összeállítása
        /// </summary>
        private void TáblaFejléc()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Dolgozószám");
                AdatTáblaALap.Columns.Add("Dolgozónév");
                AdatTáblaALap.Columns.Add("Szervezet");
                AdatTáblaALap.Columns.Add("Munkakör");
                AdatTáblaALap.Columns.Add("Cikkszám");
                AdatTáblaALap.Columns.Add("Megnevezés");
                AdatTáblaALap.Columns.Add("Járandóság");
                AdatTáblaALap.Columns.Add("Kiadott");
                AdatTáblaALap.Columns.Add("Különbözet");
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
        /// Könyvelési táblázat oszlopszélesség beállítása
        /// </summary>
        private void TáblaOszlopSzélesség()
        {
            Tábla.Columns["Dolgozószám"].Width = 150;
            Tábla.Columns["Dolgozónév"].Width = 250;
            Tábla.Columns["Szervezet"].Width = 350;
            Tábla.Columns["Munkakör"].Width = 350;
            Tábla.Columns["Cikkszám"].Width = 120;
            Tábla.Columns["Megnevezés"].Width = 250;
            Tábla.Columns["Járandóság"].Width = 100;
            Tábla.Columns["Kiadott"].Width = 100;
            Tábla.Columns["Különbözet"].Width = 120;
        }

        /// <summary>
        /// Táblázatos tartalom kiírása szűrő mezőkkel
        /// </summary>
        private void AlapTáblaTartalom()
        {
            try
            {
                if (CmbSzervezet.Text.Trim() == "") return;
                List<Adat_Dolgozó> Adatok_Dolgozók = AdatokDolgozók.Where(d => d.Szervezet == CmbSzervezet.Text.Trim()).ToList();

                List<Adat_Dolgozó> Adatok_Dolg = Adatok_Dolgozók;

                List<Adat_KészletNaplóRaktár> Adatok = KézNaplóRaktár.Lista_Adatok(Dátum.Value.Year);
                //Csak azok a rekordok amik dolgozói rögzítések
                Adatok = (from a in Adatok
                          where !(a.Dolgozószám == null || a.Dolgozószám.Trim() == "")
                          && a.Storno == false
                          select a).ToList();

                Adatok_Dolg = Adatok_Dolg.Where(a => a.Szervezet == CmbSzervezet.Text.Trim()).ToList();
                if (CmbDolgozó.Text.Trim() != "")
                {
                    string[] darabol = CmbDolgozó.Text.Split('=');
                    Adatok_Dolg = Adatok_Dolg.Where(a => a.Dolgozószám.Trim() == darabol[1].Trim()).ToList();
                }

                List<Adat_KészletNaplóRaktár> Adatoknapló = KézNaplóRaktár.Lista_Adatok(Dátum.Value.Year, false);

                foreach (Adat_Dolgozó rekord in Adatok_Dolg)
                {
                    List<Adat_KészletNaplóRaktár> AdatokSzűrt = (from a in Adatok
                                                                 where a.Dolgozószám == rekord.Dolgozószám
                                                                 select a).ToList();



                    List<Adat_Járandóság> JárAdatok = AdatokJárandóság.Where(j => j.Munkakör == rekord.Munkakör).ToList();
                    if (JárAdatok == null)
                    {
                        DataRow Soradat = AdatTáblaALap.NewRow();
                        Soradat["Dolgozószám"] = rekord.Dolgozószám;
                        Soradat["Dolgozónév"] = rekord.Dolgozónév;
                        Soradat["Munkakör"] = rekord.Munkakör;
                        Soradat["Szervezet"] = CmbSzervezet.Text.Trim();
                        Soradat["Cikkszám"] = "?";
                        Soradat["Megnevezés"] = "?";
                        Soradat["Járandóság"] = 0;
                        Soradat["Kiadott"] = 0;
                        Soradat["Különbözet"] = 0;
                        AdatTáblaALap.Rows.Add(Soradat);
                    }
                    foreach (Adat_Járandóság Elem in JárAdatok)
                    {
                        if (Elem.Mennyiség > 0)
                        {
                            DataRow Soradat = AdatTáblaALap.NewRow();
                            Soradat["Dolgozószám"] = rekord.Dolgozószám;
                            Soradat["Dolgozónév"] = rekord.Dolgozónév;
                            Soradat["Munkakör"] = rekord.Munkakör;
                            Soradat["Szervezet"] = CmbSzervezet.Text.Trim();
                            Soradat["Cikkszám"] = "?";
                            Soradat["Megnevezés"] = "?";
                            Soradat["Járandóság"] = 0;
                            Soradat["Kiadott"] = 0;
                            Soradat["Különbözet"] = 0;
                            Soradat["Cikkszám"] = Elem.Cikkszám;
                            Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == Elem.Cikkszám);
                            if (EgyAnyag != null)
                                Soradat["Megnevezés"] = EgyAnyag.Megnevezés;
                            else
                                Soradat["Megnevezés"] = "?";

                            Soradat["Járandóság"] = Elem.Mennyiség;
                            List<Adat_KészletNaplóRaktár> Dolgozói = (from a in Adatoknapló
                                                                      where a.Dolgozószám.Trim() == ""
                                                                      select a).ToList();
                            if (Dolgozói != null)
                            {
                                int kapott = (from a in AdatokSzűrt
                                              where a.Cikkszám == Elem.Cikkszám
                                              && a.Dátum >= MyF.Negyedév_elsőnapja(Dátum.Value)
                                              && a.Dátum <= MyF.Negyedév_utolsónapja(Dátum.Value)
                                              select a.Mennyiség).Sum();

                                Soradat["Kiadott"] = kapott;
                                Soradat["Különbözet"] = kapott - Elem.Mennyiség;
                            }
                            AdatTáblaALap.Rows.Add(Soradat);
                        }
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


        /// <summary>
        /// Kiemeli a törölt elemeket
        /// </summary>
        private void SzínezdStornoSorokat()
        {
            if (!Tábla.Columns.Contains("Storno"))
                return;

            int stornoOszlopIndex = Tábla.Columns["Storno"].Index;
            foreach (DataGridViewRow row in Tábla.Rows)
            {
                if (row.IsNewRow) continue;
                var cellValue = row.Cells[stornoOszlopIndex].Value;
                if (cellValue != null && cellValue.ToString() == "Stornózva")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral; // világos piros
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.Yellow;     // sárga betű
                }
            }
        }

        /// <summary>
        /// Kiírja a járandóságokat
        /// </summary>
        private int Járandóság(string cikkszám, string munkakör)
        {
            int válasz = 0;
            if (munkakör.Trim() == "?") return válasz;
            if (string.IsNullOrEmpty(cikkszám)) return válasz;

            Adat_Járandóság járandóság = AdatokJárandóság.FirstOrDefault(j => j.Cikkszám == cikkszám && j.Munkakör == munkakör);

            if (járandóság != null)
                válasz = járandóság.Mennyiség;
            return válasz;
        }
        #endregion

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
                    FileName = $"Kiosztott_Anyagok_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
                    Filter = "Excel |*.xlsx"
                };
                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (SaveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlexc = SaveFileDialog1.FileName;
                else
                    return;

                fájlexc = fájlexc.Substring(0, fájlexc.Length);
                MyE.DataGridViewToExcel(fájlexc, Tábla);
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
    }
}
