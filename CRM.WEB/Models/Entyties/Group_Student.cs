using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Group_Student")]
    public class Group_Student
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, ForeignKey(nameof(Group))]
        public int Group_Id { get; set; }
        [Required, ForeignKey(nameof(Student))]
        public int Student_Id { get; set; }
        public virtual Group Group_ { get; set; }
        public virtual Student Student_ { get; set; }
        
    }
}
