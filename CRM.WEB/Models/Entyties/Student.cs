using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Student")]
    public class Student
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Group_Student> Group_Students { get; set; }
    }
}
