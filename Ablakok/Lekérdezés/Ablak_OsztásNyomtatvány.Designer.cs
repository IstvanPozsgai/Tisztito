namespace Tisztito.Ablakok.Lekérdezés
{
    partial class Ablak_OsztásNyomtatvány
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MunkakörMinden = new System.Windows.Forms.Button();
            this.MunkakörSemmi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkDolgozók = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ChkMunkakör = new System.Windows.Forms.CheckedListBox();
            this.ChkSzervezet = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SzervezetMinden = new System.Windows.Forms.Button();
            this.SzervezetSemmi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DolgozóMinden = new System.Windows.Forms.Button();
            this.DolgozóSemmi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Osztási_PDF = new System.Windows.Forms.Button();
            this.Súgó = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MunkakörMinden);
            this.panel1.Controls.Add(this.MunkakörSemmi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 84);
            this.panel1.TabIndex = 245;
            // 
            // MunkakörMinden
            // 
            this.MunkakörMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MunkakörMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.MunkakörMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MunkakörMinden.Location = new System.Drawing.Point(3, 38);
            this.MunkakörMinden.Name = "MunkakörMinden";
            this.MunkakörMinden.Size = new System.Drawing.Size(45, 44);
            this.MunkakörMinden.TabIndex = 106;
            this.MunkakörMinden.UseVisualStyleBackColor = true;
            this.MunkakörMinden.Click += new System.EventHandler(this.MunkakörMinden_Click);
            // 
            // MunkakörSemmi
            // 
            this.MunkakörSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MunkakörSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.MunkakörSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MunkakörSemmi.Location = new System.Drawing.Point(57, 38);
            this.MunkakörSemmi.Name = "MunkakörSemmi";
            this.MunkakörSemmi.Size = new System.Drawing.Size(45, 44);
            this.MunkakörSemmi.TabIndex = 105;
            this.MunkakörSemmi.UseVisualStyleBackColor = true;
            this.MunkakörSemmi.Click += new System.EventHandler(this.MunkakörSemmi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 246;
            this.label3.Text = "Munkakör";
            // 
            // ChkDolgozók
            // 
            this.ChkDolgozók.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkDolgozók.FormattingEnabled = true;
            this.ChkDolgozók.Location = new System.Drawing.Point(114, 291);
            this.ChkDolgozók.Name = "ChkDolgozók";
            this.ChkDolgozók.Size = new System.Drawing.Size(463, 277);
            this.ChkDolgozók.TabIndex = 250;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ChkMunkakör, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ChkSzervezet, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ChkDolgozók, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 577);
            this.tableLayoutPanel1.TabIndex = 251;
            // 
            // ChkMunkakör
            // 
            this.ChkMunkakör.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkMunkakör.FormattingEnabled = true;
            this.ChkMunkakör.Location = new System.Drawing.Point(114, 147);
            this.ChkMunkakör.Name = "ChkMunkakör";
            this.ChkMunkakör.Size = new System.Drawing.Size(463, 130);
            this.ChkMunkakör.TabIndex = 252;
            this.ChkMunkakör.SelectedIndexChanged += new System.EventHandler(this.ChkMunkakör_SelectedIndexChanged);
            // 
            // ChkSzervezet
            // 
            this.ChkSzervezet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkSzervezet.FormattingEnabled = true;
            this.ChkSzervezet.Location = new System.Drawing.Point(114, 3);
            this.ChkSzervezet.Name = "ChkSzervezet";
            this.ChkSzervezet.Size = new System.Drawing.Size(463, 130);
            this.ChkSzervezet.TabIndex = 251;
            this.ChkSzervezet.SelectedIndexChanged += new System.EventHandler(this.ChkSzervezet_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SzervezetMinden);
            this.panel2.Controls.Add(this.SzervezetSemmi);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(105, 84);
            this.panel2.TabIndex = 246;
            // 
            // SzervezetMinden
            // 
            this.SzervezetMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SzervezetMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.SzervezetMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SzervezetMinden.Location = new System.Drawing.Point(3, 38);
            this.SzervezetMinden.Name = "SzervezetMinden";
            this.SzervezetMinden.Size = new System.Drawing.Size(45, 44);
            this.SzervezetMinden.TabIndex = 106;
            this.SzervezetMinden.UseVisualStyleBackColor = true;
            this.SzervezetMinden.Click += new System.EventHandler(this.SzervezetMinden_Click);
            // 
            // SzervezetSemmi
            // 
            this.SzervezetSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SzervezetSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.SzervezetSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SzervezetSemmi.Location = new System.Drawing.Point(57, 38);
            this.SzervezetSemmi.Name = "SzervezetSemmi";
            this.SzervezetSemmi.Size = new System.Drawing.Size(45, 44);
            this.SzervezetSemmi.TabIndex = 105;
            this.SzervezetSemmi.UseVisualStyleBackColor = true;
            this.SzervezetSemmi.Click += new System.EventHandler(this.SzervezetSemmi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 246;
            this.label1.Text = "Szervezet";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DolgozóMinden);
            this.panel3.Controls.Add(this.DolgozóSemmi);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 291);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 84);
            this.panel3.TabIndex = 247;
            // 
            // DolgozóMinden
            // 
            this.DolgozóMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DolgozóMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.DolgozóMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DolgozóMinden.Location = new System.Drawing.Point(3, 38);
            this.DolgozóMinden.Name = "DolgozóMinden";
            this.DolgozóMinden.Size = new System.Drawing.Size(45, 44);
            this.DolgozóMinden.TabIndex = 106;
            this.DolgozóMinden.UseVisualStyleBackColor = true;
            this.DolgozóMinden.Click += new System.EventHandler(this.DolgozóMinden_Click);
            // 
            // DolgozóSemmi
            // 
            this.DolgozóSemmi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DolgozóSemmi.BackgroundImage = global::Tisztito.Properties.Resources.üres_lista;
            this.DolgozóSemmi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DolgozóSemmi.Location = new System.Drawing.Point(57, 38);
            this.DolgozóSemmi.Name = "DolgozóSemmi";
            this.DolgozóSemmi.Size = new System.Drawing.Size(45, 44);
            this.DolgozóSemmi.TabIndex = 105;
            this.DolgozóSemmi.UseVisualStyleBackColor = true;
            this.DolgozóSemmi.Click += new System.EventHandler(this.DolgozóSemmi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 246;
            this.label2.Text = "Dolgozók";
            // 
            // Osztási_PDF
            // 
            this.Osztási_PDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Osztási_PDF.BackgroundImage = global::Tisztito.Properties.Resources.pdf;
            this.Osztási_PDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Osztási_PDF.Location = new System.Drawing.Point(603, 12);
            this.Osztási_PDF.Name = "Osztási_PDF";
            this.Osztási_PDF.Size = new System.Drawing.Size(44, 44);
            this.Osztási_PDF.TabIndex = 252;
            this.Osztási_PDF.UseVisualStyleBackColor = true;
            this.Osztási_PDF.Click += new System.EventHandler(this.Osztási_PDF_Click);
            // 
            // Súgó
            // 
            this.Súgó.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Súgó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.Súgó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Súgó.Location = new System.Drawing.Point(655, 12);
            this.Súgó.Name = "Súgó";
            this.Súgó.Size = new System.Drawing.Size(44, 44);
            this.Súgó.TabIndex = 253;
            this.Súgó.UseVisualStyleBackColor = true;
            this.Súgó.Click += new System.EventHandler(this.Súgó_Click);
            // 
            // Ablak_OsztásNyomtatvány
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(711, 601);
            this.Controls.Add(this.Súgó);
            this.Controls.Add(this.Osztási_PDF);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Ablak_OsztásNyomtatvány";
            this.Text = "Ablak_Járandóság";
            this.Load += new System.EventHandler(this.Ablak_OsztásNyomtatvány_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button MunkakörMinden;
        internal System.Windows.Forms.Button MunkakörSemmi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox ChkDolgozók;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox ChkMunkakör;
        private System.Windows.Forms.CheckedListBox ChkSzervezet;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Button SzervezetMinden;
        internal System.Windows.Forms.Button SzervezetSemmi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button DolgozóMinden;
        internal System.Windows.Forms.Button DolgozóSemmi;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button Osztási_PDF;
        internal System.Windows.Forms.Button Súgó;
    }
}