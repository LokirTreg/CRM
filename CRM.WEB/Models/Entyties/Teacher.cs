using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
