using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UC_Teacher : UserControl
    {
        public UC_Teacher()
        {
            InitializeComponent();
            UCTeacherProfile teacherProfile = new UCTeacherProfile();
            LoadForm(teacherProfile);
        }

        public void LoadForm(UserControl customizedControl)
        {
            panelTeacherProfile.Controls.Clear();
            customizedControl.Dock = DockStyle.Fill;
            panelTeacherProfile.Controls.Add(customizedControl);
            panelTeacherProfile.SendToBack();
        }

        public void ToTeacherProfile()
        {
            UCTeacherProfile teacherProfile = new UCTeacherProfile();
            LoadForm(teacherProfile);
        }

        public void ToEditTeacher()
        {
            UCEditTeacher editTeacher = new UCEditTeacher();
            LoadForm(editTeacher);
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
        }
    }
}
