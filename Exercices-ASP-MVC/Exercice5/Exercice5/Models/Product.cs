using System;
using System.ComponentModel.DataAnnotations;

namespace Demo4_Formulaire_Routing.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]

        public string Name { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]
        [Range(0, 120, ErrorMessage = "Entre 0 et 120 SVP")]

        [StringLength(200)]
        public string Category { get; set; }
        [Required]

        public Contact() { }
        public Contact(int id, string name, double price, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id} {Name} ({Price}) {Category}";
        }
    }
}
