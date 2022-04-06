using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please provide the code of product")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please provide the name of product")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the yearly price of product")]
        [Range(1, 99999999, ErrorMessage = "Please provide the yearly price of product")]
        public double Price { get; set; } = 0.00;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public String Slug => Code?.Replace(' ', '-').ToLower() + '-' + Name?.Replace(' ', '-').ToLower();


    }
}
