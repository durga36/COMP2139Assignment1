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

        [Route("[controller]s/{cat?}")]
        public ViewResult List(string id = "All")
        {
            ViewBag.Genre = id;
            return View();
        }

        public RedirectToActionResult Index() => RedirectToAction("List");

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(p => p.Name).ToList();
            return View("Edit", new Product());
        }

        public IActionResult Details(string id)
        {
            var product = context.Products
                .Include(p => p.Genre)
                .FirstOrDefault(p => p.GenreId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Genres.OrderBy(p => p.Name).ToList();
            
            var product = context.Products
                .Include(p => p.Genre)
                .FirstOrDefault(p => p.GenreId == id);
            return View(product); 
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var product = context.Products
                .Include(p => p.Genre)
                .FirstOrDefault(p => p.GenreId == id);
            return View(product); 
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            foreach (var data in filter)
            {
                var incident = context.Products
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == data);
            }
            return View(filter);
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
                    TempData["message"] = $"{product.Name} was added.";
                }
                else
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                    TempData["message"] = $"{product.Name} was edited.";
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Genres.OrderBy(p => p.Name).ToList();
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            TempData["message"] = $"{product.Name} was deleted.";
            return RedirectToAction("Index", "Home");
        }
    }
}
