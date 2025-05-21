using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tisztito
{

    public partial class AblakFelhasználó_ : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AblakFelhasználó_));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.WinUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextNév = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Felhasználómásolása = new System.Windows.Forms.Button();
            this.Win_Rögzít = new System.Windows.Forms.Button();
            this.Btnalapjogosultság = new System.Windows.Forms.Button();
            this.BtnVendég = new System.Windows.Forms.Button();
            this.BtnÚjjelszó = new System.Windows.Forms.Button();
            this.BtnDolgozótörlés = new System.Windows.Forms.Button();
            this.BtnÚjdolgozó = new System.Windows.Forms.Button();
            this.BtnSugó = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTip1
            // 
            this.ToolTip1.IsBalloon = true;
            // 
            // WinUser
            // 
            this.WinUser.Location = new System.Drawing.Point(201, 35);
            this.WinUser.MaxLength = 15;
            this.WinUser.Name = "WinUser";
            this.WinUser.Size = new System.Drawing.Size(165, 26);
            this.WinUser.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Windows Felhasználónév:";
            // 
            // TextNév
            // 
            this.TextNév.Location = new System.Drawing.Point(201, 3);
            this.TextNév.MaxLength = 15;
            this.TextNév.Name = "TextNév";
            this.TextNév.Size = new System.Drawing.Size(165, 26);
            this.TextNév.TabIndex = 88;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(124, 20);
            this.Label1.TabIndex = 87;
            this.Label1.Text = "Felhasználónév:";
            // 
            // Felhasználómásolása
            // 
            this.Felhasználómásolása.BackgroundImage = global::Tisztito.Properties.Resources.Document_Copy_01;
            this.Felhasználómásolása.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Felhasználómásolása.Location = new System.Drawing.Point(483, 3);
            this.Felhasználómásolása.Name = "Felhasználómásolása";
            this.Felhasználómásolása.Size = new System.Drawing.Size(50, 50);
            this.Felhasználómásolása.TabIndex = 98;
            this.ToolTip1.SetToolTip(this.Felhasználómásolása, "Kiválaszott felhasználó  jogosultságainak másolása");
            this.Felhasználómásolása.UseVisualStyleBackColor = true;
            // 
            // Win_Rögzít
            // 
            this.Win_Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Win_Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Win_Rögzít.Location = new System.Drawing.Point(3, 3);
            this.Win_Rögzít.Name = "Win_Rögzít";
            this.Win_Rögzít.Size = new System.Drawing.Size(45, 45);
            this.Win_Rögzít.TabIndex = 97;
            this.ToolTip1.SetToolTip(this.Win_Rögzít, "Hozzákötjük a felhasználónévhez  a Windows profilt");
            this.Win_Rögzít.UseVisualStyleBackColor = true;
            // 
            // Btnalapjogosultság
            // 
            this.Btnalapjogosultság.BackgroundImage = global::Tisztito.Properties.Resources.user_mindenjogtöröl;
            this.Btnalapjogosultság.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btnalapjogosultság.Location = new System.Drawing.Point(423, 3);
            this.Btnalapjogosultság.Name = "Btnalapjogosultság";
            this.Btnalapjogosultság.Size = new System.Drawing.Size(50, 50);
            this.Btnalapjogosultság.TabIndex = 94;
            this.ToolTip1.SetToolTip(this.Btnalapjogosultság, "Minden jogosultság törlése");
            this.Btnalapjogosultság.UseVisualStyleBackColor = true;
            // 
            // BtnVendég
            // 
            this.BtnVendég.BackgroundImage = global::Tisztito.Properties.Resources.user_vendég;
            this.BtnVendég.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnVendég.Location = new System.Drawing.Point(363, 3);
            this.BtnVendég.Name = "BtnVendég";
            this.BtnVendég.Size = new System.Drawing.Size(50, 50);
            this.BtnVendég.TabIndex = 93;
            this.ToolTip1.SetToolTip(this.BtnVendég, "Vendég jogosultságainak másolása");
            this.BtnVendég.UseVisualStyleBackColor = true;
            // 
            // BtnÚjjelszó
            // 
            this.BtnÚjjelszó.BackgroundImage = global::Tisztito.Properties.Resources.user_accept_256;
            this.BtnÚjjelszó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnÚjjelszó.Location = new System.Drawing.Point(243, 3);
            this.BtnÚjjelszó.Name = "BtnÚjjelszó";
            this.BtnÚjjelszó.Size = new System.Drawing.Size(50, 50);
            this.BtnÚjjelszó.TabIndex = 92;
            this.ToolTip1.SetToolTip(this.BtnÚjjelszó, "A Jelszó beállítása INIT- re");
            this.BtnÚjjelszó.UseVisualStyleBackColor = true;
            // 
            // BtnDolgozótörlés
            // 
            this.BtnDolgozótörlés.BackgroundImage = global::Tisztito.Properties.Resources.user_remove_256_64;
            this.BtnDolgozótörlés.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDolgozótörlés.Location = new System.Drawing.Point(183, 3);
            this.BtnDolgozótörlés.Name = "BtnDolgozótörlés";
            this.BtnDolgozótörlés.Size = new System.Drawing.Size(50, 50);
            this.BtnDolgozótörlés.TabIndex = 91;
            this.ToolTip1.SetToolTip(this.BtnDolgozótörlés, "Felhasználó törlés");
            this.BtnDolgozótörlés.UseVisualStyleBackColor = true;
            // 
            // BtnÚjdolgozó
            // 
            this.BtnÚjdolgozó.BackgroundImage = global::Tisztito.Properties.Resources.user_add_256;
            this.BtnÚjdolgozó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnÚjdolgozó.Location = new System.Drawing.Point(123, 3);
            this.BtnÚjdolgozó.Name = "BtnÚjdolgozó";
            this.BtnÚjdolgozó.Size = new System.Drawing.Size(50, 50);
            this.BtnÚjdolgozó.TabIndex = 90;
            this.ToolTip1.SetToolTip(this.BtnÚjdolgozó, "Új Felhasználó létrehozása");
            this.BtnÚjdolgozó.UseVisualStyleBackColor = true;
            // 
            // BtnSugó
            // 
            this.BtnSugó.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSugó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.BtnSugó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSugó.Location = new System.Drawing.Point(999, 12);
            this.BtnSugó.Name = "BtnSugó";
            this.BtnSugó.Size = new System.Drawing.Size(45, 45);
            this.BtnSugó.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.BtnSugó, "Online sugó megjelenítése");
            this.BtnSugó.UseVisualStyleBackColor = true;
      
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextNév, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WinUser, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 70);
            this.tableLayoutPanel1.TabIndex = 99;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 9;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Controls.Add(this.Win_Rögzít, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnÚjdolgozó, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnDolgozótörlés, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnÚjjelszó, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnVendég, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.Btnalapjogosultság, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.Felhasználómásolása, 8, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 88);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(539, 68);
            this.tableLayoutPanel3.TabIndex = 101;
            // 
            // AblakFelhasználó
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1056, 495);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.BtnSugó);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AblakFelhasználó";
            this.Text = "Felhasználók karbantartása";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
          
  
          
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal ToolTip ToolTip1;
        internal Button BtnSugó;
        internal Button Felhasználómásolása;
        internal Button Win_Rögzít;
        internal TextBox WinUser;
        internal Label label2;
        internal Button Btnalapjogosultság;
        internal Button BtnVendég;
        internal Button BtnÚjjelszó;
        internal Button BtnDolgozótörlés;
        internal Button BtnÚjdolgozó;
        internal TextBox TextNév;
        internal Label Label1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
    }
}