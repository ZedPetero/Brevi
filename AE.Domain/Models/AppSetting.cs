using System.ComponentModel.DataAnnotations;

namespace AE.Domain.Models
{
    public class AppSetting
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
