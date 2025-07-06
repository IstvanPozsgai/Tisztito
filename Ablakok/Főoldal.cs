using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Ablakok;
using Tisztito.Ablakok.Lekérdezés;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using Tisztito.Minden;


namespace Tisztito
{
    public partial class Főoldal : Form
    {
        readonly Kezelők_Oldalok KézOldal = new Kezelők_Oldalok();
        readonly Kezelők_Jogosultságok KézJog = new Kezelők_Jogosultságok();
        readonly Kezelő_Belépés_Verzió Kéz_Belépés_Verzió = new Kezelő_Belépés_Verzió();

        List<Adat_Belépés_Verzió> AdatokVerzó = new List<Adat_Belépés_Verzió>();

        private static PerformanceCounter myCounter;

        bool CTRL_le = false;
        bool Shift_le = false;
        bool Alt_le = false;

        public Főoldal()
        {
            InitializeComponent();
            Start();
        }

        #region Alap
        private void Start()
        {
            Képetvált();
            Program.PostásJogosultságok = KézJog.Lista_Adatok().Where(a => a.UserId == Program.PostásNévId).ToList();
            Program.PostásMenü = AblakokGombok.MenüListaKészítés(MenuStrip);
            Program.PostásOldalak = KézOldal.Lista_Adatok();
            MenüBeállítása();
        }

        private void Főoldal_Load(object sender, EventArgs e)
        {
        }

        private void MenüBeállítása()
        {
            try
            {
                //Kikapcsoljuk a jogosultságtól függő ablakokat
                Program.PostásOldalak = KézOldal.Lista_Adatok();
                foreach (ToolStripMenuItem item in Program.PostásMenü)
                {
                    Adat_Oldalak Adat = Program.PostásOldalak.FirstOrDefault(a => a.MenuName == item.Name);
                    if (Adat != null) item.Enabled = Adat.Látható;
                }

                //Beállítjuk a jogosultságot amit felhasználóknak adtunk
                List<Adat_Jogosultságok> JogAdatok = Program.PostásJogosultságok;
                if (JogAdatok == null) return;

                List<int> JogIDék = JogAdatok.Select(a => a.OldalId).Distinct().ToList();
                foreach (ToolStripMenuItem item in Program.PostásMenü)
                {
                    Adat_Oldalak OldalAdat = Program.PostásOldalak.FirstOrDefault(a => a.MenuName == item.Name);
                    if (OldalAdat != null)
                    {
                        if (JogIDék.Contains(OldalAdat.OldalId)) item.Enabled = true;
                    }
                }

                //Admin felhasználó menüinek láthatósága
                AblakokBeállításaMenuItem.Visible = false;
                GombokBeállításaToolStripMenuItem.Visible = false;
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

        private void Főoldal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AblakFőoldal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) Shift_le = true;
            if (e.Alt) Alt_le = true;
            if (e.Control) CTRL_le = true;
        }

        private void AblakFőoldal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift) Shift_le = false;
            if (e.Alt) Alt_le = false;
            if (e.Control) CTRL_le = false;

        }
        #endregion


        #region Menük
        #region Beállítások
        #region Ablakok beállítása
        Ablak_Formok Új_Ablak_Formok;
        private void AblakokBeállításaMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Formok == null)
            {
                Új_Ablak_Formok = new Ablak_Formok();
                Új_Ablak_Formok.FormClosed += Új_Ablak_Formok_FormClosed;
                Új_Ablak_Formok.Show();
            }
            else
            {
                Új_Ablak_Formok.Activate();
                Új_Ablak_Formok.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Formok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Formok = null;
        }
        #endregion


        #region Gombok beállítása
        Ablak_Gombok Új_Ablak_Gombok;
        private void GombokBeállításaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Gombok == null)
            {
                Új_Ablak_Gombok = new Ablak_Gombok();
                Új_Ablak_Gombok.FormClosed += Új_Új_Ablak_Gombok_FormClosed;
                Új_Ablak_Gombok.Show();
            }
            else
            {
                Új_Ablak_Gombok.Activate();
                Új_Ablak_Gombok.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Új_Ablak_Gombok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Gombok = null;
        }
        #endregion


        #region Felhasználók létrehozása    
        AblakFelhasználó Új_AblakFelhasználó;
        private void FelhasználókMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_AblakFelhasználó == null)
            {
                Új_AblakFelhasználó = new AblakFelhasználó();
                Új_AblakFelhasználó.FormClosed += Új_AblakFelhasználó_FormClosed;
                Új_AblakFelhasználó.Show();
            }
            else
            {
                Új_AblakFelhasználó.Activate();
                Új_AblakFelhasználó.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_AblakFelhasználó_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_AblakFelhasználó = null;
        }
        #endregion


        #region Jogosultság kiosztás   
        Ablak_JogKiosztás Új_Ablak_JogKiosztás;
        private void JogKiosztMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_JogKiosztás == null)
            {
                Új_Ablak_JogKiosztás = new Ablak_JogKiosztás();
                Új_Ablak_JogKiosztás.FormClosed += Új_Ablak_JogKiosztás_FormClosed;
                Új_Ablak_JogKiosztás.Show();
            }
            else
            {
                Új_Ablak_JogKiosztás.Activate();
                Új_Ablak_JogKiosztás.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_JogKiosztás_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_JogKiosztás = null;
        }
        #endregion
        #endregion



        /// <summary>
        /// Ablakokat nyitja meg és kezeli a bezárást
        /// <summary>
        #region Anyag
        /// <summary>
        /// Az Anyagtörzs karbantartásának ablakát nyitja meg.
        /// </summary>
        Ablak_Anyagok Új_Ablak_Anyagok;
        private void ToolStripMenuItem_Anyag_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Anyagok == null)
            {
                Új_Ablak_Anyagok = new Ablak_Anyagok();
                Új_Ablak_Anyagok.FormClosed += Új_Ablak_Anyagok_FormClosed;
                Új_Ablak_Anyagok.Show();
            }
            else
            {
                Új_Ablak_Anyagok.Activate();
                Új_Ablak_Anyagok.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Anyagok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Anyagok = null;
        }
        #endregion


        #region Dolgozó
        Ablak_Dolgozók Új_Ablak_Dolgozók;
        private void ToolStripMenuItem_Dolgozó_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Dolgozók == null)
            {
                Új_Ablak_Dolgozók = new Ablak_Dolgozók();
                Új_Ablak_Dolgozók.FormClosed += Új_Ablak_Dolgozók_FormClosed;
                Új_Ablak_Dolgozók.Show();
            }
            else
            {
                Új_Ablak_Dolgozók.Activate();
                Új_Ablak_Dolgozók.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Dolgozók_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Dolgozók = null;
        }
        #endregion


        #region Működési adatok
        Ablak_Beállítások Új_Ablak_Beállítások;
        private void MűködésiAdatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Beállítások == null)
            {
                Új_Ablak_Beállítások = new Ablak_Beállítások();
                Új_Ablak_Beállítások.FormClosed += Új_Ablak_Beállítások_FormClosed;
                Új_Ablak_Beállítások.Show();
            }
            else
            {
                Új_Ablak_Beállítások.Activate();
                Új_Ablak_Beállítások.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Beállítások_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Beállítások = null;
        }
        #endregion


        #region Szervezet
        Ablak_Szervezet Új_Ablak_Szervezet;
        private void ToolStripMenuItem_Szervezet_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Szervezet == null)
            {
                Új_Ablak_Szervezet = new Ablak_Szervezet();
                Új_Ablak_Szervezet.FormClosed += Új_Ablak_Szervezet_FormClosed;
                Új_Ablak_Szervezet.Show();
            }
            else
            {
                Új_Ablak_Szervezet.Activate();
                Új_Ablak_Szervezet.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Szervezet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Szervezet = null;
        }
        #endregion


        #region Járandóság
        Ablak_Járandóság Új_Ablak_Járandóság;
        private void ToolStripMenuItem_Járandóság_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Járandóság == null)
            {
                Új_Ablak_Járandóság = new Ablak_Járandóság();
                Új_Ablak_Járandóság.FormClosed += Új_Ablak_Járandóság_FormClosed;
                Új_Ablak_Járandóság.Show();
            }
            else
            {
                Új_Ablak_Járandóság.Activate();
                Új_Ablak_Járandóság.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_Járandóság_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Járandóság = null;
        }
        #endregion


        #region TerületiIgények
        Ablak_Igények Új_Ablak_Igények;
        private void TerületiIgényekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Igények == null)
            {
                Új_Ablak_Igények = new Ablak_Igények();
                Új_Ablak_Igények.FormClosed += Új_Ablak_Igények_FormClosed;
                Új_Ablak_Igények.Show();
            }
            else
            {
                Új_Ablak_Igények.Activate();
                Új_Ablak_Igények.WindowState = FormWindowState.Maximized;
            }
        }

        private void Új_Ablak_Igények_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Igények = null;
        }
        #endregion


        #region Raktárak közötti könyvelés
        Ablak_Raktár Új_Ablak_Raktár;
        private void RaktárakKözöttiKönyvelésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_Raktár == null)
            {
                Új_Ablak_Raktár = new Ablak_Raktár();
                Új_Ablak_Raktár.FormClosed += Új_Ablak_Raktár_FormClosed;
                Új_Ablak_Raktár.Show();
            }
            else
            {
                Új_Ablak_Raktár.Activate();
                Új_Ablak_Raktár.WindowState = FormWindowState.Maximized;
            }
        }

        private void Új_Ablak_Raktár_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_Raktár = null;
        }

        Ablak_KiOszt Új_Ablak_KiOszt;
        private void DolgozóiKiadásMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_KiOszt == null)
            {
                Új_Ablak_KiOszt = new Ablak_KiOszt();
                Új_Ablak_KiOszt.FormClosed += Új_Ablak_KiOszt_FormClosed;
                Új_Ablak_KiOszt.Show();
            }
            else
            {
                Új_Ablak_KiOszt.Activate();
                Új_Ablak_KiOszt.WindowState = FormWindowState.Maximized;
            }
        }

        private void Új_Ablak_KiOszt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_KiOszt = null;
        }
        #endregion

        #region Lekérdezések
        Ablak_OsztásNyomtatvány Új_Ablak_OsztásNyomtatvány;
        private void KiosztásiNyomtatványMenuItem_Click(object sender, EventArgs e)
        {
            if (Új_Ablak_OsztásNyomtatvány == null)
            {
                Új_Ablak_OsztásNyomtatvány = new Ablak_OsztásNyomtatvány();
                Új_Ablak_OsztásNyomtatvány.FormClosed += Új_Ablak_OsztásNyomtatványt_FormClosed;
                Új_Ablak_OsztásNyomtatvány.Show();
            }
            else
            {
                Új_Ablak_OsztásNyomtatvány.Activate();
                Új_Ablak_OsztásNyomtatvány.WindowState = FormWindowState.Maximized;
            }
        }

        private void Új_Ablak_OsztásNyomtatványt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_OsztásNyomtatvány = null;
        }
        #endregion

        #endregion


        #region Képkezelés
        private void Képetvált()
        {
            int választottkép = -1;

            string[] dirs = { "_" };

            try
            {
                string hely = $@"{Application.StartupPath}\Adatok\Képek".KönyvSzerk();
                //Ezt lehet allitani ha szeretnenk, ertekek amiket var: helye a kepnek, Max merete bajtban,
                //kep max szélessége és magassága és az összesen mennyi pixel lehet a kép
                //Most ki van veve belole az az opcio hogy megadjuk neki az ossz pixel mennyiséget.
                //Amik commentezve vannak reszek a programban azok a reszek amik segitenek abban
                //500_000 bájt = 500KB
                //szelesseg magassag pixelben
                //2_073_600 pixel a szelesseg es a magassag szorzata az ossz pixel

                dirs = Directory.GetFiles(hely, "*.jpg")
                                .Where(kép => ÉrvényesKép(kép, 500_000, 1920, 1080/*, 2_073_600*/))
                                .ToArray();
                if (dirs.Length < 2) return;

                //Azért van do while hogy a két kép ne legyen ugyanaz egyszerre
                Random rnd = new Random();
                választottkép = rnd.Next(dirs.Length);

                string helykép = dirs[választottkép];
                Kezelő_Kép.KépMegnyitás(Képkeret, helykép, toolTip1);

            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Meghatározatlan hiba"))
                {
                    HibaNapló.Log(ex.Message, this.ToString() + $"\nKép1:{dirs?[választottkép]}", ex.StackTrace, ex.Source, ex.HResult);
                    MessageBox.Show(ex.Message + $"\nKép1:{dirs?[választottkép]}" + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ÉrvényesKép(string helykép, long MaxMéret, int MaxSzélesség, int MaxMagasság/*, long ÖsszPixel*/)
        {
            try
            {
                // A FileInfo-val lekerdezhetjuk a fajl adatait (pl. meret, nev),
                // es fajlmuveleteket vegezhetunk rajta, mint a torles vagy datumok kezelese.

                FileInfo Flnf = new FileInfo(helykép);

                if (Flnf.Length > MaxMéret)
                {
                    //  FájlTörlés(helykép);
                    return false;
                }

                using (Image kép = Image.FromFile(helykép))
                {
                    //int ÖsszPixel = kép.Width * kép.Height;
                    if (kép.Width > MaxSzélesség || kép.Height > MaxMagasság /*|| ÖsszPixel > ÖsszPixel*/)
                    {
                        kép.Dispose();
                        //  FájlTörlés(helykép);
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                //   FájlTörlés(helykép);
                return false;
            }
        }
        #endregion


        #region Verzió kezelés
        private void VerzióListaFeltöltés()
        {
            try
            {
                AdatokVerzó.Clear();
                AdatokVerzó = Kéz_Belépés_Verzió.Lista_Adatok();
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

        private void Verziószám_kiírás()
        {
            VerzióListaFeltöltés();
            Adat_Belépés_Verzió Elem = (from a in AdatokVerzó
                                        where a.Id == 2
                                        select a).FirstOrDefault();
            if (Elem != null) TároltVerzió.Text = Elem.Verzió.ToString();
        }

        private void Verzió_Váltás_Click(object sender, EventArgs e)
        {
            // frissítjük a verziót
            Adat_Belépés_Verzió Elem = (from a in AdatokVerzó
                                        where a.Id == 2
                                        select a).FirstOrDefault();
            double verzió = double.Parse(Application.ProductVersion.Replace(".", ""));
            Adat_Belépés_Verzió ADAT = new Adat_Belépés_Verzió(2, verzió);
            if (Elem != null)
                Kéz_Belépés_Verzió.Módosítás(ADAT);
            else
                Kéz_Belépés_Verzió.Rögzítés(ADAT);
            Verziószám_kiírás();
            MessageBox.Show("Az adatok rögzítése befejeződött!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuStrip_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Rejtett.Visible = CTRL_le && Shift_le && Alt_le;
            Verziószám_kiírás();
        }
        #endregion


        #region Gombok
        private void Menükinyitás_Click(object sender, EventArgs e)
        {
            AblakokBeállításaMenuItem.Visible = true;
            GombokBeállításaToolStripMenuItem.Visible = true;
            AblakokBeállításaMenuItem.Enabled = true;
            GombokBeállításaToolStripMenuItem.Enabled = true;
        }

        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // 5 percenként frissíti az üzeneteket, stb.
                // beállítása a tulajdonságokban  5 perc=300000 érték
                Képetvált();

                // ha látszódik a figyelmeztetés, akkor kiléptetjük
                if (Figyelmeztetés.Visible == true)
                {
                    if (!PerformanceCounterCategory.Exists("Processor"))
                    {
                        if (MessageBox.Show("Az objektumfeldolgozó nem létezik! Kilép a program.", "A program karbantartás miatt kiléptet.", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Close();
                        }
                        else
                        {
                            Close();
                        }
                    }

                    if (!PerformanceCounterCategory.CounterExists("% Processor Time", "Processor"))
                    {
                        if (MessageBox.Show("Számláló % Processzoridő nem létezik! Kilép a program.", "A program karbantartás miatt kiléptet.", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Close();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    myCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                    if ((int)Math.Round(myCounter.NextValue()) < 2)
                        Close();
                }


                // ha létezik a fájl akkor megjelenítjük a figyelmeztető üzenetet
                string hely = Application.StartupPath + @"\Adatok\a.txt";
                if (File.Exists(hely))
                {
                    // ha épp dolgozik akkor figyelmezetjük, hogy ki kell lépni
                    FigyKiírás($"Karbantartás miatt a program\n ~{DateTime.Now.AddMinutes(1):HH:mm}- kor\n kiléptet.");
                    timer1.Enabled = false;
                    timer1.Interval = 60000;
                    timer1.Enabled = true;
                }

                Verziószám_kiírás();
                // Verzió váltás  akkor megjelenítjük a figyelmeztető üzenetet
                if (Convert.ToDouble(TároltVerzió.Text.Trim()) > Convert.ToDouble(Application.ProductVersion.Replace(".", "").Trim()))
                {
                    FigyKiírás($"Elavult a program verzió,\n ezért a program ki fog léptetni\n ~{DateTime.Now.AddMinutes(5d):HH:mm}- kor.");
                }
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Meghatározatlan hiba"))
                {
                    HibaNapló.Log(ex.Message, this.ToString(), ex.StackTrace, ex.Source, ex.HResult);
                    MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FigyKiírás(string szöveg)
        {
            Figyelmeztetés.Left = 10;
            Figyelmeztetés.Top = 20;
            Figyelmeztetés.Width = this.Width - 20;
            Figyelmeztetés.Height = this.Height - 40;
            Figyelmeztetés.Text = szöveg;
            Figyelmeztetés.Visible = true;
        }


    }
}

