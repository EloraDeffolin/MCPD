using System;
using System.ComponentModel.DataAnnotations;
using.System.ComponentModel.DataAnnotations.Schema;

namespace DemoEntityFramework.Model
{
    [Table("personne")]
    internal class Personne
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Personne() { }

        public Personne(string firtName, string lastName, int age, string phone, string email)
        {
            
            FirstName = firtName;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Email = email;
        }


        public override string ToString()
        {
            return $"Id : {Id}, Name : {FirstName} {LastName}, Age : {Age}, Contact : {Phone} {Email}.";
        }

    }
}