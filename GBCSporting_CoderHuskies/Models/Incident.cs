using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class Incident
    {

        [Key]
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select the customer of incident")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please enter the product of incident")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please enter the title of incident")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the description of the incident")]
        public string Description { get; set; }

        public int? TechnicianId { get; set; }
        public Technician Technician { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOpened { get; set; }

        [Required(ErrorMessage = "Please enter the closing date of incident")]
        [DataType(DataType.Date)]
        public DateTime DateClosed { get; set; }

        public String Slug => Title?.Replace(' ', '-').ToLower();


    }
}
