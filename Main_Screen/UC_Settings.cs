using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
        }

        // Event handler stubs referenced by the designer
        private void UC_Settings_Load(object sender, EventArgs e)
        {
            // Initialize radio button state from ThemeManager
            try
            {
                DarkModeRadioButton.Checked = ThemeManager.IsDarkMode;
            }
            catch
            {
                // ignore if control not available during design time
            }

            // Load username from database and display
            try
            {
                using var db = new AE.Infrastructure.Data.AppDbContext();
                var setting = db.AppSettings.Find("Username");
                if (setting != null)
                {
                    UsernameView.Text = setting.Value;
                }
                else
                {
                    UsernameView.Text = "";
                }
            }
            catch
            {
                // ignore DB errors at design time
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Intentionally left blank or implement click logic here
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Intentionally left blank or implement click logic here
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle dark mode when radio button changes
            bool enabled = false;
            try
            {
                if (sender is RadioButton rb)
                    enabled = rb.Checked;
                else
                    enabled = DarkModeRadioButton.Checked;
            }
            catch
            {
                enabled = DarkModeRadioButton.Checked;
            }

            ThemeManager.SetDarkMode(enabled);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.RoundControl(panel1, 20);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            UIHelper.RoundControl(panel2, 20);
        }

        private void changeusernamebtn_Click(object sender, EventArgs e)
        {
            using var dlg = new ChangeUsernameForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string newUsername = dlg.NewUsername;
                try
                {
                    using var db = new AE.Infrastructure.Data.AppDbContext();
                    var setting = db.AppSettings.Find("Username");
                    if (setting == null)
                    {
                        setting = new AE.Domain.Models.AppSetting { Key = "Username", Value = newUsername };
                        db.AppSettings.Add(setting);
                    }
                    else
                    {
                        setting.Value = newUsername;
                        db.AppSettings.Update(setting);
                    }
                    db.SaveChanges();

                    // Update UI
                    UsernameView.Text = newUsername;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to update username: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
