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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Dolgozói_Lekérdezés));
            this.CmbDolgozó = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CmbMunkakör = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSzervezet = new System.Windows.Forms.ComboBox();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.Frissít = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.Súgó = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbDolgozó
            // 
            this.CmbDolgozó.FormattingEnabled = true;
            this.CmbDolgozó.Location = new System.Drawing.Point(132, 85);
            this.CmbDolgozó.Name = "CmbDolgozó";
            this.CmbDolgozó.Size = new System.Drawing.Size(463, 28);
            this.CmbDolgozó.TabIndex = 257;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 256;
            this.label11.Text = "Dolgozó:";
            // 
            // CmbMunkakör
            // 
            this.CmbMunkakör.FormattingEnabled = true;
            this.CmbMunkakör.Location = new System.Drawing.Point(132, 47);
            this.CmbMunkakör.Name = "CmbMunkakör";
            this.CmbMunkakör.Size = new System.Drawing.Size(463, 28);
            this.CmbMunkakör.TabIndex = 255;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 253;
            this.label2.Text = "Munkakör:";
            // 
            // CmbSzervezet
            // 
            this.CmbSzervezet.FormattingEnabled = true;
            this.CmbSzervezet.Location = new System.Drawing.Point(132, 12);
            this.CmbSzervezet.Name = "CmbSzervezet";
            this.CmbSzervezet.Size = new System.Drawing.Size(463, 28);
            this.CmbSzervezet.TabIndex = 254;
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
            this.Tábla.Location = new System.Drawing.Point(12, 131);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersWidth = 25;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tábla.Size = new System.Drawing.Size(735, 189);
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
            this.Frissít.UseVisualStyleBackColor = true;
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(615, 70);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 260;
            this.BtnExcel.UseVisualStyleBackColor = true;
            // 
            // Súgó
            // 
            this.Súgó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.Súgó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Súgó.Location = new System.Drawing.Point(695, 12);
            this.Súgó.Name = "Súgó";
            this.Súgó.Size = new System.Drawing.Size(44, 44);
            this.Súgó.TabIndex = 261;
            this.Súgó.UseVisualStyleBackColor = true;
            // 
            // Ablak_Dolgozói_Lekérdezés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(753, 326);
            this.Controls.Add(this.Súgó);
            this.Controls.Add(this.Frissít);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.CmbDolgozó);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CmbMunkakör);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbSzervezet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_Dolgozói_Lekérdezés";
            this.Text = "Lekérdezés Dolgozók";
            this.Load += new System.EventHandler(this.Ablak_Dolgozói_Lekérdezés_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbDolgozó;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox CmbMunkakör;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbSzervezet;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.Button Frissít;
        internal System.Windows.Forms.Button BtnExcel;
        internal System.Windows.Forms.Button Súgó;
    }
}