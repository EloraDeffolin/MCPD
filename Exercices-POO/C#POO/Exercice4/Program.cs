using Exercice4.Classes;

class Program
{
    static void Main(string[] args)
    {
        Chien.AfficherNbChiens();

        Chien c = new Chien();

        Chien c1 = new Chien("beethoven", "Saint Bernard", 15);

        Console.WriteLine(c1.ToString());
        Console.WriteLine(c1);

        c1.Presentation();

        Chien.AfficherNbChiens();
    }
}