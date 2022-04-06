using GBCSporting_CoderHuskies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Controllers
{
    public class TechnicianController : Controller
    {
        private GBCSportingContext context { get; set; }

        public TechnicianController(GBCSportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
            var technicians = context.Technician.ToList();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technician.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                    context.Technician.Add(technician);
                else
                    context.Technician.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technician.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technician.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}
