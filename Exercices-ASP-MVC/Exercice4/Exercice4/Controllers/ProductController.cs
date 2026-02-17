using System;
using Exercice4.Models;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController()
    {
        _productService = new ProductService();
    }

    public IActionResult Index()
    {
        List<Product> products = _productService.GetAllProducts();
        return View(products);
    }

    
    public IActionResult Details(int id)
    {
        Product product = _productService.GetProductById(id);

        if (product == null)
        {
            return HttpNotFound();
        }

        return View(product);
    }

    public IActionResult Filter(string category, double? maxPrice)
    {
        List<Product> products = _productService.GetFilteredProducts(category, maxPrice);
        return View("Index", products);
    }
}
