namespace Tisztito.Ablakok.Lekérdezés
{
    partial class Ablak_Lekérdezés
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_Lekérdezés));
            this.Súgó = new System.Windows.Forms.Button();
            this.Frissít = new System.Windows.Forms.Button();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Szervezet = new System.Windows.Forms.ComboBox();
            this.Cikkszámok = new System.Windows.Forms.ComboBox();
            this.Megnevezések = new System.Windows.Forms.ComboBox();
            this.MezőkÜrítése = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Súgó
            // 
            this.Súgó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.Súgó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Súgó.Location = new System.Drawing.Point(718, 6);
            this.Súgó.Name = "Súgó";
            this.Súgó.Size = new System.Drawing.Size(44, 44);
            this.Súgó.TabIndex = 254;
            this.toolTip1.SetToolTip(this.Súgó, "Online súgó megjelenítése");
            this.Súgó.UseVisualStyleBackColor = true;
            this.Súgó.Click += new System.EventHandler(this.Súgó_Click);
            // 
            // Frissít
            // 
            this.Frissít.BackgroundImage = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Frissít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Frissít.Location = new System.Drawing.Point(717, 76);
            this.Frissít.Name = "Frissít";
            this.Frissít.Size = new System.Drawing.Size(45, 45);
            this.Frissít.TabIndex = 255;
            this.toolTip1.SetToolTip(this.Frissít, "Frissítés");
            this.Frissít.UseVisualStyleBackColor = true;
            this.Frissít.Click += new System.EventHandler(this.Frissít_Click);
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackgroundImage = global::Tisztito.Properties.Resources.Excel_gyűjtő;
            this.BtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExcel.Location = new System.Drawing.Point(667, 77);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(44, 44);
            this.BtnExcel.TabIndex = 256;
            this.toolTip1.SetToolTip(this.BtnExcel, "Excel kimenet készítés");
            this.BtnExcel.UseVisualStyleBackColor = true;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
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
            this.Tábla.Location = new System.Drawing.Point(12, 127);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.RowHeadersVisible = false;
            this.Tábla.RowHeadersWidth = 62;
            this.Tábla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Tábla.Size = new System.Drawing.Size(746, 199);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 257;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(3, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 262;
            this.label1.Text = "Cikkszám:";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.BackColor = System.Drawing.Color.Silver;
            this.Label23.Location = new System.Drawing.Point(3, 76);
            this.Label23.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(103, 20);
            this.Label23.TabIndex = 261;
            this.Label23.Text = "Megnevezés:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.BackColor = System.Drawing.Color.Silver;
            this.Label19.Location = new System.Drawing.Point(3, 6);
            this.Label19.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(84, 20);
            this.Label19.TabIndex = 259;
            this.Label19.Text = "Szervezet:";
            // 
            // Szervezet
            // 
            this.Szervezet.DropDownHeight = 300;
            this.Szervezet.FormattingEnabled = true;
            this.Szervezet.IntegralHeight = false;
            this.Szervezet.Location = new System.Drawing.Point(125, 3);
            this.Szervezet.MaxLength = 200;
            this.Szervezet.Name = "Szervezet";
            this.Szervezet.Size = new System.Drawing.Size(350, 28);
            this.Szervezet.Sorted = true;
            this.Szervezet.TabIndex = 258;
            // 
            // Cikkszámok
            // 
            this.Cikkszámok.DropDownHeight = 300;
            this.Cikkszámok.FormattingEnabled = true;
            this.Cikkszámok.IntegralHeight = false;
            this.Cikkszámok.Location = new System.Drawing.Point(125, 38);
            this.Cikkszámok.MaxLength = 10;
            this.Cikkszámok.Name = "Cikkszámok";
            this.Cikkszámok.Size = new System.Drawing.Size(220, 28);
            this.Cikkszámok.TabIndex = 260;
            this.Cikkszámok.SelectionChangeCommitted += new System.EventHandler(this.Cikkszámok_SelectionChangeCommitted);
            // 
            // Megnevezések
            // 
            this.Megnevezések.DropDownHeight = 300;
            this.Megnevezések.FormattingEnabled = true;
            this.Megnevezések.IntegralHeight = false;
            this.Megnevezések.Location = new System.Drawing.Point(125, 73);
            this.Megnevezések.MaxLength = 20;
            this.Megnevezések.Name = "Megnevezések";
            this.Megnevezések.Size = new System.Drawing.Size(410, 28);
            this.Megnevezések.TabIndex = 263;
            this.Megnevezések.SelectionChangeCommitted += new System.EventHandler(this.Megnevezések_SelectionChangeCommitted);
            // 
            // MezőkÜrítése
            // 
            this.MezőkÜrítése.BackgroundImage = global::Tisztito.Properties.Resources.New_gyűjtemény;
            this.MezőkÜrítése.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MezőkÜrítése.Location = new System.Drawing.Point(616, 76);
            this.MezőkÜrítése.Name = "MezőkÜrítése";
            this.MezőkÜrítése.Size = new System.Drawing.Size(45, 45);
            this.MezőkÜrítése.TabIndex = 264;
            this.toolTip1.SetToolTip(this.MezőkÜrítése, "Új adat");
            this.MezőkÜrítése.UseVisualStyleBackColor = true;
            this.MezőkÜrítése.Click += new System.EventHandler(this.MezőkÜrítése_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.56856F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.43144F));
            this.tableLayoutPanel1.Controls.Add(this.Label19, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Megnevezések, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Cikkszámok, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Szervezet, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label23, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 109);
            this.tableLayoutPanel1.TabIndex = 265;
            // 
            // Ablak_Lekérdezés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(770, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MezőkÜrítése);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.BtnExcel);
            this.Controls.Add(this.Frissít);
            this.Controls.Add(this.Súgó);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_Lekérdezés";
            this.Text = "Raktárkészletek lekérdezése";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ablak_Lekérdezés_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Súgó;
        internal System.Windows.Forms.Button Frissít;
        internal System.Windows.Forms.Button BtnExcel;
        internal Zuby.ADGV.AdvancedDataGridView Tábla;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.ComboBox Szervezet;
        internal System.Windows.Forms.ComboBox Cikkszámok;
        internal System.Windows.Forms.ComboBox Megnevezések;
        internal System.Windows.Forms.Button MezőkÜrítése;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}