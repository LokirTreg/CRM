using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        public ICollection<Course_Teacher> Course_Teachers { get; set; }
        public virtual Event Event { get; set; }
    }
}
