using Bejelentkezés.Adatszerkezet;
using Bejelentkezés.Kezelők;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using Tisztito.Minden;
using static System.IO.File;

namespace Tisztito
{
    public partial class Ablak_Login : Form
    {
        readonly Kezelők_Users Kéz = new Kezelők_Users();
        readonly Kezelő_Belépés_Verzió KézVerzió = new Kezelő_Belépés_Verzió();
        List<Adat_Users> Adatok = new List<Adat_Users>();
        bool Beléphet = true;

        public Ablak_Login()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            lblVerzió.Text = "Verzió: " + Application.ProductVersion;
            Timer_kilép.Enabled = false;
            Hálózat();
            Dátumformátumellenőrzés();
            Karbantartásellenőrzés();
            Adatok = Kéz.Lista_Adatok();
            AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Adat_Users Belép = (from a in Adatok
                                    where a.UserName == txtUsername.Text.ToLower().Trim()
                                    && a.Törölt == false
                                    select a).FirstOrDefault() ?? throw new HibásBevittAdat("Hibás felhasználónév.");

                if (Belép.Frissít)
                {
                    MessageBox.Show("A jelszó még nem lett módosítva az alapbeállításról, a jelszó módosítani szükséges.", "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //kérjük, hogy változtassa meg a jelszavát
                    Subjelszómódosítás(Belép);
                    Adatok = Kéz.Lista_Adatok();
                    return;
                }
                if (Jelszó.HashPassword(txtPassword.Text.Trim()) != Belép.Password) throw new HibásBevittAdat("Hibás jelszó!");
                Belépés(Belép);
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
        /// Beállítjuk , hogy ki lép be, milyen joggal és a programba és beléptetjük
        /// </summary>
        private void Belépés(Adat_Users Elem)
        {
            Program.PostásNév = Elem.UserName;
            //Valamint, hogy mire van jogosultsága


            Főoldal Főoldalablak = new Főoldal();
            Főoldalablak.Show();
            this.Hide();
        }

        private void Subjelszómódosítás(Adat_Users Adat)
        {
            AblakJelszóváltoztatás jelszó_váltás = new AblakJelszóváltoztatás(Adat);
            jelszó_váltás.ShowDialog();
            txtPassword.Text = "";
            txtPassword.Focus();
        }

        private void Ablak_Login_Load(object sender, EventArgs e)
        {

        }

        private void Ablak_Login_Shown(object sender, EventArgs e)
        {
            if (Beléphet) WinVan();
        }

        private void WinVan()
        {
            try
            {
                if (Adatok != null)
                {
                    Adat_Users Elem = (from a in Adatok
                                       where a.WinUserName.ToLower().Trim() == Environment.UserName.ToLower().Trim()
                                       select a).FirstOrDefault();

                    //Ha van ilyen dolgozó, akkor beléptetjük
                    if (Elem != null) Belépés(Elem);

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


        #region Ellenőrzések
        private void Hálózat()
        {
            if (Application.StartupPath.Substring(0, 2) == @"\\")
            {
                FigyKiírás("A programot csak hálózati meghajtón keresztül lehet elindítani. \n Kérem csatlakoztasson hálózati meghajtót.");
                KönyvtárEllenőr KV = new KönyvtárEllenőr();
                KV.Megfelelő(Application.StartupPath);
                Beléphet = false;
            }
        }


        private void Dátumformátumellenőrzés()
        {
            try
            {
                string formátum = @"^([12]\d{3}.(0[1-9]|1[0-2]).(0[1-9]|[12]\d|3[01]). ([0-2][0-9]|[0-9]):([0-5][0-9]):([0-5][0-9]))$";

                if (!Regex.IsMatch(DateTime.Now.ToString(), formátum))
                {
                    // Ha rossz a dátum formátum, akkor átállítjuk
                    string dateFormat = "yyyy.MM.dd.";
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
                    key.SetValue("sShortDate", dateFormat);

                    //Ha kijavítottuk, akkor és tájékozatunk
                    string szöveg = "A számítógépen az idő formátum nem volt jól beállíva, ezért a program átírta a rendszer időformátumát. \n A helyes működéshez a program újraindul.";
                    MessageBox.Show(szöveg, "Számítógép beállítási Hiba javítva lett", MessageBoxButtons.OK);
                    Application.Restart();

                    if (!Regex.IsMatch(DateTime.Now.ToString(), formátum))
                    {
                        //Ha továbbra is rossz a dátum formátum akkor kilépünk üzenettel
                        szöveg = "A számítógépen az idő formátum nincs jól beállíva, ezért a program leáll.\r\n";
                        szöveg += " A helyes formátum: éééé.HH.nn. nincs szóköz a pont után.\r\n";
                        szöveg += " Beállítani a területi/ régió beállításoknál kell.";
                        FigyKiírás(szöveg);
                        //     HibaNapló.Log("Hibás  dátum forma.", $"Dátum: {DateTime.Now}\n Felhasználó : {Environment.UserName}", "Dátumformátumellenőrzés", "", 0);
                        Timer_kilép.Enabled = true;

                        Application.Exit();
                    }
                    else
                    {
                        //Ha kijavítottuk, akkor és tájékozatunk
                        szöveg = "A számítógépen az idő formátum nem volt jól beállíva, ezért a program átírta a rendszer időformátumát.";
                        MessageBox.Show(szöveg, "Számítógép beállítási Hiba javítva lett", MessageBoxButtons.OK);
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

        private void Karbantartásellenőrzés()
        {
            // ha karbantartás van nem engedünk belépni
            string hely = $@"{Application.StartupPath}\Főmérnökség\Szerszám\a.txt";
            if (Exists(hely))
            {
                FigyKiírás("\nJelenleg az adatok karbantartása folyik. \r\n\n Kis türelmet kérek ....");
                Beléphet = false;
            }
            else
                Verzióellenőrzés();
        }

        private void FigyKiírás(string szöveg)
        {

            Timer_kilép.Enabled = true;

            Label Figyelmeztetés = new Label
            {
                Left = 5,
                Top = 5,
                Width = 920,
                Height = 230,
                Text = szöveg,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Tomato,
                Font = new System.Drawing.Font("Arial", 20, FontStyle.Bold),
                Visible = true
            };
            this.Controls.Add(Figyelmeztetés);

            Timer_kilép.Enabled = true;
            Application.Exit();
        }


        private void Verzióellenőrzés()
        {
            try
            {
                List<Adat_Belépés_Verzió> Adatok = KézVerzió.Lista_Adatok();

                Adat_Belépés_Verzió Elem = (from a in Adatok
                                            where a.Id == 2
                                            select a).FirstOrDefault();
                if (Elem != null)
                {
                    if (Application.ProductVersion.Replace(".", "").ToÉrt_Double() < Elem.Verzió)
                    {
                        FigyKiírás("Elavult a program verzió!\n\n Új parancsikont kell készíteni.\n\n Ha szükséges a számítógépet újra kell indítani.");
                        Beléphet = false;
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


    }
}
