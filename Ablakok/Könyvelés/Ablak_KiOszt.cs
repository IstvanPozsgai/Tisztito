using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;
using MyE = Tisztito.Module_Excel;

namespace Tisztito.Ablakok
{
    public partial class Ablak_KiOszt : Form
    {
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

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        #region Alap
        public Ablak_KiOszt()
        {
            InitializeComponent();
            Start();
        }

        /// <summary>
        /// Betöltjük a comboboxba a listákat
        /// </summary>
        private void Start()
        {
            SzervezetFeltöltés();
            AdatokAnyag = KézAnyag.Lista_Adatok();
            CikkszámokFeltöltése();
            MegnevezésekFeltöltése();
            AdatokRaktár = KézRaktár.Lista_Adatok();
            AdatokJárandóság = KézJárandóság.Lista_Adatok();
            AdatokDolgozók = KézDolgozó.Lista_Adatok();
            GombLathatosagKezelo.Beallit(this);
        }

        private void Ablak_Raktár_Load(object sender, System.EventArgs e)
        {

        }
        #endregion


        #region Listák Feltöltése és események
        /// <summary>
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {

                AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();

                //Felhasználó jogosultságok lekérése
                List<int> ÜzemekId = Program.PostásJogosultságok.Select(j => j.SzervezetId).Distinct().ToList();
                CmbSzervezet.Items.Clear();
                CmbSzervezet.Items.Add("");
                for (int i = 0; i < ÜzemekId.Count; i++)
                {
                    Adat_Szervezet szervezet = AdatokSzervezet.FirstOrDefault(s => s.Id == ÜzemekId[i]);
                    if (szervezet != null) CmbSzervezet.Items.Add(szervezet.Szervezet);
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
        /// Szervezethez tartozó munkakörök feltöltése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSzervezet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbSzervezet.Text = CmbSzervezet.Items[CmbSzervezet.SelectedIndex].ToString();
            string szervezet = CmbSzervezet.Text.Trim();
            CmbMunkakör.Text = "";
            CmbMunkakör.Items.Clear();
            ChkDolgozók.Items.Clear();
            if (string.IsNullOrEmpty(szervezet)) return;

            try
            {
                // Munkakörök feltöltése
                List<string> munkakörök = KézDolgozó.Lista_Adatok()
                     .Where(d => d.Szervezet == szervezet && d.Státus == false)
                     .OrderBy(d => d.Munkakör)
                     .Select(d => d.Munkakör)
                     .Distinct()
                     .ToList();

                foreach (var munkakör in munkakörök)
                    CmbMunkakör.Items.Add(munkakör);

                int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
                RaktárKészlet.Text = készlet.ToString();
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
        /// Szervezethez és munkakörköz tartotó dolgozók feltöltése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbMunkakör_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbMunkakör.Text = CmbMunkakör.Items[CmbMunkakör.SelectedIndex].ToString();
            string szervezet = CmbSzervezet.Text.Trim();
            string munkakör = CmbMunkakör.Text.Trim();
            ChkDolgozók.Items.Clear();

            if (string.IsNullOrEmpty(szervezet) || string.IsNullOrEmpty(munkakör)) return;

            try
            {
                List<Adat_Dolgozó> dolgozók = AdatokDolgozók
                    .Where(d => d.Szervezet == szervezet && d.Munkakör == munkakör && d.Státus == false)
                    .OrderBy(d => d.Dolgozónév)
                    .ToList();

                foreach (Adat_Dolgozó dolgozó in dolgozók)
                    ChkDolgozók.Items.Add($"{dolgozó.Dolgozószám} - {dolgozó.Dolgozónév}");

                FrissítJárandóság();
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
        /// Cikkszámok feltöltése
        /// </summary>
        private void CikkszámokFeltöltése()
        {
            try
            {
                List<Adat_Anyag> anyagok = AdatokAnyag
                    .Where(a => a.Státus == false) // Csak aktívak
                    .OrderBy(a => a.Cikkszám)
                    .ToList();

                CmbCikkszámok.Items.Clear();
                CmbCikkszámok.Items.Add(""); // Üres elem az elejére

                foreach (var anyag in anyagok)
                    CmbCikkszámok.Items.Add(anyag.Cikkszám);
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

        private void CmbCikkszámok_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbCikkszámok.Text = CmbCikkszámok.Items[CmbCikkszámok.SelectedIndex].ToString();
            CmbMegnevezés.Text = "";
            RaktárKészlet.Text = "0";
            if (string.IsNullOrEmpty(CmbCikkszámok.Text.Trim())) return;


            // Megnevezés beállítása
            Adat_Anyag anyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == CmbCikkszámok.Text.Trim() && a.Státus == false);
            if (anyag != null) CmbMegnevezés.Text = anyag.Megnevezés;

            int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
            RaktárKészlet.Text = készlet.ToString();
            FrissítJárandóság();
        }

        /// <summary>
        /// Megnevezések feltöltése a kiválasztott cikkszámhoz
        /// </summary>
        private void MegnevezésekFeltöltése()
        {
            try
            {
                List<Adat_Anyag> anyagok = AdatokAnyag
                    .Where(a => a.Státus == false) // Csak aktívak
                    .OrderBy(a => a.Megnevezés)
                    .ToList();

                CmbMegnevezés.Items.Clear();
                CmbMegnevezés.Items.Add(""); // Üres elem az elejére

                foreach (Adat_Anyag anyag in anyagok)
                    CmbMegnevezés.Items.Add(anyag.Megnevezés);
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

        private void CmbMegnevezés_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbMegnevezés.Text = CmbMegnevezés.Items[CmbMegnevezés.SelectedIndex].ToString();
            if (string.IsNullOrEmpty(CmbMegnevezés.Text.Trim()))
            {
                CmbMegnevezés.Text = "";
                RaktárKészlet.Text = "";
                return;
            }

            // Megnevezés beállítása
            Adat_Anyag anyag = AdatokAnyag.FirstOrDefault(a => a.Megnevezés == CmbMegnevezés.Text.Trim() && a.Státus == false);
            if (anyag != null)
                CmbCikkszámok.Text = anyag.Cikkszám;
            else
                CmbCikkszámok.Text = "";

            int készlet = Készlet(CmbCikkszámok.Text.Trim(), CmbSzervezet.Text.Trim());
            RaktárKészlet.Text = készlet.ToString();
            FrissítJárandóság();
        }


        /// <summary>
        /// Szervezetnél fellelhető készlet lekérdezése
        /// </summary>
        /// <param name="cikkszám"></param>
        /// <param name="szervezet"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Kiírja a járandóságokat
        /// </summary>
        private void FrissítJárandóság()
        {
            string cikkszám = CmbCikkszámok.Text.Trim();
            string munkakör = CmbMunkakör.Text.Trim();

            if (string.IsNullOrEmpty(cikkszám) || string.IsNullOrEmpty(munkakör))
            {
                LblJárandóság.Text = "0";
                return;
            }

            Adat_Járandóság járandóság = AdatokJárandóság
                .FirstOrDefault(j => j.Cikkszám == cikkszám && j.Munkakör == munkakör);

            if (járandóság != null)
                LblJárandóság.Text = járandóság.Mennyiség.ToString();
            else
                LblJárandóság.Text = "0";
        }

        /// <summary>
        /// Minden dolgozó kiválasztása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GombokMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Minden dolgozó törlése a listából
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GombokSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkDolgozók.Items.Count; i++)
            {
                ChkDolgozók.SetItemChecked(i, false);
            }
        }


        /// <summary>
        /// Rögzítjük a kiadást és naplózzuk a raktárkészletet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rögzít_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CmbSzervezet.Text.Trim())) throw new HibásBevittAdat("Kérem válasszon szervezetet!");
                if (string.IsNullOrEmpty(CmbCikkszámok.Text.Trim())) throw new HibásBevittAdat("Kérem válasszon cikkszámot!");
                if (!int.TryParse(TxtMennyiség.Text.Trim(), out int mennyiség) || mennyiség <= 0) throw new HibásBevittAdat("A mennyiség csak pozitív egész szám lehet!");
                if (ChkDolgozók.CheckedItems.Count == 0) throw new HibásBevittAdat("Nincs kiválasztott dolgozó!");

                // Kiválasztott dolgozók
                List<string> dolgozószámok = new List<string>();
                foreach (string checkedItem in ChkDolgozók.CheckedItems)
                {
                    // Feltételezve: "Dolgozószám - Dolgozónév" formátum
                    string[] parts = checkedItem.ToString().Split('-');
                    if (parts.Length > 0)
                        dolgozószámok.Add(parts[0].Trim());
                }

                // Járandóság ellenőrzése
                if (!int.TryParse(LblJárandóság.Text.Trim(), out int járandóság)) járandóság = 0;
                if (mennyiség > járandóság) throw new HibásBevittAdat("A megadott mennyiség nagyobb, mint a járandóság! A kiadás nem lehetséges.");

                // Raktárkészlet ellenőrzése
                Adat_Raktár raktárAdat = AdatokRaktár.FirstOrDefault(a => a.Cikkszám == CmbCikkszámok.Text.Trim() && a.Szervezet == CmbSzervezet.Text.Trim());
                if (raktárAdat == null || raktárAdat.Mennyiség < mennyiség * dolgozószámok.Count) throw new HibásBevittAdat("Nincs elegendő készlet a raktárban!");


                // Naplózás és készlet csökkentése
                List<Adat_KészletNaplóRaktár> AdatokGy = new List<Adat_KészletNaplóRaktár>();
                foreach (string dolgozószám in dolgozószámok)
                {
                    Adat_KészletNaplóRaktár napló = new Adat_KészletNaplóRaktár
                    (
                        mennyiség,
                        CmbCikkszámok.Text.Trim(),
                        CmbSzervezet.Text.Trim(),
                        dolgozószám,
                        Program.PostásNév, // A postás neve, aki rögzíti
                        DateTime.Now,
                        false,
                        "",
                        new DateTime(1900, 1, 1) // Storno dátum
                    );
                    AdatokGy.Add(napló);
                }
                KézNaplóRaktár.Rögzítés(Dátum.Value.Year, AdatokGy);

                TáblázatKönyvelés();
                RaktárKészlet.Text = raktárAdat.Mennyiség.ToString();
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
        /// Űrítés eljárás, minden mező törlése
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MezőkÜrítése_Click(object sender, EventArgs e)
        {
            Űrítés();
        }

        /// <summary>
        ///   minden mező törlése
        /// </summary>
        private void Űrítés()
        {
            CmbSzervezet.Text = "";
            CmbMunkakör.Text = "";
            CmbCikkszámok.Text = "";
            CmbMegnevezés.Text = "";
            TxtMennyiség.Text = "";
            ChkDolgozók.Items.Clear();
            LblJárandóság.Text = "0";
            RaktárKészlet.Text = "0";
            Dátum.Value = DateTime.Now;
        }

        /// <summary>
        /// A feltételeknek megfelelően kilistázza a raktárakat készletét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frissít_Click(object sender, EventArgs e)
        {
            TáblázatKönyvelés();
        }

        /// <summary>
        /// A kiválaszotott tételeket, ha még nincs stornózva, akkor stornózza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Storno_Click(object sender, EventArgs e)
        {
            try
            {
                List<Adat_KészletNaplóRaktár> stornózhatóTételek = new List<Adat_KészletNaplóRaktár>();

                foreach (DataRow row in AdatTáblaALap.Rows)
                {
                    if (row["Storno Rögzítő"] != null && row["Storno Rögzítő"].ToString() == "Rögzítés")
                    {
                        string cikkszám = row["Cikkszám"]?.ToString() ?? "";
                        if (!int.TryParse(row["Mennyiség"].ToStrTrim(), out int mennyiség)) mennyiség = 0;
                        string szervezetHonnan = row["Szervezet Honnan"]?.ToString() ?? "";
                        string dolgozószám = row["Dolgozószám"]?.ToString() ?? "";
                        string rögzítő = row["Rögzítő"]?.ToString() ?? "";
                        DateTime dátum = DateTime.Today;
                        DateTime.TryParse(row["Dátum"]?.ToString(), out dátum);
                        bool storno = true;
                        string stornoRögzítő = Program.PostásNév;
                        DateTime stornoDátum = DateTime.Now;


                        Adat_KészletNaplóRaktár tétel = new Adat_KészletNaplóRaktár(
                            mennyiség,
                            cikkszám,
                            szervezetHonnan,
                            dolgozószám,
                            rögzítő,
                            dátum,
                            storno,
                            stornoRögzítő,
                            stornoDátum
                        );
                        stornózhatóTételek.Add(tétel);
                    }
                }
                KézNaplóRaktár.Módosítás(Dátum.Value.Year, stornózhatóTételek);
                TáblázatKönyvelés();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Táblázat Készlet
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
                AdatTáblaALap.Columns.Add("Szervezet Honnan");
                AdatTáblaALap.Columns.Add("Dolgozószám");
                AdatTáblaALap.Columns.Add("Dolgozónév");
                AdatTáblaALap.Columns.Add("Mennyiség");
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
            Tábla.Columns["Szervezet Honnan"].Width = 350;
            Tábla.Columns["Dolgozószám"].Width = 150;
            Tábla.Columns["Dolgozónév"].Width = 250;
            Tábla.Columns["Mennyiség"].Width = 100;
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
                List<Adat_KészletNaplóRaktár> Adatok = KézNaplóRaktár.Lista_Adatok(Dátum.Value.Year);
                //Csak azok a rekordok amik dolgozói rögzítések
                Adatok = (from a in Adatok
                          where !(a.Dolgozószám == null || a.Dolgozószám.Trim() == "")
                          select a).ToList();

                if (CmbSzervezet.Text.Trim() != "") Adatok = Adatok.Where(a => a.SzervezetHonnan == CmbSzervezet.Text.Trim()).ToList();
                if (CmbCikkszámok.Text.Trim() != "") Adatok = Adatok.Where(a => a.Cikkszám == CmbCikkszámok.Text.Trim()).ToList();

                foreach (Adat_KészletNaplóRaktár rekord in Adatok)
                {
                    DataRow Soradat = AdatTáblaALap.NewRow();

                    Soradat["Cikkszám"] = rekord.Cikkszám;
                    Adat_Anyag EgyAnyag = AdatokAnyag.FirstOrDefault(a => a.Cikkszám == rekord.Cikkszám);
                    if (EgyAnyag != null)
                        Soradat["Megnevezés"] = EgyAnyag.Megnevezés;
                    else
                        Soradat["Megnevezés"] = "";

                    Soradat["Szervezet Honnan"] = rekord.SzervezetHonnan;
                    Soradat["Dolgozószám"] = rekord.Dolgozószám;
                    Adat_Dolgozó dolgNév = AdatokDolgozók.FirstOrDefault(d => d.Dolgozószám == rekord.Dolgozószám && d.Szervezet == rekord.SzervezetHonnan);
                    if (dolgNév != null)
                        Soradat["Dolgozónév"] = dolgNév.Dolgozónév;
                    else
                        Soradat["Dolgozónév"] = "?";
                    Soradat["Mennyiség"] = rekord.Mennyiség;
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
                    FileName = $"Kiosztott_Anyagok_{Program.PostásNév}-{DateTime.Now:yyyyMMddHHmmss}",
                    Filter = "Excel |*.xlsx"
                };
                // bekérjük a fájl nevét és helyét ha mégse, akkor kilép
                if (SaveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    fájlexc = SaveFileDialog1.FileName;
                else
                    return;

                fájlexc = fájlexc.Substring(0, fájlexc.Length - 5);
                MyE.EXCELtábla(fájlexc, Tábla, false);
                MessageBox.Show("Elkészült az Excel tábla: " + fájlexc, "Tájékoztatás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyE.Megnyitás(fájlexc + ".xlsx");
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
