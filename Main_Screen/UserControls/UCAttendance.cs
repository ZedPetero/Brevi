using Brevi.Domain.Models;
using Brevi.Services.Repositories.IRepositories;
using Brevi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brevi.Application
{
    public partial class UCAttendance : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int CurrentSectionId { get; set; }

        private readonly ISectionService _sectionService;
        private readonly IAttendanceService _attendanceService;
        private readonly IGradeService _gradeService;
        private readonly IStudentService _studentService;
        public UCAttendance(ISectionService sectionService, IAttendanceService attendanceService, IGradeService gradeService, IStudentService studentService)
        {
            InitializeComponent();
            _sectionService = sectionService;
            _attendanceService = attendanceService;
            _gradeService = gradeService;
            _studentService = studentService;
            UpdateDateDisplay();
            SetSection(CurrentSectionId);
            FilterComboBox.SelectedIndexChanged += async (s, ev) => await LoadStudentsForDateAsync();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp; 
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserControl CallerControl { get; set; }

        private DateTime _selectedDate = DateTime.Today;
        private enum SortMethod { Surname, FirstName }
        private SortMethod _currentSort = SortMethod.Surname;

        public async void SetSection(int sectionId)
        {
            CurrentSectionId = sectionId;
            await LoadSectionInfoAsync();
            await LoadStudentsForDateAsync();
            await SetSummaryCardsAsync();
        }

        private void RoundPanel(object sender, EventArgs e)
        {
            if (sender is Control panel)
            {
                UIHelper.RoundControl(panel, 20);
            }
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (FormAddStudent popup = new FormAddStudent())
            {
                MainScreenForm mainForm = (MainScreenForm)this.FindForm();
                mainForm.ShowOverlay();
                popup.CurrentSectionId = CurrentSectionId;
                var result = popup.ShowDialog();
                mainForm.HideOverlay();
                await LoadStudentsForDateAsync();
                await SetSummaryCardsAsync();
            }
        }

        private async Task SetSummaryCardsAsync()
        {
            try
            {
                pnlTotalStudents.SuspendLayout();
                pnlPresent.SuspendLayout();
                pnlLate.SuspendLayout();
                pnlAbsent.SuspendLayout();
                pnlExcused.SuspendLayout();
                if (CurrentSectionId == 0)
                {
                    pnlTotalStudents.Title = "Total Students";
                    pnlTotalStudents.TitleColor = "77, 180, 170";
                    pnlTotalStudents.Integer = 0;
                    pnlTotalStudents.IntegerColor = "39, 165, 173";
                    pnlTotalStudents.Percentage = string.Empty;
                    pnlTotalStudents.PercentageColor = "77, 180, 170";

                    pnlPresent.Title = "Present";
                    pnlPresent.TitleColor = "72, 205, 121";
                    pnlPresent.Integer = 0;
                    pnlPresent.IntegerColor = "34, 195, 93";
                    pnlPresent.Percentage = "0.0%";
                    pnlPresent.PercentageColor = "72, 205, 121";

                    pnlLate.Title = "Late";
                    pnlLate.TitleColor = "246, 175, 53";
                    pnlLate.Integer = 0;
                    pnlLate.IntegerColor = "245, 159, 10";
                    pnlLate.Percentage = "0.0%";
                    pnlLate.PercentageColor = "246, 175, 53";

                    pnlAbsent.Title = "Absent";
                    pnlAbsent.TitleColor = "230, 110, 110";
                    pnlAbsent.Integer = 0;
                    pnlAbsent.IntegerColor = "223, 58, 58";
                    pnlAbsent.Percentage = "0.0%";
                    pnlAbsent.PercentageColor = "230, 110, 110";

                    pnlExcused.Title = "Excused";
                    pnlExcused.TitleColor = "55, 178, 235";
                    pnlExcused.Integer = 0;
                    pnlExcused.IntegerColor = "13, 162, 231";
                    pnlExcused.Percentage = "0.0%";
                    pnlExcused.PercentageColor = "55, 178, 235";

                    return;
                }

                using var _context = new AppDbContext();

                int total = await _context.Students.CountAsync(s => s.SectionId == CurrentSectionId);

                DateTime dateStart = _selectedDate.Date;
                DateTime dateEnd = dateStart.AddDays(1);

                var attendance = await _context.AttendanceRecords
                    .Where(a => a.SectionId == CurrentSectionId && a.Date >= dateStart && a.Date < dateEnd)
                    .AsNoTracking()
                    .ToListAsync();

                int present = attendance.Count(a => a.Status == AttendanceStatus.Present);
                int late = attendance.Count(a => a.Status == AttendanceStatus.Late);
                int absent = attendance.Count(a => a.Status == AttendanceStatus.Absent);
                int excused = attendance.Count(a => a.Status == AttendanceStatus.Excused);

                double pctPresent = total > 0 ? (present * 100.0) / total : 0.0;
                double pctLate = total > 0 ? (late * 100.0) / total : 0.0;
                double pctAbsent = total > 0 ? (absent * 100.0) / total : 0.0;
                double pctExcused = total > 0 ? (excused * 100.0) / total : 0.0;

                pnlTotalStudents.Title = "Total Students";
                pnlTotalStudents.Integer = total;
                pnlTotalStudents.Percentage = string.Empty;

                pnlPresent.Title = "Present";
                pnlPresent.Integer = present;
                pnlPresent.Percentage = $"{pctPresent:0.0}%";

                pnlLate.Title = "Late";
                pnlLate.Integer = late;
                pnlLate.Percentage = $"{pctLate:0.0}%";

                pnlAbsent.Title = "Absent";
                pnlAbsent.Integer = absent;
                pnlAbsent.Percentage = $"{pctAbsent:0.0}%";

                pnlExcused.Title = "Excused";
                pnlExcused.Integer = excused;
                pnlExcused.Percentage = $"{pctExcused:0.0}%";

                pnlTotalStudents.ResumeLayout();
                pnlPresent.ResumeLayout();
                pnlLate.ResumeLayout();
                pnlAbsent.ResumeLayout();
                pnlExcused.ResumeLayout();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[UC_Attendance] SetSummaryCards error: " + ex);
            }
        }

        private async Task LoadSectionInfoAsync()
        {
            lblSectionName.Text = "Loading...";
            lblSubjectName.Text = string.Empty;

            if (CurrentSectionId == 0)
            {
                lblSectionName.Text = "No section selected";
                lblSubjectName.Text = string.Empty;
                return;
            }

            try
            {
                var section = await _sectionService.GetSectionByIdAsync(CurrentSectionId);
                if (section != null)
                {
                    lblSectionName.Text = section.SectionName;
                    lblSubjectName.Text = section.Subject?.Name ?? "No Subject";
                }
                else
                {
                    lblSectionName.Text = "Section not found";
                    lblSubjectName.Text = string.Empty;
                    Debug.WriteLine($"[UC_Attendance] Section with ID {CurrentSectionId} was not found.");
                }
            }
            catch (Exception ex)
            {
                lblSectionName.Text = "Error loading section";
                lblSubjectName.Text = string.Empty;
                Debug.WriteLine($"[UC_Attendance] LoadSectionInfo error: {ex}");
            }
        }

        public async Task LoadStudentsForDateAsync()
        {
            if (CurrentSectionId == 0)
            {
                lblNumberofStudents.Text = "0 Students";
                return;
            }

            Point scrollPos = layoutStudents.AutoScrollPosition;

            layoutStudents.SuspendLayout();
            layoutStudents.Controls.Clear();
            layoutStudents.FlowDirection = FlowDirection.TopDown;
            layoutStudents.WrapContents = false;
            layoutStudents.AutoScrollPosition = new Point(0, 0);

            using (var _context = new AppDbContext())
            {
                var studentsQuery = _context.Students.Where(s => s.SectionId == this.CurrentSectionId);

                if (_currentSort == SortMethod.Surname)
                {
                    studentsQuery = studentsQuery.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
                }
                else
                {
                    studentsQuery = studentsQuery.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
                }

                var students = await studentsQuery.ToListAsync();

                DateTime dateStart = _selectedDate.Date;
                DateTime dateEnd = dateStart.AddDays(1);

                var attendanceRecords = await _context.AttendanceRecords
                    .Where(a => a.SectionId == this.CurrentSectionId && a.Date >= dateStart && a.Date < dateEnd)
                    .AsNoTracking()
                    .ToListAsync();
                var attendanceForDay = attendanceRecords.ToDictionary(a => a.StudentId, a => a.Status);

                string selectedFilter = FilterComboBox.SelectedItem?.ToString() ?? "All";
                var filteredStudents = students.Where(student =>
                {
                    if (attendanceForDay.TryGetValue(student.Id, out var status))
                        return selectedFilter == "All" || status.ToString() == selectedFilter;
                    return selectedFilter == "All";
                }).ToList();

                int count = 1;
                foreach (var student in filteredStudents)
                {
                    UCStudentRow studentRow = new UCStudentRow(_attendanceService, _studentService);

                    studentRow.StudentId = student.Id;
                    studentRow.SectionId = this.CurrentSectionId;
                    studentRow.AttendanceDate = _selectedDate;

                    if (_currentSort == SortMethod.Surname)
                    {
                        studentRow.StudentName = $"{student.LastName}, {student.FirstName}";
                    }
                    else
                    {
                        studentRow.StudentName = $"{student.FirstName} {student.LastName}";
                    }

                    studentRow.StudentNumber = count.ToString();

                    if (attendanceForDay.TryGetValue(student.Id, out var status))
                    {
                        studentRow.SetSelectedStatus(status);
                    }
                    else
                    {
                        studentRow.SetSelectedStatus(null);
                    }
                    studentRow.Width1 = layoutStudents.ClientSize.Width - 10;
                    studentRow.AttendanceStatusChanged += async (s, id) => await StudentRow_AttendanceStatusChangedAsync(s, id);
                    layoutStudents.Controls.Add(studentRow);
                    count++;
                }

                lblNumberofStudents.Text = $"{students.Count} Students";
            }

            layoutStudents.ResumeLayout();

            layoutStudents.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));

            SetSummaryCardsAsync();
        }
        private async Task StudentRow_AttendanceStatusChangedAsync(object sender, int studentId)
        {
            await RecalculateSingleStudentGradeAsync(studentId, CurrentSectionId);
            await SetSummaryCardsAsync();
        }

        private async void UC_Attendance_Load(object sender, EventArgs e)
        {
            UpdateDateDisplay();

            if (CurrentSectionId != 0)
            {
                await LoadSectionInfoAsync();
                await LoadStudentsForDateAsync();
            }

            RoundPanel(pnlTotalStudents, EventArgs.Empty);
            RoundPanel(panelTotalBorder, EventArgs.Empty);
            RoundPanel(pnlPresent, EventArgs.Empty);
            RoundPanel(panelPresentBorder, EventArgs.Empty);
            RoundPanel(pnlLate, EventArgs.Empty);
            RoundPanel(panelLateBorder, EventArgs.Empty);
            RoundPanel(pnlAbsent, EventArgs.Empty);
            RoundPanel(panelAbsentBorder, EventArgs.Empty);
            RoundPanel(pnlExcused, EventArgs.Empty);
            RoundPanel(panelExcusedBorder, EventArgs.Empty);
            RoundPanel(panelCalendar, EventArgs.Empty);
            RoundPanel(panelCalendarBorder, EventArgs.Empty);
        }

        private void lblBackToClass_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as MainScreenForm;
            if (mainForm == null)
                return;

            if (CallerControl != null)
            {
                mainForm.LoadForm(CallerControl);
            }
            else
            {
                mainForm.LoadForm(new UCClasses(_sectionService, _attendanceService, _gradeService, _studentService));
            }
        }

        private void UpdateDateDisplay()
        {
            lblDateNow.Values.ExtraText = _selectedDate.ToString("D");

            if (btnNextDate != null)
            {
                btnNextDate.Enabled = _selectedDate.Date < DateTime.Today;
            }
        }

        private void lblDateNow_Click(object? sender, EventArgs e)
        {
            ShowCalendarPicker();
        }

        private async void btnNextDate_Click(object? sender, EventArgs e)
        {
            if (_selectedDate >= DateTime.Today)
            {
                MessageBox.Show("You cannot select a future date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _selectedDate = _selectedDate.AddDays(1);
            UpdateDateDisplay();
            await LoadStudentsForDateAsync();
        }

        private async void btnPreviousDate_Click(object? sender, EventArgs e)
        {
            _selectedDate = _selectedDate.AddDays(-1);
            UpdateDateDisplay();
            await LoadStudentsForDateAsync();
        }

        private void ShowCalendarPicker()
        {
            var container = new Panel { BackColor = Color.White, Size = new Size(245, 250) };

            var cbMonth = new Krypton.Toolkit.KryptonComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 110,
                Location = new Point(10, 5)
            };
            cbMonth.Items.AddRange(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            cbMonth.SelectedIndex = _selectedDate.Month - 1;

            var numYear = new Krypton.Toolkit.KryptonNumericUpDown
            {
                Width = 80,
                Location = new Point(130, 5),
                Minimum = 2000,
                Maximum = 2100,
                Value = _selectedDate.Year
            };

            var cal = new Krypton.Toolkit.KryptonMonthCalendar
            {
                MaxSelectionCount = 1,
                SelectionStart = _selectedDate,
                SelectionEnd = _selectedDate,
                ShowTodayCircle = false,
                ShowWeekNumbers = false,
                Location = new Point(5, 35),
                MaxDate = DateTime.Today
            };

            cal.StateCommon.Back.Color1 = Color.White;
            cal.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;

            cal.StateTracking.Day.Back.Color1 = Color.FromArgb(228, 242, 240);
            cal.StateTracking.Day.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.All;
            cal.StateTracking.Day.Border.Rounding = 6F;
            cal.StateTracking.Day.Border.Width = 0;

            cal.StateCheckedNormal.Day.Back.Color1 = Color.FromArgb(39, 165, 173);
            cal.StateCheckedNormal.Day.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.All;
            cal.StateCheckedNormal.Day.Border.Rounding = 6F;
            cal.StateCheckedNormal.Day.Border.Width = 0;
            cal.StateCheckedNormal.Day.Content.ShortText.Color1 = Color.White;

            container.Controls.Add(cbMonth);
            container.Controls.Add(numYear);
            container.Controls.Add(cal);

            var host = new ToolStripControlHost(container) { Padding = Padding.Empty, Margin = Padding.Empty };
            var dropDown = new ToolStripDropDown { Padding = new Padding(1), BackColor = Color.FromArgb(224, 230, 235) };
            dropDown.Items.Add(host);

            bool isNavigating = false;

            cbMonth.SelectedIndexChanged += (s, e) =>
            {
                isNavigating = true;
                cal.SetDate(new DateTime((int)numYear.Value, cbMonth.SelectedIndex + 1, 1));
                isNavigating = false;
            };

            numYear.ValueChanged += (s, e) =>
            {
                isNavigating = true;
                cal.SetDate(new DateTime((int)numYear.Value, cbMonth.SelectedIndex + 1, 1));
                isNavigating = false;
            };

            cal.DateChanged += async (s, e) =>
            {
                if (isNavigating) return;

                _selectedDate = cal.SelectionStart.Date;
                UpdateDateDisplay();
                await LoadStudentsForDateAsync();
                dropDown.Close();
            };

            int offsetX = (lblDateNow.Width - container.Width) / 2;
            int offsetY = lblDateNow.Height + 4;

            dropDown.Show(lblDateNow, new Point(offsetX, offsetY));
        }

        private async void btnMarkAllPresent_Click(object? sender, EventArgs e)
        {
            if (CurrentSectionId == 0) return;

            try
            {
                DateTime dateStart = _selectedDate.Date;
                DateTime dateEnd = dateStart.AddDays(1);

                using var _context = new AppDbContext();

                var students = await _context.Students.Where(s => s.SectionId == CurrentSectionId).ToListAsync();

                foreach (var student in students)
                {
                    var existing = _context.AttendanceRecords
                        .FirstOrDefault(a => a.StudentId == student.Id
                                             && a.SectionId == CurrentSectionId
                                             && a.Date >= dateStart && a.Date < dateEnd);

                    if (existing == null)
                    {
                        _context.AttendanceRecords.Add(new Attendance
                        {
                            StudentId = student.Id,
                            SectionId = CurrentSectionId,
                            Date = dateStart,
                            Status = AttendanceStatus.Present,
                            Remarks = string.Empty
                        });
                    }
                    else
                    {
                        existing.Status = AttendanceStatus.Present;
                    }
                }

                _context.SaveChanges();

                await RecalculateClassGradesAsync(_context, CurrentSectionId);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[UC_Attendance] btnMarkAllPresent error: " + ex);
            }

            foreach (Control control in layoutStudents.Controls)
            {
                if (control is UCStudentRow studentRow)
                {
                    studentRow.SetSelectedStatus(AttendanceStatus.Present);
                }
            }
            await SetSummaryCardsAsync();
        }

        private async void btnReset_Click(object? sender, EventArgs e)
        {
            if (CurrentSectionId == 0) return;

            try
            {
                if (MessageBox.Show("This will remove all attendance records for the selected date. Are you sure?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
                DateTime dateStart = _selectedDate.Date;
                DateTime dateEnd = dateStart.AddDays(1);

                using var _context = new AppDbContext();

                var toRemove = await _context.AttendanceRecords
                    .Where(a => a.SectionId == CurrentSectionId && a.Date == dateStart)
                    .ToListAsync();

                if (toRemove.Any())
                {
                    _context.AttendanceRecords.RemoveRange(toRemove);
                    await _context.SaveChangesAsync();

                    await RecalculateClassGradesAsync(_context, CurrentSectionId);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[UC_Attendance] btnReset error: " + ex);
            }

            foreach (Control control in layoutStudents.Controls)
            {
                if (control is UCStudentRow studentRow)
                {
                    studentRow.SetSelectedStatus(null);
                }
            }
            await SetSummaryCardsAsync();
        }

        public async void RefreshSummaryAndRoster()
        {
            await SetSummaryCardsAsync();
        }

        private void btnExportSummary_Click(object sender, EventArgs e)
        {
            if (CurrentSectionId == 0)
            {
                MessageBox.Show("No section selected to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormAttendanceSummary summaryForm = new FormAttendanceSummary(CurrentSectionId))
            {
                MainScreenForm mainForm = (MainScreenForm)this.FindForm();
                if (mainForm != null) mainForm.ShowOverlay();
                summaryForm.ShowDialog();
                if (mainForm != null) mainForm.HideOverlay();
            }
        }

        private async void btnSortSurname_Click(object sender, EventArgs e)
        {
            _currentSort = SortMethod.Surname;
            await LoadStudentsForDateAsync();
        }

        private async void btnSortFirstname_Click(object sender, EventArgs e)
        {
            _currentSort = SortMethod.FirstName;
            await LoadStudentsForDateAsync();
        }
        public async Task RecalculateSingleStudentGradeAsync(int studentId, int sectionId)
        {
            using (var db = new AppDbContext())
            {
                var section = await db.Sections.Include(s => s.Subject).FirstOrDefaultAsync(s => s.Id == sectionId);
                if (section == null) return;

                var records = await db.AttendanceRecords
                                .Where(a => a.StudentId == studentId && a.SectionId == sectionId)
                                .ToListAsync();

                int total = records.Count;
                int p = records.Count(r => r.Status == AttendanceStatus.Present);
                int e = records.Count(r => r.Status == AttendanceStatus.Excused);
                int l = records.Count(r => r.Status == AttendanceStatus.Late);
                int a = records.Count(r => r.Status == AttendanceStatus.Absent);

                double points = (p * 1.0) + (e * 1.0) + (l * 0.5) + (a * 0.0);
                double percentage = total > 0 ? (points / total) * 100.0 : 0;

                var grade = db.Grades.FirstOrDefault(g => g.StudentId == studentId && g.SectionId == sectionId);

                if (grade == null)
                {
                    db.Grades.Add(new Grade
                    {
                        StudentId = studentId,
                        SectionId = sectionId,
                        Subject = section.Subject?.Name ?? "Unknown",
                        Percentage = percentage
                    });
                }
                else
                {
                    grade.Percentage = percentage;
                }

                db.SaveChanges();
            }
        }
        public async Task RecalculateClassGradesAsync(AppDbContext db, int sectionId)
        {
            var section = await db.Sections.Include(s => s.Subject).FirstOrDefaultAsync(s => s.Id == sectionId);
            if (section == null) return;

            var studentIds = await db.Students.Where(s => s.SectionId == sectionId).Select(s => s.Id).ToListAsync();
            var allAttendance = await db.AttendanceRecords.Where(a => a.SectionId == sectionId).ToListAsync();
            var allGrades = await db.Grades.Where(g => g.SectionId == sectionId).ToListAsync();

            foreach (var sId in studentIds)
            {
                var records = allAttendance.Where(a => a.StudentId == sId).ToList();

                int total = records.Count;
                int p = records.Count(r => r.Status == AttendanceStatus.Present);
                int e = records.Count(r => r.Status == AttendanceStatus.Excused);
                int l = records.Count(r => r.Status == AttendanceStatus.Late);

                double points = p + e + (l * 0.5);
                double percentage = total > 0 ? (points / total) * 100.0 : 0;

                var grade = allGrades.FirstOrDefault(g => g.StudentId == sId);
                if (grade == null)
                {
                    db.Grades.Add(new Grade
                    {
                        StudentId = sId,
                        SectionId = sectionId,
                        Subject = section.Subject?.Name ?? "Unknown",
                        Percentage = percentage
                    });
                }
                else
                {
                    grade.Percentage = percentage;
                }
            }
        }
        private void layoutStudents_SizeChanged(object sender, EventArgs e)
        {
            layoutStudents.SuspendLayout();

            int targetWidth = layoutStudents.ClientSize.Width - 3 - 3 - 5;

            foreach (Control ctrl in layoutStudents.Controls)
            {
                if (ctrl is UCStudentRow)
                {
                    ctrl.Width = targetWidth;
                }
            }

            layoutStudents.ResumeLayout();
        }
    }
}
