using Bejelentkezés.Adatszerkezet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;
using MyF = Függvénygyűjtemény;


namespace Tisztito.Ablakok
{
    public partial class Ablak_Bizonylat : Form
    {

        // itt: PDF fájlt meg kellene jeleníteni miután feltöltésre került kettős funkció feltöltés/megjelenítés


        const string BázisRaktár = "Központi raktár";

        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();
        readonly Kezelő_KészletNaplóRaktár KézNaplóRaktár = new Kezelő_KészletNaplóRaktár();

        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Raktár> AdatokRaktár = new List<Adat_Raktár>();

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        public Ablak_Bizonylat()
        {
            InitializeComponent();
            Start();
        }


        /// <summary>
        /// Betöltjük a comboboxba a listákat
        /// </summary>
        private void Start()
        {
            AdatokSzervezet = KézSzervezet.Lista_Adatok();
            AdatokAnyag = KézAnyag.Lista_Adatok().Where(a => a.Státus == false).ToList();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            SzervezetFeltöltés();
            CikkszámokFeltöltése();
            GombLathatosagKezelo.Beallit(this);
            Dátumtól.Value = MyF.Év_elsőnapja(DateTime.Now);
            Dátumig.Value = MyF.Év_utolsónapja(DateTime.Now);
        }


        private void Ablak_Raktár_Load(object sender, System.EventArgs e)
        {

        }


        #region Mozgások és szervezetek
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

                Honnan.Items.Clear();
                Honnan.Items.Add("");
                Honnan.Items.Add("Selejtezés");
                Hova.Items.Clear();
                Hova.Items.Add("");
                Hova.Items.Add("Selejtezés");
                for (int i = 0; i < ÜzemekId.Count; i++)
                {
                    Adat_Szervezet szervezet = AdatokSzervezet.FirstOrDefault(s => s.Id == ÜzemekId[i]);
                    if (szervezet != null)
                    {
                        Honnan.Items.Add(szervezet.Szervezet);
                        Hova.Items.Add(szervezet.Szervezet);
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
        #endregion


        #region Anyag adatok
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

        /// <summary>
        /// Kiválasztott azonosítóhoz kiírjuk a megnevezését
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cikszámok_SelectionChangeCommitted(object sender, EventArgs e)
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

        /// <summary>
        /// Kiválasztott megnevezéshez kiírjuk a cikkszámot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Ha ki van választva, akkor listázza a készletét
        /// és a bizonylatszámot üríti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Honnan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Honnan.Text = Honnan.Items[Honnan.SelectedIndex].ToString();
            TáblaKitöltés();
        }
        #endregion


        #region Táblázat Készlet
        /// <summary>
        /// A feltételeknek megfelelően kilistázza a raktárakat készletét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frissít_Click(object sender, EventArgs e)
        {
            TáblaKitöltés();
        }

        /// <summary>
        /// Státusnak megfelelően írja ki az adotak
        /// </summary>
        private void TáblaKitöltés()
        {
            TáblázatKönyvelés();
        }

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
                List<Adat_Raktár> Adatok = new List<Adat_Raktár>();
                if (Honnan.Text.Trim() == "" && Hova.Text.Trim() == BázisRaktár) Adatok = AdatokRaktár.Where(a => a.Szervezet == BázisRaktár).ToList(); ;
                if (Honnan.Text.Trim() != "") Adatok = AdatokRaktár.Where(a => a.Szervezet == Honnan.Text.Trim()).ToList();

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


        #region Készletkiírás
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


        #region Könyvelés kiírása
        /// <summary>
        /// Táblázat összeállítása könyvelési adatoknak megfelelően
        /// </summary>
        private void TáblázatKönyvelés()
        {
            try
            {

                AdatokRaktár.Clear();
                AdatTáblaALap.Clear();
                AdatokRaktár = KézRaktár.Lista_Adatok();
                Tábla.Visible = false;
                Tábla.CleanFilterAndSort();
                TáblaFejlécKönyvelés();
                AlapTáblaTartalomKönyvelés();
                Tábla.DataSource = AdatTáblaALap;
                TáblaOszlopSzélességKönyvelés();
                Tábla.Visible = true;
                Tábla.Refresh();
                Tábla.ClearSelection();
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
        private void TáblaFejlécKönyvelés()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Cikkszám");
                AdatTáblaALap.Columns.Add("Megnevezés");
                AdatTáblaALap.Columns.Add("Mennyiség");
                AdatTáblaALap.Columns.Add("Szervezet Honnan");
                AdatTáblaALap.Columns.Add("Szervezet Hova");
                AdatTáblaALap.Columns.Add("Bizonylat");
                AdatTáblaALap.Columns.Add("Rögzítő");
                AdatTáblaALap.Columns.Add("Dátum");
                AdatTáblaALap.Columns.Add("Storno");
                AdatTáblaALap.Columns.Add("Storno Rögzítő");
                AdatTáblaALap.Columns.Add("Storno Dátum");
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
        private void TáblaOszlopSzélességKönyvelés()
        {
            Tábla.Columns["Cikkszám"].Width = 120;
            Tábla.Columns["Megnevezés"].Width = 250;
            Tábla.Columns["Mennyiség"].Width = 100;
            Tábla.Columns["Szervezet Honnan"].Width = 250;
            Tábla.Columns["Szervezet Hova"].Width = 250;
            Tábla.Columns["Bizonylat"].Width = 150;
            Tábla.Columns["Rögzítő"].Width = 100;
            Tábla.Columns["Dátum"].Width = 150;
            Tábla.Columns["Storno"].Width = 120;
            Tábla.Columns["Storno Rögzítő"].Width = 100;
            Tábla.Columns["Storno Dátum"].Width = 180;
        }

        /// <summary>
        /// Táblázatos tartalom kiírása szűrő mezőkkel
        /// </summary>
        private void AlapTáblaTartalomKönyvelés()
        {
            try
            {
                List<Adat_KészletNaplóRaktár> Adatok = KézNaplóRaktár.Lista_Adatok(Dátumtól.Value.Year);
                if (Dátumtól.Value.Year < Dátumig.Value.Year)
                {
                    for (int i = Dátumtól.Value.Year + 1; i < Dátumig.Value.Year; i++)
                    {
                        List<Adat_KészletNaplóRaktár> AdatokIdeig = KézNaplóRaktár.Lista_Adatok(i);
                        Adatok.AddRange(AdatokIdeig);
                    }
                }

                //Csak a raktárak közötti mozgásokat írjuk ki
                Adatok = (from a in Adatok
                          where !(a.SzervezetHova == null || a.SzervezetHova.Trim() == "")
                          select a).ToList();
                if (Honnan.Text.Trim() != "") Adatok = Adatok.Where(a => a.SzervezetHonnan == Honnan.Text.Trim()).ToList();
                if (Hova.Text.Trim() != "") Adatok = Adatok.Where(a => a.SzervezetHova == Hova.Text.Trim()).ToList();

                foreach (Adat_KészletNaplóRaktár rekord in Adatok)
                {
                    DataRow Soradat = AdatTáblaALap.NewRow();

                    Soradat["Cikkszám"] = rekord.Cikkszám;
                    Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == rekord.Cikkszám);
                    if (EgyAnyag != null)
                        Soradat["Megnevezés"] = EgyAnyag.Megnevezés;
                    else
                        Soradat["Megnevezés"] = "";

                    Soradat["Mennyiség"] = rekord.Mennyiség;
                    Soradat["Szervezet Honnan"] = rekord.SzervezetHonnan;
                    Soradat["Szervezet Hova"] = rekord.SzervezetHova;
                    Soradat["Bizonylat"] = rekord.Bizonylat;
                    Soradat["Rögzítő"] = rekord.Rögzítő;
                    Soradat["Dátum"] = $"{rekord.Dátum:yyyy.MM.dd}";
                    Soradat["Storno"] = rekord.Storno ? "Stornózva" : "Rögzítés";
                    Soradat["Storno Rögzítő"] = rekord.Storno_Rögzítő;
                    Soradat["Storno Dátum"] = rekord.Storno_Dátum;

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
                    FileName = $"Raktárak_Között_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
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

        private void Pdf_Készítés_Click(object sender, EventArgs e)
        {
            KészítsSzállítóPDF();
        }




        private void KészítsSzállítóPDF()
        {
            try
            {
                if (Tábla.SelectedRows.Count < 1) throw new HibásBevittAdat("Nincs kijelölve érvényes sor.");
                if (Honnan.Text.Trim() == "") throw new HibásBevittAdat("Nincs kijelölve a Honnan szervezet.");
                if (Hova.Text.Trim() == "") throw new HibásBevittAdat("Nincs kijelölve a Hova szervezet.");


                string bizonylatszám = Tábla.SelectedRows[0].Cells["Bizonylat"].Value.ToStrTrim();

                string FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Selejtezés_{bizonylatszám}.pdf");
                if (Hova.Text.Trim() == "Selejtezés")
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Szállító_{bizonylatszám}.pdf");

                string fontPath = Path.Combine(Application.StartupPath, @"Adatok\Fonts\arial.ttf");
                using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                using (Document doc = new Document(PageSize.A4.Rotate()))
                {
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Kép beolvasása
                    string logoPath1 = Path.Combine($@"{Application.StartupPath}\Adatok\Logo\", "BKV.png");
                    iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(logoPath1);
                    img1.ScaleToFit(100f, 100f);

                    // Táblázat létrehozása 2 oszloppal
                    PdfPTable table = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };

                    // Kép cella
                    PdfPCell imageCell = new PdfPCell(img1, false)
                    {
                        VerticalAlignment = Element.ALIGN_TOP,
                        Border = Rectangle.NO_BORDER
                    };

                    // Szöveg cella
                    string szoveg = "BKV Zrt.";
                    PdfPCell textCell = new PdfPCell(new Phrase(szoveg))
                    {
                        VerticalAlignment = Element.ALIGN_TOP,
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Border = Rectangle.NO_BORDER
                    };

                    table.AddCell(imageCell);
                    table.AddCell(textCell);
                    doc.Add(table);
                    //Szállítólevél felirat
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);

                    if (Hova.Text.Trim() == "Selejtezés")
                    {
                        Paragraph p = new Paragraph("Selejtezési Bizonylat", font)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingBefore = 50f // 20 ponttal lejjebb
                        };
                        doc.Add(p);
                    }
                    else
                    {
                        Paragraph p = new Paragraph("Szállítólevél", font)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingBefore = 50f // 20 ponttal lejjebb
                        };
                        doc.Add(p);
                    }

                    // Üres bekezdés, ami 20 pont térközt ad (növeld, ha több kell)
                    Paragraph space = new Paragraph(" ")
                    {
                        SpacingBefore = 0f,
                        SpacingAfter = 20f
                    };
                    doc.Add(space);

                    // Honnan és Hova táblázat keret nélkül, igazításokkal
                    PdfPTable table1 = new PdfPTable(2)
                    {
                        WidthPercentage = 100,   // teljes szélesség
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };

                    // Fejléc: balra és jobbra igazítva, keret nélkül
                    PdfPCell honnanHeader = new PdfPCell(new Phrase("Honnan:", headerFont))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    PdfPCell hovaHeader = new PdfPCell(new Phrase("Hova:", headerFont))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    table1.AddCell(honnanHeader);
                    table1.AddCell(hovaHeader);

                    // Adatok: balra és jobbra igazítva, keret nélkül
                    string honnan = Honnan.Text.Trim();
                    string hova = Hova.Text.Trim();
                    PdfPCell honnanCell = new PdfPCell(new Phrase(honnan))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    PdfPCell hovaCell = new PdfPCell(new Phrase(hova))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    table1.AddCell(honnanCell);
                    table1.AddCell(hovaCell);
                    doc.Add(table1);

                    doc.Add(space);
                    baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
                    // Papírszélességű, háromoszlopos táblázat keretes fejléccel
                    PdfPTable t = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    t.SetWidths(new float[] { 2, 5, 2 }); // arányos oszlopszélességek (igény szerint módosítható)

                    // Fejléc cellák (kerettel, félkövérrel)
                    PdfPCell cikkszamHeader = new PdfPCell(new Phrase("Cikkszám", headerFont));
                    PdfPCell megnevezesHeader = new PdfPCell(new Phrase("Megnevezés", headerFont));
                    PdfPCell mennyisegHeader = new PdfPCell(new Phrase("Mennyiség", headerFont));

                    // Fejléc cellák igazítása (középre)
                    cikkszamHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                    megnevezesHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                    mennyisegHeader.HorizontalAlignment = Element.ALIGN_CENTER;

                    // Fejléc cellák hozzáadása
                    t.AddCell(cikkszamHeader);
                    t.AddCell(megnevezesHeader);
                    t.AddCell(mennyisegHeader);

                    // Példa sorok hozzáadása (töltsd fel a saját adataiddal)
                    foreach (DataGridViewRow tetel in Tábla.SelectedRows)
                    {
                        string cikkszam = tetel.Cells["Cikkszám"].Value.ToStrTrim() ?? "";
                        string megnevezes = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == cikkszam)?.Megnevezés ?? "";
                        string mennyiseg = tetel.Cells["Mennyiség"].Value.ToString();

                        PdfPCell cikkszamCell = new PdfPCell(new Phrase(cikkszam, font));
                        PdfPCell megnevezesCell = new PdfPCell(new Phrase(megnevezes, font));
                        PdfPCell mennyisegCell = new PdfPCell(new Phrase(mennyiseg, font));

                        cikkszamCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        megnevezesCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        mennyisegCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                        t.AddCell(cikkszamCell);
                        t.AddCell(megnevezesCell);
                        t.AddCell(mennyisegCell);
                    }
                    doc.Add(t);

                    doc.Add(space);
                    //Dátum helye
                    PdfPTable table2 = new PdfPTable(2)
                    {
                        WidthPercentage = 100,   // teljes szélesség
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };

                    // Fejléc: balra és jobbra igazítva, keret nélkül
                    PdfPCell honnanDátum = new PdfPCell(new Phrase($"{DateTime.Now.Year} év {DateTime.Now:MM} hó {DateTime.Now:dd} nap", font))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    PdfPCell hovaDátum = new PdfPCell(new Phrase($"{DateTime.Now.Year} év .............. hó ......... nap", font))
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table2.AddCell(honnanDátum);
                    table2.AddCell(hovaDátum);
                    doc.Add(table2);


                    //Alírás helye
                    doc.Add(space);
                    doc.Add(space);

                    // Aláírási sorok pontsorral, csak a szöveg fölött, kicsit szélesebben
                    PdfPTable table3 = new PdfPTable(2)
                    {
                        WidthPercentage = 100
                    };
                    table3.SetWidths(new float[] { 1, 1 }); // két egyenlő szélességű oszlop

                    // Átadó aláírása cella
                    Phrase honnanAlairas = new Phrase();
                    DottedLineSeparator dotted1 = new DottedLineSeparator
                    {
                        LineWidth = 1f,
                        Gap = 2f,
                        Percentage = 60f // a cella szélességének 70%-a (igény szerint állítható)
                    };
                    honnanAlairas.Add(new Chunk(dotted1));
                    honnanAlairas.Add(Chunk.NEWLINE);
                    honnanAlairas.Add(new Chunk("Átadó aláírása", font));
                    PdfPCell honnanAlairasCell = new PdfPCell(honnanAlairas)
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        PaddingTop = 10f
                    };

                    // Átvevő aláírása cella
                    Phrase hovaAlairas = new Phrase
                    {
                        new Chunk(dotted1),
                        Chunk.NEWLINE,
                        new Chunk("Átvevő aláírása", font)
                    };
                    PdfPCell hovaAlairasCell = new PdfPCell(hovaAlairas)
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        PaddingTop = 10f
                    };

                    table3.AddCell(honnanAlairasCell);
                    table3.AddCell(hovaAlairasCell);
                    doc.Add(table3);


                    doc.Close();
                }

                Process.Start(FileName);
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
