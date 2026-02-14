using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UC_StudentRow : UserControl
    {
        public UC_StudentRow()
        {
            InitializeComponent();
        }

        private void UC_StudentRow_Load(object sender, EventArgs e)
        {
            UIHelper.RoundControl(this, 20);
            UIHelper.RoundControl(lblNumber, 18);
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    UIHelper.RoundControl(c, 5);
                }
            }
        }
    }
}
