using GBCSporting_CoderHuskies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Controllers
{
    public class CustomerController : Controller
    {
        private GBCSportingContext context { get; set; }

        public CustomerController(GBCSportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
            var customers = context.Customer
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName)
                .ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Country = context.Country.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Country = context.Country.OrderBy(c => c.Name).ToList();
            var customer = context.Customer.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                    context.Customer.Add(customer);
                else
                    context.Customer.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
                ViewBag.Country = context.Country.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customer.Find(id);
            ViewBag.Country = context.Country.OrderBy(c => c.Name).ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customer.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List", "Customer");
        }
    }
}
