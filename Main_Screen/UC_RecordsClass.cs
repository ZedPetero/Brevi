using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Brevi.Application
{
    public partial class UC_RecordsClass : UserControl
    {
        private int _sectionId;
        private bool _isArchived = false;

        public void SetSection(int sectionId)
        {
            _sectionId = sectionId;
            LoadSection();
        }

        private void LoadSection()
        {
            try
            {
                classinfotable.Visible = false; // hide by default

                using var db = new AE.Infrastructure.Data.AppDbContext();
                var section = db.Sections
                    .Where(s => s.Id == _sectionId)
                    .Select(s => new { s.SectionName, StudentCount = s.Students.Count })
                    .AsNoTracking()
                    .SingleOrDefault();

                if (section != null)
                {
                    classnamelabel.Values.Text = section.SectionName;
                    AmountofStudentslabel.Values.Text = $"{section.StudentCount} Students";

                    // set archive button initial text
                    ArchiveorRestorebutton.Values.Text = section.StudentCount >= 0 ? ( _isArchived ? "Restore" : "Archive") : ArchiveorRestorebutton.Values.Text;

                    // populate classinfotable with students and their attendance summary
                    classinfotable.Controls.Clear();
                    classinfotable.ColumnCount = 5;
                    classinfotable.ColumnStyles.Clear();
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // name
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // present
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // late
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // absent
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); // score

                    // header row
                    classinfotable.RowCount = 1;
                    classinfotable.RowStyles.Clear();
                    classinfotable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    AddCellToTable(0, 0, new Label { Text = "Name", AutoSize = true, Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold) });
                    AddCellToTable(0, 1, new Label { Text = "Present", AutoSize = true });
                    AddCellToTable(0, 2, new Label { Text = "Late", AutoSize = true });
                    AddCellToTable(0, 3, new Label { Text = "Absent", AutoSize = true });
                    AddCellToTable(0, 4, new Label { Text = "Score", AutoSize = true });

                    var students = db.Students.Where(st => st.SectionId == _sectionId).ToList();

                    int row = 1;
                    foreach (var student in students)
                    {
                        classinfotable.RowCount = row + 1;
                        classinfotable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                        AddCellToTable(row, 0, new Label { Text = $"{student.LastName}, {student.FirstName}", AutoSize = true });

                        // compute attendance counts for this student (simple totals)
                        int present = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == AE.Domain.Models.AttendanceStatus.Present);
                        int late = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == AE.Domain.Models.AttendanceStatus.Late);
                        int absent = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == AE.Domain.Models.AttendanceStatus.Absent);

                        AddCellToTable(row, 1, new Label { Text = present.ToString(), AutoSize = true });
                        AddCellToTable(row, 2, new Label { Text = late.ToString(), AutoSize = true });
                        AddCellToTable(row, 3, new Label { Text = absent.ToString(), AutoSize = true });

                        // score: placeholder, compute as percentage present / total records
                        int total = present + late + absent;
                        string score = total > 0 ? $"{(present * 100.0 / total):0.0}%" : "-";
                        AddCellToTable(row, 4, new Label { Text = score, AutoSize = true });

                        row++;
                    }
                }
            }
            catch (Exception ex)
            {
                // ignore DB issues in designer
                System.Diagnostics.Debug.WriteLine("UC_RecordsClass LoadSection error: " + ex.Message);
            }
        }

        private void AddCellToTable(int row, int col, Control ctrl)
        {
            // ensure enough controls
            ctrl.Margin = new Padding(3);
            classinfotable.Controls.Add(ctrl, col, row);
        }
        public UC_RecordsClass()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            classinfotable.Visible = !classinfotable.Visible;
        }

        private void classinfotable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ArchiveorRestorebutton_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new AE.Infrastructure.Data.AppDbContext();
                var sec = db.Sections.Find(_sectionId);
                if (sec == null) return;

                // toggle archived state
                sec.IsArchived = !sec.IsArchived;
                db.Sections.Update(sec);
                db.SaveChanges();

                // update UI by asking parent control to move this control
                var parent = this.FindForm();
                if (parent != null)
                {
                    var mainControl = FindParentRecordsNew();
                    if (mainControl != null)
                    {
                        if (sec.IsArchived)
                        {
                            mainControl.MoveToArchived(this);
                            ArchiveorRestorebutton.Values.Text = "Restore";
                        }
                        else
                        {
                            mainControl.MoveToCurrent(this);
                            ArchiveorRestorebutton.Values.Text = "Archive";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Archive toggle failed: " + ex.Message);
            }
        }

        private UC_Records_New FindParentRecordsNew()
        {
            Control p = this.Parent;
            while (p != null)
            {
                if (p is UC_Records_New rn)
                    return rn;
                p = p.Parent;
            }
            return null;
        }

        public void SetArchivedState(bool archived)
        {
            _isArchived = archived;
            ArchiveorRestorebutton.Values.Text = archived ? "Restore" : "Archive";
        }
    }
}
