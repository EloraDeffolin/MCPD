namespace Exercice20
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // CAS 1 : jeux video

            SortedSet<string> participants = new SortedSet<string>();

            participants.Add("Ratseau");
            participants.Add("Boomnasty");
            participants.Add("Zilimy");
            participants.Add("Ratseau");
            participants.Add("Akasha");
            participants.Add("Spicy_FR");

            Console.WriteLine("Liste des participants qui est triée : ");
            foreach (string pseudo in participants)
            {
                Console.WriteLine(pseudo);
            }

            string aVerifier = "Zilimy";
            if (participants.Contains(aVerifier))
            {
                Console.WriteLine($" Le/la Gameur(se) {aVerifier} est bien inscrit !");
            }
            else
            {
                Console.WriteLine($" Le/la Gameur(se) {aVerifier} n'est pas inscrit !");
            }

            // CAS 2 : File d’attente dans un service client

            Queue<string> fileAttente = new Queue<string>();

            fileAttente.Enqueue("Père-Fouras");
            fileAttente.Enqueue("Willy");
            fileAttente.Enqueue("Passe-Partout");
            fileAttente.Enqueue("Passe-Muraille");
            fileAttente.Enqueue("Felindra");

            Console.WriteLine("Appuyez sur Entrée pour traiter un client et pour quitter taper 'Q' : ");
            
            while (fileAttente.Count > 0)
            {
                Console.ReadLine();

                string client = fileAttente.Dequeue();
                Console.WriteLine($"Traitement commande du client {client} : ");

                Console.WriteLine($"Clients restant dans la file d'attente : {fileAttente.Count}");

                if (fileAttente.Count == 0)
                {
                    Console.WriteLine("La file est vide, c'est l'heure de la pause café !");
                }
            }

            // CAS 3 : Gestion des notes d’élèves

            Dictionary<string, double> notes = new Dictionary<string, double>();

            notes.Add("Jade", 15.5);
            notes.Add("Léa", 12);
            notes.Add("Hugo", 16);
            notes.Add("Nathan", 9);
            notes.Add("Enzo", 5);

            notes["Jade"] = 18.5;

            Console.WriteLine($"Note de Léa : {notes["Léa"]}/20");

            Console.WriteLine("Liste des élèves et leurs notes :");
            foreach (KeyValuePair<string, double> eleve in notes)
            {
                Console.WriteLine($"{eleve.Key,-12} : {eleve.Value,5}/20");
            }   Console.ReadLine();
        }
    }
}
