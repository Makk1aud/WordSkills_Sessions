using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WordSkills_Session1.Models;

namespace WordSkills_Session1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Home()
        {
            return View();
        }
    }
}
