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
            UIHelper.RoundControl(kryptonPanel1, 20);
        }

        private void UC_Teacher_Load(object sender, EventArgs e)
        {

        }
    }
}
