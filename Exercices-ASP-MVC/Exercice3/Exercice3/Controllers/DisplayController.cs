using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TonProjet.Controllers
{
    public class DisplayController : Controller
    {
        public IActionResult Index()
        {
            string prenom = "Toto";
            int age = 20;

            List<string> hobbies = new List<string>();
            hobbies.Add("Lecture");
            hobbies.Add("Sport");
            hobbies.Add("Musique");
            hobbies.Add("Jeux vidéo");

            ViewData["Prenom"] = prenom;
            ViewData["Age"] = age;
            ViewData["Hobbies"] = hobbies;

            return View();
        }
    }
}