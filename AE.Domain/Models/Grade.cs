using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AE.Domain.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } 
        public int Score { get; set; } 
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}