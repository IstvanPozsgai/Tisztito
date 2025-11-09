using Bejelentkezés.Adatszerkezet;
using Bejelentkezés.Kezelők;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;

namespace Tisztito
{

    public partial class Ablak_JogKiosztás : Form
    {
        readonly Kezelők_Oldalok KézOldal = new Kezelők_Oldalok();
        readonly Kezelők_Gombok KézGombok = new Kezelők_Gombok();
        readonly Kezelő_Szervezet KézSzervezet = new Kezelő_Szervezet();
        readonly Kezelők_Users KézUsers = new Kezelők_Users();
        readonly Kezelő_Dolgozó KézDolgozó = new Kezelő_Dolgozó();
        readonly Kezelők_Jogosultságok KézJogosultságok = new Kezelők_Jogosultságok();

        List<Adat_Users> AdatokUsers = new List<Adat_Users>();
        List<Adat_Oldalak> AdatokOldal = new List<Adat_Oldalak>();
        List<Adat_Gombok> AdatokGombok = new List<Adat_Gombok>();
        List<Adat_Szervezet> AdatokSzervezet = new List<Adat_Szervezet>();
        List<Adat_Dolgozó> AdatokDolgozó = new List<Adat_Dolgozó>();
        List<Adat_Jogosultságok> AdatokJogosultságok = new List<Adat_Jogosultságok>();

#pragma warning disable IDE0044
        DataTable AdatTáblaALap = new DataTable();
#pragma warning restore IDE0044

        //Kiválasztott felhasználó id-je
        int FelhasználóId = -1;
        string AblakForm = "";
        int AblakID = -1;

        public Ablak_JogKiosztás()
        {
            InitializeComponent();
            Start();
        }

        private void Ablak_JogKiosztás_Load(object sender, System.EventArgs e)
        {

        }

        private void Start()
        {
            AdatokOldal = KézOldal.Lista_Adatok().Where(a => a.Törölt == false).ToList();
            AdatokGombok = KézGombok.Lista_Adatok().Where(a => a.Törölt == false).ToList();
            AdatokSzervezet = KézSzervezet.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Szervezet).ToList();
            AdatokUsers = KézUsers.Lista_Adatok().Where(a => a.Törölt == false).ToList();
            AdatokDolgozó = KézDolgozó.Lista_Adatok().Where(a => a.Státus == false).OrderBy(a => a.Dolgozónév).ToList();
            AdatokJogosultságok = KézJogosultságok.Lista_Adatok();
            OldalFeltöltés();
            FelhasználóFeltöltés();
            GombLathatosagKezelo.Beallit(this);
            CMBSzervezetFeltöltés();
        }


        #region Mezők feltöltése

        /// <summary>
        /// Oldalak feltöltése a comboxba.
        /// </summary>
        private void OldalFeltöltés()
        {
            try
            {
                foreach (Adat_Oldalak Elem in AdatokOldal)
                    CmbAblak.Items.Add(Elem.MenuFelirat);
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
        /// Ablak gombok feltöltése a comboxba.
        /// </summary>
        private void GombokFeltöltése()
        {
            if (CmbAblak.Text.Trim() == "") return;
            LstChkGombok.Items.Clear();
            Adat_Oldalak oldal = (from a in AdatokOldal
                                  where a.Törölt == false
                                  && a.MenuFelirat == CmbAblak.Text.Trim()
                                  orderby a.MenuFelirat
                                  select a).FirstOrDefault();
            if (oldal == null) return;
            List<Adat_Gombok> gombok = (from a in AdatokGombok
                                        where a.Törölt == false
                                        && a.FromName == oldal.FromName
                                        select a).ToList();
            if (gombok == null) return;
            for (int i = 0; i < gombok.Count; i++)
            {
                Adat_Gombok item = gombok[i];
                string felirat = $"{item.GombName} - {item.GombFelirat}";
                LstChkGombok.Items.Add(felirat);

                // Ha jogosult, akkor legyen bejelölve
                Adat_Jogosultságok EgyJog = (from a in AdatokJogosultságok
                                             where a.UserId == FelhasználóId
                                             && a.OldalId == oldal.OldalId
                                             && a.GombokId == gombok[i].GombokId
                                             select a).FirstOrDefault();
                if (EgyJog != null) LstChkGombok.SetItemChecked(i, !EgyJog.Törölt);

            }
        }


        /// <summary>
        /// Feltöltjük, hogy melyik szervezetnek engedjük meg a módosítást
        /// </summary>
        private void SzervezetFeltöltés()
        {
            try
            {
                LstChkSzervezet.Items.Clear();
                for (int i = 0; i < AdatokSzervezet.Count; i++)
                {
                    LstChkSzervezet.Items.Add(AdatokSzervezet[i].Szervezet);
                    Adat_Jogosultságok EgyJog = (from a in AdatokJogosultságok
                                                 where a.UserId == FelhasználóId
                                                 && a.OldalId == AblakID
                                                 && a.SzervezetId == AdatokSzervezet[i].Id
                                                 select a).FirstOrDefault();
                    if (EgyJog != null) LstChkSzervezet.SetItemChecked(i, true);
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


        private void CMBSzervezetFeltöltés()
        {
            try
            {
                CmbSzervezetek.Items.Clear();
                CmbSzervezetek.Items.Add("");
                for (int i = 0; i < AdatokSzervezet.Count; i++)
                {
                    CmbSzervezetek.Items.Add(AdatokSzervezet[i].Szervezet);
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
        /// Feltöltjük a felhasználókat a comboxba.
        /// </summary>
        private void FelhasználóFeltöltés()
        {
            try
            {
                Felhasználók.Items.Clear();
                Felhasználók.Items.Add("");
                foreach (Adat_Users item in AdatokUsers)
                {
                    Felhasználók.Items.Add(item.UserName);
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


        #region Mezők kijelölése és választása
        private void CmbAblak_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CmbAblak.Text = CmbAblak.Items[CmbAblak.SelectedIndex].ToString();
                Adat_Oldalak Ablak = AdatokOldal.FirstOrDefault(a => a.MenuFelirat == CmbAblak.Text);
                AblakForm = Ablak.FromName;
                AblakID = Ablak.OldalId;
                GombokFeltöltése();
                SzervezetFeltöltés();
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


        private void Felhasználók_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Felhasználók.Text = Felhasználók.Items[Felhasználók.SelectedIndex].ToString();
                Adat_Users Felhasználó = AdatokUsers.FirstOrDefault(a => a.UserName == Felhasználók.Text);
                if (Felhasználó == null)
                {
                    DolgozóNév.Text = $"<< - >>";
                    FelhasználóId = -1;
                }

                else
                {
                    FelhasználóId = Felhasználó.UserId;
                    Adat_Dolgozó dolgozó = AdatokDolgozó.FirstOrDefault(a => a.Dolgozószám == Felhasználó.Dolgozószám);
                    if (dolgozó != null)
                        DolgozóNév.Text = $"<<{dolgozó.Dolgozószám} - {dolgozó.Dolgozónév}>>";
                    else
                        DolgozóNév.Text = $"<<{Felhasználó.Dolgozószám} - >>";
                }
                MezőkÜrítése();
                TáblázatListázás();
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

        private void MezőkÜrítése()
        {
            CmbAblak.Text = "";
            LstChkGombok.Items.Clear();
            LstChkSzervezet.Items.Clear();
        }

        private void CmbSzervezetek_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbSzervezetek.Text = CmbSzervezetek.Items[CmbSzervezetek.SelectedIndex].ToString();
        }
        #endregion


        #region Gombok 
        /// <summary>
        /// Kilistázzuk a kiválaszo felhasználóhoz tartozó jogosultságokat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frissít_Click(object sender, EventArgs e)
        {
            TáblázatListázás();
        }


        /// <summary>
        /// Rögzítjük a kiválasztott felhasználóhoz az ablak, gombokat és szervezeteket jogosultásgát.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rögzít_Click(object sender, EventArgs e)
        {
            try
            {
                if (Felhasználók.Text.Trim() == "") throw new HibásBevittAdat("Kérem adja meg a Felhasználót!");
                if (CmbAblak.Text.Trim() == "") throw new HibásBevittAdat("Kérem válasszon egy Ablakot!");
                if (LstChkGombok.CheckedItems.Count == 0 && LstChkSzervezet.CheckedItems.Count == 0)
                {
                    Adat_Jogosultságok adat = new Adat_Jogosultságok
                          (
                              FelhasználóId,
                              AblakID,
                              -1,
                              -1,
                              false
                          );
                    KézJogosultságok.Törlés(adat);
                }
                else
                {
                    if (LstChkGombok.CheckedItems.Count == 0) throw new HibásBevittAdat("Kérem válasszon legalább egy Gombot gombot!");
                    if (LstChkSzervezet.CheckedItems.Count == 0) throw new HibásBevittAdat("Kérem válasszon legalább egy Szervezetet!");
                    List<Adat_Jogosultságok> Adatok = new List<Adat_Jogosultságok>();


                    foreach (string Gomb in LstChkGombok.CheckedItems)
                    {
                        string[] gomb = Gomb.Split('-');
                        if (gomb.Length < 2) continue;
                        int GombokID = AdatokGombok.FirstOrDefault(a => a.GombName == gomb[0].Trim() && a.FromName == AblakForm)?.GombokId ?? -1;
                        foreach (string Szervezet in LstChkSzervezet.CheckedItems)
                        {
                            int SzervezetId = AdatokSzervezet.FirstOrDefault(a => a.Szervezet == Szervezet)?.Id ?? -1;
                            Adat_Jogosultságok adat = new Adat_Jogosultságok
                            (
                                FelhasználóId,
                                AblakID,
                                GombokID,
                                SzervezetId,
                                false
                            );
                            Adatok.Add(adat);
                        }
                    }
                    if (Adatok.Count > 0) KézJogosultságok.Rögzítés(Adatok);
                }
                TáblázatListázás();
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


        private void GombokMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LstChkGombok.Items.Count; i++)
                LstChkGombok.SetItemChecked(i, true);

        }

        private void GombokSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LstChkGombok.Items.Count; i++)
                LstChkGombok.SetItemChecked(i, false);
        }

        private void SzervezetMinden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LstChkSzervezet.Items.Count; i++)
                LstChkSzervezet.SetItemChecked(i, true);
        }

        private void SzervezetSemmi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LstChkSzervezet.Items.Count; i++)
                LstChkSzervezet.SetItemChecked(i, false);
        }

        private void Másolás_Click(object sender, EventArgs e)
        {
            try
            {
                if (Felhasználók.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva másolandó felhasználó");
                Másolt.Text = Felhasználók.Text.Trim();
            }
            catch (HibásBevittAdat ex)
            {
                MessageBox.Show(ex.Message, "Információ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Másolt.Text = "<< >>";
            }
            catch (Exception ex)
            {
                HibaNapló.Log(ex.Message, this.ToString(), ex.StackTrace, ex.Source, ex.HResult);
                MessageBox.Show(ex.Message + "\n\n a hiba naplózásra került.", "A program hibára futott", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MindenJog_Click(object sender, EventArgs e)
        {
            try
            {

                if (Másolt.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva másolandó felhasználó.");
                if (Másolt.Text.Trim() == Felhasználók.Text.Trim()) throw new HibásBevittAdat("Most komolyan saját magára akarod másolni?");
                CsoportosJogok(false);
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

        private void SzervezetBővítés_Click(object sender, EventArgs e)
        {
            try
            {
                if (Másolt.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva másolandó felhasználó.");
                if (CmbSzervezetek.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva másolandó szervezet.");
                CsoportosJogok(true);

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

        private void CsoportosJogok(bool szűrt)
        {
            try
            {
                Adat_Users MásoltFelhasználó = (from a in AdatokUsers
                                                where a.UserName.Trim() == Másolt.Text.Trim()
                                                select a).FirstOrDefault() ?? throw new HibásBevittAdat("Nincs jogosultsági adata kiválasztott felhasználónak.");

                List<Adat_Jogosultságok> MásoltJogok = (from a in AdatokJogosultságok
                                                        where a.UserId == MásoltFelhasználó.UserId
                                                        && a.Törölt == false
                                                        select a).ToList();

                Adat_Szervezet EgySzervezet = null;
                if (szűrt)
                {
                    MásoltJogok = MásoltJogok.GroupBy(x => x.GombokId)
                                                            .Select(g => g.First())
                                                            .ToList();
                    EgySzervezet = (from a in AdatokSzervezet
                                    where a.Szervezet.Trim() == CmbSzervezetek.Text.Trim()
                                    select a).FirstOrDefault() ?? throw new HibásBevittAdat("Nincs ilyen szervezet.");
                }

                Adat_Users Kikapja = (from a in AdatokUsers
                                      where a.UserName.Trim() == Felhasználók.Text.Trim()
                                      select a).FirstOrDefault() ?? throw new HibásBevittAdat("Nincs kinek másolni.");

                List<Adat_Jogosultságok> Adatok = new List<Adat_Jogosultságok>();
                foreach (Adat_Jogosultságok Elem in MásoltJogok)
                {
                    if (szűrt)
                    {
                        Adat_Jogosultságok ADAT = new Adat_Jogosultságok(Kikapja.UserId, Elem.OldalId, Elem.GombokId, EgySzervezet.Id, false);
                        Adatok.Add(ADAT);
                    }
                    else
                    {
                        Adat_Jogosultságok ADAT = new Adat_Jogosultságok(Kikapja.UserId, Elem.OldalId, Elem.GombokId, Elem.SzervezetId, false);
                        Adatok.Add(ADAT);
                    }
                }
                if (Adatok.Count > 0) KézJogosultságok.Rögzítés(Adatok);
                TáblázatListázás();
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

        private void JogosultságokTörlése_Click(object sender, EventArgs e)
        {
            try
            {
                if (Felhasználók.Text.Trim() == "") throw new HibásBevittAdat("Nincs kiválasztva felhasználó.");
                Adat_Users Felhasználó = (from a in AdatokUsers
                                          where a.UserName.Trim() == Felhasználók.Text.Trim()
                                          select a).FirstOrDefault() ?? throw new HibásBevittAdat("Nincs jogosultsági adata kiválasztott felhasználónak.");
                KézJogosultságok.MindenTörlés(Felhasználó.UserId);
                TáblázatListázás();
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


        #region Táblázat
        private void TáblázatListázás()
        {
            try
            {
                AdatokJogosultságok = KézJogosultságok.Lista_Adatok();
                Tábla.Visible = false;
                Tábla.CleanFilterAndSort();
                AlapTáblaFejléc();
                AlapTáblaTartalom();
                Tábla.DataSource = AdatTáblaALap;
                AlapTáblaOszlopSzélesség();
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

        private void AlapTáblaFejléc()
        {
            try
            {
                AdatTáblaALap.Columns.Clear();
                AdatTáblaALap.Columns.Add("Felhasználó név");
                AdatTáblaALap.Columns.Add("Ablak név");
                AdatTáblaALap.Columns.Add("Gomb név");
                AdatTáblaALap.Columns.Add("Szervezet");
                AdatTáblaALap.Columns.Add("Törölt");
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

        private void AlapTáblaTartalom()
        {
            try
            {
                AdatTáblaALap.Clear();
                AdatokJogosultságok = KézJogosultságok.Lista_Adatok();
                //ha nincs kiválasztva akkor az összes adatot írjuk ki
                List<Adat_Jogosultságok> Adatok = AdatokJogosultságok;
                if (Felhasználók.Text.Trim() != "")
                {
                    //csak a kiválasztott felhasználó adatait írjuk ki
                    Adat_Users Egy = (from a in AdatokUsers
                                      where a.UserName == Felhasználók.Text.Trim()
                                      select a).FirstOrDefault();
                    Adatok = AdatokJogosultságok.Where(a => a.UserId == Egy.UserId).ToList();
                }
                foreach (Adat_Jogosultságok rekord in Adatok)
                {
                    DataRow Soradat = AdatTáblaALap.NewRow();
                    Soradat["Felhasználó név"] = AdatokUsers.FirstOrDefault(a => a.UserId == rekord.UserId)?.UserName ?? "<<Nincs felhasználó>>";
                    Soradat["Ablak név"] = AdatokOldal.FirstOrDefault(a => a.OldalId == rekord.OldalId)?.MenuFelirat ?? "<<Nincs Ablak>>";
                    string gombnév = "<<Nincs Gomb>>";
                    Adat_Gombok EgyGomb = AdatokGombok.FirstOrDefault(a => a.GombokId == rekord.GombokId);
                    if (EgyGomb != null)
                        gombnév = $"{EgyGomb.GombName} - {EgyGomb.GombFelirat}";
                    Soradat["Gomb név"] = gombnév;
                    string szervezet = "<<Nincs Szervezet>>";
                    szervezet = AdatokSzervezet.FirstOrDefault(a => a.Id == rekord.SzervezetId)?.Szervezet ?? "<<Nincs Szervezet>>";
                    Soradat["Szervezet"] = szervezet;
                    Soradat["Törölt"] = rekord.Törölt ? "Igen" : "Nem";
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

        private void AlapTáblaOszlopSzélesség()
        {
            Tábla.Columns["Felhasználó név"].Width = 180;
            Tábla.Columns["Ablak név"].Width = 250;
            Tábla.Columns["Gomb név"].Width = 500;
            Tábla.Columns["Szervezet"].Width = 500;
            Tábla.Columns["Törölt"].Width = 110;
        }



        #endregion


    }
}