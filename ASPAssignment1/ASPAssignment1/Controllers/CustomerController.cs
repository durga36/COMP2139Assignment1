using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPAssignment1.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerContext context { get; set; }

        public CustomerController(CustomerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ModelState.AddModelError("", "There are some errors in the form.");
                return View(customer);
            }
        }

        [Route("[controller]s/{cat?}")]
        public IActionResult List(string id = "All")
        {
            ViewBag.Genre = id;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        public IActionResult Details(int id)
        {
            var customer = context.Customers
                .Include(c => c.Genre)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(c => c.Name).ToList();

            var customer = context.Customers
                .Include(c => c.Genre)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Genre)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            foreach (var data in filter)
            {
                var incident = context.Customers
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == data);
            }
            return View(filter);
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustomerId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                else
                {
                    context.Customers.Update(customer);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Genres.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}