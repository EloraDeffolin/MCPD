using Exercice8.Classes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Compte bancaire classique");

        CompteBancaire compte = new CompteBancaire("Martin Dupont", 1200.50, "EUR");
        compte.AfficherSolde();
        compte.Deposer(800);
        compte.Retirer(500);
        compte.Retirer(2000);
        compte.AfficherSolde();

        Console.WriteLine("Compte Épargne");

        CompteEpargne compteEpargne = new CompteEpargne("Sophie Martin", 4500, "EUR", 2.5);
        compteEpargne.AfficherSolde();
        compteEpargne.Deposer(1500);
        compteEpargne.CalculerInterets();
        compteEpargne.AfficherSolde();

        Console.WriteLine("Compte Courant");

        CompteCourant compteCourant = new CompteCourant("Lucas Bernard", 300, "EUR", 800);
        compteCourant.AfficherSolde();
        compteCourant.Deposer(400);
        compteCourant.RetirerAvecDecouvert(900);  
        compteCourant.RetirerAvecDecouvert(600);   
        compteCourant.RetirerAvecDecouvert(1500);  
        compteCourant.AfficherSolde();

        Console.WriteLine("Fin du programme.");
    }Console.ReadLine();
}