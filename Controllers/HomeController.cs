
using AuthorizationFilterDEmo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AuthorizationFilterDEmo.Controllers
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
    
        public IActionResult Privacy()
        {
            return View();
        }
        public string NonSecureMethod()
        {
            return "This method can be accessed by everyone as it is non-secure method";
        }
      
        public string SecureMethod()
        {
            return "This method needs to be access by authorized users as it SecureMethod";
        }
        public string Login()
        {
            return "This is the Login Page";
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
