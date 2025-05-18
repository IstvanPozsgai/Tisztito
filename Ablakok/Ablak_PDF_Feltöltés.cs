using System;
using System.IO;
using System.Windows.Forms;
using static System.IO.File;
using MyF = Függvénygyűjtemény;

namespace Tisztito
{
    public delegate void Event_Kidobó();
    public partial class Ablak_PDF_Feltöltés : Form
    {
        public event Event_Kidobó Változás;

        private string BeolvasásiHely;

        private string Bizonylat { get; set; }
        private DateTime Dátum { get; set; }
        private string Hova { get; set; }
        private bool Megjelenítés { get; set; }

        public Ablak_PDF_Feltöltés(string bizonylat, string hova, bool megjelenítés, DateTime dátum)
        {
            Bizonylat = bizonylat;
            Megjelenítés = megjelenítés;
            Hova = hova;
            Dátum = dátum;
            InitializeComponent();

        }

        private void Ablak_Sérülés_PDF_Load(object sender, EventArgs e)
        {
            if (Megjelenítés)
            {
                Btn_PDFNyitó.Visible = false;
                Btn_Másolás.Visible = false;
                ElemekListája();
                this.Text = "PDF megjelenítés";
            }
        }

        private void ElemekListája()
        {
            try
            {       // A tervezett fájlnévnek megfelelően szűrjük a könyvtár tartalmát
                FájlLista.Items.Clear();
                DirectoryInfo Directories = new DirectoryInfo(Hova);
                string mialapján = $@"{Bizonylat}_{Dátum:yyyy}*.pdf";


                FileInfo[] fileInfo = Directories.GetFiles(mialapján, SearchOption.TopDirectoryOnly);

                foreach (FileInfo file in fileInfo)
                    FájlLista.Items.Add(file.Name);

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

        private void Btn_PDFNyitó_Click(object sender, EventArgs e)
        {
            Pdfekkel();
        }

        private void Pdfekkel()
        {
            try
            {
                FájlLista.Items.Clear();
                using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        DirectoryInfo di = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                        BeolvasásiHely = folderBrowserDialog1.SelectedPath;
                        FileInfo[] aryFi = di.GetFiles("*.pdf");
                        foreach (FileInfo fi in aryFi)
                            FájlLista.Items.Add(fi.Name);
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

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (FájlLista.SelectedItems.Count == 0) return;
                string hely = $@"{BeolvasásiHely}\{FájlLista.SelectedItems[0]}";
                if (!Exists(hely)) throw new HibásBevittAdat("Nem létezik a betölteni kívánt pdf.");

                Kezelő_Pdf.PdfMegnyitás(Pdftöltő, hely);
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, this.ToStrTrim(), ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Másolás_Click(object sender, EventArgs e)
        {
            try
            {
                if (FájlLista.SelectedItems.Count < 1) throw new HibásBevittAdat("Nincs kiválasztva dokumentum!");
                int elem = MyF.VanPDFdb(Bizonylat, Dátum, Hova);
                // kijelölt elemeket másolja a kijelölt könyvtárba
                for (int i = 0; i < FájlLista.SelectedItems.Count; i++)
                {
                    string hely = $@"{Hova}\{Bizonylat}_{Dátum:yyyyMMdd}_{++elem}.pdf";
                    string honnan = $@"{BeolvasásiHely}\{FájlLista.SelectedItems[i].ToStrTrim()}";
                    Copy(honnan, hely);
                }
                MessageBox.Show("A PDF feltöltés sikeres volt.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Változás?.Invoke();
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
