using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPAssignment1.Controllers
{
    public class TechnicianController : Controller
    {
        private TechnicianContext context { get; set; }

        public TechnicianController(TechnicianContext ttx)
        {
            context = ttx;
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
            ViewBag.Genres = context.Genres.OrderBy(t => t.Name).ToList();
            return View("Edit", new Technician());
        }

        public IActionResult Details(string id)
        {
            var technician = context.Technicians
                .Include(t => t.Genre)
                .FirstOrDefault(t => t.GenreId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Genres.OrderBy(t => t.Name).ToList();

            var technician = context.Technicians
                .Include(t => t.Genre)
                .FirstOrDefault(t => t.GenreId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians
                .Include(t => t.Genre)
                .FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            foreach (var data in filter)
            {
                var incident = context.Technicians
                .Include(i => i.Genre)
                .FirstOrDefault(i => i.GenreId == data);
            }
            return View(filter);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Technicians.Add(technician);
                    context.SaveChanges();
                }
                else
                {
                    context.Technicians.Update(technician);
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Genres.OrderBy(t => t.Name).ToList();
                return View(technician);
            }
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index(string activeConf = "all", string activeDiv = "all")
        {
            var session = new TechnicianSession(HttpContext.Session);
            session.SetActiveConf(activeConf);
            session.SetActiveDiv(activeDiv);

            var model = new Technician
            {
                Name = activeConf,
                Email = activeDiv,
                Conferences = context.Conference,
                Divisions = context.Divisions
            };

            IQueryable<Technician> query = context.Technicians;
            if (activeConf != "all")
                query = query.Where(
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                    t => t.Conference == activeConf.ToLower());
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (activeDiv != "all")
                query = query.Where(
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                    t => t.Division == activeDiv.ToLower());
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
            model.Technicians = query.ToList();

            return View(model);

        }
    }
}
