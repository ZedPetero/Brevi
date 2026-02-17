using System;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class ChangeUsernameForm : Form
    {
        public string NewUsername { get; private set; }

        public ChangeUsernameForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            NewUsername = txtNewUsername.Text?.Trim();
            if (string.IsNullOrEmpty(NewUsername))
            {
                MessageBox.Show("Please enter a username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
