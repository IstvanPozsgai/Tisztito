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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alapAdatokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.könyvelésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lekérdezésekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Anyag = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Dolgozó = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Szervezet = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Járandóság = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.beállításokToolStripMenuItem.Text = "Beállítások";
            // 
            // alapAdatokToolStripMenuItem
            // 
            this.alapAdatokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Anyag,
            this.ToolStripMenuItem_Dolgozó,
            this.ToolStripMenuItem_Szervezet,
            this.ToolStripMenuItem_Járandóság});
            this.alapAdatokToolStripMenuItem.Name = "alapAdatokToolStripMenuItem";
            this.alapAdatokToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.alapAdatokToolStripMenuItem.Text = "Alap adatok";
            // 
            // könyvelésekToolStripMenuItem
            // 
            this.könyvelésekToolStripMenuItem.Name = "könyvelésekToolStripMenuItem";
            this.könyvelésekToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.könyvelésekToolStripMenuItem.Text = "Könyvelések";
            // 
            // lekérdezésekToolStripMenuItem
            // 
            this.lekérdezésekToolStripMenuItem.Name = "lekérdezésekToolStripMenuItem";
            this.lekérdezésekToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.lekérdezésekToolStripMenuItem.Text = "Lekérdezések";
            // 
            // ToolStripMenuItem_Anyag
            // 
            this.ToolStripMenuItem_Anyag.Name = "ToolStripMenuItem_Anyag";
            this.ToolStripMenuItem_Anyag.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Anyag.Text = "Anyag törzs";
            this.ToolStripMenuItem_Anyag.Click += new System.EventHandler(this.ToolStripMenuItem_Anyag_Click);
            // 
            // ToolStripMenuItem_Dolgozó
            // 
            this.ToolStripMenuItem_Dolgozó.Name = "ToolStripMenuItem_Dolgozó";
            this.ToolStripMenuItem_Dolgozó.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Dolgozó.Text = "Dolgozó Törzs";
            // 
            // ToolStripMenuItem_Szervezet
            // 
            this.ToolStripMenuItem_Szervezet.Name = "ToolStripMenuItem_Szervezet";
            this.ToolStripMenuItem_Szervezet.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Szervezet.Text = "Szervezet Törzs";
            // 
            // ToolStripMenuItem_Járandóság
            // 
            this.ToolStripMenuItem_Járandóság.Name = "ToolStripMenuItem_Járandóság";
            this.ToolStripMenuItem_Járandóság.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Járandóság.Text = "Járandóság Törzs";
            // 
            // Főoldal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Főoldal";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Főoldal_FormClosing);
            this.Load += new System.EventHandler(this.Főoldal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

