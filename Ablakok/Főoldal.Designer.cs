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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AblakokBeállításaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GombokBeállításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FelhasználókMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JogKiosztMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.működésiAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alapAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Anyag = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Dolgozó = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Szervezet = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Járandóság = new System.Windows.Forms.ToolStripMenuItem();
            this.könyvelésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raktárakKözöttiKönyvelésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.készletSelejtezésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DolgozóiKiadásMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lekérdezésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.területiIgényekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KiosztásiNyomtatványMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LekérdezésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dolgozóiLekérdezésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Verzió_Váltás = new System.Windows.Forms.Button();
            this.Menükinyitás = new System.Windows.Forms.Button();
            this.Képkeret = new System.Windows.Forms.PictureBox();
            this.Rejtett = new System.Windows.Forms.GroupBox();
            this.TároltVerzió = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Figyelmeztetés = new System.Windows.Forms.Label();
            this.BizonylatMenu = new System.Windows.Forms.ToolStripSeparator();
            this.BizonylatMenü = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Képkeret)).BeginInit();
            this.Rejtett.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beállításokToolStripMenuItem,
            this.alapAdatokToolStripMenuItem,
            this.könyvelésekToolStripMenuItem,
            this.lekérdezésekToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MenuStrip.Size = new System.Drawing.Size(656, 30);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDoubleClick);
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AblakokBeállításaMenuItem,
            this.GombokBeállításaToolStripMenuItem,
            this.toolStripSeparator1,
            this.FelhasználókMenuItem,
            this.JogKiosztMenuItem,
            this.toolStripSeparator2,
            this.működésiAdatokToolStripMenuItem});
            this.beállításokToolStripMenuItem.Image = global::Tisztito.Properties.Resources.Action_configure;
            this.beállításokToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.beállításokToolStripMenuItem.Text = "&Beállítások";
            // 
            // AblakokBeállításaMenuItem
            // 
            this.AblakokBeállításaMenuItem.Name = "AblakokBeállításaMenuItem";
            this.AblakokBeállításaMenuItem.Size = new System.Drawing.Size(311, 24);
            this.AblakokBeállításaMenuItem.Text = "Ablakok beállítása";
            this.AblakokBeállításaMenuItem.Click += new System.EventHandler(this.AblakokBeállításaMenuItem_Click);
            // 
            // GombokBeállításaToolStripMenuItem
            // 
            this.GombokBeállításaToolStripMenuItem.Name = "GombokBeállításaToolStripMenuItem";
            this.GombokBeállításaToolStripMenuItem.Size = new System.Drawing.Size(311, 24);
            this.GombokBeállításaToolStripMenuItem.Text = "Gombok beállítása";
            this.GombokBeállításaToolStripMenuItem.Click += new System.EventHandler(this.GombokBeállításaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // FelhasználókMenuItem
            // 
            this.FelhasználókMenuItem.Name = "FelhasználókMenuItem";
            this.FelhasználókMenuItem.Size = new System.Drawing.Size(311, 24);
            this.FelhasználókMenuItem.Text = "Felhasználók létrehozása törlése";
            this.FelhasználókMenuItem.Click += new System.EventHandler(this.FelhasználókMenuItem_Click);
            // 
            // JogKiosztMenuItem
            // 
            this.JogKiosztMenuItem.Name = "JogKiosztMenuItem";
            this.JogKiosztMenuItem.Size = new System.Drawing.Size(311, 24);
            this.JogKiosztMenuItem.Text = "Jogosultság kiosztás";
            this.JogKiosztMenuItem.Click += new System.EventHandler(this.JogKiosztMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(308, 6);
            // 
            // működésiAdatokToolStripMenuItem
            // 
            this.működésiAdatokToolStripMenuItem.Name = "működésiAdatokToolStripMenuItem";
            this.működésiAdatokToolStripMenuItem.Size = new System.Drawing.Size(311, 24);
            this.működésiAdatokToolStripMenuItem.Text = "&Működési Adatok";
            this.működésiAdatokToolStripMenuItem.Click += new System.EventHandler(this.MűködésiAdatokToolStripMenuItem_Click);
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
            this.alapAdatokToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.alapAdatokToolStripMenuItem.Text = "&Alap adatok";
            // 
            // ToolStripMenuItem_Anyag
            // 
            this.ToolStripMenuItem_Anyag.Image = global::Tisztito.Properties.Resources.App_warehause;
            this.ToolStripMenuItem_Anyag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Anyag.Name = "ToolStripMenuItem_Anyag";
            this.ToolStripMenuItem_Anyag.Size = new System.Drawing.Size(205, 24);
            this.ToolStripMenuItem_Anyag.Text = "Anyag törzs";
            this.ToolStripMenuItem_Anyag.Click += new System.EventHandler(this.ToolStripMenuItem_Anyag_Click);
            // 
            // ToolStripMenuItem_Dolgozó
            // 
            this.ToolStripMenuItem_Dolgozó.Image = global::Tisztito.Properties.Resources.community_users;
            this.ToolStripMenuItem_Dolgozó.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Dolgozó.Name = "ToolStripMenuItem_Dolgozó";
            this.ToolStripMenuItem_Dolgozó.Size = new System.Drawing.Size(205, 24);
            this.ToolStripMenuItem_Dolgozó.Text = "Dolgozó Törzs";
            this.ToolStripMenuItem_Dolgozó.Click += new System.EventHandler(this.ToolStripMenuItem_Dolgozó_Click);
            // 
            // ToolStripMenuItem_Szervezet
            // 
            this.ToolStripMenuItem_Szervezet.Image = global::Tisztito.Properties.Resources.Filesystem_blockdevice_cubes;
            this.ToolStripMenuItem_Szervezet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Szervezet.Name = "ToolStripMenuItem_Szervezet";
            this.ToolStripMenuItem_Szervezet.Size = new System.Drawing.Size(205, 24);
            this.ToolStripMenuItem_Szervezet.Text = "Szervezet Törzs";
            this.ToolStripMenuItem_Szervezet.Click += new System.EventHandler(this.ToolStripMenuItem_Szervezet_Click);
            // 
            // ToolStripMenuItem_Járandóság
            // 
            this.ToolStripMenuItem_Járandóság.Image = global::Tisztito.Properties.Resources.lista;
            this.ToolStripMenuItem_Járandóság.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripMenuItem_Járandóság.Name = "ToolStripMenuItem_Járandóság";
            this.ToolStripMenuItem_Járandóság.Size = new System.Drawing.Size(205, 24);
            this.ToolStripMenuItem_Járandóság.Text = "Járandóság Törzs";
            this.ToolStripMenuItem_Járandóság.Click += new System.EventHandler(this.ToolStripMenuItem_Járandóság_Click);
            // 
            // könyvelésekToolStripMenuItem
            // 
            this.könyvelésekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raktárakKözöttiKönyvelésToolStripMenuItem,
            this.készletSelejtezésToolStripMenuItem,
            this.BizonylatMenu,
            this.BizonylatMenü,
            this.toolStripSeparator3,
            this.DolgozóiKiadásMenuItem});
            this.könyvelésekToolStripMenuItem.Image = global::Tisztito.Properties.Resources.App_edit;
            this.könyvelésekToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.könyvelésekToolStripMenuItem.Name = "könyvelésekToolStripMenuItem";
            this.könyvelésekToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.könyvelésekToolStripMenuItem.Text = "&Könyvelések";
            // 
            // raktárakKözöttiKönyvelésToolStripMenuItem
            // 
            this.raktárakKözöttiKönyvelésToolStripMenuItem.Name = "raktárakKözöttiKönyvelésToolStripMenuItem";
            this.raktárakKözöttiKönyvelésToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.raktárakKözöttiKönyvelésToolStripMenuItem.Text = "&Raktárak közötti könyvelés";
            this.raktárakKözöttiKönyvelésToolStripMenuItem.Click += new System.EventHandler(this.RaktárakKözöttiKönyvelésToolStripMenuItem_Click);
            // 
            // készletSelejtezésToolStripMenuItem
            // 
            this.készletSelejtezésToolStripMenuItem.Name = "készletSelejtezésToolStripMenuItem";
            this.készletSelejtezésToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.készletSelejtezésToolStripMenuItem.Text = "Készlet selejtezés";
            this.készletSelejtezésToolStripMenuItem.Click += new System.EventHandler(this.KészletSelejtezésToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(264, 6);
            // 
            // DolgozóiKiadásMenuItem
            // 
            this.DolgozóiKiadásMenuItem.Name = "DolgozóiKiadásMenuItem";
            this.DolgozóiKiadásMenuItem.Size = new System.Drawing.Size(267, 24);
            this.DolgozóiKiadásMenuItem.Text = "&Dolgozói Kiadás";
            this.DolgozóiKiadásMenuItem.Click += new System.EventHandler(this.DolgozóiKiadásMenuItem_Click);
            // 
            // lekérdezésekToolStripMenuItem
            // 
            this.lekérdezésekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.területiIgényekToolStripMenuItem,
            this.KiosztásiNyomtatványMenuItem,
            this.LekérdezésToolStripMenuItem,
            this.dolgozóiLekérdezésekToolStripMenuItem});
            this.lekérdezésekToolStripMenuItem.Image = global::Tisztito.Properties.Resources.Aha_Soft_Large_Seo_SEO;
            this.lekérdezésekToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lekérdezésekToolStripMenuItem.Name = "lekérdezésekToolStripMenuItem";
            this.lekérdezésekToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.lekérdezésekToolStripMenuItem.Text = "&Lekérdezések";
            // 
            // területiIgényekToolStripMenuItem
            // 
            this.területiIgényekToolStripMenuItem.Image = global::Tisztito.Properties.Resources.App_spreadsheet;
            this.területiIgényekToolStripMenuItem.Name = "területiIgényekToolStripMenuItem";
            this.területiIgényekToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.területiIgényekToolStripMenuItem.Text = "Területi igények";
            this.területiIgényekToolStripMenuItem.Click += new System.EventHandler(this.TerületiIgényekToolStripMenuItem_Click);
            // 
            // KiosztásiNyomtatványMenuItem
            // 
            this.KiosztásiNyomtatványMenuItem.Name = "KiosztásiNyomtatványMenuItem";
            this.KiosztásiNyomtatványMenuItem.Size = new System.Drawing.Size(271, 24);
            this.KiosztásiNyomtatványMenuItem.Text = "Kiosztási Nyomtatvány";
            this.KiosztásiNyomtatványMenuItem.Click += new System.EventHandler(this.KiosztásiNyomtatványMenuItem_Click);
            // 
            // LekérdezésToolStripMenuItem
            // 
            this.LekérdezésToolStripMenuItem.Name = "LekérdezésToolStripMenuItem";
            this.LekérdezésToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.LekérdezésToolStripMenuItem.Text = "Raktár készlet Lekérdezés ";
            this.LekérdezésToolStripMenuItem.Click += new System.EventHandler(this.LekérdezésToolStripMenuItem_Click);
            // 
            // dolgozóiLekérdezésekToolStripMenuItem
            // 
            this.dolgozóiLekérdezésekToolStripMenuItem.Name = "dolgozóiLekérdezésekToolStripMenuItem";
            this.dolgozóiLekérdezésekToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.dolgozóiLekérdezésekToolStripMenuItem.Text = "Dolgozói Lekérdezések";
            this.dolgozóiLekérdezésekToolStripMenuItem.Click += new System.EventHandler(this.DolgozóiLekérdezésekToolStripMenuItem_Click);
            // 
            // Verzió_Váltás
            // 
            this.Verzió_Váltás.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Verzió_Váltás.Image = global::Tisztito.Properties.Resources.frissít_gyűjtemény;
            this.Verzió_Váltás.Location = new System.Drawing.Point(338, 23);
            this.Verzió_Váltás.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Verzió_Váltás.Name = "Verzió_Váltás";
            this.Verzió_Váltás.Size = new System.Drawing.Size(45, 45);
            this.Verzió_Váltás.TabIndex = 26;
            this.toolTip1.SetToolTip(this.Verzió_Váltás, "Aktuális verziót állítja be a verzió számnak");
            this.Verzió_Váltás.UseVisualStyleBackColor = true;
            this.Verzió_Váltás.Click += new System.EventHandler(this.Verzió_Váltás_Click);
            // 
            // Menükinyitás
            // 
            this.Menükinyitás.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menükinyitás.Image = global::Tisztito.Properties.Resources.Filesystem_blockdevice_cubes;
            this.Menükinyitás.Location = new System.Drawing.Point(409, 23);
            this.Menükinyitás.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Menükinyitás.Name = "Menükinyitás";
            this.Menükinyitás.Size = new System.Drawing.Size(45, 45);
            this.Menükinyitás.TabIndex = 29;
            this.toolTip1.SetToolTip(this.Menükinyitás, "Admin felület");
            this.Menükinyitás.UseVisualStyleBackColor = true;
            this.Menükinyitás.Click += new System.EventHandler(this.Menükinyitás_Click);
            // 
            // Képkeret
            // 
            this.Képkeret.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Képkeret.Image = global::Tisztito.Properties.Resources.BKV_háttér;
            this.Képkeret.Location = new System.Drawing.Point(0, 27);
            this.Képkeret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Képkeret.Name = "Képkeret";
            this.Képkeret.Size = new System.Drawing.Size(656, 272);
            this.Képkeret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Képkeret.TabIndex = 28;
            this.Képkeret.TabStop = false;
            // 
            // Rejtett
            // 
            this.Rejtett.BackColor = System.Drawing.Color.Peru;
            this.Rejtett.Controls.Add(this.Menükinyitás);
            this.Rejtett.Controls.Add(this.TároltVerzió);
            this.Rejtett.Controls.Add(this.Label5);
            this.Rejtett.Controls.Add(this.Verzió_Váltás);
            this.Rejtett.Location = new System.Drawing.Point(13, 134);
            this.Rejtett.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rejtett.Name = "Rejtett";
            this.Rejtett.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rejtett.Size = new System.Drawing.Size(473, 84);
            this.Rejtett.TabIndex = 30;
            this.Rejtett.TabStop = false;
            this.Rejtett.Visible = false;
            // 
            // TároltVerzió
            // 
            this.TároltVerzió.Location = new System.Drawing.Point(160, 23);
            this.TároltVerzió.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TároltVerzió.Name = "TároltVerzió";
            this.TároltVerzió.Size = new System.Drawing.Size(148, 26);
            this.TároltVerzió.TabIndex = 28;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Label5.Location = new System.Drawing.Point(8, 29);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(144, 20);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Tárolt Verzió szám:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Figyelmeztetés
            // 
            this.Figyelmeztetés.BackColor = System.Drawing.Color.LightSalmon;
            this.Figyelmeztetés.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Figyelmeztetés.Location = new System.Drawing.Point(12, 43);
            this.Figyelmeztetés.Name = "Figyelmeztetés";
            this.Figyelmeztetés.Size = new System.Drawing.Size(136, 86);
            this.Figyelmeztetés.TabIndex = 31;
            this.Figyelmeztetés.Text = "A program karbantartás miatt ki fogja léptetni!";
            this.Figyelmeztetés.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Figyelmeztetés.Visible = false;
            // 
            // BizonylatMenu
            // 
            this.BizonylatMenu.Name = "BizonylatMenu";
            this.BizonylatMenu.Size = new System.Drawing.Size(264, 6);
            // 
            // BizonylatMenü
            // 
            this.BizonylatMenü.Name = "BizonylatMenü";
            this.BizonylatMenü.Size = new System.Drawing.Size(267, 24);
            this.BizonylatMenü.Text = "Bizonylat nyomtatás";
            this.BizonylatMenü.Click += new System.EventHandler(this.BizonylatMenü_Click);
            // 
            // Főoldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(656, 299);
            this.Controls.Add(this.Figyelmeztetés);
            this.Controls.Add(this.Rejtett);
            this.Controls.Add(this.Képkeret);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Főoldal";
            this.Text = "Humánellátás ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Főoldal_FormClosing);
            this.Load += new System.EventHandler(this.Főoldal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AblakFőoldal_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AblakFőoldal_KeyUp);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Képkeret)).EndInit();
            this.Rejtett.ResumeLayout(false);
            this.Rejtett.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alapAdatokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem könyvelésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lekérdezésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Anyag;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Dolgozó;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Szervezet;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Járandóság;
        private System.Windows.Forms.ToolStripMenuItem működésiAdatokToolStripMenuItem;
        internal System.Windows.Forms.PictureBox Képkeret;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem területiIgényekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raktárakKözöttiKönyvelésToolStripMenuItem;
        internal System.Windows.Forms.GroupBox Rejtett;
        internal System.Windows.Forms.Button Menükinyitás;
        internal System.Windows.Forms.TextBox TároltVerzió;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button Verzió_Váltás;
        private System.Windows.Forms.ToolStripMenuItem DolgozóiKiadásMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AblakokBeállításaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GombokBeállításaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem FelhasználókMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JogKiosztMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label Figyelmeztetés;
        private System.Windows.Forms.ToolStripMenuItem KiosztásiNyomtatványMenuItem;
        private System.Windows.Forms.ToolStripMenuItem készletSelejtezésToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem LekérdezésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dolgozóiLekérdezésekToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator BizonylatMenu;
        private System.Windows.Forms.ToolStripMenuItem BizonylatMenü;
    }
}

