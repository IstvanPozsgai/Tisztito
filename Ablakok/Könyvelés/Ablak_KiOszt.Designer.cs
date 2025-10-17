namespace Tisztito.Ablakok
{
    partial class Ablak_KiOszt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_KiOszt));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnExcel = new System.Windows.Forms.Button();
            this.GombokMinden = new System.Windows.Forms.Button();
            this.GombokSemmi = new System.Windows.Forms.Button();
            this.Frissít = new System.Windows.Forms.Button();
            this.MezőkÜrítése = new System.Windows.Forms.Button();
            this.Storno = new System.Windows.Forms.Button();
            this.Rögzít = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CmbDolgozó = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbMunkakör = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSzervezet = new System.Windows.Forms.ComboBox();
            this.ChkDolgozók = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Gyakoriság = new System.Windows.Forms.Label();
            this.LblJárandóság = new System.Windows.Forms.Label();
            this.CmbMegnevezés = new System.Windows.Forms.ComboBox();
            this.CmbCikkszámok = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Dátum = new System.Windows.Forms.DateTimePicker();
            this.TxtMennyiség = new System.Windows.Forms.TextBox();
            this.RaktárKészlet = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(3, 103);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 248;
            this.toolTip1.SetToolTip(this.BtnExcel, "Excel kimenetet készít a táblázat adatai alapján");
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // GombokMinden
            // 
            this.GombokMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GombokMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.GombokMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GombokMinden.Location = new System.Drawing.Point(3, 38);
            this.GombokMinden.Name = "GombokMinden";
            this.GombokMinden.Size = new System.Drawing.Size(45, 44);
            this.GombokMinden.TabIndex = 106;
            this.toolTip1.SetToolTip(this.GombokMinden, "Minden kijeölése");
            this.GombokMinden.UseVisualStyleBackColor = true;
            this.GombokMinden.Click += new System.EventHandler(this.GombokMinden_Click);
            // 
            // GombokSemmi
            // 
            this.GombokSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GombokSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.GombokSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GombokSemmi.Location = new System.Drawing.Point(57, 38);
            this.GombokSemmi.Name = "GombokSemmi";
            this.GombokSemmi.Size = new System.Drawing.Size(45, 44);
            this.GombokSemmi.TabIndex = 105;
            this.toolTip1.SetToolTip(this.GombokSemmi, "Minden kijelölést megszüntet");
            this.GombokSemmi.UseVisualStyleBackColor = true;
            this.GombokSemmi.Click += new System.EventHandler(this.GombokSemmi_Click);
            // 
            // Frissít
            // 
            this.Frissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Frissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Frissít.Location = new System.Drawing.Point(3, 3);
            this.Frissít.Name = "Frissít";
            this.Frissít.Size = new System.Drawing.Size(44, 44);
            this.Frissít.TabIndex = 233;
            this.toolTip1.SetToolTip(this.Frissít, "Frissítés");
            this.Frissít.UseVisualStyleBackColor = true;
            this.Frissít.Click += new System.EventHandler(this.Frissít_Click);
            // 
            // MezőkÜrítése
            // 
            this.MezőkÜrítése.BackgroundImage = global::Tisztito.Properties.Resources.New_gyűjtemény;
            this.MezőkÜrítése.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MezőkÜrítése.Location = new System.Drawing.Point(53, 3);
            this.MezőkÜrítése.Name = "MezőkÜrítése";
            this.MezőkÜrítése.Size = new System.Drawing.Size(44, 44);
            this.MezőkÜrítése.TabIndex = 232;
            this.toolTip1.SetToolTip(this.MezőkÜrítése, "Új adat");
            this.MezőkÜrítése.UseVisualStyleBackColor = true;
            this.MezőkÜrítése.Click += new System.EventHandler(this.MezőkÜrítése_Click);
            // 
            // Storno
            // 
            this.Storno.BackgroundImage = global::Tisztito.Properties.Resources.Orange_System_Icon_05;
            this.Storno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Storno.Location = new System.Drawing.Point(3, 203);
            this.Storno.Name = "Storno";
            this.Storno.Size = new System.Drawing.Size(44, 44);
            this.Storno.TabIndex = 247;
            this.toolTip1.SetToolTip(this.Storno, "Stornózza a könyvelést");
            this.Storno.UseVisualStyleBackColor = true;
            this.Storno.Click += new System.EventHandler(this.Storno_Click);
            // 
            // Rögzít
            // 
            this.Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rögzít.Location = new System.Drawing.Point(103, 203);
            this.Rögzít.Name = "Rögzít";
            this.Rögzít.Size = new System.Drawing.Size(44, 44);
            this.Rögzít.TabIndex = 229;
            this.toolTip1.SetToolTip(this.Rögzít, "Rögzítés");
            this.Rögzít.UseVisualStyleBackColor = true;
            this.Rögzít.Click += new System.EventHandler(this.Rögzít_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.20202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.79798F));
            this.tableLayoutPanel1.Controls.Add(this.CmbDolgozó, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CmbMunkakör, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CmbSzervezet, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChkDolgozók, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 304);
            this.tableLayoutPanel1.TabIndex = 243;
            // 
            // CmbDolgozó
            // 
            this.CmbDolgozó.FormattingEnabled = true;
            this.CmbDolgozó.Location = new System.Drawing.Point(123, 266);
            this.CmbDolgozó.Name = "CmbDolgozó";
            this.CmbDolgozó.Size = new System.Drawing.Size(463, 28);
            this.CmbDolgozó.TabIndex = 251;
            this.CmbDolgozó.SelectionChangeCommitted += new System.EventHandler(this.CmbDolgozó_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 250;
            this.label11.Text = "Dolgozó:";
            // 
            // CmbMunkakör
            // 
            this.CmbMunkakör.FormattingEnabled = true;
            this.CmbMunkakör.Location = new System.Drawing.Point(123, 38);
            this.CmbMunkakör.Name = "CmbMunkakör";
            this.CmbMunkakör.Size = new System.Drawing.Size(463, 28);
            this.CmbMunkakör.TabIndex = 248;
            this.CmbMunkakör.SelectionChangeCommitted += new System.EventHandler(this.CmbMunkakör_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 244;
            this.label1.Text = "Szervezet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 245;
            this.label2.Text = "Munkakör:";
            // 
            // CmbSzervezet
            // 
            this.CmbSzervezet.FormattingEnabled = true;
            this.CmbSzervezet.Location = new System.Drawing.Point(123, 3);
            this.CmbSzervezet.Name = "CmbSzervezet";
            this.CmbSzervezet.Size = new System.Drawing.Size(463, 28);
            this.CmbSzervezet.TabIndex = 247;
            this.CmbSzervezet.SelectionChangeCommitted += new System.EventHandler(this.CmbSzervezet_SelectionChangeCommitted);
            // 
            // ChkDolgozók
            // 
            this.ChkDolgozók.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkDolgozók.FormattingEnabled = true;
            this.ChkDolgozók.Location = new System.Drawing.Point(123, 73);
            this.ChkDolgozók.Name = "ChkDolgozók";
            this.ChkDolgozók.Size = new System.Drawing.Size(463, 172);
            this.ChkDolgozók.TabIndex = 249;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GombokMinden);
            this.panel1.Controls.Add(this.GombokSemmi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 84);
            this.panel1.TabIndex = 244;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 246;
            this.label3.Text = "Dolgozók";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Gyakoriság, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.LblJárandóság, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.CmbMegnevezés, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.CmbCikkszámok, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.Dátum, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.TxtMennyiség, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.RaktárKészlet, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(612, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(537, 264);
            this.tableLayoutPanel3.TabIndex = 244;
            // 
            // Gyakoriság
            // 
            this.Gyakoriság.AutoSize = true;
            this.Gyakoriság.Location = new System.Drawing.Point(240, 105);
            this.Gyakoriság.Name = "Gyakoriság";
            this.Gyakoriság.Size = new System.Drawing.Size(49, 20);
            this.Gyakoriság.TabIndex = 258;
            this.Gyakoriság.Text = "<< >>";
            // 
            // LblJárandóság
            // 
            this.LblJárandóság.AutoSize = true;
            this.LblJárandóság.Location = new System.Drawing.Point(240, 70);
            this.LblJárandóság.Name = "LblJárandóság";
            this.LblJárandóság.Size = new System.Drawing.Size(49, 20);
            this.LblJárandóság.TabIndex = 250;
            this.LblJárandóság.Text = "<< >>";
            // 
            // CmbMegnevezés
            // 
            this.CmbMegnevezés.FormattingEnabled = true;
            this.CmbMegnevezés.Location = new System.Drawing.Point(240, 38);
            this.CmbMegnevezés.Name = "CmbMegnevezés";
            this.CmbMegnevezés.Size = new System.Drawing.Size(294, 28);
            this.CmbMegnevezés.TabIndex = 249;
            this.CmbMegnevezés.SelectionChangeCommitted += new System.EventHandler(this.CmbMegnevezés_SelectionChangeCommitted);
            // 
            // CmbCikkszámok
            // 
            this.CmbCikkszámok.FormattingEnabled = true;
            this.CmbCikkszámok.Location = new System.Drawing.Point(240, 3);
            this.CmbCikkszámok.Name = "CmbCikkszámok";
            this.CmbCikkszámok.Size = new System.Drawing.Size(219, 28);
            this.CmbCikkszámok.TabIndex = 248;
            this.CmbCikkszámok.SelectionChangeCommitted += new System.EventHandler(this.CmbCikkszámok_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 246;
            this.label5.Text = "Megnevezés:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 245;
            this.label4.Text = "Cikkszám:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 247;
            this.label6.Text = "Járandóság:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 255;
            this.label9.Text = "Dátum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 253;
            this.label8.Text = "Mennyiség:";
            // 
            // Dátum
            // 
            this.Dátum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dátum.Location = new System.Drawing.Point(240, 213);
            this.Dátum.Name = "Dátum";
            this.Dátum.Size = new System.Drawing.Size(128, 26);
            this.Dátum.TabIndex = 256;
            // 
            // TxtMennyiség
            // 
            this.TxtMennyiség.Location = new System.Drawing.Point(240, 178);
            this.TxtMennyiség.Name = "TxtMennyiség";
            this.TxtMennyiség.Size = new System.Drawing.Size(100, 26);
            this.TxtMennyiség.TabIndex = 252;
            // 
            // RaktárKészlet
            // 
            this.RaktárKészlet.AutoSize = true;
            this.RaktárKészlet.Location = new System.Drawing.Point(240, 140);
            this.RaktárKészlet.Name = "RaktárKészlet";
            this.RaktárKészlet.Size = new System.Drawing.Size(49, 20);
            this.RaktárKészlet.TabIndex = 254;
            this.RaktárKészlet.Text = "<< >>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 251;
            this.label7.Text = "Raktárkészlet:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 20);
            this.label10.TabIndex = 257;
            this.label10.Text = "Esedékesség gyakorisága (hó):";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.Frissít, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.MezőkÜrítése, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Storno, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.BtnExcel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Rögzít, 2, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1151, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 264);
            this.tableLayoutPanel2.TabIndex = 245;
            // 
            // Tábla
            // 
            this.Tábla.AllowUserToAddRows = false;
            this.Tábla.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Tábla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Tábla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Tábla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Tábla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tábla.EnableHeadersVisualStyles = false;
            this.Tábla.FilterAndSortEnabled = true;
            this.Tábla.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.Location = new System.Drawing.Point(12, 322);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersWidth = 25;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tábla.Size = new System.Drawing.Size(1289, 203);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 246;
            // 
            // Ablak_KiOszt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1315, 537);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_KiOszt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dolgozói kiosztás";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Raktár_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button Rögzít;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMunkakör;
        private System.Windows.Forms.ComboBox CmbSzervezet;
        private System.Windows.Forms.CheckedListBox ChkDolgozók;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button GombokMinden;
        internal System.Windows.Forms.Button GombokSemmi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblJárandóság;
        private System.Windows.Forms.ComboBox CmbMegnevezés;
        private System.Windows.Forms.ComboBox CmbCikkszámok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMennyiség;
        private System.Windows.Forms.Label RaktárKészlet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker Dátum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.Button Frissít;
        internal System.Windows.Forms.Button MezőkÜrítése;
        internal System.Windows.Forms.Button Storno;
        internal System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Gyakoriság;
        private System.Windows.Forms.ComboBox CmbDolgozó;
        private System.Windows.Forms.Label label11;
    }
}