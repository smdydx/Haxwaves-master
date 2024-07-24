using Haxwaves_master.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        
        public IActionResult Contact()
        {
            var createDb = new Contact();
            createDb.OnGet(); // Assuming OnGet() retrieves data needed for creating a client
            return View(createDb);
        }

        [HttpPost]
        public IActionResult Contact(Contact createDb)
        {
            createDb.OnPost(HttpContext);

            if (!string.IsNullOrEmpty(createDb.ErrorMessage))
            {
                ModelState.AddModelError("", createDb.ErrorMessage);
                return View(createDb); // Return the view with errors
            }

            TempData["SuccessMessage"] = createDb.SuccessMessage;
            return RedirectToAction("Client"); // Redirect to client list after successful creation
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
