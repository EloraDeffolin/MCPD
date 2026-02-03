using Exercice3.Classes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" === DEBUT === ");

        Personnage p1 = new Personnage("Thor", 20, 5);
        Personnage p2 = new Personnage("Loki", 10, 3);

        while (p1.IsAlive() && p2.IsAlive())
        {
            p1.Attack(p2);
            if (p2.IsAlive())
                break;

            p2.Attack(p1);
        }

        if (p1.IsAlive())
            Console.WriteLine($" {p1.Name} gagne le combat !!! ");
        else
            Console.WriteLine($" {p2.Name} gagne le combat !!! ");

        Console.WriteLine(" === FIN DU COMBAT === ");
    }
}