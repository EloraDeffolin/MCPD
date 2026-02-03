namespace Exercice18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Bibliotheque biblio = new Bibliotheque();

                
                biblio.AjouterLivre("Le livre des Dofus, tome 1 : Julith", "Geneviève Chaussende", 5);
                biblio.AjouterLivre("Le livre des Dofus, tome 2 : Jiva", "Geneviève Chaussende", 3);
                biblio.AjouterLivre("Le livre des Dofus, tome 3 : Bolgrot", "Geneviève Chaussende", 2);
                biblio.AjouterLivre("Le livre des Dofus, tome 4 : Menalt", "Geneviève Chaussende", 7);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== Gestion de Bibliothèque ===\n");
                    Console.WriteLine("1 - Ajouter un livre");
                    Console.WriteLine("2 - Afficher tous les livres");
                    Console.WriteLine("3 - Rechercher un livre par titre");
                    Console.WriteLine("4 - Rechercher un livre par auteur");
                    Console.WriteLine("5 - Supprimer un livre (par numéro)");
                    Console.WriteLine("0 - Quitter\n");
                    Console.Write("Votre choix : ");

                    string choix = Console.ReadLine()?.Trim();

                    switch (choix)
                    {
                        case "1":
                            AjouterLivreMenu(biblio);
                            break;

                        case "2":
                            biblio.AfficherTousLesLivres();
                            Pause();
                            break;

                        case "3":
                            Console.Write("\nTitre recherché : ");
                            string titre = Console.ReadLine();
                            biblio.RechercherParTitre(titre);
                            Pause();
                            break;

                        case "4":
                            Console.Write("\nAuteur recherché : ");
                            string auteur = Console.ReadLine();
                            biblio.RechercherParAuteur(auteur);
                            Pause();
                            break;

                        case "5":
                           Console.Write("\nNuméro du livre à supprimer : ");
                           if (int.TryParse(Console.ReadLine(), out int num))
                              biblio.SupprimerLivre(num);
                          else
                                 Console.WriteLine("Numéro invalide.");
                           Pause();
                           break;

                        case "0":
                            Console.WriteLine("\nAu revoir !\n");
                            return;

                        default:
                            Console.WriteLine("\nChoix invalide...");
                            Pause();
                            break;
                    }
                }
            }

            static void AjouterLivreMenu(Bibliotheque biblio)
            {
                Console.Write("\nTitre      : ");
                string titre = Console.ReadLine();

                Console.Write("Auteur     : ");
                string auteur = Console.ReadLine();

                Console.Write("Exemplaires : ");
                if (!int.TryParse(Console.ReadLine(), out int nb) || nb < 0)
                {
                    Console.WriteLine("Nombre d'exemplaires invalide → annulé");
                    return;
                }

                biblio.AjouterLivre(titre, auteur, nb);
                Pause();
            }

            static void Pause()
            {
                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey(true);
            }
        }
    }
}