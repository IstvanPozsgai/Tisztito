using Bejelentkezés.Adatszerkezet;
using Bejelentkezés.Kezelők;
using System;
using System.Windows.Forms;
using Tisztito.Minden;

namespace Tisztito
{
    public partial class AblakJelszóváltoztatás
    {
        readonly Kezelők_Users Kéz = new Kezelők_Users();
        Adat_Users Adat;
        public AblakJelszóváltoztatás(Adat_Users adat)
        {
            InitializeComponent();
            Adat = adat;
        }


        private void BtnMégse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btnok_Click(object sender, EventArgs e)
        {
            try
            {
                if (Jelszó.HashPassword(TxtPassword.Text.Trim()) != Adat.Password)
                {
                    TxtPassword.Focus();
                    throw new HibásBevittAdat("A régi jelszó nem egyezik a tárolt adatokkal !");
                }

                // ha nem egyforma a két jelszó akkor kilép
                if (Első.Text.Trim() != Második.Text.Trim())
                {
                    MessageBox.Show("A két jelszó nem egyezik!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Első.Focus();
                    return;
                }
                if (Első.Text.Trim().Length < 5)
                {
                    MessageBox.Show("A jelszónak 5 karakternél hosszabbnak kell lennie !", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Első.Focus();
                    return;
                }
                if (Első.Text.Trim().Length > 20)
                {
                    MessageBox.Show("A jelszónak 20 karakternél rövidebbnek kell lennie !", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Első.Focus();
                    return;
                }

                Adat_Users adat = new Adat_Users(Adat.UserId, Adat.UserName, Adat.WinUserName, Adat.Dolgozószám, Jelszó.HashPassword(Első.Text.Trim()), DateTime.Now, false, false);
                Kéz.Döntés(adat);

                MessageBox.Show("A jelszó módosításra került !", "Tájékoztatás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

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




        private void TxtPassword_MouseLeave(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = true;
        }

        private void TxtPassword_MouseMove(object sender, MouseEventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = false;
        }

        private void Első_MouseMove(object sender, MouseEventArgs e)
        {
            Első.UseSystemPasswordChar = false;
        }

        private void Első_MouseLeave(object sender, EventArgs e)
        {
            Első.UseSystemPasswordChar = true;
        }
        private void Második_MouseMove(object sender, MouseEventArgs e)
        {
            Második.UseSystemPasswordChar = false;
        }

        private void Második_MouseLeave(object sender, EventArgs e)
        {
            Második.UseSystemPasswordChar = true;
        }

        private void AblakJelszóváltoztatás_Load(object sender, EventArgs e)
        {

        }
    }
}