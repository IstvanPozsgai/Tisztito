namespace Tisztito.Ablakok
{
    partial class Ablak_Raktár
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Raktár));
            this.label1 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.HonnanMennyiség = new System.Windows.Forms.Label();
            this.HováMennyiség = new System.Windows.Forms.Label();
            this.Cikkszámok = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Mennyiség = new System.Windows.Forms.TextBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.Bizonylatszám = new System.Windows.Forms.TextBox();
            this.Hova = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.Honnan = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Mozgás = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Dátum = new System.Windows.Forms.DateTimePicker();
            this.Megnevezések = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SAPbeolvasás = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.Frissít = new System.Windows.Forms.Button();
            this.MezőkÜrítése = new System.Windows.Forms.Button();
            this.PDFAblak = new System.Windows.Forms.Button();
            this.Rögzít = new System.Windows.Forms.Button();
            this.Storno = new System.Windows.Forms.Button();
            this.Pdf_Készítés = new System.Windows.Forms.Button();
            this.PDFNéz = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 237;
            this.label1.Text = "Cikkszám:";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.BackColor = System.Drawing.Color.Silver;
            this.Label20.Location = new System.Drawing.Point(507, 74);
            this.Label20.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(65, 20);
            this.Label20.TabIndex = 230;
            this.Label20.Text = "Készlet:";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.BackColor = System.Drawing.Color.Silver;
            this.Label21.Location = new System.Drawing.Point(3, 74);
            this.Label21.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(65, 20);
            this.Label21.TabIndex = 231;
            this.Label21.Text = "Készlet:";
            // 
            // HonnanMennyiség
            // 
            this.HonnanMennyiség.AutoSize = true;
            this.HonnanMennyiség.BackColor = System.Drawing.Color.Silver;
            this.HonnanMennyiség.Location = new System.Drawing.Point(151, 74);
            this.HonnanMennyiség.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.HonnanMennyiség.Name = "HonnanMennyiség";
            this.HonnanMennyiség.Size = new System.Drawing.Size(37, 20);
            this.HonnanMennyiség.TabIndex = 235;
            this.HonnanMennyiség.Text = "<-->";
            // 
            // HováMennyiség
            // 
            this.HováMennyiség.AutoSize = true;
            this.HováMennyiség.BackColor = System.Drawing.Color.Silver;
            this.HováMennyiség.Location = new System.Drawing.Point(628, 74);
            this.HováMennyiség.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.HováMennyiség.Name = "HováMennyiség";
            this.HováMennyiség.Size = new System.Drawing.Size(37, 20);
            this.HováMennyiség.TabIndex = 236;
            this.HováMennyiség.Text = "<-->";
            // 
            // Cikkszámok
            // 
            this.Cikkszámok.DropDownHeight = 300;
            this.Cikkszámok.FormattingEnabled = true;
            this.Cikkszámok.IntegralHeight = false;
            this.Cikkszámok.Location = new System.Drawing.Point(151, 100);
            this.Cikkszámok.MaxLength = 10;
            this.Cikkszámok.Name = "Cikkszámok";
            this.Cikkszámok.Size = new System.Drawing.Size(220, 28);
            this.Cikkszámok.TabIndex = 225;
            this.Cikkszámok.SelectionChangeCommitted += new System.EventHandler(this.Cikszámok_SelectionChangeCommitted);
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.BackColor = System.Drawing.Color.Silver;
            this.Label23.Location = new System.Drawing.Point(507, 103);
            this.Label23.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(103, 20);
            this.Label23.TabIndex = 232;
            this.Label23.Text = "Megnevezés:";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.Silver;
            this.Label24.Location = new System.Drawing.Point(3, 137);
            this.Label24.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(85, 20);
            this.Label24.TabIndex = 233;
            this.Label24.Text = "Mennyiség";
            // 
            // Mennyiség
            // 
            this.Mennyiség.Location = new System.Drawing.Point(151, 134);
            this.Mennyiség.Name = "Mennyiség";
            this.Mennyiség.Size = new System.Drawing.Size(128, 26);
            this.Mennyiség.TabIndex = 227;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.BackColor = System.Drawing.Color.Silver;
            this.Label25.Location = new System.Drawing.Point(507, 169);
            this.Label25.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(115, 20);
            this.Label25.TabIndex = 234;
            this.Label25.Text = "Bizonylatszám:";
            // 
            // Bizonylatszám
            // 
            this.Bizonylatszám.Location = new System.Drawing.Point(628, 166);
            this.Bizonylatszám.MaxLength = 15;
            this.Bizonylatszám.Name = "Bizonylatszám";
            this.Bizonylatszám.Size = new System.Drawing.Size(301, 26);
            this.Bizonylatszám.TabIndex = 228;
            // 
            // Hova
            // 
            this.Hova.DropDownHeight = 300;
            this.Hova.FormattingEnabled = true;
            this.Hova.IntegralHeight = false;
            this.Hova.Location = new System.Drawing.Point(628, 37);
            this.Hova.MaxLength = 200;
            this.Hova.Name = "Hova";
            this.Hova.Size = new System.Drawing.Size(350, 28);
            this.Hova.Sorted = true;
            this.Hova.TabIndex = 219;
            this.Hova.SelectionChangeCommitted += new System.EventHandler(this.Hova_SelectionChangeCommitted);
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Silver;
            this.Label18.Location = new System.Drawing.Point(507, 40);
            this.Label18.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(50, 20);
            this.Label18.TabIndex = 222;
            this.Label18.Text = "Hova:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.BackColor = System.Drawing.Color.Silver;
            this.Label19.Location = new System.Drawing.Point(3, 40);
            this.Label19.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(70, 20);
            this.Label19.TabIndex = 220;
            this.Label19.Text = "Honnan:";
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
            this.Tábla.Location = new System.Drawing.Point(12, 237);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersVisible = false;
            this.Tábla.RowHeadersWidth = 62;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Tábla.Size = new System.Drawing.Size(1227, 191);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 224;
            this.Tábla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tábla_CellClick);
            // 
            // Honnan
            // 
            this.Honnan.DropDownHeight = 300;
            this.Honnan.FormattingEnabled = true;
            this.Honnan.IntegralHeight = false;
            this.Honnan.Location = new System.Drawing.Point(151, 37);
            this.Honnan.MaxLength = 200;
            this.Honnan.Name = "Honnan";
            this.Honnan.Size = new System.Drawing.Size(350, 28);
            this.Honnan.Sorted = true;
            this.Honnan.TabIndex = 218;
            this.Honnan.SelectionChangeCommitted += new System.EventHandler(this.Honnan_SelectionChangeCommitted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Bizonylatszám, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.Label25, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.Label21, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.HonnanMennyiség, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Label24, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Mennyiség, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Label20, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.HováMennyiség, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label23, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Hova, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label18, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label19, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Honnan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Mozgás, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cikkszámok, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Dátum, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.Megnevezések, 3, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 202);
            this.tableLayoutPanel1.TabIndex = 241;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 244;
            this.label3.Text = "Mozgás:";
            // 
            // Mozgás
            // 
            this.Mozgás.DropDownHeight = 300;
            this.Mozgás.FormattingEnabled = true;
            this.Mozgás.IntegralHeight = false;
            this.Mozgás.Location = new System.Drawing.Point(151, 3);
            this.Mozgás.MaxLength = 20;
            this.Mozgás.Name = "Mozgás";
            this.Mozgás.Size = new System.Drawing.Size(350, 28);
            this.Mozgás.Sorted = true;
            this.Mozgás.TabIndex = 245;
            this.Mozgás.SelectionChangeCommitted += new System.EventHandler(this.Mozgás_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(3, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 247;
            this.label4.Text = "Könyvelés dátuma:";
            // 
            // Dátum
            // 
            this.Dátum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dátum.Location = new System.Drawing.Point(151, 166);
            this.Dátum.Name = "Dátum";
            this.Dátum.Size = new System.Drawing.Size(128, 26);
            this.Dátum.TabIndex = 248;
            // 
            // Megnevezések
            // 
            this.Megnevezések.DropDownHeight = 300;
            this.Megnevezések.FormattingEnabled = true;
            this.Megnevezések.IntegralHeight = false;
            this.Megnevezések.Location = new System.Drawing.Point(628, 100);
            this.Megnevezések.MaxLength = 20;
            this.Megnevezések.Name = "Megnevezések";
            this.Megnevezések.Size = new System.Drawing.Size(410, 28);
            this.Megnevezések.TabIndex = 246;
            this.Megnevezések.SelectionChangeCommitted += new System.EventHandler(this.Megnevezések_SelectionChangeCommitted);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Controls.Add(this.SAPbeolvasás, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnExcel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Frissít, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MezőkÜrítése, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PDFAblak, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.Rögzít, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.Storno, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Pdf_Készítés, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.PDFNéz, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1067, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 219);
            this.tableLayoutPanel2.TabIndex = 242;
            // 
            // SAPbeolvasás
            // 
            this.SAPbeolvasás.BackgroundImage = global::Tisztito.Properties.Resources.SAP;
            this.SAPbeolvasás.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SAPbeolvasás.Location = new System.Drawing.Point(3, 58);
            this.SAPbeolvasás.Name = "SAPbeolvasás";
            this.SAPbeolvasás.Size = new System.Drawing.Size(45, 45);
            this.SAPbeolvasás.TabIndex = 252;
            this.toolTip1.SetToolTip(this.SAPbeolvasás, "SAP adatok beolvasása ");
            this.SAPbeolvasás.UseVisualStyleBackColor = true;
            this.SAPbeolvasás.Click += new System.EventHandler(this.SAPbeolvasás_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(113, 3);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 249;
            this.toolTip1.SetToolTip(this.BtnExcel, "Excel kimenetet készít a táblázat adatai alapján");
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // Frissít
            // 
            this.Frissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Frissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Frissít.Location = new System.Drawing.Point(58, 3);
            this.Frissít.Name = "Frissít";
            this.Frissít.Size = new System.Drawing.Size(45, 45);
            this.Frissít.TabIndex = 231;
            this.toolTip1.SetToolTip(this.Frissít, "Frissítés");
            this.Frissít.UseVisualStyleBackColor = true;
            this.Frissít.Click += new System.EventHandler(this.Frissít_Click);
            // 
            // MezőkÜrítése
            // 
            this.MezőkÜrítése.BackgroundImage = global::Tisztito.Properties.Resources.New_gyűjtemény;
            this.MezőkÜrítése.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MezőkÜrítése.Location = new System.Drawing.Point(3, 3);
            this.MezőkÜrítése.Name = "MezőkÜrítése";
            this.MezőkÜrítése.Size = new System.Drawing.Size(45, 45);
            this.MezőkÜrítése.TabIndex = 230;
            this.toolTip1.SetToolTip(this.MezőkÜrítése, "Új adat");
            this.MezőkÜrítése.UseVisualStyleBackColor = true;
            this.MezőkÜrítése.Click += new System.EventHandler(this.MezőkÜrítése_Click);
            // 
            // PDFAblak
            // 
            this.PDFAblak.BackgroundImage = global::Tisztito.Properties.Resources.pdf;
            this.PDFAblak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PDFAblak.Location = new System.Drawing.Point(3, 168);
            this.PDFAblak.Name = "PDFAblak";
            this.PDFAblak.Size = new System.Drawing.Size(45, 45);
            this.PDFAblak.TabIndex = 232;
            this.toolTip1.SetToolTip(this.PDFAblak, "Pdf csatolása a könyveléshez");
            this.PDFAblak.UseVisualStyleBackColor = true;
            this.PDFAblak.Click += new System.EventHandler(this.PDFAblak_Click);
            // 
            // Rögzít
            // 
            this.Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rögzít.Location = new System.Drawing.Point(113, 113);
            this.Rögzít.Name = "Rögzít";
            this.Rögzít.Size = new System.Drawing.Size(45, 45);
            this.Rögzít.TabIndex = 229;
            this.toolTip1.SetToolTip(this.Rögzít, "Rögzítés");
            this.Rögzít.UseVisualStyleBackColor = true;
            this.Rögzít.Click += new System.EventHandler(this.Rögzít_Click);
            // 
            // Storno
            // 
            this.Storno.BackgroundImage = global::Tisztito.Properties.Resources.Orange_System_Icon_05;
            this.Storno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Storno.Location = new System.Drawing.Point(3, 113);
            this.Storno.Name = "Storno";
            this.Storno.Size = new System.Drawing.Size(45, 45);
            this.Storno.TabIndex = 233;
            this.toolTip1.SetToolTip(this.Storno, "Stornózza a kijelölt könyvelést");
            this.Storno.UseVisualStyleBackColor = true;
            this.Storno.Click += new System.EventHandler(this.Storno_Click);
            // 
            // Pdf_Készítés
            // 
            this.Pdf_Készítés.BackgroundImage = global::Tisztito.Properties.Resources.pdf_32;
            this.Pdf_Készítés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pdf_Készítés.Location = new System.Drawing.Point(113, 168);
            this.Pdf_Készítés.Name = "Pdf_Készítés";
            this.Pdf_Készítés.Size = new System.Drawing.Size(45, 45);
            this.Pdf_Készítés.TabIndex = 250;
            this.toolTip1.SetToolTip(this.Pdf_Készítés, "Átadás-átvételi dokumentumot generál");
            this.Pdf_Készítés.UseVisualStyleBackColor = true;
            this.Pdf_Készítés.Click += new System.EventHandler(this.Pdf_Készítés_Click);
            // 
            // PDFNéz
            // 
            this.PDFNéz.BackgroundImage = global::Tisztito.Properties.Resources.App_dict;
            this.PDFNéz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PDFNéz.Location = new System.Drawing.Point(58, 168);
            this.PDFNéz.Name = "PDFNéz";
            this.PDFNéz.Size = new System.Drawing.Size(45, 45);
            this.PDFNéz.TabIndex = 251;
            this.toolTip1.SetToolTip(this.PDFNéz, "Rögzített Pdf megjelenítése");
            this.PDFNéz.UseVisualStyleBackColor = true;
            this.PDFNéz.Click += new System.EventHandler(this.PDFNéz_Click);
            // 
            // Ablak_Raktár
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1251, 440);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Tábla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_Raktár";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raktárok közötti könyvelések";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Raktár_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label HonnanMennyiség;
        internal System.Windows.Forms.Label HováMennyiség;
        internal System.Windows.Forms.ComboBox Cikkszámok;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.TextBox Mennyiség;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.TextBox Bizonylatszám;
        internal System.Windows.Forms.Button Rögzít;
        internal System.Windows.Forms.ComboBox Hova;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label19;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.ComboBox Honnan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.Button Frissít;
        internal System.Windows.Forms.Button MezőkÜrítése;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox Mozgás;
        internal System.Windows.Forms.ComboBox Megnevezések;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Dátum;
        internal System.Windows.Forms.Button PDFAblak;
        internal System.Windows.Forms.Button Storno;
        internal System.Windows.Forms.Button BtnExcel;
        internal System.Windows.Forms.Button Pdf_Készítés;
        internal System.Windows.Forms.Button PDFNéz;
        internal System.Windows.Forms.Button SAPbeolvasás;
    }
}