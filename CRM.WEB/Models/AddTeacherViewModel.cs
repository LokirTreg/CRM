using System.ComponentModel.DataAnnotations;

namespace CRM.WEB.Models
{
    public class AddTeacherViewModel
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}
