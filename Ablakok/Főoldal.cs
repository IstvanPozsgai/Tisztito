using Bejelentkezés.Adatszerkezet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Ablakok;
using Tisztito.Kezelők;
using Tisztito.Minden;


namespace Tisztito
{
    public partial class Főoldal : Form
    {
        readonly Kezelők_Oldalok KézOldal = new Kezelők_Oldalok();
        readonly Kezelők_Jogosultságok KézJog = new Kezelők_Jogosultságok();



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

                //Admin felhasználó menüinek engedélyezése
                if (Program.PostásNév != "admin")
                {
                    AblakokBeállításaMenuItem.Visible = false;
                    GombokBeállításaToolStripMenuItem.Visible = false;
                }
                else
                {
                    AblakokBeállításaMenuItem.Visible = true;
                    GombokBeállításaToolStripMenuItem.Visible = true;
                    AblakokBeállításaMenuItem.Enabled = true;
                    GombokBeállításaToolStripMenuItem.Enabled = true;
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

        private void Főoldal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
        private void működésiAdatokToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void területiIgényekToolStripMenuItem_Click(object sender, EventArgs e)
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


    }
}
