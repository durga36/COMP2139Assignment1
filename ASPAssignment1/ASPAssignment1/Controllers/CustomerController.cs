using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerContext context { get; set; }

        public CustomerController(CustomerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View("Edit", new Customer());
        }

        public IActionResult Details(int id)
        {
            var customer = context.Customers
                .Include(c => c.Category)
                .FirstOrDefault(c => c.CategoryId == id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();

            var customer = context.Customers
                .Include(c => c.Category)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Category)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
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
                ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
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