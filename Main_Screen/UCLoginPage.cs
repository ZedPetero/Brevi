using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UCLoginPage : UserControl
    {
        public UCLoginPage()
        {
            InitializeComponent();
            UIHelper.RoundControl(panel1, 15);
        }
    }
}
