using System;
using System.ComponentModel.DataAnnotations;

namespace ASPAssignment1.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the customer name.")]
        public string Customer { get; set; }

        public Product ProductId { get; set; }

        public String DateOpened { get; set; }

        [Range(1, 10000, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Slug => Title?.Replace(" ", "-").ToLower();
    }
}
