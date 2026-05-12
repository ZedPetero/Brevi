using System;
using System.Collections.Generic;
using System.Text;
using Brevi.Domain.Models;
using Brevi.Infrastructure.Data;
using Brevi.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace Brevi.Services.Repositories
{
    public class GradeService : Repository<Grade>, IGradeService
    {
        private readonly AppDbContext _context;
        public GradeService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task RecalculateGradeAsync(int studentId, int sectionId)
        {
            var records = await _context.AttendanceRecords
                .Where(a => a.StudentId == studentId && a.SectionId == sectionId)
                .ToListAsync();

            // You could also inject IAttendanceWeightsService here to make this dynamic!
            double points = records.Sum(r => r.Status switch {
                AttendanceStatus.Present => 1.0,
                AttendanceStatus.Excused => 1.0,
                AttendanceStatus.Late => 0.5,
                _ => 0.0
            });

            double percentage = records.Count > 0 ? (points / records.Count) * 100.0 : 0;

            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.StudentId == studentId && g.SectionId == sectionId);
            if (grade == null)
            {
                _context.Grades.Add(new Grade { StudentId = studentId, SectionId = sectionId, Percentage = percentage });
            }
            else { grade.Percentage = percentage; }

            await _context.SaveChangesAsync();
        }
    }
}
