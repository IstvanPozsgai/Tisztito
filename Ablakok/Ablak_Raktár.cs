using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyEn = Tisztito.Minden.Enumok;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Raktár : Form
    {
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        readonly Kezelő_Anyag KézAnyag = new Kezelő_Anyag();
        readonly Kezelő_Raktár KézRaktár = new Kezelő_Raktár();

        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Anyag> AdatokAnyag = new List<Adat_Anyag>();
        List<Adat_Raktár> AdatokRaktár = new List<Adat_Raktár>();

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        public Ablak_Raktár()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// Betöltjük a comboboxba a listákat
        /// </summary>
        private void Start()
        {
            MozgásokFeltöltése();
            AdatokSzervezet = KézSzervezet.Lista_Adatok();
            AdatokAnyag = KézAnyag.Lista_Adatok().Where(a => a.Státus == false).ToList();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            CikkszámokFeltöltése();

        }


        private void Ablak_Raktár_Load(object sender, System.EventArgs e)
        {

        }


        #region Mozgások és szervezetek
        /// <summary>
        /// Feltöltjük a comboboxba enumként tárolt mozgásokat
        /// </summary>
        private void MozgásokFeltöltése()
        {
            try
            {
                Mozgás.Items.Add("");
                foreach (string adat in Enum.GetNames(typeof(MyEn.Mozgás)))
                    Mozgás.Items.Add(adat);
                Mozgás.Text = "";
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
        /// Kiválasztott elemnek megfelelően feltöltjük a Honnan és Hova comboboxokat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mozgás_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //kiürítjük a comboboxokat
                Honnan.Items.Clear();
                Hova.Items.Clear();
                if (Mozgás.Text.Trim() == "")
                    HonnanHovaFeltöltés(99);
                else
                {
                    int KiválasztottStátusz = (int)Enum.Parse(typeof(MyEn.Mozgás), Mozgás.Text);
                    HonnanHovaFeltöltés(KiválasztottStátusz);
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
        /// Mozgásnak megfelelően töltjük fel a Honnan és Hova comboboxokat
        /// Üríteni nem kell, mert a Mozgás_SelectedIndexChanged már kiürítette
        /// </summary>
        /// <param name="Melyik"></param>
        private void HonnanHovaFeltöltés(int Melyik)
        {
            try
            {
                List<Adat_Szervezet> Adatok = AdatokSzervezet.Where(a => a.Szervezet != "Központi raktár").ToList();
                switch (Melyik)
                {
                    case 0:
                        //Beérkezés
                        Honnan.Text = "";
                        Honnan.Enabled = false;
                        Hova.Items.Add("Központi raktár");
                        Hova.Text = "Központi raktár";
                        Hova.Enabled = false;
                        break;
                    case 1:
                        //Beérkezés_Storno
                        Honnan.Text = "";
                        Honnan.Enabled = false;
                        Hova.Items.Add("Központi raktár");
                        Hova.Text = "Központi raktár";
                        Hova.Enabled = false;
                        break;
                    case 3:
                        //Átadás
                        Honnan.Text = "Központi raktár";
                        Honnan.Enabled = false;

                        Hova.Items.Add("");
                        foreach (Adat_Szervezet Elem in Adatok)
                            Hova.Items.Add(Elem.Szervezet);
                        Hova.Text = "";
                        Hova.Enabled = true;
                        break;
                    case 4:
                        //Átadás stornó
                        Honnan.Text = "Központi raktár";
                        Honnan.Enabled = false;
                        Hova.Items.Add("");
                        foreach (Adat_Szervezet Elem in Adatok)
                            Hova.Items.Add(Elem.Szervezet);
                        Hova.Text = "";
                        Hova.Enabled = true;
                        break;

                    default:
                        Honnan.Text = "";
                        Hova.Text = "";
                        Honnan.Enabled = true;
                        Hova.Enabled = true;
                        Honnan.Items.Add("");
                        foreach (Adat_Szervezet Elem in AdatokSzervezet)
                            Honnan.Items.Add(Elem.Szervezet);
                        break;
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
                Azonosítók.Items.Add("");
                Megnevezések.Items.Add("");
                foreach (Adat_Anyag Elem in AdatokAnyag.OrderBy(a => a.Cikkszám).ToList())
                    Azonosítók.Items.Add(Elem.Cikkszám);


                foreach (Adat_Anyag Elem in AdatokAnyag.OrderBy(a => a.Megnevezés).ToList())
                    Megnevezések.Items.Add(Elem.Megnevezés);

                if (Azonosítók.Items.Count > 0) Azonosítók.SelectedIndex = 0;
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
        private void Azonosítók_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Azonosítók.SelectedIndex < 1)
                {
                    Megnevezések.Text = "";
                    return;
                }
                Azonosítók.Text = Azonosítók.Items[Azonosítók.SelectedIndex].ToString();
                Megnevezések.Text = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == Azonosítók.Text).Megnevezés;
                HonnanMennyiség.Text = Készlet(Azonosítók.Text, Honnan.Text).ToString();
                HováMennyiség.Text = Készlet(Azonosítók.Text, Hova.Text).ToString();
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
                    Azonosítók.Text = "";
                    return;
                }
                Megnevezések.Text = Megnevezések.Items[Megnevezések.SelectedIndex].ToString();
                Azonosítók.Text = AdatokAnyag.FirstOrDefault(a => a.Megnevezés == Megnevezések.Text).Cikkszám;
                HonnanMennyiség.Text = Készlet(Azonosítók.Text, Honnan.Text).ToString();
                HováMennyiség.Text = Készlet(Azonosítók.Text, Hova.Text).ToString();
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


        #region Könyvelés
        /// <summary>
        /// Az anyagok rögzítése a raktárakba
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rögzít_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mozgás.Text.Trim() == "") return;
                if (Hova.Text.Trim() == "") throw new HibásBevittAdat("A könyvelés helyét meg kell adni."); ;
                if (!int.TryParse(Mennyiség.Text, out int darab)) throw new HibásBevittAdat("A mennyiség csak szám lehet!");
                if (!int.TryParse(HonnanMennyiség.Text, out int Honnandarab)) throw new HibásBevittAdat("A mennyiség csak szám lehet!");
                if (Honnan.Text.Trim() != "" && Honnandarab < darab) throw new HibásBevittAdat("A készleten lévő mennyiségnél nem lehet többet kiadni.");


                //Ahova könyvelünk
                Adat_Raktár ADAT = new Adat_Raktár(
                    Azonosítók.Text.Trim(),
                    Hova.Text.Trim(),
                    darab);
                KézRaktár.Döntés(ADAT);

                if (Honnan.Text.Trim() != "")
                {
                    //Ahonnan könyvelünk de csak akkor ha nem beérkezés
                    ADAT = new Adat_Raktár(
                           Azonosítók.Text.Trim(),
                           Honnan.Text.Trim(),
                           -1 * darab);
                    KézRaktár.Döntés(ADAT);
                }

                Táblázat();
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


        #region Listázások
        /// <summary>
        /// A feltételeknek megfelelően kilistázza a raktárakat készletét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frissít_Click(object sender, EventArgs e)
        {
            Táblázat();
        }

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
                if (Honnan.Text.Trim() == "")
                    Adatok = AdatokRaktár;
                else
                    Adatok = AdatokRaktár.Where(a => a.Szervezet == Honnan.Text.Trim()).ToList();

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


    }
}
