using Haxwaves_master.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Haxwaves_master.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
         {
            return View(); // This will render Views/Home/About.cshtml
        }
        public IActionResult Services()
        {
           
            return View();
        }
        public IActionResult Why()
        {
            return View(); // This will render Views/Home/services.cshtml
        }
        public IActionResult team()
        {
            return View(); // This will render Views/Home/services.cshtml
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
