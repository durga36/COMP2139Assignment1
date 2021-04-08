using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPAssignment1.Models
{
    public class Registration
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Conference { get; internal set; }
        public string Division { get; internal set; }
    }
}
