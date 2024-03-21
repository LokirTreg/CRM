using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace CRM.WEB.Models.Entyties
{
    [Table("Event")]
    public class Event
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Weekday { get; set; }


        [Required, ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }


        [Required, ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Required, ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Required, ForeignKey(nameof(Сlassroom))]
        public int СlassroomId { get; set; }
        public virtual Сlassroom Сlassroom { get; set; }
    }
}
