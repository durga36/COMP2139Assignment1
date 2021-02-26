using System;
using System.ComponentModel.DataAnnotations;

namespace ASPAssignment1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the name.")]
        public string Name { get; set; }

        public String Email { get; set; }

        public String City { get; set; }

        [Range(1, 10000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
