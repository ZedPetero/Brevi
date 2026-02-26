using AE.Application.DTO;
using AE.Domain.Models;
using AE.Infrastructure.Data;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AE.Application
{
    public partial class Form_AttendanceSummary : KryptonForm
    {
        private readonly int _sectionId;
        private List<StudentSummaryDTO> _summaryData;
        public Form_AttendanceSummary(int sectionId)
        {
            InitializeComponent();
            _sectionId = sectionId;
        }
        private void LoadSummaryData()
        {
            var summaryList = new List<StudentSummaryDTO>();

            using (var db = new AppDbContext())
            {
                var students = db.Students
                                 .Where(s => s.SectionId == _sectionId)
                                 .ToList();

                var attendance = db.AttendanceRecords
                                   .Where(a => a.SectionId == _sectionId)
                                   .ToList();

                int counter = 1;
                foreach (var student in students)
                {
                    var records = attendance.Where(a => a.StudentId == student.Id).ToList();

                    int total = records.Count;
                    int p = records.Count(r => r.Status == AttendanceStatus.Present);
                    int l = records.Count(r => r.Status == AttendanceStatus.Late);
                    int a = records.Count(r => r.Status == AttendanceStatus.Absent);
                    int e = records.Count(r => r.Status == AttendanceStatus.Excused);

                    double points = p + e + (l * 0.5);
                    double percentage = total > 0 ? (points / total) * 100 : 0;

                    summaryList.Add(new StudentSummaryDTO
                    {
                        RollNo = counter.ToString("D3"),
                        Name = $"{student.LastName}, {student.FirstName}",
                        Days = total,
                        Present = p,
                        Late = l,
                        Absent = a,
                        Excused = e,
                        RawScore = percentage,
                        Score = $"{Math.Round(percentage)}/100"
                    });
                    counter++;
                }

                // Persist the generated list to the backing field so export uses the same data
                _summaryData = summaryList;

                gridSummary.DataSource = _summaryData;
            }
        }

        private void gridSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if we are looking at the "Score" column
            if (gridSummary.Columns[e.ColumnIndex].Name == "Score" && e.Value != null)
            {
                // Get the actual DTO object for this row
                var rowData = gridSummary.Rows[e.RowIndex].DataBoundItem as StudentSummaryDTO;

                if (rowData != null)
                {
                    if (rowData.RawScore >= 80)
                        e.CellStyle.ForeColor = Color.FromArgb(92, 184, 92); // Green
                    else if (rowData.RawScore >= 50)
                        e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7);  // Orange/Yellow
                    else
                        e.CellStyle.ForeColor = Color.FromArgb(220, 53, 69); // Red
                }
            }
        }

        private void Form_AttendanceSummary_Load(object sender, EventArgs e)
        {
            LoadSummaryData();
        }

        private void btnDownloadCSV_Click(object sender, EventArgs e)
        {
            // TEST: If you see this message, the button is hooked up correctly!
            // MessageBox.Show("Button clicked! Starting export...");

            if (_summaryData == null || _summaryData.Count == 0)
            {
                MessageBox.Show("No data found to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.Title = "Save Attendance Summary";
                // Default filename with current date
                sfd.FileName = $"Attendance_Summary_{DateTime.Now:yyyy-MM-dd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // 1. Write the Headers
                        sb.AppendLine("Roll No,Name,Days,Present,Late,Absent,Excused,Score");

                        // 2. Write the Rows
                        foreach (var row in _summaryData)
                        {
                            // Wrap the name in quotes in case it contains a comma (e.g., "Doe, John")
                            string safeName = $"\"{row.Name}\"";

                            sb.AppendLine($"{row.RollNo},{safeName},{row.Days},{row.Present},{row.Late},{row.Absent},{row.Excused},{row.Score}");
                        }

                        // 3. Save the actual file
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("Successfully exported!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optional: Automatically open the file in Excel after saving
                        // System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
