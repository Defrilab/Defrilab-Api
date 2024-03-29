﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReaiotBackend.Models
{
    public class Help : BaseModel
    {
        [Required, Column(TypeName = "VARCHAR(64)")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string DateOfReporting { get; set; }
        public string ProblemLevel { get; set; }
        public  string  Project { get; set; }
        public  bool  IsSolved { get; set; }
    }
}
