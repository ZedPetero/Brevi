namespace AE.Application
{
    partial class UC_Classes
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
            panel1 = new Panel();
            flowLayoutPanelCards = new FlowLayoutPanel();
            btnAddClass = new Syncfusion.WinForms.Controls.SfButton();
            label2 = new Label();
            lblTeacher = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanelCards);
            panel1.Controls.Add(btnAddClass);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblTeacher);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 640);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanelCards
            // 
            flowLayoutPanelCards.AutoScroll = true;
            flowLayoutPanelCards.Location = new Point(43, 179);
            flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            flowLayoutPanelCards.Size = new Size(1038, 421);
            flowLayoutPanelCards.TabIndex = 4;
            // 
            // btnAddClass
            // 
            btnAddClass.Font = new Font("Segoe UI Semibold", 9F);
            btnAddClass.ForeColor = Color.Black;
            btnAddClass.Location = new Point(985, 103);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(96, 28);
            btnAddClass.Style.ForeColor = Color.Black;
            btnAddClass.TabIndex = 3;
            btnAddClass.Text = "Add Class+";
            btnAddClass.Click += btnAddClass_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(43, 101);
            label2.Name = "label2";
            label2.Size = new Size(82, 30);
            label2.TabIndex = 1;
            label2.Text = "Classes";
            // 
            // lblTeacher
            // 
            lblTeacher.AutoSize = true;
            lblTeacher.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTeacher.Location = new Point(36, 38);
            lblTeacher.Name = "lblTeacher";
            lblTeacher.Size = new Size(242, 45);
            lblTeacher.TabIndex = 0;
            lblTeacher.Text = "Hello, Teacher!";
            // 
            // UC_Classes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Name = "UC_Classes";
            Size = new Size(1150, 640);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTeacher;
        private Label label2;
        private Syncfusion.WinForms.Controls.SfButton btnAddClass;
        private FlowLayoutPanel flowLayoutPanelCards;
    }
}
