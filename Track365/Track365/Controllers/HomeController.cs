using Microsoft.AspNetCore.Mvc;

namespace Track365.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
