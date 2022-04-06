using GBCSporting_CoderHuskies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting_CoderHuskies.Controllers
{
    public class ProductController : Controller
    {

        private GBCSportingContext context { get; set; }

        public ProductController (GBCSportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = context.Product.ToList();
            return View(products);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";            
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";            
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    product.Code = product.Code.ToUpper();
                    context.Product.Add(product);
                }
                else
                    context.Product.Update(product);
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";              
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
