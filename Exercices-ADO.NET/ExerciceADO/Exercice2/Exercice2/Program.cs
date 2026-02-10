using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DatabaseService db = new DatabaseService();

        while (true)
        {
            Console.Clear();
            AfficherMenu();

            Console.Write("Choix : ");
            string choixStr = Console.ReadLine();

            if (!int.TryParse(choixStr, out int choix))
            {
                Console.WriteLine("Choix invalide");
                AttendreTouche();
                continue;
            }

            switch (choix)
            {
                case 1:
                    AfficherTousLesClients(db);
                    break;

                case 2:
                    CreerClient(db);
                    break;

                case 3:
                    ModifierClient(db);
                    break;

                case 4:
                    SupprimerClient(db);
                    break;

                case 5:
                    AfficherDetailClient(db);
                    break;

                case 6:
                    AjouterCommande(db);
                    break;

                case 0:
                    Console.WriteLine("Au revoir !");
                    return;

                default:
                    Console.WriteLine("Option inconnue");
                    break;
            }

            AttendreTouche();
        }
    }

    static void AfficherMenu()
    {
        
        Console.WriteLine("1. Afficher les clients");
        Console.WriteLine("2. Créer un client");
        Console.WriteLine("3. Modifier un client");
        Console.WriteLine("4. Supprimer un client");
        Console.WriteLine("5. Afficher les détails d'un client");
        Console.WriteLine("6. Ajouter une commande");
        Console.WriteLine("0. Quitter");
        Console.WriteLine();
    }

    static void AfficherTousLesClients(DatabaseService db)
    {
        List<Client> clients = db.GetAllClients();

        Console.WriteLine("LISTE DES CLIENTS : ");
        if (clients.Count == 0)
        {
            Console.WriteLine("Aucun client pour le moment.");
            return;
        }

        Console.WriteLine("ID | Nom Prénom | Ville");
        foreach (Client c in clients)
        {
            Console.WriteLine($"{c.Id,-4} | {c.Nom,-15} {c.Prenom,-12} | {c.Ville}");
        }
        Console.WriteLine();
    }

    static void CreerClient(DatabaseService db)
    {
        Client c = new Client();

        Console.Write("Nom : "); c.Nom = Console.ReadLine();
        Console.Write("Prénom : "); c.Prenom = Console.ReadLine();
        Console.Write("Adresse : "); c.Adresse = Console.ReadLine();
        Console.Write("Code postal : "); c.CodePostal = Console.ReadLine();
        Console.Write("Ville : "); c.Ville = Console.ReadLine();
        Console.Write("Téléphone : "); c.Telephone = Console.ReadLine();

        bool succes = db.AjouterClient(c);
        if (succes)
            Console.WriteLine("Client créé avec succès !");
        else
            Console.WriteLine("Erreur lors de la création");
    }

    static void ModifierClient(DatabaseService db)
    {
        Console.Write("ID du client à modifier : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID invalide.");
            return;
        }

        Client c = new Client();
        c.Id = id;

        Console.Write("Nouveau Nom : "); c.Nom = Console.ReadLine();
        Console.Write("Nouveau Prénom : "); c.Prenom = Console.ReadLine();
        Console.Write("Nouvelle Adresse : "); c.Adresse = Console.ReadLine();
        Console.Write("Nouveau CP : "); c.CodePostal = Console.ReadLine();
        Console.Write("Nouvelle Ville : "); c.Ville = Console.ReadLine();
        Console.Write("Nouveau Téléphone : "); c.Telephone = Console.ReadLine();

        bool ok = db.ModifierClient(c);
        Console.WriteLine(ok ? "Modification réussie !" : "Erreur ou client introuvable.");
    }

    static void SupprimerClient(DatabaseService db)
    {
        Console.Write("ID du client à supprimer : ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bool ok = db.SupprimerClient(id);
            Console.WriteLine(ok ? "Client et ses commandes supprimés." : "Erreur ou client introuvable.");
        }
        else
        {
            Console.WriteLine("ID invalide.");
        }
    }

    static void AfficherDetailClient(DatabaseService db)
    {
        Console.Write("ID du client : ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            db.AfficherDetailClient(id);
        }
        else
        {
            Console.WriteLine("ID invalide.");
        }
    }

    static void AjouterCommande(DatabaseService db)
    {
        Console.Write("ID du client : ");
        if (!int.TryParse(Console.ReadLine(), out int clientId))
        {
            Console.WriteLine("ID invalide.");
            return;
        }

        Console.Write("Date (jj/mm/aaaa) : ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Format de date invalide.");
            return;
        }

        Console.Write("Montant total : ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal total))
        {
            Console.WriteLine("Montant invalide.");
            return;
        }

        bool ok = db.AjouterCommande(clientId, date, total);
        Console.WriteLine(ok ? "Commande ajoutée !" : "Erreur lors de l'ajout.");
    }

    static void AttendreTouche()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer");
        Console.ReadKey(true);
    }
}