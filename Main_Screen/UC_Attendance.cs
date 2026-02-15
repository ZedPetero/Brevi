using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace AE.Application
{
    public partial class UC_Attendance : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CurrentSectionId { get; set; }

        public UC_Attendance()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (Form_AddStudent popup = new Form_AddStudent())
            {
                var result = popup.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadStudents();
                }
            }
        }

        private void UC_Attendance_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            layoutStudents.Controls.Clear();
            using (var _context = new AppDbContext())
            {
                var students = _context.Students.ToList();
                for (int i = 0; i < students.Count; i++)
                {
                    var student = students[i];
                    UC_StudentRow studentRow = new UC_StudentRow();
                    studentRow.StudentName = $"{student.FirstName} {student.LastName}";
                    studentRow.StudentNumber = (i + 1).ToString();
                    studentRow.StudentStatus = student.status.ToString();
                    layoutStudents.Controls.Add(studentRow);
                }
            }
        }
    }
}
