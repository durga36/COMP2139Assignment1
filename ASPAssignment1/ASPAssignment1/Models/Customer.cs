using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPAssignment1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the first name.")]
        [StringLength(51, ErrorMessage = "First name must be 51 characters or less.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name.")]
        [StringLength(51, ErrorMessage = "Last name must be 51 characters or less.")]
        public string lastName { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [StringLength(51, ErrorMessage = "Address must be 51 characters or less.")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter the city.")]
        [StringLength(51, ErrorMessage = "City must be 51 characters or less.")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please enter the state.")]
        [StringLength(51, ErrorMessage = "State must be 51 characters or less.")]
        public String state { get; set; }

        [Required(ErrorMessage = "Please enter the postal code.")]
        [StringLength(21, ErrorMessage = "Postal code must be 21 characters or less.")]
        public String postCode { get; set; }

        [Required(ErrorMessage = "Please choose the country")]
        public String country { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter the email.")]
        [StringLength(51, ErrorMessage = "Email must be 51 characters or less.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("EmailExists", "Account", HttpMethod = "POST", ErrorMessage = "Email address is already registered.")]
        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{3}{1})\d{3}{0,1}-\d{4}?$", ErrorMessage = "The phone Number is not a valid number.")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public object Conferences { get; set; }
        public object Conference { get; set; }
        public object Division { get; set; }
        public List<Customer> Registrations { get; set; }
        public object Divisions { get; set; }

        public string Slug => lastName?.Replace(" ", "-").ToLower();
    }
}
