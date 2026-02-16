using Microsoft.AspNetCore.Mvc;
using VotreNomDeProjet.Models;
using System.Collections.Generic;
using System.Linq;

namespace Dogs.Controllers
{
    public class DogController : Controller
    {
        public List<Dog> Dogs { get; set; }

        public DogController()

        {
            Dogs = new List<Dog>();
            Dogs.Add(new Dog(1, "Rex", 4, "Berger allemand"));
            Dogs.Add(new Dog(2, "Luna", 2, "Labrador"));
            Dogs.Add(new Dog(3, "Max", 7, "Golden Retriever"));
            Dogs.Add(new Dog(4, "Bella", 3, "Husky"));
            Dogs.Add(new Dog(5, "Charlie", 1, "Beagle"));
        };

        // http:localhost:5239/Dog/AfficherDog/1
        // http:localhost:5239/Dog/AfficherDog?id=1
        public IActionResult AfficherDog(int id)
        {
            var dog = _dogs.FirstOrDefault(d => d.Id == id);

            if (dog == null)
            {
                // Redirection si ID invalide
                return RedirectToAction("DisplayAll");
            }

            ViewData["Dog"] = dog;
            return View();
        }

        // GET: /Dog/DisplayAll
        public IActionResult DisplayAll()
        {
            ViewData["Dogs"] = _dogs;
            return View();
        }

        // GET: /Dog/Greeting
        // GET: /Dog/Greeting?name=Toto
        public IActionResult Greeting(string? name)
        {
            string message = string.IsNullOrWhiteSpace(name)
                ? "Bonjour visiteur !"
                : $"Bonjour {name} ! Content de te voir !";

            ViewData["Message"] = message;
            return View();
        }
    }
}