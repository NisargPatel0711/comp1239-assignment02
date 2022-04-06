using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class Technician
    {

        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter the name of technician")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the email of technician")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the phone number of technician")]
        public string Phone { get; set; }

        public String Slug => Name?.Replace(' ', '-').ToLower();


    }
}
