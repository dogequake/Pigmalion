using Microsoft.AspNetCore.Mvc;
using Pigmalion.Models;
using System.Diagnostics;

namespace Pigmalion.Controllers
{
    public class HomeController : Controller
    {
        private readonly PigmalionContext _context;

        public HomeController(PigmalionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Index(string numphone)
        {
            return View();
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