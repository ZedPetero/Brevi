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
                this.Height = 100;

                using var db = new Brevi.Infrastructure.Data.AppDbContext();
                var section = db.Sections
                    .Where(s => s.Id == _sectionId)
                    .Select(s => new { s.SectionName, StudentCount = s.Students.Count })
                    .AsNoTracking()
                    .SingleOrDefault();

                if (section != null)
                {
                    lblClassName.Values.Text = section.SectionName;
                    lblSubject.Values.Text = $"{section.StudentCount} Students";

                    // set archive button initial text
                    ArchiveorRestorebutton.Values.Text = section.StudentCount >= 0 ? (_isArchived ? "Restore" : "Archive") : ArchiveorRestorebutton.Values.Text;

                    // 1. Setup Table Layout with 6 Columns
                    classinfotable.Controls.Clear();
                    classinfotable.ColumnCount = 6;
                    classinfotable.ColumnStyles.Clear();
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F)); // name
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F)); // present
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F)); // late
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F)); // absent
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F)); // excused (NEW)
                    classinfotable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F)); // score

                    // 2. Add Header Row (Using DockStyle.Fill and TextAlign for perfect spacing)
                    classinfotable.RowCount = 1;
                    classinfotable.RowStyles.Clear();
                    classinfotable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F)); // Fixed height for headers

                    Font headerFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                    Color headerColor = Color.Gray;

                    AddCellToTable(0, 0, new Label { Text = "Name", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = headerFont, ForeColor = headerColor });
                    AddCellToTable(0, 1, new Label { Text = "Present", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = headerFont, ForeColor = headerColor });
                    AddCellToTable(0, 2, new Label { Text = "Late", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = headerFont, ForeColor = headerColor });
                    AddCellToTable(0, 3, new Label { Text = "Absent", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = headerFont, ForeColor = headerColor });
                    AddCellToTable(0, 4, new Label { Text = "Excused", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = headerFont, ForeColor = headerColor });
                    AddCellToTable(0, 5, new Label { Text = "Score", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = headerFont, ForeColor = headerColor });

                    var students = db.Students.Where(st => st.SectionId == _sectionId).ToList();

                    // 3. Handle Empty Class State
                    if (students.Count == 0)
                    {
                        classinfotable.RowCount = 2;
                        classinfotable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

                        Label emptyStateLabel = new Label
                        {
                            Text = "No students enrolled in this class yet.",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = Color.DimGray
                        };

                        classinfotable.Controls.Add(emptyStateLabel, 0, 1);
                        classinfotable.SetColumnSpan(emptyStateLabel, 6); // Spans across all 6 columns
                    }
                    else
                    {
                        // 4. Populate Student Rows
                        int row = 1;
                        foreach (var student in students)
                        {
                            classinfotable.RowCount = row + 1;
                            classinfotable.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));

                            AddCellToTable(row, 0, new Label { Text = $"{student.LastName}, {student.FirstName}", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft });

                            // compute attendance counts for this student
                            int present = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == Brevi.Domain.Models.AttendanceStatus.Present);
                            int late = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == Brevi.Domain.Models.AttendanceStatus.Late);
                            int absent = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == Brevi.Domain.Models.AttendanceStatus.Absent);

                            // Assuming you have Excused in your enum, add it here:
                            int excused = db.AttendanceRecords.Count(a => a.StudentId == student.Id && a.Status == Brevi.Domain.Models.AttendanceStatus.Excused);

                            // Using colors similar to your reference images for better UI
                            AddCellToTable(row, 1, new Label { Text = present.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.FromArgb(39, 165, 153) });
                            AddCellToTable(row, 2, new Label { Text = late.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Goldenrod });
                            AddCellToTable(row, 3, new Label { Text = absent.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.IndianRed });
                            AddCellToTable(row, 4, new Label { Text = excused.ToString(), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.CornflowerBlue });

                            // score calculation
                            int total = present + late + absent + excused;
                            string score = total > 0 ? $"{(present * 100.0 / total):0}%" : "-";
                            AddCellToTable(row, 5, new Label { Text = score, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });

                            row++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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
            UIHelper.RoundControl(lblSubject, 20);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UIHelper.RoundControl(this, 20);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            // Toggle the visibility of the table
            classinfotable.Visible = !classinfotable.Visible;

            if (classinfotable.Visible)
            {
                // EXPANDING
                // Change the arrow icon to point UP (assuming you are using Material Symbols)
                sidebarbtn.Values.Text = ""; // expand_less icon (replace with your specific up arrow character)

                // Extend the height of the UserControl. 
                // 350 is a good fixed expanded height. Since AutoScroll is true, long lists will scroll.
                this.Height = 350;
            }
            else
            {
                // COLLAPSING
                // Change the arrow icon to point DOWN
                sidebarbtn.Values.Text = ""; // expand_more icon

                // Shrink the UserControl back to just the header height
                this.Height = 100;
            }
        }

        private void ArchiveorRestorebutton_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new Brevi.Infrastructure.Data.AppDbContext();
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

        private void kryptonLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
