using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Course")]
    public class Course
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}