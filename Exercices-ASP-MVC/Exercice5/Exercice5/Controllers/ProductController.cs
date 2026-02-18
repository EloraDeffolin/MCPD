using System;
using System.Diagnostics;
using Exercice5_Formulaire_Routing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice5_Formulaire_Routing.Controllers
{
    [Route("Accueil")]
    public class ProductController : Controller
    {

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Product"] = model;

            return RedirectToAction("Details");
        }

        [HttpGet]
        public IActionResult Details()
        {
            int product = TempData["Product"] as Product;

            if (product == null)
            {
                return RedirectToAction("Form");
            }

            return View(product);
        }
    }
}