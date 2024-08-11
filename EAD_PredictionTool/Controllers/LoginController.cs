using Microsoft.AspNetCore.Mvc;

namespace EAD_PredictionTool.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
