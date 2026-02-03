using Exercice12.Classes;

class Program
{
    static void Main()
    {
        Voiture voiture = new Voiture("Clio 3", "Renault");
        VoitureHybride hybride = new VoitureHybride("Spring", "Dacia");
        Hydravion hydravion = new Hydravion("Gannet S100", "Colyaer");

        Console.WriteLine(voiture);
        voiture.Demarrer();
        Console.WriteLine();

        Console.WriteLine(hybride);
        hybride.Demarrer();
        hybride.Recharger();
        Console.WriteLine();

        Console.WriteLine(hydravion);
        hydravion.Demarrer();
        hydravion.Naviguer();
        hydravion.Decoller();
        hydravion.Atterir();
    }
}