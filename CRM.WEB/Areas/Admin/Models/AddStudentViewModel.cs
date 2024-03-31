﻿using System.ComponentModel.DataAnnotations;

namespace CRM.WEB.Models
{
    public class AddStudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
    }
}
