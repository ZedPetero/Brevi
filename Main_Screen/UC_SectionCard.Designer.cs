namespace AE.Application
{
    partial class UC_SectionCard
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
            lblSectionName = new Krypton.Toolkit.KryptonLabel();
            btnTakeAttendance = new Krypton.Toolkit.KryptonButton();
            btnDeleteSection = new Krypton.Toolkit.KryptonButton();
            lblSubjectName = new Krypton.Toolkit.KryptonLabel();
            lblNumOfStudents = new Krypton.Toolkit.KryptonLabel();
            lblTime = new Krypton.Toolkit.KryptonLabel();
            SuspendLayout();
            // 
            // lblSectionName
            // 
            lblSectionName.Location = new Point(20, 25);
            lblSectionName.Name = "lblSectionName";
            lblSectionName.Size = new Size(90, 25);
            lblSectionName.TabIndex = 0;
            lblSectionName.Values.Text = "kryptonLabel1";
            // 
            // btnTakeAttendance
            // 
            btnTakeAttendance.Location = new Point(168, 112);
            btnTakeAttendance.Name = "btnTakeAttendance";
            btnTakeAttendance.Size = new Size(90, 25);
            btnTakeAttendance.TabIndex = 1;
            btnTakeAttendance.Values.DropDownArrowColor = Color.Empty;
            btnTakeAttendance.Values.Text = "kryptonButton1";
            btnTakeAttendance.Click += btnTakeAttendance_Click_1;
            // 
            // btnDeleteSection
            // 
            btnDeleteSection.Location = new Point(246, 25);
            btnDeleteSection.Name = "btnDeleteSection";
            btnDeleteSection.Size = new Size(37, 25);
            btnDeleteSection.TabIndex = 2;
            btnDeleteSection.Values.DropDownArrowColor = Color.Empty;
            btnDeleteSection.Values.Text = "kryptonButton2";
            // 
            // lblSubjectName
            // 
            lblSubjectName.Location = new Point(20, 56);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(90, 25);
            lblSubjectName.TabIndex = 3;
            lblSubjectName.Values.Text = "kryptonLabel2";
            // 
            // lblNumOfStudents
            // 
            lblNumOfStudents.Location = new Point(20, 112);
            lblNumOfStudents.Name = "lblNumOfStudents";
            lblNumOfStudents.Size = new Size(90, 25);
            lblNumOfStudents.TabIndex = 4;
            lblNumOfStudents.Values.Text = "kryptonLabel3";
            // 
            // lblTime
            // 
            lblTime.Location = new Point(150, 25);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(90, 25);
            lblTime.TabIndex = 5;
            lblTime.Values.Text = "kryptonLabel3";
            // 
            // UC_SectionCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTime);
            Controls.Add(lblNumOfStudents);
            Controls.Add(lblSubjectName);
            Controls.Add(btnDeleteSection);
            Controls.Add(btnTakeAttendance);
            Controls.Add(lblSectionName);
            Name = "UC_SectionCard";
            Size = new Size(300, 175);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonLabel lblSectionName;
        private Krypton.Toolkit.KryptonButton btnTakeAttendance;
        private Krypton.Toolkit.KryptonButton btnDeleteSection;
        private Krypton.Toolkit.KryptonLabel lblSubjectName;
        private Krypton.Toolkit.KryptonLabel lblNumOfStudents;
        private Krypton.Toolkit.KryptonLabel lblTime;
    }
}
