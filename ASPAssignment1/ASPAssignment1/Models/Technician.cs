using System;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string Slug => Name?.Replace(" ", "-").ToLower();

        public object Conferences { get; internal set; }
        public object Conference { get; internal set; }
        public object Division { get; internal set; }
        public List<Technician> Technicians { get; internal set; }
        public object Divisions { get; internal set; }
    }
}
