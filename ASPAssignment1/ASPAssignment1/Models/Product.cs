using System;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();
    }
}
