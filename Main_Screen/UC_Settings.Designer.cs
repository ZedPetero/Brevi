namespace AE.Application
{
    partial class UC_Settings
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
            Label label1;
            label2 = new Label();
            label3 = new Label();
            DarkModeRadioButton = new RadioButton();
            label4 = new Label();
            UsernameView = new TextBox();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            changeusernamebtn = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 15);
            label1.Name = "label1";
            label1.Size = new Size(0, 45);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 6);
            label2.Name = "label2";
            label2.Size = new Size(138, 45);
            label2.TabIndex = 3;
            label2.Text = "Settings";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(14, 90);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 4;
            label3.Text = "Dark Mode";
            label3.Click += label3_Click;
            // 
            // DarkModeRadioButton
            // 
            DarkModeRadioButton.AutoSize = true;
            DarkModeRadioButton.ForeColor = Color.Black;
            DarkModeRadioButton.Location = new Point(111, 96);
            DarkModeRadioButton.Name = "DarkModeRadioButton";
            DarkModeRadioButton.Size = new Size(14, 13);
            DarkModeRadioButton.TabIndex = 5;
            DarkModeRadioButton.TabStop = true;
            DarkModeRadioButton.UseVisualStyleBackColor = true;
            DarkModeRadioButton.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(28, 19);
            label4.Name = "label4";
            label4.Size = new Size(344, 45);
            label4.TabIndex = 6;
            label4.Text = "Account Management";
            label4.Click += label4_Click;
            // 
            // UsernameView
            // 
            UsernameView.Location = new Point(137, 98);
            UsernameView.Name = "UsernameView";
            UsernameView.ReadOnly = true;
            UsernameView.Size = new Size(186, 23);
            UsernameView.TabIndex = 7;
            UsernameView.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(28, 95);
            label5.Name = "label5";
            label5.Size = new Size(103, 25);
            label5.TabIndex = 8;
            label5.Text = "Username:";
            label5.Click += label5_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(40, 164, 153);
            panel1.Controls.Add(changeusernamebtn);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(UsernameView);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(30, 179);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 213);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(40, 164, 153);
            panel2.Controls.Add(DarkModeRadioButton);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(30, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(460, 138);
            panel2.TabIndex = 11;
            panel2.Paint += panel2_Paint;
            // 
            // changeusernamebtn
            // 
            changeusernamebtn.Location = new Point(341, 98);
            changeusernamebtn.Name = "changeusernamebtn";
            changeusernamebtn.Size = new Size(75, 23);
            changeusernamebtn.TabIndex = 9;
            changeusernamebtn.Text = "Change";
            changeusernamebtn.UseVisualStyleBackColor = true;
            changeusernamebtn.Click += changeusernamebtn_Click;
            // 
            // UC_Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_Settings";
            Size = new Size(1150, 640);
            Load += UC_Settings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label3;
        private RadioButton DarkModeRadioButton;
        private Label label4;
        private TextBox UsernameView;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Button changeusernamebtn;
    }
}
