﻿using System.ComponentModel.DataAnnotations;
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
        public int Time { get; set; }
        [Required]
        public int Weekday { get; set; }
        [Required, ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required, ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        [Required, ForeignKey(nameof(Audi))]
        public int AudiId { get; set; }
        public virtual Audi Audi { get; set; }
    }
}
