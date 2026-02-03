using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice3.Classes
{
    internal class Personnage
    {
        private string name;
        private int health;
        private int damage;

        public Personnage (string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public void Attack(Personnage adversaire)
        {
            if (this.IsAlive() || adversaire.IsAlive())
                return;

            adversaire.health -= this.damage;
            if (adversaire.health < 0)
                adversaire.health = 0;

            Console.WriteLine($" {this.name} a attaqué {adversaire.name} ");
            Console.WriteLine($" Il reste {adversaire.health} pv à {adversaire.name} ");
        }

        public bool IsAlive()
        {
            return this.health > 0;
        }

        Personnage()
        {
         Console.WriteLine($"{name} disparait.");
        }
    }
}
