namespace AE.Application
{
    partial class Homepage
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
            kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            pictureBox2 = new PictureBox();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kryptonButton2);
            kryptonPanel1.Controls.Add(kryptonButton1);
            kryptonPanel1.Controls.Add(kryptonBorderEdge1);
            kryptonPanel1.Controls.Add(pictureBox2);
            kryptonPanel1.Dock = DockStyle.Top;
            kryptonPanel1.Location = new Point(0, 0);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.Size = new Size(784, 66);
            kryptonPanel1.StateCommon.Color1 = Color.FromArgb(249, 250, 251);
            kryptonPanel1.StateNormal.Color1 = Color.FromArgb(250, 250, 250);
            kryptonPanel1.StateNormal.Color2 = Color.FromArgb(250, 250, 250);
            kryptonPanel1.TabIndex = 1;
            // 
            // kryptonButton2
            // 
            kryptonButton2.CausesValidation = false;
            kryptonButton2.Location = new Point(561, 3);
            kryptonButton2.Name = "kryptonButton2";
            kryptonButton2.Size = new Size(107, 58);
            kryptonButton2.StateCommon.Border.Rounding = 20F;
            kryptonButton2.StateCommon.Content.ShortText.Color1 = Color.FromArgb(29, 37, 48);
            kryptonButton2.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonButton2.StateNormal.Back.Color1 = Color.White;
            kryptonButton2.StateNormal.Back.Color2 = Color.White;
            kryptonButton2.StateNormal.Border.Color1 = SystemColors.ActiveCaption;
            kryptonButton2.TabIndex = 3;
            kryptonButton2.Values.DropDownArrowColor = Color.Empty;
            kryptonButton2.Values.Text = "Login";
            // 
            // kryptonButton1
            // 
            kryptonButton1.CausesValidation = false;
            kryptonButton1.Location = new Point(674, 3);
            kryptonButton1.Name = "kryptonButton1";
            kryptonButton1.Size = new Size(107, 58);
            kryptonButton1.StateCommon.Border.Rounding = 20F;
            kryptonButton1.StateCommon.Content.ShortText.Color1 = Color.White;
            kryptonButton1.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonButton1.StateNormal.Back.Color1 = Color.FromArgb(39, 165, 153);
            kryptonButton1.StateNormal.Back.Color2 = Color.FromArgb(39, 165, 153);
            kryptonButton1.TabIndex = 2;
            kryptonButton1.Values.DropDownArrowColor = Color.Empty;
            kryptonButton1.Values.Text = "Sign Up";
            kryptonButton1.Click += kryptonButton1_Click;
            // 
            // kryptonBorderEdge1
            // 
            kryptonBorderEdge1.Dock = DockStyle.Bottom;
            kryptonBorderEdge1.Location = new Point(0, 64);
            kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            kryptonBorderEdge1.Size = new Size(784, 2);
            kryptonBorderEdge1.StateCommon.Color1 = Color.FromArgb(224, 230, 235);
            kryptonBorderEdge1.StateCommon.Width = 2;
            kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Logo_Name_only;
            pictureBox2.Location = new Point(-96, -27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(375, 119);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(352, 104);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(406, 300);
            kryptonLabel2.StateCommon.Image.ImageH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            kryptonLabel2.StateCommon.Image.ImageV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            kryptonLabel2.StateCommon.LongText.Image = Properties.Resources.homepageimg;
            kryptonLabel2.StateCommon.ShortText.Image = Properties.Resources.homepageimg;
            kryptonLabel2.TabIndex = 5;
            kryptonLabel2.Values.Image = Properties.Resources.resized_400x298;
            kryptonLabel2.Values.Text = "";
            kryptonLabel2.Click += kryptonLabel2_Click;
            // 
            // kryptonButton3
            // 
            kryptonButton3.CausesValidation = false;
            kryptonButton3.Location = new Point(67, 286);
            kryptonButton3.Name = "kryptonButton3";
            kryptonButton3.Size = new Size(155, 58);
            kryptonButton3.StateCommon.Border.Rounding = 20F;
            kryptonButton3.StateCommon.Content.LongText.Color1 = Color.White;
            kryptonButton3.StateCommon.Content.LongText.Color2 = Color.White;
            kryptonButton3.StateCommon.Content.LongText.Font = new Font("Material Symbols Sharp", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kryptonButton3.StateCommon.Content.ShortText.Color1 = Color.White;
            kryptonButton3.StateCommon.Content.ShortText.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kryptonButton3.StateNormal.Back.Color1 = Color.FromArgb(39, 165, 153);
            kryptonButton3.StateNormal.Back.Color2 = Color.FromArgb(39, 165, 153);
            kryptonButton3.TabIndex = 5;
            kryptonButton3.Values.DropDownArrowColor = Color.Empty;
            kryptonButton3.Values.ExtraText = "";
            kryptonButton3.Values.Text = "Get Started";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Logo_Name_with_Motto_removebg_preview;
            pictureBox1.Location = new Point(0, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            ClientSize = new Size(784, 461);
            Controls.Add(kryptonButton3);
            Controls.Add(kryptonLabel2);
            Controls.Add(kryptonPanel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Homepage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Homepage";
            Load += Homepage_Load;
            ((System.ComponentModel.ISupportInitialize)kryptonPanel1).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}