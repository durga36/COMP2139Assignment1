using ASPAssignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace ASPAssignment1.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext context { get; set; }

        public HomeController(ProductContext ptx)
        {
            context = ptx;
        }

        [Route("[controller]s/{cat?}")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Index()
        {
            var products = context.Products
                .Include(p => p.Genre)
                .OrderBy(p => p.Name)
                .ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
