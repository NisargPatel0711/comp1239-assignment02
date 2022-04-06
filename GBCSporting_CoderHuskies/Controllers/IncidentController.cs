using GBCSporting_CoderHuskies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Controllers
{
    public class IncidentController : Controller
    {
        private GBCSportingContext context { get; set; }

        public IncidentController(GBCSportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
            var incidents = context.Incident
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .OrderBy(i => i.Title)
                .ToList();
            return View(incidents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customer = context.Customer.OrderBy(c => c.FirstName).ToList();
            ViewBag.Product = context.Product.OrderBy(p => p.Name).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.Name).ToList();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customer = context.Customer.OrderBy(c => c.FirstName).ToList();
            ViewBag.Product = context.Product.OrderBy(p => p.Name).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.Name).ToList();
            var incident = context.Incident.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                    context.Incident.Add(incident);
                else
                    context.Incident.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add" : "Edit";
                ViewBag.Customer = context.Customer.OrderBy(c => c.FirstName).ToList();
                ViewBag.Product = context.Product.OrderBy(p => p.Name).ToList();
                ViewBag.Technician = context.Technician.OrderBy(t => t.Name).ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incident.Find(id);
            ViewBag.Customer = context.Customer.OrderBy(c => c.FirstName).ToList();
            ViewBag.Product = context.Product.OrderBy(p => p.Name).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.Name).ToList();
            return View(incident);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incident.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }

    }
}
