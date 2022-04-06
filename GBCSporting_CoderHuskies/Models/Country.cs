using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Models
{
    public class Country
    {

        [Key]
        public string CountryId { get; set; }

        public string Name { get; set; }

    }
}
