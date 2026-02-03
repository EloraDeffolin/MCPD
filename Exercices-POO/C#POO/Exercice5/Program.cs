using GestionSalaries;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Gestion des salariés");

        Salarie s1 = new Salarie("Chloé", "Marketing", 24000);
        Salarie s2 = new Salarie("Pierre", "Développement", 30000);
        Salarie s3 = new Salarie("Sam", "Direction", 36000);

        s1.AfficherSalaire();
        s2.AfficherSalaire();
        s3.AfficherSalaire();

        Console.WriteLine();

        Salarie.AfficherStatistiquesGlobales();

        Console.WriteLine($"Le montant total des salaires des {Salarie.GetNombreEmployes()} employés est de {Salarie.GetMasseSalarialeTotale()} euros.");

        Console.WriteLine("Appuyez sur Entrée pour faire un reset du compteur");
        Console.ReadLine();

        Salarie.ResetNombreEmployes();

        Salarie.AfficherStatistiquesGlobales();

        Console.WriteLine("Fin du programme.");
        Console.ReadLine();
    }
}
