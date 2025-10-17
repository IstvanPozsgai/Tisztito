namespace Tisztito.Ablakok.Lekérdezés
{
    partial class Ablak_Dolgozói_Lekérdezés
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Dolgozói_Lekérdezés));
            this.CmbDolgozó = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbSzervezet = new System.Windows.Forms.ComboBox();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.Frissít = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.Súgó = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Dátum = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbDolgozó
            // 
            this.CmbDolgozó.FormattingEnabled = true;
            this.CmbDolgozó.Location = new System.Drawing.Point(132, 46);
            this.CmbDolgozó.Name = "CmbDolgozó";
            this.CmbDolgozó.Size = new System.Drawing.Size(463, 28);
            this.CmbDolgozó.TabIndex = 257;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 256;
            this.label11.Text = "Dolgozó:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 252;
            this.label1.Text = "Szervezet:";
            // 
            // CmbSzervezet
            // 
            this.CmbSzervezet.FormattingEnabled = true;
            this.CmbSzervezet.Location = new System.Drawing.Point(132, 12);
            this.CmbSzervezet.Name = "CmbSzervezet";
            this.CmbSzervezet.Size = new System.Drawing.Size(463, 28);
            this.CmbSzervezet.TabIndex = 254;
            this.CmbSzervezet.SelectionChangeCommitted += new System.EventHandler(this.CmbSzervezet_SelectionChangeCommitted);
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
            this.Tábla.Location = new System.Drawing.Point(12, 120);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersWidth = 25;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tábla.Size = new System.Drawing.Size(735, 298);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 258;
            // 
            // Frissít
            // 
            this.Frissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Frissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Frissít.Location = new System.Drawing.Point(615, 12);
            this.Frissít.Name = "Frissít";
            this.Frissít.Size = new System.Drawing.Size(44, 44);
            this.Frissít.TabIndex = 259;
            this.toolTip1.SetToolTip(this.Frissít, "Frissítés");
            this.Frissít.UseVisualStyleBackColor = true;
            this.Frissít.Click += new System.EventHandler(this.Frissít_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(615, 70);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 260;
            this.toolTip1.SetToolTip(this.BtnExcel, "Excel kimenet készítés");
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // Súgó
            // 
            this.Súgó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.Súgó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Súgó.Location = new System.Drawing.Point(695, 12);
            this.Súgó.Name = "Súgó";
            this.Súgó.Size = new System.Drawing.Size(44, 44);
            this.Súgó.TabIndex = 261;
            this.toolTip1.SetToolTip(this.Súgó, "Online súgó megjelenítése");
            this.Súgó.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 262;
            this.label9.Text = "Dátum:";
            // 
            // Dátum
            // 
            this.Dátum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dátum.Location = new System.Drawing.Point(132, 80);
            this.Dátum.Name = "Dátum";
            this.Dátum.Size = new System.Drawing.Size(128, 26);
            this.Dátum.TabIndex = 263;
            // 
            // Ablak_Dolgozói_Lekérdezés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(753, 424);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Dátum);
            this.Controls.Add(this.Súgó);
            this.Controls.Add(this.Frissít);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.CmbDolgozó);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbSzervezet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_Dolgozói_Lekérdezés";
            this.Text = "Dolgozói lekérdezések";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Dolgozói_Lekérdezés_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbDolgozó;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbSzervezet;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.Button Frissít;
        internal System.Windows.Forms.Button BtnExcel;
        internal System.Windows.Forms.Button Súgó;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker Dátum;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}