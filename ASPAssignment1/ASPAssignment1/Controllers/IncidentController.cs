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

        [Route("[controller]s/{cat?}")]
        public IActionResult List (string id = "All")
        {
            ViewBag.Genre = id;
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(i => i.Name).ToList();
            return View("Edit", new Incident());
        }

        public IActionResult Details(string id)
        {
            var incident = context.Incidents
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == id);
            return View(incident);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(i => i.Name).ToList();

            var incident = context.Incidents
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var incident = context.Incidents
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            foreach (var data in filter)
            {
                var incident = context.Incidents
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == data);
            }
            return View(filter);
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
                ViewBag.Genres = context.Genres.OrderBy(i => i.Name).ToList();
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
