using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;

namespace Tisztito.Ablakok.Lekérdezés
{
    public partial class Ablak_OsztásNyomtatvány : Form
    {
        readonly DataTable AdatKioszt = new DataTable();

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
        #region Alap
        public Ablak_OsztásNyomtatvány()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {

            AdatokAnyag = KézAnyag.Lista_Adatok();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            AdatokJárandóság = KézJárandóság.Lista_Adatok();
            AdatokDolgozók = KézDolgozó.Lista_Adatok();
            DolgozóFeltöltés();
            MunkakörFeltöltés();
            SzervezetFeltöltés();
            //    GombLathatosagKezelo.Beallit(this);
        }

        private void Ablak_OsztásNyomtatvány_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region Feltöltések


        /// <summary>
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {
                AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();
                ChkSzervezet.Items.Clear();

                foreach (Adat_Szervezet szervezet in AdatokSzervezet)
                    ChkSzervezet.Items.Add(szervezet.Szervezet);
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
        /// Szervezethez tartozó dolgozók feltöltése
        /// </summary>
        private void DolgozóFeltöltés()
        {
            try
            {
                // Dolgozók Lista a kilépett dolgozók nélkül
                List<Adat_Dolgozó> Adatok = AdatokDolgozók
                    .Where(d => d.Státus == false)
                    .OrderBy(d => d.Dolgozónév)
                    .ToList();

                //Csak azokat a dolgozókat adjuk hozzá akik a szervezethez tartoznak
                List<Adat_Dolgozó> dolgozókS = new List<Adat_Dolgozó>();
                if (ChkSzervezet.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < ChkSzervezet.CheckedItems.Count; i++)
                    {
                        List<Adat_Dolgozó> Ideig = Adatok
                             .Where(d => d.Szervezet == ChkSzervezet.CheckedItems[i].ToStrTrim())
                             .ToList();
                        dolgozókS.AddRange(Ideig);
                    }
                }
                else
                    dolgozókS = Adatok;

                //Csak azokat a dolgozókat adjuk hozzá akik a Munkakörhöz tartoznak
                List<Adat_Dolgozó> dolgozók = new List<Adat_Dolgozó>();
                if (ChkMunkakör.CheckedItems.Count > 0)
                {
                    for (int i = 0; i < ChkMunkakör.CheckedItems.Count; i++)
                    {
                        List<Adat_Dolgozó> Ideig = Adatok
                             .Where(d => d.Munkakör == ChkMunkakör.CheckedItems[i].ToStrTrim())
                             .ToList();
                        dolgozók.AddRange(Ideig);
                    }
                }
                else
                    dolgozók = dolgozókS;

                ChkDolgozók.Items.Clear();
                foreach (Adat_Dolgozó dolgozó in dolgozók)
                    ChkDolgozók.Items.Add($"{dolgozó.Dolgozónév} = {dolgozó.Dolgozószám}");
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
        ///   Szervezethez tartozó munkakörök feltöltése
        /// </summary>
        private void MunkakörFeltöltés()
        {
            // Munkakörök feltöltése                 
            try
            {
                List<string> munkakörök;

                munkakörök = KézDolgozó.Lista_Adatok()
                    .Where(d => !d.Státus)
                    .OrderBy(d => d.Munkakör)
                    .Select(d => d.Munkakör)
                    .Distinct()
                    .ToList();

                foreach (string munkakör in munkakörök)
                    ChkMunkakör.Items.Add(munkakör);
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


        #region Pdf

        private void Osztási_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChkDolgozók.CheckedItems.Count < 1) return;
                string fájlnév;
                // kimeneti fájl helye és neve
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = "MyDocuments",
                    Title = "Listázott tartalom mentése Excel fájlba",
                    FileName = $"Kiosztott_Anyagok_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
                    Filter = "PDF |*.pdf"
                };
                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (SaveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlnév = SaveFileDialog1.FileName;
                else
                    return;

                FejlécTábla();
                TartalomTábla();

                //Pdf létrehozása
                Byte[] bytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Document pdfDoc = new Document(PageSize.A4.Rotate(), 25f, 25f, 20f, 20f))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms))
                        {
                            pdfDoc.Open();

                            // Betűtípus betöltése (Arial, Unicode támogatás)
                            string betutipusUt = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                            BaseFont alapFont = BaseFont.CreateFont(betutipusUt, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                            // Fejléc betűtípus - fekete, vastag
                            iTextSharp.text.Font fejlecBetu = new iTextSharp.text.Font(alapFont, 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                            PdfPTable pdfTable = new PdfPTable(AdatKioszt.Columns.Count);
                            //OSzlopszélesség beállítása
                            pdfTable.HorizontalAlignment = 0;
                            pdfTable.TotalWidth = 800;
                            pdfTable.LockedWidth = true;
                            float[] widths = new float[] { 100f, 45f, 100f, 100f, 60f, 80f, 20f, 50f, 50f, 50f };
                            pdfTable.SetWidths(widths);
                            pdfTable.HeaderRows = 1;
                            // Fejléc hozzáadása, egységes fekete háttérrel (vagy tetszőleges színnel)
                            for (int oszlop = 0; oszlop < AdatKioszt.Columns.Count; oszlop++)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(AdatKioszt.Columns[oszlop].ColumnName, fejlecBetu));
                                cell.BackgroundColor = new BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            for (int sor = 0; sor < AdatKioszt.Rows.Count; sor++)
                            {
                                for (int oszlop = 0; oszlop < AdatKioszt.Columns.Count; oszlop++)
                                {
                                    // Cella szövegének lekérése
                                    string szöveg = AdatKioszt.Rows[sor][oszlop].ToStrTrim() ?? "";
                                    // Színek lekérése az InheritedStyle-ból (ez tartalmazza a tényleges megjelenő színt)
                                    BaseColor háttérSzín = BaseColor.WHITE;
                                    BaseColor szovegSzín = BaseColor.BLACK;
                                    // Betűtípus az adott cella szövegszínével
                                    iTextSharp.text.Font betű = new iTextSharp.text.Font(alapFont, 10f, iTextSharp.text.Font.NORMAL, szovegSzín);
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(szöveg, betű))
                                    {
                                        BackgroundColor = háttérSzín
                                    };
                                    pdfTable.AddCell(pdfCell);
                                }

                            }
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                        }
                    }
                    bytes = ms.ToArray();
                }

                //Olvasd el a minta PDF-ünket és alkalmazd az oldalszámozást
                using (PdfReader reader = new PdfReader(bytes))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (PdfStamper stamper = new PdfStamper(reader, ms))
                        {
                            int PageCount = reader.NumberOfPages;
                            for (int i = 1; i <= PageCount; i++)
                            {
                                ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(String.Format("{0}/{1} oldal", i, PageCount)), 750, 10, 0);
                            }
                        }
                        bytes = ms.ToArray();
                    }
                }

                System.IO.File.WriteAllBytes(fájlnév, bytes);

                MyE.Megnyitás(fájlnév);
                MessageBox.Show("A nyomtatvány elkészült.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FejlécTábla()
        {
            AdatKioszt.Columns.Clear();
            AdatKioszt.Columns.Add("Szervezet");
            AdatKioszt.Columns.Add("HR azonosító");
            AdatKioszt.Columns.Add("Név");
            AdatKioszt.Columns.Add("Munkakör");
            AdatKioszt.Columns.Add("Cikkszám");
            AdatKioszt.Columns.Add("Megnevezés");
            AdatKioszt.Columns.Add("db");
            AdatKioszt.Columns.Add("Felvett mennyiség");
            AdatKioszt.Columns.Add("Felvétel Dátuma");
            AdatKioszt.Columns.Add("Az átvétel elismerése");
        }

        /// <summary>
        /// A chkDolgozók listájában lévő dolgozókat és a hozzájuk tartozó adatokkal készít egy táblát
        /// </summary>
        private void TartalomTábla()
        {
            try
            {
                if (ChkDolgozók.CheckedItems.Count < 1) throw new HibásBevittAdat("Nincs kijelölve dolgozó");
                AdatKioszt.Clear();

                for (int i = 0; i < ChkDolgozók.CheckedItems.Count; i++)
                {
                    string[] darabol = ChkDolgozók.CheckedItems[i].ToString().Split('=');
                    if (darabol.Length == 2)
                    {
                        //Dolgozó adatok leszűrése
                        Adat_Dolgozó Dolgozó = (from a in AdatokDolgozók
                                                where a.Dolgozószám == darabol[1].ToStrTrim()
                                                select a).FirstOrDefault();

                        List<Adat_Járandóság> járandóságok = (from a in AdatokJárandóság
                                                              where !a.Státus
                                                              && a.Munkakör == Dolgozó.Munkakör.Trim()
                                                              orderby a.Cikkszám
                                                              select a).ToList();

                        foreach (Adat_Járandóság rekord in járandóságok)
                        {
                            if (rekord.Mennyiség != 0)
                            {
                                DataRow Soradat = AdatKioszt.NewRow();
                                Soradat["Név"] = darabol[0].ToStrTrim();
                                Soradat["HR azonosító"] = darabol[1].ToStrTrim();
                                Soradat["Felvett mennyiség"] = "";
                                Soradat["Felvétel Dátuma"] = "";
                                Soradat["Az átvétel elismerése"] = "";
                                if (Dolgozó != null)
                                {
                                    Soradat["Szervezet"] = Dolgozó.Szervezet.Trim();
                                    Soradat["Munkakör"] = Dolgozó.Munkakör.Trim();
                                }
                                else
                                {
                                    Soradat["Szervezet"] = "";
                                    Soradat["Munkakör"] = "";
                                }

                                Soradat["db"] = rekord.Mennyiség.ToString();
                                Soradat["Cikkszám"] = rekord.Cikkszám.Trim();

                                Adat_Anyag Anyag = (from a in AdatokAnyag
                                                    where a.Cikkszám == rekord.Cikkszám
                                                    select a).FirstOrDefault();
                                if (Anyag != null) Soradat["Megnevezés"] = Anyag.Megnevezés.Trim();

                                AdatKioszt.Rows.Add(Soradat);
                            }

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
        #endregion


        #region Kijelölések
        private void DolgozóSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, false);
            }
        }

        private void DolgozóMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, true);
            }
        }

        private void SzervezetMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkSzervezet.Items.Count; i++)
            {
                ChkSzervezet.SetItemChecked(i, true);
            }
            DolgozóFeltöltés();
        }

        private void SzervezetSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkSzervezet.Items.Count; i++)
            {
                ChkSzervezet.SetItemChecked(i, false);
            }
            DolgozóFeltöltés();
        }

        private void MunkakörMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkMunkakör.Items.Count; i++)
            {
                ChkMunkakör.SetItemChecked(i, true);
            }
        }

        private void MunkakörSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkMunkakör.Items.Count; i++)
            {
                ChkMunkakör.SetItemChecked(i, false);
            }
        }



        private void ChkSzervezet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DolgozóFeltöltés();
        }


        private void ChkMunkakör_SelectedIndexChanged(object sender, EventArgs e)
        {
            DolgozóFeltöltés();
        }
        #endregion
    }
}
