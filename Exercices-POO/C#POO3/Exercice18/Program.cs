namespace Exercice18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {

                Bibliotheque biblio = new Bibliotheque();


                biblio.AjouterLivre("Les Douze Dieux", "Sage Ax", 25);
                biblio.AjouterLivre("Les Dofus Primordiaux", "Alibert le Sage", 15);
                biblio.AjouterLivre("Les Iops, force et honneur", "Maître Kahel", 10);
                biblio.AjouterLivre("Les Enutrofs et l'amour des kamas", "Prospecteur Roid", 5);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Gestion de la Bibliothèque du Monde des Douzes :");
                    Console.WriteLine("1. Ajouter un livre");
                    Console.WriteLine("2. Afficher tous les livres");
                    Console.WriteLine("3. Rechercher un livre par titre");
                    Console.WriteLine("4. Rechercher un livre par auteur");
                    Console.WriteLine("5. Supprimer un livre (par numéro)");
                    Console.WriteLine("0. Quitter la Bibliothèque du Monde des Douze");
                    Console.WriteLine("Votre choix final jeune Bouftoupi : ");

                    string choix = Console.ReadLine()?.Trim();

                    switch (choix)
                    {
                        case "1":
                            AjouterLivreMenu(biblio);
                            break;

                        case "2":
                            biblio.AfficherTousLesLivres();
                            break;

                        case "3":
                            Console.Write("Titre recherché : ");
                            string titre = Console.ReadLine();
                            biblio.RechercherParTitre(titre);
                            break;

                        case "4":
                            Console.Write("Auteur recherché : ");
                            string auteur = Console.ReadLine();
                            biblio.RechercherParAuteur(auteur);
                            break;

                        case "5":
                            Console.Write("Numéro du livre à supprimer : ");
                            if (int.TryParse(Console.ReadLine(), out int num))
                                biblio.SupprimerLivre(num);
                            else
                                Console.WriteLine("Numéro invalide.");
                            break;

                        case "0":
                            Console.WriteLine("J’étais venu pour un livre … Me voilà en plus avec une quête secondaire à Astrub tchip ! ");
                            return;

                        default:
                            Console.WriteLine("Par les Douze, ce choix n'est pas valable jeune Iopou !");
                            break;
                    }
                }
            }

            static void AjouterLivreMenu(Bibliotheque biblio)
            {
                Console.Write("Titre : ");
                string titre = Console.ReadLine();

                Console.Write("Auteur : ");
                string auteur = Console.ReadLine();

                Console.Write("Exemplaires : ");
                if (!int.TryParse(Console.ReadLine(), out int nb) || nb < 0)
                {
                    Console.WriteLine("Nombre d'exemplaires invalide, même un Bouftou ne peut pas porter autant de kamas.");
                    return;
                }

                biblio.AjouterLivre(titre, auteur, nb);
                Pause();
            }

            static void Pause()
            {
                Console.WriteLine("Appuie sur une case pour continuer (spoiler : c’était la case du puits, espèce de Bouftou mal peigné HAHA !).");
                Console.ReadKey(true);
            }
        }
    }
}