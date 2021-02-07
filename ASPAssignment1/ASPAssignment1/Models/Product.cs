using System;
using System.ComponentModel.DataAnnotations;

namespace ASPAssignment1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the code number.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter the name.")]
        public string Name { get; set; }

        public string Price { get; set; }

        public String ReleaseDate { get; set; }

        [Range(1, 10000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
