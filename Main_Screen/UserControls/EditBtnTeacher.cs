using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application.UserControls
{
    public partial class EditBtnTeacher : UserControl
    {
        public EditBtnTeacher()
        {
            InitializeComponent();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            UC_Teacher teacher = new UC_Teacher();
            teacher.ToEditTeacher();
        }
    }
}
