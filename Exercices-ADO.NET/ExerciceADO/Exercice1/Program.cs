using System;
using GestionEtudiantsAdoNet.Classes;
using GestionEtudiantsAdoNet.Repositories;

namespace GestionEtudiantsAdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            EtudiantRepository repo = new EtudiantRepository();

            repo.CreateTableEtudiant();
            Console.WriteLine("Table Etudiant créée.");

            while (true)
            {
                AfficherMenu();

                string choix = Console.ReadLine();

                Console.Clear();

                switch (choix)
                {
                    case "1":
                        AfficherTousLesEtudiants(repo);
                        break;

                    case "2":
                        AjouterEtudiant(repo);
                        break;

                    case "3":
                        ModifierEtudiant(repo);
                        break;

                    case "4":
                        SupprimerEtudiant(repo);
                        break;

                    case "0":
                        Console.WriteLine("Au revoir !");
                        return;

                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }

                Console.WriteLine("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
            }
        }

        static void AfficherMenu()
        {
            Console.WriteLine("1. Voir tous les étudiants");
            Console.WriteLine("2. Ajouter un étudiant");
            Console.WriteLine("3. Modifier un étudiant");
            Console.WriteLine("4. Supprimer un étudiant");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
        }

        static void AfficherTousLesEtudiants(EtudiantRepository repo)
        {
            List<Etudiant> etudiants = repo.AfficherTousLesEtudiants();

            Console.WriteLine("Liste des étudiants :");

            if (etudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant enregistré.");
                return;
            }

            Console.WriteLine(" ID  | Nom | Prénom | Naissance | Email : ");
            Console.WriteLine(new string('-', 80));

            foreach (Etudiant e in etudiants)
            {
                Console.WriteLine(e);
            }
        }

        static void AjouterEtudiant(EtudiantRepository repo)
        {
            Console.WriteLine("Ajout d'un étudiant : ");

            Etudiant e = new Etudiant();

            Console.Write("Nom : ");
            e.Nom = Console.ReadLine();

            Console.Write("Prénom : ");
            e.Prenom = Console.ReadLine();

            Console.Write("Date de naissance (jj/mm/aaaa) : ");
            if (!DateTime.TryParse(Console.ReadLine()))
            {
                Console.WriteLine("Date invalide, ajout annulé.");
                return;
            }
            e.DateNaissance = dateNaiss;

            Console.Write("Email (facultatif) : ");
            e.Email = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(e.Nom) || string.IsNullOrWhiteSpace(e.Prenom))
            {
                Console.WriteLine("Le nom et le prénom sont obligatoires !");
                return;
            }

            repo.AjouterUnEtudiant(e);
        }

        static void ModifierEtudiant(EtudiantRepository repo)
        {
            Console.Write("ID de l'étudiant à modifier : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Etudiant? e = repo.AfficherUnEtudiantParSonId(id);
            if (e == null)
            {
                Console.WriteLine("Étudiant non trouvé.");
                return;
            }

            Console.WriteLine("Étudiant actuel :");
            Console.WriteLine(e);

            Console.Write($"Nom ({e.Nom}) : ");
            string? saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) e.Nom = saisie;

            Console.Write($"Prénom ({e.Prenom}) : ");
            saisie = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(saisie)) e.Prenom = saisie;

            Console.Write($"Date naissance ({e.DateNaissance:dd/MM/yyyy}) : ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime nouvelleDate))
            {
                e.DateNaissance = nouvelleDate;
            }

            Console.Write($"Email {e.Email} : ");
            saisie = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(saisie)) e.Email = saisie;

            repo.ModifierUnEtudiant(e);
        }

        static void SupprimerEtudiant(EtudiantRepository repo)
        {
            Console.Write("ID de l'étudiant à supprimer : ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Etudiant? e = repo.AfficherUnEtudiantParSonId(id);
            if (e == null)
            {
                Console.WriteLine("Étudiant non trouvé.");
                return;
            }

            Console.WriteLine($"Étudiant trouvé : {e}");
            Console.Write("Confirmer la suppression ? (oui/non) : ");
            string? reponse = Console.ReadLine();

            if (reponse != "oui" && reponse != "non")
            {
                Console.WriteLine("Suppression annulée.");
                return;
            }

            repo.SupprimerUnEtudiant(id);
        }
    }
}