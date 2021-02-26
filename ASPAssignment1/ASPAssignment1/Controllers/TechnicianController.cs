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

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(t => t.CategoryName).ToList();
            return View("Edit", new Technician());
        }

        public IActionResult Details(int id)
        {
            var technician = context.Technicians
                .Include(t => t.Category)
                .FirstOrDefault(t => t.CategoryId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(t => t.CategoryName).ToList();

            var technician = context.Technicians
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TechnicianId == id);
            return View(technician);
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
                ViewBag.Categories = context.Categories.OrderBy(t => t.CategoryName).ToList();
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
    }
}
