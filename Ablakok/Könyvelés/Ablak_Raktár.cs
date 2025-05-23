using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyEn = Tisztito.Minden.Enumok;
using MyF = Függvénygyűjtemény;

namespace Tisztito.Ablakok
{
    public partial class Ablak_Raktár : Form
    {
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

        private void MezőkÜrítése_Click(object sender, EventArgs e)
        {
            Mozgás.Text = "";
            Honnan.Text = "";
            Hova.Text = "";
            Cikkszámok.Text = "";
            Megnevezések.Text = "";
            HonnanMennyiség.Text = "<-->";
            HováMennyiség.Text = "<-->";
            Mennyiség.Text = "";
            Bizonylatszám.Text = "";
            Honnan.Enabled = true;
            Hova.Enabled = true;

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
                List<Adat_Szervezet> Adatok = AdatokSzervezet.Where(a => a.Szervezet != BázisRaktár).ToList();
                switch (Melyik)
                {
                    case 0:
                        //Beérkezés
                        Honnan.Text = "";
                        Honnan.Enabled = false;
                        Hova.Items.Add(BázisRaktár);
                        Hova.Text = BázisRaktár;
                        Hova.Enabled = false;
                        break;
                    case 3:
                        //Átadás
                        Honnan.Text = BázisRaktár;
                        Honnan.Enabled = false;

                        Hova.Items.Add("");
                        foreach (Adat_Szervezet Elem in Adatok)
                            Hova.Items.Add(Elem.Szervezet);
                        Hova.Text = "";
                        Hova.Enabled = true;
                        break;
                    case 5:
                        //Visszavétel
                        Hova.Text = BázisRaktár;
                        Hova.Enabled = false;

                        foreach (Adat_Szervezet Elem in Adatok)
                            Honnan.Items.Add(Elem.Szervezet);
                        Honnan.Text = "";
                        Honnan.Enabled = true;
                        break;
                    case 9:
                        //Stornó
                        Honnan.Text = "";
                        Hova.Text = "";
                        Honnan.Enabled = true;
                        Hova.Enabled = true;

                        foreach (Adat_Szervezet Elem in AdatokSzervezet)
                        {
                            Hova.Items.Add(Elem.Szervezet);
                            Honnan.Items.Add(Elem.Szervezet);
                        }
                        TáblázatKönyvelés();
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
                HonnanMennyiség.Text = Készlet(Cikkszámok.Text, Honnan.Text).ToString();
                HováMennyiség.Text = Készlet(Cikkszámok.Text, Hova.Text).ToString();
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
                HonnanMennyiség.Text = Készlet(Cikkszámok.Text, Honnan.Text).ToString();
                HováMennyiség.Text = Készlet(Cikkszámok.Text, Hova.Text).ToString();
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
                // írni kell: a stornozást
                // írni kell: a könyvelés sorszámozását
                if (Mozgás.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva a mozgás.");
                if (Hova.Text.Trim() == "") throw new HibásBevittAdat("A könyvelés helyét meg kell adni.");
                if (!(Hova.Text.Trim() == BázisRaktár || Honnan.Text.Trim() == BázisRaktár)) throw new HibásBevittAdat($"A {BázisRaktár}-nak szerepelnie kell valamelyik helyen.");
                if (!int.TryParse(Mennyiség.Text, out int darab)) throw new HibásBevittAdat("A mennyiség csak szám lehet!");
                if (!int.TryParse(HonnanMennyiség.Text, out int Honnandarab)) throw new HibásBevittAdat("A mennyiség csak szám lehet!");
                if (Honnan.Text.Trim() != "" && Honnandarab < darab) throw new HibásBevittAdat("A készleten lévő mennyiségnél nem lehet többet kiadni.");

                Adat_KészletNaplóRaktár AdatNapló = new Adat_KészletNaplóRaktár(
                     Cikkszámok.Text.Trim(),
                     darab,
                     Honnan.Text.Trim() == "" ? "Érkeztetés" : BázisRaktár,
                     Hova.Text.Trim(),
                     Bizonylatszám.Text.Trim(),
                     Program.PostásNév,
                     Dátum.Value,
                     false,
                     "",
                     new DateTime(1900, 1, 1));
                KézNaplóRaktár.Rögzítés(DateTime.Now.Year, AdatNapló);

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
            if (Mozgás.Text.Trim() == "") return;
            int KiválasztottStátusz = (int)Enum.Parse(typeof(MyEn.Mozgás), Mozgás.Text);

            switch (KiválasztottStátusz)
            {
                case 0:
                    break;
                case 3:
                    Táblázat();
                    break;
                case 5:
                    Táblázat();
                    break;
                case 9:
                    TáblázatKönyvelés();
                    break;
                default:
                    break;
            }

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

        /// <summary>
        /// Kiválasztott sorra kattintva kiírja a szervezet készlet adatait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tábla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (Tábla.Columns[0].ToString() != "Szervezet")
            {
                //Ez a képernyő a készlet lista
                string cikkszám = Tábla.Rows[e.RowIndex].Cells[1].Value.ToStrTrim();
                Adatokkiírása(cikkszám);
                Honnan.Text = Tábla.Rows[e.RowIndex].Cells[0].Value.ToStrTrim();
            }
            else
            {
                // Ez a képernyő a napló lista
            }



        }

        /// <summary>
        /// Kiírja a kiválasztott cikkszámhoz tartozó adatokat
        /// </summary>
        /// <param name="cikkszám"></param>
        private void Adatokkiírása(string cikkszám)
        {
            try
            {
                Adat_Raktár adat = (from a in AdatokRaktár
                                    where a.Cikkszám == cikkszám
                                    select a).FirstOrDefault();
                if (adat == null) return;

                Cikkszámok.Text = adat.Cikkszám;
                HonnanMennyiség.Text = Készlet(adat.Cikkszám, Honnan.Text.Trim()).ToString();
                HováMennyiség.Text = Készlet(adat.Cikkszám, Hova.Text.Trim()).ToString();
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
            Tábla.Columns["Bizonylat"].Width = 100;
            Tábla.Columns["Rögzítő"].Width = 100;
            Tábla.Columns["Dátum"].Width = 180;
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
                List<Adat_KészletNaplóRaktár> Adatok = KézNaplóRaktár.Lista_Adatok(Dátum.Value.Year);
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
                    Soradat["Dátum"] = rekord.Dátum;
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
        #endregion

        #region PdfAblak
        Ablak_PDF_Feltöltés Új_Ablak_PDF_Feltöltés;
        private void PDFAblak_Click(object sender, EventArgs e)
        {
            if (Bizonylatszám.Text.Trim() == "") throw new HibásBevittAdat("A bizonylatszám mező nem lehet üres.");
            string hely = $@"{Application.StartupPath}\Adatok\PDF".KönyvSzerk();
            Bizonylatszám.Text = MyF.Szöveg_Tisztítás(Bizonylatszám.Text);
            if (Új_Ablak_PDF_Feltöltés == null)
            {
                Új_Ablak_PDF_Feltöltés = new Ablak_PDF_Feltöltés(Bizonylatszám.Text, hely, false, Dátum.Value);
                Új_Ablak_PDF_Feltöltés.FormClosed += Új_Ablak_PDF_Feltöltés_FormClosed;
                Új_Ablak_PDF_Feltöltés.Show();
            }
            else
            {
                Új_Ablak_PDF_Feltöltés.Activate();
                Új_Ablak_PDF_Feltöltés.WindowState = FormWindowState.Maximized;
            }

        }

        private void Új_Ablak_PDF_Feltöltés_FormClosed(object sender, FormClosedEventArgs e)
        {
            Új_Ablak_PDF_Feltöltés = null;
        }

        #endregion

    }
}
