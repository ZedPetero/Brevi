using Brevi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brevi.Services.Repositories.IRepositories
{
    public interface IAttendanceService : IRepository<Attendance>
    {
        Task<Attendance> GetSpecificRecordAsync(int studentId, int sectionId, DateTime date);
        Task SaveAttendanceAsync(Attendance record);
    }
}
