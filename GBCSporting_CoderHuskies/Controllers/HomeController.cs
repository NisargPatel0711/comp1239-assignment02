using GBCSporting_CoderHuskies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Controllers
{
    public class HomeController : Controller
    {

        private GBCSportingContext context { get; set; }

        public HomeController(GBCSportingContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
