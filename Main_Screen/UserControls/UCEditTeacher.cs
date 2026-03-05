using AE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class UCEditTeacher : UserControl
    {
        public UCEditTeacher()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            var subjects = Enum.GetValues(typeof(AE.Domain.Models.Subject));
            foreach (var subject in subjects)
            {
                cmbSubject.Items.Add(subject);
            }
        }

        public void SaveTeacherEdit()
        {
            using (var context = new AppDbContext())
            {
                var teacher = context.Teachers.FirstOrDefault();
                if (teacher != null)
                {
                    teacher.FirstName = txtFirstName.Text;
                    teacher.MiddleName = txtMiddleName.Text;
                    teacher.LastName = txtLastName.Text;
                    // teacher.Subject = comp cmbSubject.SelectedValue);
                    context.SaveChanges();
                }
            }
        }
    }
}
