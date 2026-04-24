using Brevi.Domain.Models;
using Brevi.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brevi.Application
{
    public partial class UCInteractionPage : UserControl
    {
        private readonly IUserService _userService;
        public event EventHandler? StartNowClicked;
        public event Action<string>? AccountSelected;

        public UCInteractionPage(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            LoadSavedAccounts();
        }

        private void LoadSavedAccounts()
        {
            try
            {
                var usernames = _userService.GetAllUsernames();
                sfListView1.DataSource = usernames;

                sfListView1.DoubleClick += SfListView1_DoubleClick;
            }
            catch (Exception)
            {
                // handle/log if needed
            }
        }

        private void SfListView1_DoubleClick(object? sender, EventArgs e)
        {
            try
            {
                var selected = sfListView1.SelectedItem;
                if (selected != null)
                {
                    var username = selected.ToString();
                    if (!string.IsNullOrEmpty(username))
                        AccountSelected?.Invoke(username);
                }
            }
            catch (Exception)
            {
                // swallow any selection errors
            }
        }

        private void btnStartNow_Click(object sender, EventArgs e)
        {
            StartNowClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
