using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Audi")]
    public class Audi
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
