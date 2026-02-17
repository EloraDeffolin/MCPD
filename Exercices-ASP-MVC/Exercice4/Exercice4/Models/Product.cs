using System;
using Exercice4.Models;
using Microsoft.AspNetCore.Mvc;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
}