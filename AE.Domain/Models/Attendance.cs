using System;
using System.ComponentModel.DataAnnotations;

namespace AE.Domain.Models
{
    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        Excused
    }

    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; } 

        public string Remarks { get; set; } 
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}