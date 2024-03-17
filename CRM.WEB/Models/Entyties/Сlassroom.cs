using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Сlassroom")]
    public class Сlassroom
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual Event Event { get; set; }
    }
}
