using Brevi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Brevi.Application
{
    public partial class UCSignUpPage : UserControl
    {
        private readonly UserManager<Teacher> _userManager;
        private bool _visibility = false;

        public event EventHandler? ToLoginPage;

        public UCSignUpPage(UserManager<Teacher> userManager)
        {
            _userManager = userManager;
            InitializeComponent();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            var teacher = new Teacher
            {
                UserName = txtUsername.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                PhoneNumber = txtPhoneNumber.Text
            };

            var result = await _userManager.CreateAsync(teacher, txtPassword.Text);

            if (result.Succeeded)
            {
                MessageBox.Show("Registration successful! You can now log in.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // Go to login page 
                ToLoginPage?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                string errors = string.Join("\n", result.Errors.Select(e => e.Description));
                MessageBox.Show($"Registration failed:\n{errors}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void linkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToLoginPage?.Invoke(this, EventArgs.Empty);
        }

        private void UCSignUpPage_Load(object sender, EventArgs e)
        {
            if (this.FindForm() != null)
            {
                this.FindForm().AcceptButton = btnSignUp;
            }
        }

        private void visibilityBtn_Click(object sender, EventArgs e)
        {
            // Toggle flag
            _visibility = !_visibility;

            if (_visibility)
            {
                // Show plain text: disable system password char and clear any PasswordChar
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
                visibilityBtn.Values.Image = Properties.Resources.visibility_off;
            }
            else
            {
                // Hide password: enable system password char (fallback will be used by the control)
                txtPassword.UseSystemPasswordChar = true;
                // Clear explicit PasswordChar so the system char is used consistently
                txtPassword.PasswordChar = '\0';
                visibilityBtn.Values.Image = Properties.Resources.visibility;
            }
        }
    }
}
