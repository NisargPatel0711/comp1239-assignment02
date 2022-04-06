using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter first name of customer")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name of customer")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter address of the customer")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter the city of customer")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the state of customer")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter the postal code of customer")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please select the country of the customer")]
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public String Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

    }
}
