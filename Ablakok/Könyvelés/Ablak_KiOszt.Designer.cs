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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ablak_KiOszt));
            this.Rögzít = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GombokMinden = new System.Windows.Forms.Button();
            this.GombokSemmi = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbMunkakör = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSzervezet = new System.Windows.Forms.ComboBox();
            this.ChkDolgozók = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.LblJárandóság = new System.Windows.Forms.Label();
            this.CmbMegnevezés = new System.Windows.Forms.ComboBox();
            this.CmbCikkszámok = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMennyiség = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RaktárKészlet = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rögzít
            // 
            this.Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rögzít.Location = new System.Drawing.Point(1104, 208);
            this.Rögzít.Name = "Rögzít";
            this.Rögzít.Size = new System.Drawing.Size(45, 45);
            this.Rögzít.TabIndex = 229;
            this.Rögzít.UseVisualStyleBackColor = true;
            // 
            // GombokMinden
            // 
            this.GombokMinden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GombokMinden.BackgroundImage = global::Tisztito.Properties.Resources.mndent_kijelöl;
            this.GombokMinden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GombokMinden.Location = new System.Drawing.Point(6, 3);
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
            this.GombokSemmi.Location = new System.Drawing.Point(57, 3);
            this.GombokSemmi.Name = "GombokSemmi";
            this.GombokSemmi.Size = new System.Drawing.Size(45, 44);
            this.GombokSemmi.TabIndex = 105;
            this.toolTip1.SetToolTip(this.GombokSemmi, "Minden kijelölést megszüntet");
            this.GombokSemmi.UseVisualStyleBackColor = true;
            this.GombokSemmi.Click += new System.EventHandler(this.GombokSemmi_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.20202F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.79798F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CmbMunkakör, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CmbSzervezet, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChkDolgozók, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 416);
            this.tableLayoutPanel1.TabIndex = 243;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GombokMinden);
            this.panel1.Controls.Add(this.GombokSemmi);
            this.panel1.Location = new System.Drawing.Point(123, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 54);
            this.panel1.TabIndex = 244;
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
            this.ChkDolgozók.Location = new System.Drawing.Point(123, 133);
            this.ChkDolgozók.Name = "ChkDolgozók";
            this.ChkDolgozók.Size = new System.Drawing.Size(463, 277);
            this.ChkDolgozók.TabIndex = 249;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 246;
            this.label3.Text = "Dolgozók";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.41527F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.58473F));
            this.tableLayoutPanel3.Controls.Add(this.RaktárKészlet, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.LblJárandóság, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.CmbMegnevezés, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.CmbCikkszámok, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TxtMennyiség, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(612, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(537, 176);
            this.tableLayoutPanel3.TabIndex = 244;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 35);
            this.label7.TabIndex = 251;
            this.label7.Text = "Raktárkészlet:";
            // 
            // LblJárandóság
            // 
            this.LblJárandóság.AutoSize = true;
            this.LblJárandóság.Location = new System.Drawing.Point(118, 70);
            this.LblJárandóság.Name = "LblJárandóság";
            this.LblJárandóság.Size = new System.Drawing.Size(49, 20);
            this.LblJárandóság.TabIndex = 250;
            this.LblJárandóság.Text = "<< >>";
            // 
            // CmbMegnevezés
            // 
            this.CmbMegnevezés.FormattingEnabled = true;
            this.CmbMegnevezés.Location = new System.Drawing.Point(118, 38);
            this.CmbMegnevezés.Name = "CmbMegnevezés";
            this.CmbMegnevezés.Size = new System.Drawing.Size(416, 28);
            this.CmbMegnevezés.TabIndex = 249;
            this.CmbMegnevezés.SelectionChangeCommitted += new System.EventHandler(this.CmbMegnevezés_SelectionChangeCommitted);
            // 
            // CmbCikkszámok
            // 
            this.CmbCikkszámok.FormattingEnabled = true;
            this.CmbCikkszámok.Location = new System.Drawing.Point(118, 3);
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
            // TxtMennyiség
            // 
            this.TxtMennyiség.Location = new System.Drawing.Point(118, 143);
            this.TxtMennyiség.Name = "TxtMennyiség";
            this.TxtMennyiség.Size = new System.Drawing.Size(100, 26);
            this.TxtMennyiség.TabIndex = 252;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 253;
            this.label8.Text = "Mennyiség:";
            // 
            // RaktárKészlet
            // 
            this.RaktárKészlet.AutoSize = true;
            this.RaktárKészlet.Location = new System.Drawing.Point(118, 105);
            this.RaktárKészlet.Name = "RaktárKészlet";
            this.RaktárKészlet.Size = new System.Drawing.Size(49, 20);
            this.RaktárKészlet.TabIndex = 254;
            this.RaktárKészlet.Text = "<< >>";
            // 
            // Ablak_KiOszt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(1162, 440);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Rögzít);
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
    }
}