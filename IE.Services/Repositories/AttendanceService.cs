using Brevi.Domain.Models;
using Brevi.Infrastructure.Data;
using Brevi.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brevi.Services.Repositories
{
    public class AttendanceService : Repository<Attendance>, IAttendanceService
    {
        private readonly AppDbContext _context;
        public AttendanceService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Attendance> GetSpecificRecordAsync(int studentId, int sectionId, DateTime date)
        {
            var dayStart = date.Date;
            var dayEnd = dayStart.AddDays(1);
            return await _context.AttendanceRecords
                .FirstOrDefaultAsync(a => a.StudentId == studentId &&
                                         a.SectionId == sectionId &&
                                         a.Date >= dayStart && a.Date < dayEnd);
        }

        public async Task SaveAttendanceAsync(Attendance record)
        {
            var existing = await GetSpecificRecordAsync(record.StudentId, record.SectionId, record.Date);
            if (existing == null) _context.AttendanceRecords.Add(record);
            else existing.Status = record.Status;

            await _context.SaveChangesAsync();
        }
    }
}
