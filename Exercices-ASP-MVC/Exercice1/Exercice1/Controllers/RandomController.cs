using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Exercice1.Controllers
{
    public class RandomController : Controller
    {
        public IActionResult Index()
        {
            Random random = new Random();
            int nombreAleatoire = random.Next(1, 100);

            ViewData["RandomNumber"] = nombreAleatoire;

            return View();
        }
    }
}
