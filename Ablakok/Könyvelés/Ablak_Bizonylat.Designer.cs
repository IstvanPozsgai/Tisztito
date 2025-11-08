namespace Tisztito.Ablakok
{
    partial class Ablak_Bizonylat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Bizonylat));
            this.label1 = new System.Windows.Forms.Label();
            this.Cikkszámok = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.Hova = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.Honnan = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Megnevezések = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dátumig = new System.Windows.Forms.DateTimePicker();
            this.Dátumtól = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.Frissít = new System.Windows.Forms.Button();
            this.Pdf_Készítés = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 237;
            this.label1.Text = "Cikkszám:";
            // 
            // Cikkszámok
            // 
            this.Cikkszámok.DropDownHeight = 300;
            this.Cikkszámok.FormattingEnabled = true;
            this.Cikkszámok.IntegralHeight = false;
            this.Cikkszámok.Location = new System.Drawing.Point(151, 37);
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
            this.Label23.Location = new System.Drawing.Point(507, 40);
            this.Label23.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(103, 20);
            this.Label23.TabIndex = 232;
            this.Label23.Text = "Megnevezés:";
            // 
            // Hova
            // 
            this.Hova.DropDownHeight = 300;
            this.Hova.FormattingEnabled = true;
            this.Hova.IntegralHeight = false;
            this.Hova.Location = new System.Drawing.Point(616, 3);
            this.Hova.MaxLength = 200;
            this.Hova.Name = "Hova";
            this.Hova.Size = new System.Drawing.Size(350, 28);
            this.Hova.Sorted = true;
            this.Hova.TabIndex = 219;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Silver;
            this.Label18.Location = new System.Drawing.Point(507, 6);
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
            this.Label19.Location = new System.Drawing.Point(3, 6);
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
            this.Tábla.Location = new System.Drawing.Point(12, 130);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersWidth = 30;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tábla.Size = new System.Drawing.Size(1227, 298);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 224;
            // 
            // Honnan
            // 
            this.Honnan.DropDownHeight = 300;
            this.Honnan.FormattingEnabled = true;
            this.Honnan.IntegralHeight = false;
            this.Honnan.Location = new System.Drawing.Point(151, 3);
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
            this.tableLayoutPanel1.Controls.Add(this.Label18, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Hova, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Megnevezések, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label23, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label19, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Honnan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cikkszámok, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 112);
            this.tableLayoutPanel1.TabIndex = 241;
            // 
            // Megnevezések
            // 
            this.Megnevezések.DropDownHeight = 300;
            this.Megnevezések.FormattingEnabled = true;
            this.Megnevezések.IntegralHeight = false;
            this.Megnevezések.Location = new System.Drawing.Point(616, 37);
            this.Megnevezések.MaxLength = 20;
            this.Megnevezések.Name = "Megnevezések";
            this.Megnevezések.Size = new System.Drawing.Size(410, 28);
            this.Megnevezések.TabIndex = 246;
            this.Megnevezések.SelectionChangeCommitted += new System.EventHandler(this.Megnevezések_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 247;
            this.label4.Text = "Könyvelés dátuma:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Dátumig);
            this.panel1.Controls.Add(this.Dátumtól);
            this.panel1.Location = new System.Drawing.Point(151, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 33);
            this.panel1.TabIndex = 250;
            // 
            // Dátumig
            // 
            this.Dátumig.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dátumig.Location = new System.Drawing.Point(147, 4);
            this.Dátumig.Name = "Dátumig";
            this.Dátumig.Size = new System.Drawing.Size(128, 26);
            this.Dátumig.TabIndex = 249;
            // 
            // Dátumtól
            // 
            this.Dátumtól.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dátumtól.Location = new System.Drawing.Point(3, 4);
            this.Dátumtól.Name = "Dátumtól";
            this.Dátumtól.Size = new System.Drawing.Size(128, 26);
            this.Dátumtól.TabIndex = 248;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Controls.Add(this.BtnExcel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Frissít, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Pdf_Készítés, 2, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1067, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 112);
            this.tableLayoutPanel2.TabIndex = 242;
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
            // Pdf_Készítés
            // 
            this.Pdf_Készítés.BackgroundImage = global::Tisztito.Properties.Resources.pdf_32;
            this.Pdf_Készítés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pdf_Készítés.Location = new System.Drawing.Point(113, 58);
            this.Pdf_Készítés.Name = "Pdf_Készítés";
            this.Pdf_Készítés.Size = new System.Drawing.Size(45, 45);
            this.Pdf_Készítés.TabIndex = 250;
            this.toolTip1.SetToolTip(this.Pdf_Készítés, "Selejtezési bizonylatot készít");
            this.Pdf_Készítés.UseVisualStyleBackColor = true;
            this.Pdf_Készítés.Click += new System.EventHandler(this.Pdf_Készítés_Click);
            // 
            // Ablak_Bizonylat
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
            this.Name = "Ablak_Bizonylat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bizonylatok nyomtatása";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Raktár_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox Cikkszámok;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.ComboBox Hova;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label19;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.ComboBox Honnan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        internal System.Windows.Forms.Button Frissít;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ComboBox Megnevezések;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Dátumtól;
        internal System.Windows.Forms.Button Pdf_Készítés;
        private System.Windows.Forms.DateTimePicker Dátumig;
        internal System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.Panel panel1;
    }
}