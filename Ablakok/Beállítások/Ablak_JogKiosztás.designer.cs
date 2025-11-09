using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tisztito
{

    public partial class Ablak_JogKiosztás : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_JogKiosztás));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SzervezetBővítés = new System.Windows.Forms.Button();
            this.MindenJog = new System.Windows.Forms.Button();
            this.Másolás = new System.Windows.Forms.Button();
            this.Frissít = new System.Windows.Forms.Button();
            this.GombokMinden = new System.Windows.Forms.Button();
            this.GombokSemmi = new System.Windows.Forms.Button();
            this.SzervezetMinden = new System.Windows.Forms.Button();
            this.SzervezetSemmi = new System.Windows.Forms.Button();
            this.Rögzít = new System.Windows.Forms.Button();
            this.BtnSugó = new System.Windows.Forms.Button();
            this.JogosultságokTörlése = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbAblak = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstChkGombok = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LstChkSzervezet = new System.Windows.Forms.CheckedListBox();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.Felhasználók = new System.Windows.Forms.ComboBox();
            this.DolgozóNév = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbSzervezetek = new System.Windows.Forms.ComboBox();
            this.Másolt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTip1
            // 
            this.ToolTip1.IsBalloon = true;
            // 
            // SzervezetBővítés
            // 
            this.SzervezetBővítés.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SzervezetBővítés.BackgroundImage = global::Tisztito.Properties.Resources.Action_run;
            this.SzervezetBővítés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SzervezetBővítés.Location = new System.Drawing.Point(785, 3);
            this.SzervezetBővítés.Name = "SzervezetBővítés";
            this.SzervezetBővítés.Size = new System.Drawing.Size(45, 45);
            this.SzervezetBővítés.TabIndex = 229;
            this.ToolTip1.SetToolTip(this.SzervezetBővítés, "Másolt jogosultságok új szervezethez rendelése");
            this.SzervezetBővítés.UseVisualStyleBackColor = true;
            this.SzervezetBővítés.Click += new System.EventHandler(this.SzervezetBővítés_Click);
            // 
            // MindenJog
            // 
            this.MindenJog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MindenJog.BackgroundImage = global::Tisztito.Properties.Resources.Action_paste;
            this.MindenJog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MindenJog.Location = new System.Drawing.Point(449, 2);
            this.MindenJog.Name = "MindenJog";
            this.MindenJog.Size = new System.Drawing.Size(45, 45);
            this.MindenJog.TabIndex = 227;
            this.ToolTip1.SetToolTip(this.MindenJog, "Másolt jogosultságok Teljes rögzítése");
            this.MindenJog.UseVisualStyleBackColor = true;
            this.MindenJog.Click += new System.EventHandler(this.MindenJog_Click);
            // 
            // Másolás
            // 
            this.Másolás.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Másolás.BackgroundImage = global::Tisztito.Properties.Resources.Document_Copy_01;
            this.Másolás.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Másolás.Location = new System.Drawing.Point(9, 3);
            this.Másolás.Name = "Másolás";
            this.Másolás.Size = new System.Drawing.Size(45, 45);
            this.Másolás.TabIndex = 225;
            this.ToolTip1.SetToolTip(this.Másolás, "Jogosultságok másolása");
            this.Másolás.UseVisualStyleBackColor = true;
            this.Másolás.Click += new System.EventHandler(this.Másolás_Click);
            // 
            // Frissít
            // 
            this.Frissít.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Frissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Frissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Frissít.Location = new System.Drawing.Point(1340, 92);
            this.Frissít.Name = "Frissít";
            this.Frissít.Size = new System.Drawing.Size(45, 45);
            this.Frissít.TabIndex = 223;
            this.ToolTip1.SetToolTip(this.Frissít, "Frissíti a táblázatot");
            this.Frissít.UseVisualStyleBackColor = true;
            this.Frissít.Click += new System.EventHandler(this.Frissít_Click);
            // 
            // GombokMinden
            // 
            this.GombokMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GombokMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.GombokMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GombokMinden.Location = new System.Drawing.Point(449, 9);
            this.GombokMinden.Name = "GombokMinden";
            this.GombokMinden.Size = new System.Drawing.Size(45, 44);
            this.GombokMinden.TabIndex = 104;
            this.ToolTip1.SetToolTip(this.GombokMinden, "Minden kijelölése");
            this.GombokMinden.UseVisualStyleBackColor = true;
            this.GombokMinden.Click += new System.EventHandler(this.GombokMinden_Click);
            // 
            // GombokSemmi
            // 
            this.GombokSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GombokSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.GombokSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GombokSemmi.Location = new System.Drawing.Point(449, 59);
            this.GombokSemmi.Name = "GombokSemmi";
            this.GombokSemmi.Size = new System.Drawing.Size(45, 44);
            this.GombokSemmi.TabIndex = 103;
            this.ToolTip1.SetToolTip(this.GombokSemmi, "Minden kijelölést megszüntet");
            this.GombokSemmi.UseVisualStyleBackColor = true;
            this.GombokSemmi.Click += new System.EventHandler(this.GombokSemmi_Click);
            // 
            // SzervezetMinden
            // 
            this.SzervezetMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SzervezetMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.SzervezetMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SzervezetMinden.Location = new System.Drawing.Point(449, 9);
            this.SzervezetMinden.Name = "SzervezetMinden";
            this.SzervezetMinden.Size = new System.Drawing.Size(45, 44);
            this.SzervezetMinden.TabIndex = 104;
            this.ToolTip1.SetToolTip(this.SzervezetMinden, "Minden kijelölése");
            this.SzervezetMinden.UseVisualStyleBackColor = true;
            this.SzervezetMinden.Click += new System.EventHandler(this.SzervezetMinden_Click);
            // 
            // SzervezetSemmi
            // 
            this.SzervezetSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SzervezetSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.SzervezetSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SzervezetSemmi.Location = new System.Drawing.Point(449, 59);
            this.SzervezetSemmi.Name = "SzervezetSemmi";
            this.SzervezetSemmi.Size = new System.Drawing.Size(45, 44);
            this.SzervezetSemmi.TabIndex = 103;
            this.ToolTip1.SetToolTip(this.SzervezetSemmi, "Minden kijelölést megszüntet");
            this.SzervezetSemmi.UseVisualStyleBackColor = true;
            this.SzervezetSemmi.Click += new System.EventHandler(this.SzervezetSemmi_Click);
            // 
            // Rögzít
            // 
            this.Rögzít.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rögzít.Location = new System.Drawing.Point(1340, 352);
            this.Rögzít.Name = "Rögzít";
            this.Rögzít.Size = new System.Drawing.Size(45, 45);
            this.Rögzít.TabIndex = 97;
            this.ToolTip1.SetToolTip(this.Rögzít, "Rögzíti az adatokat");
            this.Rögzít.UseVisualStyleBackColor = true;
            this.Rögzít.Click += new System.EventHandler(this.Rögzít_Click);
            // 
            // BtnSugó
            // 
            this.BtnSugó.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSugó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.BtnSugó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSugó.Location = new System.Drawing.Point(1340, 12);
            this.BtnSugó.Name = "BtnSugó";
            this.BtnSugó.Size = new System.Drawing.Size(45, 45);
            this.BtnSugó.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.BtnSugó, "Online súgó megjelenítése");
            this.BtnSugó.UseVisualStyleBackColor = true;
            // 
            // JogosultságokTörlése
            // 
            this.JogosultságokTörlése.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JogosultságokTörlése.BackgroundImage = global::Tisztito.Properties.Resources.Orange_System_Icon_05;
            this.JogosultságokTörlése.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.JogosultságokTörlése.Location = new System.Drawing.Point(1340, 210);
            this.JogosultságokTörlése.Name = "JogosultságokTörlése";
            this.JogosultságokTörlése.Size = new System.Drawing.Size(45, 45);
            this.JogosultságokTörlése.TabIndex = 230;
            this.ToolTip1.SetToolTip(this.JogosultságokTörlése, "A kiválasztott személy jogosultságainak törlése");
            this.JogosultságokTörlése.UseVisualStyleBackColor = true;
            this.JogosultságokTörlése.Click += new System.EventHandler(this.JogosultságokTörlése_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(124, 20);
            this.Label1.TabIndex = 87;
            this.Label1.Text = "Felhasználónév:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 510F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 510F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 315F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1320, 315);
            this.tableLayoutPanel1.TabIndex = 99;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbAblak);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 60);
            this.groupBox3.TabIndex = 228;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ablak";
            // 
            // CmbAblak
            // 
            this.CmbAblak.FormattingEnabled = true;
            this.CmbAblak.Location = new System.Drawing.Point(6, 25);
            this.CmbAblak.Name = "CmbAblak";
            this.CmbAblak.Size = new System.Drawing.Size(284, 28);
            this.CmbAblak.TabIndex = 101;
            this.CmbAblak.SelectionChangeCommitted += new System.EventHandler(this.CmbAblak_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GombokMinden);
            this.groupBox1.Controls.Add(this.GombokSemmi);
            this.groupBox1.Controls.Add(this.LstChkGombok);
            this.groupBox1.Location = new System.Drawing.Point(303, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 309);
            this.groupBox1.TabIndex = 225;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gombok";
            // 
            // LstChkGombok
            // 
            this.LstChkGombok.FormattingEnabled = true;
            this.LstChkGombok.Location = new System.Drawing.Point(6, 25);
            this.LstChkGombok.Name = "LstChkGombok";
            this.LstChkGombok.Size = new System.Drawing.Size(426, 277);
            this.LstChkGombok.TabIndex = 102;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SzervezetMinden);
            this.groupBox2.Controls.Add(this.SzervezetSemmi);
            this.groupBox2.Controls.Add(this.LstChkSzervezet);
            this.groupBox2.Location = new System.Drawing.Point(813, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 309);
            this.groupBox2.TabIndex = 226;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Szervezet";
            // 
            // LstChkSzervezet
            // 
            this.LstChkSzervezet.FormattingEnabled = true;
            this.LstChkSzervezet.Location = new System.Drawing.Point(8, 25);
            this.LstChkSzervezet.Name = "LstChkSzervezet";
            this.LstChkSzervezet.Size = new System.Drawing.Size(435, 277);
            this.LstChkSzervezet.TabIndex = 98;
            // 
            // Tábla
            // 
            this.Tábla.AllowUserToAddRows = false;
            this.Tábla.AllowUserToDeleteRows = false;
            this.Tábla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tábla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tábla.FilterAndSortEnabled = true;
            this.Tábla.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.Location = new System.Drawing.Point(10, 410);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.ReadOnly = true;
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.Size = new System.Drawing.Size(1375, 179);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 221;
            // 
            // Felhasználók
            // 
            this.Felhasználók.FormattingEnabled = true;
            this.Felhasználók.Location = new System.Drawing.Point(142, 6);
            this.Felhasználók.Name = "Felhasználók";
            this.Felhasználók.Size = new System.Drawing.Size(223, 28);
            this.Felhasználók.TabIndex = 103;
            this.Felhasználók.SelectionChangeCommitted += new System.EventHandler(this.Felhasználók_SelectionChangeCommitted);
            // 
            // DolgozóNév
            // 
            this.DolgozóNév.AutoSize = true;
            this.DolgozóNév.Location = new System.Drawing.Point(371, 12);
            this.DolgozóNév.Name = "DolgozóNév";
            this.DolgozóNév.Size = new System.Drawing.Size(49, 20);
            this.DolgozóNév.TabIndex = 222;
            this.DolgozóNév.Text = "<< >>";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SzervezetBővítés);
            this.panel1.Controls.Add(this.CmbSzervezetek);
            this.panel1.Controls.Add(this.MindenJog);
            this.panel1.Controls.Add(this.Másolt);
            this.panel1.Controls.Add(this.Másolás);
            this.panel1.Location = new System.Drawing.Point(10, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 50);
            this.panel1.TabIndex = 224;
            // 
            // CmbSzervezetek
            // 
            this.CmbSzervezetek.FormattingEnabled = true;
            this.CmbSzervezetek.Location = new System.Drawing.Point(500, 12);
            this.CmbSzervezetek.Name = "CmbSzervezetek";
            this.CmbSzervezetek.Size = new System.Drawing.Size(284, 28);
            this.CmbSzervezetek.TabIndex = 228;
            this.CmbSzervezetek.SelectionChangeCommitted += new System.EventHandler(this.CmbSzervezetek_SelectionChangeCommitted);
            // 
            // Másolt
            // 
            this.Másolt.AutoSize = true;
            this.Másolt.Location = new System.Drawing.Point(60, 15);
            this.Másolt.Name = "Másolt";
            this.Másolt.Size = new System.Drawing.Size(49, 20);
            this.Másolt.TabIndex = 226;
            this.Másolt.Text = "<< >>";
            // 
            // Ablak_JogKiosztás
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1397, 600);
            this.Controls.Add(this.JogosultságokTörlése);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Frissít);
            this.Controls.Add(this.DolgozóNév);
            this.Controls.Add(this.Felhasználók);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Rögzít);
            this.Controls.Add(this.BtnSugó);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_JogKiosztás";
            this.Text = "Felhasználók jogkiosztása";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_JogKiosztás_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal ToolTip ToolTip1;
        internal Button BtnSugó;
        internal Button Rögzít;
        internal Label Label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Zuby.ADGV.AdvancedDataGridView Tábla;
        private ComboBox Felhasználók;
        internal Label DolgozóNév;
        internal Button Frissít;
        internal Button GombokSemmi;
        internal Button GombokMinden;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        internal Button SzervezetMinden;
        internal Button SzervezetSemmi;
        private CheckedListBox LstChkGombok;
        private ComboBox CmbAblak;
        private CheckedListBox LstChkSzervezet;
        private GroupBox groupBox3;
        private Panel panel1;
        internal Button Másolás;
        internal Label Másolt;
        internal Button SzervezetBővítés;
        private ComboBox CmbSzervezetek;
        internal Button MindenJog;
        internal Button JogosultságokTörlése;
    }
}