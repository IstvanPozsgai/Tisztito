using Bejelentkezés.Adatszerkezet;
using Bejelentkezés.Kezelők;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tisztito
{
    public partial class Ablak_Login : Form
    {
        readonly Kezelők_Users Kéz = new Kezelők_Users();
        List<Adat_Users> Adatok = new List<Adat_Users>();


        public Ablak_Login()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            Adatok = Kéz.Lista_Adatok();
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                Adat_Users Belép = (from a in Adatok
                                    where a.UserName == txtUsername.Text.Trim()
                                    && a.Törölt == false
                                    select a).FirstOrDefault();

                if (Belép == null)
                    if (txtPassword.Trim().ToUpper() == "INIT") throw new HibásBevittAdat("A jelszó még nem lett módosítva az alapbeállításról, a jelszó módosítani szükséges.");

                Adat_Belépés_Bejelentkezés Elem = (from a in AdatokBelépésTelephely
                                                   where a.Név.ToUpper() == UserName.ToUpper()
                                                   select a).FirstOrDefault();
                if (Elem != null)
                {
                    if (Begépeltjelszó.Trim().ToUpper() == Elem.Jelszó.Trim().ToUpper())
                        Jogosultság_Belépés(Telephely, UserName);
                    else
                    {
                        MessageBox.Show("Hibás jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        TxtPassword.Text = "";
                        TxtPassword.Focus();
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
    }
}
