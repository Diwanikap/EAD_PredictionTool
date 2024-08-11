using EAD_PredictionTool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EAD_PredictionTool.Controllers
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
            return View("Index");
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            _logger.LogInformation("POST /Login hit with username: {Username}", model.Username);

            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "123")
                {
                    _logger.LogInformation("Login successful");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    _logger.LogWarning("Invalid login attempt");
                    ModelState.AddModelError("Password", "Invalid login attempt."); 
                }
            }
            return View("Index",model);
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
