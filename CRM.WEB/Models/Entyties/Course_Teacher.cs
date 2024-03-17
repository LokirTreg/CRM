using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.WEB.Models.Entyties
{
    [Table("Course_Teacher")]
    public class Course_Teacher
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(Course))]
        public int Course_Id { get; set; }
        [Required, ForeignKey(nameof(Teacher))]
        public int Teacher_Id { get; set; }
        public virtual Course Course_ { get; set; }
        public virtual Teacher Teacher_ { get; set; }
    }
}
