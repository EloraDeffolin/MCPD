using System;

namespace Exercice6.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Student() { }
        public Student(string firstname, string lastname, int age, string email)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Email = email;
        }

    }
}