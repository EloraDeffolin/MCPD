namespace Exercice19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                int caisse = new Caisse();

                caisse.AjouterProduitAuCatalogue(1, "Eau 1.5L", 0.89m, 40);
                caisse.AjouterProduitAuCatalogue(2, "Pain de mie", 1.29m, 25);
                caisse.AjouterProduitAuCatalogue(3, "Café moulu 250g", 3.99m, 18);
                caisse.AjouterProduitAuCatalogue(4, "Lait 1L", 1.19m, 35);
                caisse.AjouterProduitAuCatalogue(5, "Pâtes 500g", 0.79m, 60);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== CAISSE ENREGISTREUSE ===\n");
                    Console.WriteLine("1. Nouvelle vente");
                    Console.WriteLine("2. Ajouter produit à la vente");
                    Console.WriteLine("3. Voir panier actuel");
                    Console.WriteLine("4. Valider la vente");
                    Console.WriteLine("5. Annuler la vente en cours");
                    Console.WriteLine("6. Voir catalogue produits");
                    Console.WriteLine("7. Ajouter un nouveau produit (admin)");
                    Console.WriteLine("0. Quitter");

                    Console.Write("Choix : ");
                    string choix = Console.ReadLine()?.Trim();

                    switch (choix)
                    {
                        case "1":
                            caisse.NouvelleVente();
                            Attendre();
                            break;

                        case "2":
                            caisse.AfficherCatalogue();
                            Console.Write("Numéro produit : ");
                            if (int.TryParse(Console.ReadLine(), out int num))
                            {
                                Console.Write("Quantité : ");
                                int qte = int.TryParse(Console.ReadLine(), out int q) ? q : 1;
                                caisse.AjouterProduitAVenteEnCours(num, qte);
                            }
                            Attendre();
                            break;

                        case "3":
                            caisse.AfficherVenteEnCours();
                            Attendre();
                            break;

                        case "4":
                            Console.Write("Type paiement (espece / cb) : ");
                            string type = Console.ReadLine()?.Trim().ToLower() ?? "";
                            string refPaie = "";
                            string infoCB = "";

                            if (type == "cb")
                            {
                                Console.Write("4 derniers chiffres CB : ");
                                infoCB = Console.ReadLine()?.Trim() ?? "";
                            }

                            Console.Write("Référence paiement (Entrée = auto) : ");
                            refPaie = Console.ReadLine()?.Trim();

                            caisse.ValiderVenteCourante(type, refPaie, infoCB);
                            Attendre();
                            break;

                        case "5":
                            caisse.AnnulerVenteCourante();
                            Attendre();
                            break;

                        case "6":
                            caisse.AfficherCatalogue();
                            Attendre();
                            break;

                        case "7":
                            Console.Write("Numéro : "); int.TryParse(Console.ReadLine(), out int n);
                            Console.Write("Nom : "); string nom = Console.ReadLine();
                            Console.Write("Prix : "); decimal.TryParse(Console.ReadLine(), out decimal prix);
                            Console.Write("Stock init : "); int.TryParse(Console.ReadLine(), out int stock);
                            caisse.AjouterProduitAuCatalogue(n, nom, prix, stock);
                            Attendre();
                            break;

                        case "0":
                            Console.WriteLine("Au revoir !");
                            return;

                        default:
                            Console.WriteLine("Choix invalide...");
                            Attendre();
                            break;
                    }
                }
            }

            static void Attendre()
            {
                Console.WriteLine("Appuyez sur une touche pour continuer");
                Console.ReadKey(true);
            }
        }
    }
}