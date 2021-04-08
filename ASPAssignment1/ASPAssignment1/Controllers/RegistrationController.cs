using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Controllers
{
    public class RegistrationController : Controller
    {
        private RegistrationContext context { get; set; }

        public RegistrationController(RegistrationContext rtx)
        {
            context = rtx;
        }

        public IActionResult Index(string activeConf = "all", string activeDiv = "all")
        {
            var session = new CustomerSession(HttpContext.Session);
            session.SetActiveConf(activeConf);
            session.SetActiveDiv(activeDiv);

            var model = new Customer
            {
                Name = activeConf,
                Email = activeDiv,
                Conferences = context.Conference,
                Divisions = context.Divisions
            };

            IQueryable<Registration> query = context.Registrations;
            if (activeConf != "all")
                query = query.Where(
                    t => t.Conference == activeConf.ToLower());
            if (activeDiv != "all")
                query = query.Where(
                    t => t.Division == activeDiv.ToLower());
            model.Registrations = (System.Collections.Generic.List<Customer>)query;

            return View(model);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Products.OrderBy(p => p.Name).ToList();
            return View("Edit", new Registration());
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
        public IActionResult Delete(Registration registration)
        {
            //Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Genre> entityEntry = rContext.Products.Remove(registration);
            context.SaveChanges();
            TempData["message"] = $"{registration.ProductId} was deleted.";
            return RedirectToAction("Index", "Home");
        }
    }
}

