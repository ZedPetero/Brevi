namespace AE.Application
{
    partial class UCInteractionPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            kryptonButton7 = new Krypton.Toolkit.KryptonButton();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImage = Properties.Resources.homepageimg;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(471, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(569, 420);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // kryptonButton7
            // 
            kryptonButton7.Anchor = AnchorStyles.None;
            kryptonButton7.AutoSize = true;
            kryptonButton7.Location = new Point(161, 353);
            kryptonButton7.Name = "kryptonButton7";
            kryptonButton7.Size = new Size(100, 40);
            kryptonButton7.TabIndex = 8;
            kryptonButton7.Values.DropDownArrowColor = Color.Empty;
            kryptonButton7.Values.Text = "Start Now ->";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Anchor = AnchorStyles.None;
            kryptonLabel3.Location = new Point(150, 299);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(283, 35);
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Inter", 18F);
            kryptonLabel3.TabIndex = 7;
            kryptonLabel3.Values.Text = "Your Presence Matters";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Anchor = AnchorStyles.None;
            kryptonLabel2.Location = new Point(144, 206);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(204, 74);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Inter", 40F, FontStyle.Bold);
            kryptonLabel2.TabIndex = 6;
            kryptonLabel2.Values.Text = "Korum";
            // 
            // UCInteractionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(kryptonButton7);
            Controls.Add(kryptonLabel3);
            Controls.Add(kryptonLabel2);
            Name = "UCInteractionPage";
            Size = new Size(1184, 599);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Krypton.Toolkit.KryptonButton kryptonButton7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}
