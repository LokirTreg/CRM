using CRM.WEB.Models.Entyties;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRM.WEB.Models
{
    public class AddGroupStudentViewModel
    {
        public List<Student> Students { get; set; }
        public List<Group> Groups { get; set; }
    }
}
