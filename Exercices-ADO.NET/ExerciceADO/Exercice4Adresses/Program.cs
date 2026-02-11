using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionAdresses
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;

            while (continuer)
            {
                AfficherMenu();

                string choix = Console.ReadLine();

                Console.WriteLine();

                switch (choix)
                {
                    case "1":
                        ListerToutesLesAdresses();
                        break;

                    case "2":
                        AjouterUneAdresse();
                        break;

                    case "3":
                        ModifierUneAdresse();
                        break;

                    case "4":
                        SupprimerUneAdresse();
                        break;

                    case "0":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;

                    default:
                        Console.WriteLine("Choix non valide");
                        break;
                }

                if (continuer)
                {
                    Console.WriteLine("Appuyez sur Entrée pour revenir au menu");
                    Console.ReadLine();
                }
            }
        }

        static void AfficherMenu()
        {
            Console.WriteLine("1. Lister toutes les adresses");
            Console.WriteLine("2. Ajouter une nouvelle adresse");
            Console.WriteLine("3. Modifier une adresse existante");
            Console.WriteLine("4. Supprimer une adresse");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
        }

        static void ListerToutesLesAdresses()
        {
            Console.WriteLine("LISTE DES ADRESSES :");

            using (AdressesDbContext contexte = new AdressesDbContext())
            {
               
                List<Adresse> toutesLesAdresses = contexte.Adresses.ToList();

                if (toutesLesAdresses.Count == 0)
                {
                    Console.WriteLine("Aucune adresse enregistrée pour le moment.");
                    return;
                }

                int numeroLigne = 1;
                foreach (Adresse adresse in toutesLesAdresses)
                {
                    Console.WriteLine($"{numeroLigne,2}. [{adresse.Id}] {adresse}");
                    numeroLigne++;
                }
            }
        }

        static void AjouterUneAdresse()
        {
            Console.WriteLine("AJOUT D'UNE NOUVELLE ADRESSE :");

            Adresse nouvelleAdresse = new Adresse();

            Console.Write("Numéro de voie (ex: 12, 3 bis) : ");
            nouvelleAdresse.NumeroVoie = Console.ReadLine();

            Console.Write("Complément (appart, étage, bât...) : ");
            nouvelleAdresse.Complement = Console.ReadLine();

            Console.Write("Intitulé de la voie : ");
            nouvelleAdresse.IntituleVoie = Console.ReadLine();

            Console.Write("Commune / Ville : ");
            nouvelleAdresse.Commune = Console.ReadLine();

            Console.Write("Code postal : ");
            nouvelleAdresse.CodePostal = Console.ReadLine();

            using (AdressesDbContext contexte = new AdressesDbContext())
            {
                contexte.Adresses.Add(nouvelleAdresse);
                contexte.SaveChanges();

                Console.WriteLine($"Adresse ajoutée avec succès ! (ID = {nouvelleAdresse.Id})");
                Console.WriteLine(nouvelleAdresse);
            }
        }

        static void ModifierUneAdresse()
        {
            Console.Write("Entrez l'ID de l'adresse à modifier : ");
            string saisie = Console.ReadLine();

            if (!int.TryParse(saisie, out int id))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            using (AdressesDbContext contexte = new AdressesDbContext())
            {
                Adresse adresse = contexte.Adresses.Find(id);

                if (adresse == null)
                {
                    Console.WriteLine("Aucune adresse trouvée avec cet ID.");
                    return;
                }

                Console.WriteLine("Adresse actuelle :");
                Console.WriteLine(adresse);
                Console.WriteLine();

                Console.Write($"Numéro de voie ({adresse.NumeroVoie}) : ");
                string temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp)) adresse.NumeroVoie = temp;

                Console.Write($"Complément ({adresse.Complement}) : ");
                temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp)) adresse.Complement = temp;

                Console.Write($"Voie ({adresse.IntituleVoie}) : ");
                temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp)) adresse.IntituleVoie = temp;

                Console.Write($"Commune ({adresse.Commune}) : ");
                temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp)) adresse.Commune = temp;

                Console.Write($"Code postal ({adresse.CodePostal}) : ");
                temp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(temp)) adresse.CodePostal = temp;

                contexte.SaveChanges();

                Console.WriteLine("Modification enregistrée !");
                Console.WriteLine(adresse);
            }
        }

        static void SupprimerUneAdresse()
        {
            Console.Write("Entrez l'ID de l'adresse à supprimer : ");
            string saisie = Console.ReadLine();

            if (!int.TryParse(saisie, out int id))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            using (AdressesDbContext contexte = new AdressesDbContext())
            {
                Adresse adresse = contexte.Adresses.Find(id);

                if (adresse == null)
                {
                    Console.WriteLine("Adresse introuvable.");
                    return;
                }

                Console.WriteLine("\nVous allez supprimer :");
                Console.WriteLine(adresse);
                Console.Write("Confirmer ? (oui/non) : ");

                string reponse = Console.ReadLine().ToLower();
                if (reponse != "oui" && reponse != "o" && reponse != "yes" && reponse != "y")
                {
                    Console.WriteLine("Suppression annulée.");
                    return;
                }

                contexte.Adresses.Remove(adresse);
                contexte.SaveChanges();

                Console.WriteLine("Adresse supprimée avec succès.");
            }
        }
    }
}