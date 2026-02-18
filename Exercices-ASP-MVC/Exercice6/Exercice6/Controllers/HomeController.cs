using Microsoft.AspNetCore.Mvc;

namespace Exercice6.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
