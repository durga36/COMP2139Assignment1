using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext context { get; set; }

        public ProductController(ProductContext ptx)
        {
            context = ptx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(p => p.CategoryName).ToList();
            return View("Edit", new Product());
        }

        public IActionResult Details(int id)
        {
            var product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.CategoryId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(p => p.CategoryName).ToList();
            
            var product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(p => p.CategoryName).ToList();
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
