using System;

namespace Exercice4.Classes
{
    internal class Chien
    {
        private string _nom;
        private string _race;
        private int _age;

        private static string _nomDuChenil = "Non défini";
        private static int _nbChiens = 0;

        public static int NbChiens => _nbChiens;

        public string Nom { get => _nom; set => _nom = value; }
        public string Race { get => _race; set => _race = value; }
        public int Age { get => _age; set => _age = value; }

        public Chien()
        {
            _nbChiens++;
        }

        public Chien(string nom, string race, int age)
            : this()  
        {
            _nom = nom;
            _race = race;
            _age = age;
        }

        public Chien(string nom, string race, int age, string nomChenil)
            : this(nom, race, age)  
        {
            _nomDuChenil = nomChenil;
        }

        public void StartEngine()  
        {
            Console.WriteLine($"Le chien {Nom} remue la queue !");
        }

        public static void AfficherNbChiens()
        {
            Console.WriteLine($"Il y a actuellement {NbChiens} chien(s) dans le chenil.");
        }

        public static void Presentation(string race)
        {
            Console.WriteLine($"La race {race} est super affectueuse !");
        }

        public override string ToString()
        {
            return $"Je m'appelle {Nom}, je suis un {Race}, j'ai {Age} an(s) – chenil : {_nomDuChenil}";
        }
    }
}


