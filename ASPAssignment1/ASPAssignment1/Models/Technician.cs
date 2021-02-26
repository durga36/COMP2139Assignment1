using System;
using System.ComponentModel.DataAnnotations;

namespace ASPAssignment1.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter the name.")]
        public string Name { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        [Range(1, 10000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
