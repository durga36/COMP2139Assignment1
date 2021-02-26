using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Controllers
{
    public class IncidentController : Controller
    {
        private IncidentContext context { get; set; }

        public IncidentController(IncidentContext itx)
        {
            context = itx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(i => i.CategoryName).ToList();
            return View("Edit", new Incident());
        }

        public IActionResult Details(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Category)
                .FirstOrDefault(i => i.CategoryId == id);
            return View(incident);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(i => i.CategoryName).ToList();

            var incident = context.Incidents
                .Include(i => i.Category)
                .FirstOrDefault(i => i.ProductId == id);
            return View(incident);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Category)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Incidents.Add(incident);
                    context.SaveChanges();
                }
                else
                {
                    context.Incidents.Update(incident);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(i => i.CategoryName).ToList();
                return View(incident);
            }
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
