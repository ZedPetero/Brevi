using AE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application.UserControls
{
    public partial class SaveBtnTeacher : UserControl
    {
        public SaveBtnTeacher()
        {
            InitializeComponent();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            UC_Teacher teacher = new UC_Teacher();
            teacher.ToTeacherProfile();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            
        }
    }
}
