namespace Tisztito
{
    partial class Főoldal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Főoldal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jogosultságBeállításToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.működésiAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alapAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Anyag = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Dolgozó = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Szervezet = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Járandóság = new System.Windows.Forms.ToolStripMenuItem();
            this.könyvelésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lekérdezésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Képkeret = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Képkeret)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beállításokToolStripMenuItem,
            this.alapAdatokToolStripMenuItem,
            this.könyvelésekToolStripMenuItem,
            this.lekérdezésekToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jogosultságBeállításToolStripMenuItem,
            this.működésiAdatokToolStripMenuItem});
            this.beállításokToolStripMenuItem.Image = global::Tisztito.Properties.Resources.Action_configure;
            this.beállításokToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.beállításokToolStripMenuItem.Text = "&Beállítások";
            // 
            // jogosultságBeállításToolStripMenuItem
            // 
            this.jogosultságBeállításToolStripMenuItem.Name = "jogosultságBeállításToolStripMenuItem";
            this.jogosultságBeállításToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.jogosultságBeállításToolStripMenuItem.Text = "&Jogosultság beállítás";
            // 
            // működésiAdatokToolStripMenuItem
            // 
            this.működésiAdatokToolStripMenuItem.Name = "működésiAdatokToolStripMenuItem";
            this.működésiAdatokToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.működésiAdatokToolStripMenuItem.Text = "&Működési Adatok";
            this.működésiAdatokToolStripMenuItem.Click += new System.EventHandler(this.működésiAdatokToolStripMenuItem_Click);
            // 
            // alapAdatokToolStripMenuItem
            // 
            this.alapAdatokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Anyag,
            this.ToolStripMenuItem_Dolgozó,
            this.ToolStripMenuItem_Szervezet,
            this.ToolStripMenuItem_Járandóság});
            this.alapAdatokToolStripMenuItem.Image = global::Tisztito.Properties.Resources.Gear_01;
            this.alapAdatokToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.alapAdatokToolStripMenuItem.Name = "alapAdatokToolStripMenuItem";
            this.alapAdatokToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.alapAdatokToolStripMenuItem.Text = "&Alap adatok";
            // 
            // ToolStripMenuItem_Anyag
            // 
            this.ToolStripMenuItem_Anyag.Image = global::Tisztito.Properties.Resources.App_warehause;
            this.ToolStripMenuItem_Anyag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Anyag.Name = "ToolStripMenuItem_Anyag";
            this.ToolStripMenuItem_Anyag.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Anyag.Text = "Anyag törzs";
            this.ToolStripMenuItem_Anyag.Click += new System.EventHandler(this.ToolStripMenuItem_Anyag_Click);
            // 
            // ToolStripMenuItem_Dolgozó
            // 
            this.ToolStripMenuItem_Dolgozó.Image = global::Tisztito.Properties.Resources.community_users;
            this.ToolStripMenuItem_Dolgozó.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Dolgozó.Name = "ToolStripMenuItem_Dolgozó";
            this.ToolStripMenuItem_Dolgozó.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Dolgozó.Text = "Dolgozó Törzs";
            this.ToolStripMenuItem_Dolgozó.Click += new System.EventHandler(this.ToolStripMenuItem_Dolgozó_Click);
            // 
            // ToolStripMenuItem_Szervezet
            // 
            this.ToolStripMenuItem_Szervezet.Image = global::Tisztito.Properties.Resources.Filesystem_blockdevice_cubes;
            this.ToolStripMenuItem_Szervezet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Szervezet.Name = "ToolStripMenuItem_Szervezet";
            this.ToolStripMenuItem_Szervezet.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Szervezet.Text = "Szervezet Törzs";
            this.ToolStripMenuItem_Szervezet.Click += new System.EventHandler(this.ToolStripMenuItem_Szervezet_Click);
            // 
            // ToolStripMenuItem_Járandóság
            // 
            this.ToolStripMenuItem_Járandóság.Image = global::Tisztito.Properties.Resources.lista;
            this.ToolStripMenuItem_Járandóság.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Járandóság.Name = "ToolStripMenuItem_Járandóság";
            this.ToolStripMenuItem_Járandóság.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Járandóság.Text = "Járandóság Törzs";
            this.ToolStripMenuItem_Járandóság.Click += new System.EventHandler(this.ToolStripMenuItem_Járandóság_Click);
            // 
            // könyvelésekToolStripMenuItem
            // 
            this.könyvelésekToolStripMenuItem.Enabled = false;
            this.könyvelésekToolStripMenuItem.Image = global::Tisztito.Properties.Resources.App_edit;
            this.könyvelésekToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.könyvelésekToolStripMenuItem.Name = "könyvelésekToolStripMenuItem";
            this.könyvelésekToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.könyvelésekToolStripMenuItem.Text = "&Könyvelések";
            // 
            // lekérdezésekToolStripMenuItem
            // 
            this.lekérdezésekToolStripMenuItem.Enabled = false;
            this.lekérdezésekToolStripMenuItem.Image = global::Tisztito.Properties.Resources.Aha_Soft_Large_Seo_SEO;
            this.lekérdezésekToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lekérdezésekToolStripMenuItem.Name = "lekérdezésekToolStripMenuItem";
            this.lekérdezésekToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.lekérdezésekToolStripMenuItem.Text = "&Lekérdezések";
            // 
            // Képkeret
            // 
            this.Képkeret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Képkeret.Location = new System.Drawing.Point(12, 41);
            this.Képkeret.Name = "Képkeret";
            this.Képkeret.Size = new System.Drawing.Size(776, 397);
            this.Képkeret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Képkeret.TabIndex = 28;
            this.Képkeret.TabStop = false;
            // 
            // Főoldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Képkeret);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Főoldal";
            this.Text = "Humánellátás ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Főoldal_FormClosing);
            this.Load += new System.EventHandler(this.Főoldal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Képkeret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alapAdatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem könyvelésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lekérdezésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Anyag;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Dolgozó;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Szervezet;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Járandóság;
        private System.Windows.Forms.ToolStripMenuItem jogosultságBeállításToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem működésiAdatokToolStripMenuItem;
        internal System.Windows.Forms.PictureBox Képkeret;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

