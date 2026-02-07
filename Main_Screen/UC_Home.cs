using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Main_Screen;
namespace Main_Screen
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
            UIHelper.RoundControl(this.btnGetStarted, 20);
        }

        private void btnGetStarted_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.FindForm();
            if (mainForm != null) 
            {
                UC_Classes myClasses = new UC_Classes();
                mainForm.loadForm(myClasses);
            }
        }
    }
}
