﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.WEB.Models.Entyties
{
    [Table("Group")]
    public class Group
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual ICollection<Group_Student> Group_Students { get; set; }
        public virtual Event Event { get; set; }
    }
}
