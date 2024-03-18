using CRM.WEB.Models.Entyties;
using System.Text.RegularExpressions;

namespace CRM.WEB.Models
{
    public class AddGroupModelView
    {
        public int Number { get; set; }
        public ICollection<Group_Student> Group_Students { get; set; }
    }
}
