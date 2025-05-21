using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tisztito
{

    public partial class AblakFelhasználó : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AblakFelhasználó));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Win_Rögzít = new System.Windows.Forms.Button();
            this.BtnSugó = new System.Windows.Forms.Button();
            this.WinUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextNév = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Tábla = new Zuby.ADGV.AdvancedDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolTip1
            // 
            this.ToolTip1.IsBalloon = true;
            // 
            // Win_Rögzít
            // 
            this.Win_Rögzít.BackgroundImage = global::Tisztito.Properties.Resources.Ok_gyűjtemény;
            this.Win_Rögzít.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Win_Rögzít.Location = new System.Drawing.Point(688, 12);
            this.Win_Rögzít.Name = "Win_Rögzít";
            this.Win_Rögzít.Size = new System.Drawing.Size(45, 45);
            this.Win_Rögzít.TabIndex = 97;
            this.ToolTip1.SetToolTip(this.Win_Rögzít, "Hozzákötjük a felhasználónévhez  a Windows profilt");
            this.Win_Rögzít.UseVisualStyleBackColor = true;
            // 
            // BtnSugó
            // 
            this.BtnSugó.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSugó.BackgroundImage = global::Tisztito.Properties.Resources.Help_Support;
            this.BtnSugó.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSugó.Location = new System.Drawing.Point(827, 12);
            this.BtnSugó.Name = "BtnSugó";
            this.BtnSugó.Size = new System.Drawing.Size(45, 45);
            this.BtnSugó.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.BtnSugó, "Online sugó megjelenítése");
            this.BtnSugó.UseVisualStyleBackColor = true;
            this.BtnSugó.Click += new System.EventHandler(this.BtnSugó_Click);
            // 
            // WinUser
            // 
            this.WinUser.Location = new System.Drawing.Point(201, 38);
            this.WinUser.MaxLength = 15;
            this.WinUser.Name = "WinUser";
            this.WinUser.Size = new System.Drawing.Size(165, 26);
            this.WinUser.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextNév, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WinUser, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 181);
            this.tableLayoutPanel1.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "Dolgozó szám";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 98;
            this.label4.Text = "Dolgozó név:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(201, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 28);
            this.comboBox1.TabIndex = 99;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(201, 108);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(459, 28);
            this.comboBox2.TabIndex = 100;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(201, 143);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 24);
            this.checkBox1.TabIndex = 101;
            this.checkBox1.Text = "Törölt";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // Tábla
            // 
            this.Tábla.AllowUserToAddRows = false;
            this.Tábla.AllowUserToDeleteRows = false;
            this.Tábla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tábla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tábla.FilterAndSortEnabled = true;
            this.Tábla.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.Location = new System.Drawing.Point(12, 203);
            this.Tábla.MaxFilterButtonImageHeight = 23;
            this.Tábla.Name = "Tábla";
            this.Tábla.ReadOnly = true;
            this.Tábla.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tábla.Size = new System.Drawing.Size(860, 280);
            this.Tábla.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.Tábla.TabIndex = 221;
            // 
            // AblakFelhasználó
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(884, 495);
            this.Controls.Add(this.Tábla);
            this.Controls.Add(this.Win_Rögzít);
            this.Controls.Add(this.BtnSugó);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AblakFelhasználó";
            this.Text = "Felhasználók karbantartása";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      
            this.Load += new System.EventHandler(this.AblakFelhasználó_Load);
     
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tábla)).EndInit();
            this.ResumeLayout(false);

        }
        internal ToolTip ToolTip1;
        internal Button BtnSugó;
        internal Button Win_Rögzít;
        internal TextBox WinUser;
        internal Label label2;
        internal TextBox TextNév;
        internal Label Label1;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboBox2;
        internal Label label3;
        internal Label label4;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private Zuby.ADGV.AdvancedDataGridView Tábla;
    }
}