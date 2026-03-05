using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UC_SectionCard : UserControl
    {
        public int SectionId { get; private set; }
        public event EventHandler<int> TakeAttendanceClicked;
        public UC_SectionCard()
        {
            InitializeComponent();
        }
        public void SetData(int sectionId, string sectionName, string subject, int studentCount, string timeSchedule)
        {
            SectionId = sectionId;
            lblSectionName.Text = sectionName;
            lblSubjectName.Text = subject;
            lblNumOfStudents.Text = $"{studentCount} students";
            lblTime.Text = timeSchedule;
        }
        private void btnTakeAttendance_Click_1(object sender, EventArgs e)
        {
            TakeAttendanceClicked?.Invoke(this, SectionId);
        }
    }
}
