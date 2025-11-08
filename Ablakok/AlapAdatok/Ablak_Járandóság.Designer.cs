namespace Tisztito.Ablakok
{
    partial class Ablak_Járandóság
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Járandóság));
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Munkakör = new System.Windows.Forms.ComboBox();
            this.Cikkszám = new System.Windows.Forms.ComboBox();
            this.Megnevezés = new System.Windows.Forms.ComboBox();
            this.Mennyiség = new System.Windows.Forms.TextBox();
            this.Gyakoriság = new System.Windows.Forms.TextBox();
            this.CmbStátus = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Új_adat = new System.Windows.Forms.Button();
            this.Alap_Rögzít = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.BtnFrissít = new System.Windows.Forms.Button();
            this.FeltöltésiTábla = new System.Windows.Forms.Button();
            this.AdatokFeltölése = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Holtart = new Villamos.V_MindenEgyéb.MyProgressbar();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
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
            this.Tábla.Location = new System.Drawing.Point(12, 237);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.ReadOnly = true;
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.Size = new System.Drawing.Size(1095, 222);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 220;
            this.Tábla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tábla_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Label34, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Munkakör, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cikkszám, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Megnevezés, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Mennyiség, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Gyakoriság, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.CmbStátus, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(894, 219);
            this.tableLayoutPanel1.TabIndex = 221;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.BackColor = System.Drawing.Color.Silver;
            this.Label34.Location = new System.Drawing.Point(3, 0);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(83, 20);
            this.Label34.TabIndex = 211;
            this.Label34.Text = "Munkakör:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Silver;
            this.Label4.Location = new System.Drawing.Point(3, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(77, 20);
            this.Label4.TabIndex = 214;
            this.Label4.Text = "Cikkszám";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Silver;
            this.Label2.Location = new System.Drawing.Point(3, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 20);
            this.Label2.TabIndex = 212;
            this.Label2.Text = "Megnevezés:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Silver;
            this.Label3.Location = new System.Drawing.Point(3, 105);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(89, 20);
            this.Label3.TabIndex = 213;
            this.Label3.Text = "Mennyiség:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 20);
            this.label5.TabIndex = 221;
            this.label5.Text = "Esedékesség gyakorisága (hó):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 216;
            this.label1.Text = "Státus:";
            // 
            // Munkakör
            // 
            this.Munkakör.DropDownHeight = 300;
            this.Munkakör.FormattingEnabled = true;
            this.Munkakör.IntegralHeight = false;
            this.Munkakör.Location = new System.Drawing.Point(240, 3);
            this.Munkakör.MaxLength = 20;
            this.Munkakör.Name = "Munkakör";
            this.Munkakör.Size = new System.Drawing.Size(518, 28);
            this.Munkakör.Sorted = true;
            this.Munkakör.TabIndex = 222;
            // 
            // Cikkszám
            // 
            this.Cikkszám.DropDownHeight = 300;
            this.Cikkszám.FormattingEnabled = true;
            this.Cikkszám.IntegralHeight = false;
            this.Cikkszám.Location = new System.Drawing.Point(240, 38);
            this.Cikkszám.MaxLength = 20;
            this.Cikkszám.Name = "Cikkszám";
            this.Cikkszám.Size = new System.Drawing.Size(224, 28);
            this.Cikkszám.Sorted = true;
            this.Cikkszám.TabIndex = 224;
            this.Cikkszám.SelectionChangeCommitted += new System.EventHandler(this.Cikkszám_SelectionChangeCommitted);
            // 
            // Megnevezés
            // 
            this.Megnevezés.DropDownHeight = 300;
            this.Megnevezés.FormattingEnabled = true;
            this.Megnevezés.IntegralHeight = false;
            this.Megnevezés.Location = new System.Drawing.Point(240, 73);
            this.Megnevezés.MaxLength = 20;
            this.Megnevezés.Name = "Megnevezés";
            this.Megnevezés.Size = new System.Drawing.Size(635, 28);
            this.Megnevezés.Sorted = true;
            this.Megnevezés.TabIndex = 223;
            this.Megnevezés.SelectionChangeCommitted += new System.EventHandler(this.Megnevezés_SelectionChangeCommitted);
            // 
            // Mennyiség
            // 
            this.Mennyiség.Location = new System.Drawing.Point(240, 108);
            this.Mennyiség.MaxLength = 10;
            this.Mennyiség.Name = "Mennyiség";
            this.Mennyiség.Size = new System.Drawing.Size(180, 26);
            this.Mennyiség.TabIndex = 199;
            // 
            // Gyakoriság
            // 
            this.Gyakoriság.Location = new System.Drawing.Point(240, 143);
            this.Gyakoriság.MaxLength = 10;
            this.Gyakoriság.Name = "Gyakoriság";
            this.Gyakoriság.Size = new System.Drawing.Size(180, 26);
            this.Gyakoriság.TabIndex = 220;
            // 
            // CmbStátus
            // 
            this.CmbStátus.DropDownHeight = 300;
            this.CmbStátus.FormattingEnabled = true;
            this.CmbStátus.IntegralHeight = false;
            this.CmbStátus.Location = new System.Drawing.Point(240, 178);
            this.CmbStátus.MaxLength = 20;
            this.CmbStátus.Name = "CmbStátus";
            this.CmbStátus.Size = new System.Drawing.Size(180, 28);
            this.CmbStátus.TabIndex = 217;
            // 
            // Új_adat
            // 
            this.Új_adat.BackgroundImage = global::Tisztito.Properties.Resources.New_gyűjtemény;
            this.Új_adat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Új_adat.Location = new System.Drawing.Point(3, 3);
            this.Új_adat.Name = "Új_adat";
            this.Új_adat.Size = new System.Drawing.Size(44, 44);
            this.Új_adat.TabIndex = 209;
            this.toolTip1.SetToolTip(this.Új_adat, "Új adat");
            this.Új_adat.UseVisualStyleBackColor = true;
            this.Új_adat.Click += new System.EventHandler(this.Új_adat_Click);
            // 
            // Alap_Rögzít
            // 
            this.Alap_Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Alap_Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Alap_Rögzít.Location = new System.Drawing.Point(53, 3);
            this.Alap_Rögzít.Name = "Alap_Rögzít";
            this.Alap_Rögzít.Size = new System.Drawing.Size(44, 44);
            this.Alap_Rögzít.TabIndex = 206;
            this.toolTip1.SetToolTip(this.Alap_Rögzít, "Rögzítés");
            this.Alap_Rögzít.UseVisualStyleBackColor = true;
            this.Alap_Rögzít.Click += new System.EventHandler(this.Alap_Rögzít_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(153, 3);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 218;
            this.toolTip1.SetToolTip(this.BtnExcel, "Excel kimenet készítés");
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // BtnFrissít
            // 
            this.BtnFrissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.BtnFrissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFrissít.Location = new System.Drawing.Point(103, 3);
            this.BtnFrissít.Name = "BtnFrissít";
            this.BtnFrissít.Size = new System.Drawing.Size(44, 44);
            this.BtnFrissít.TabIndex = 215;
            this.toolTip1.SetToolTip(this.BtnFrissít, "Frissítés");
            this.BtnFrissít.UseVisualStyleBackColor = true;
            this.BtnFrissít.Click += new System.EventHandler(this.BtnFrissít_Click);
            // 
            // FeltöltésiTábla
            // 
            this.FeltöltésiTábla.BackgroundImage = global::Tisztito.Properties.Resources.Custom_Icon_Design_Flatastic_1_Export;
            this.FeltöltésiTábla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FeltöltésiTábla.Location = new System.Drawing.Point(53, 73);
            this.FeltöltésiTábla.Name = "FeltöltésiTábla";
            this.FeltöltésiTábla.Size = new System.Drawing.Size(44, 44);
            this.FeltöltésiTábla.TabIndex = 219;
            this.toolTip1.SetToolTip(this.FeltöltésiTábla, "Feltöltési Excel táblát készít");
            this.FeltöltésiTábla.UseVisualStyleBackColor = true;
            this.FeltöltésiTábla.Click += new System.EventHandler(this.FeltöltésiTábla_Click);
            // 
            // AdatokFeltölése
            // 
            this.AdatokFeltölése.BackgroundImage = global::Tisztito.Properties.Resources.Custom_Icon_Design_Flatastic_1_Import;
            this.AdatokFeltölése.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AdatokFeltölése.Location = new System.Drawing.Point(103, 73);
            this.AdatokFeltölése.Name = "AdatokFeltölése";
            this.AdatokFeltölése.Size = new System.Drawing.Size(44, 44);
            this.AdatokFeltölése.TabIndex = 220;
            this.toolTip1.SetToolTip(this.AdatokFeltölése, "Adatok feltöltése Excel segítségével");
            this.AdatokFeltölése.UseVisualStyleBackColor = true;
            this.AdatokFeltölése.Click += new System.EventHandler(this.AdatokFeltölése_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Új_adat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Alap_Rögzít, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnExcel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnFrissít, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.FeltöltésiTábla, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.AdatokFeltölése, 2, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(912, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 128);
            this.tableLayoutPanel2.TabIndex = 222;
            // 
            // Holtart
            // 
            this.Holtart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Holtart.Location = new System.Drawing.Point(73, 237);
            this.Holtart.Name = "Holtart";
            this.Holtart.Size = new System.Drawing.Size(961, 30);
            this.Holtart.TabIndex = 223;
            this.Holtart.Visible = false;
            // 
            // Ablak_Járandóság
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1119, 470);
            this.Controls.Add(this.Holtart);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Tábla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_Járandóság";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Járandóság Törzs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Anyagok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button Új_adat;
        internal System.Windows.Forms.Button Alap_Rögzít;
        private Zuby.ADGV.AdvancedDataGridView Tábla;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Button BtnFrissít;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox Mennyiség;
        internal System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox Gyakoriság;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox CmbStátus;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox Munkakör;
        internal System.Windows.Forms.ComboBox Megnevezés;
        internal System.Windows.Forms.ComboBox Cikkszám;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.Button FeltöltésiTábla;
        internal System.Windows.Forms.Button AdatokFeltölése;
        private Villamos.V_MindenEgyéb.MyProgressbar Holtart;
    }
}