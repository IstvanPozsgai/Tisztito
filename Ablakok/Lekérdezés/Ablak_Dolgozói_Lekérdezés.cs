using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tisztito.Adatszerkezet;
using Tisztito.Kezelők;

namespace Tisztito.Ablakok.Lekérdezés
{
    public partial class Ablak_Dolgozói_Lekérdezés : Form
    {
        #region Alap
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

        public Ablak_Dolgozói_Lekérdezés()
        {
            InitializeComponent();
            Start();
        }

        private void Ablak_Dolgozói_Lekérdezés_Load(object sender, EventArgs e)
        {

        }
        private void Start()
        {
        }

        #endregion
    }
}
