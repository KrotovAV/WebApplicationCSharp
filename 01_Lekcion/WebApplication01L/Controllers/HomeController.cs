using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication01L.Models;

namespace WebApplication01L.Controllers
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
            this.ViewData["Text"] = "Hello World!!!";
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
        
        public IActionResult HelloWorld()
        {
            
            return Content("Hello World!!!4");
        }

        public IActionResult MyExeption()
        {
            throw new Exception("i am my exceptin");
            return Content("Hello World!!!4");
        }
    }
}