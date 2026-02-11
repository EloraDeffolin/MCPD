using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionRecettes
{
    class Program
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=ef;uid=root;pwd=",
                ServerVersion.AutoDetect("server=localhost;database=ef;uid=root;pwd=")
                );
        }

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
                        AfficherToutesLesRecettes();
                        break;

                    case "2":
                        AfficherTousLesIngredients();
                        break;

                    case "3":
                        AjouterUneRecette();
                        break;

                    case "4":
                        AjouterUnIngredient();
                        break;

                    case "5":
                        AfficherDetailRecette();
                        break;

                    case "6":
                        SupprimerUneRecette();
                        break;

                    case "7":
                        AfficherIngredientLePlusUtilise();
                        break;

                    case "8":
                        AfficherRecetteAvecLePlusDIngredients();
                        break;

                    case "0":
                        continuer = false;
                        Console.WriteLine("Au revoir !");
                        break;

                    default:
                        Console.WriteLine("Choix invalide, veuillez-recommencez.");
                        break;
                }

                Console.WriteLine("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
            }
        }


        static void AfficherMenu()
        {
            Console.WriteLine("  ____ _ _                           ");
            Console.WriteLine(" | _ \\ ___ ___ ___| |_| |_ ___     ");
            Console.WriteLine(" | |_) / _ \\/ __/ _ \\ __| __/ _ \\    ");
            Console.WriteLine(" |  _ <  __/ (_|  __/ |_| ||  __/    ");
            Console.WriteLine(" |_| \\_\\___|\\___\\___|\\__|\\__\\___|   \n");

            Console.WriteLine("1. Afficher les recettes");
            Console.WriteLine("2. Afficher les ingrédients");
            Console.WriteLine("3. Ajouter une recette");
            Console.WriteLine("4. Ajouter un ingrédient");
            Console.WriteLine("5. Afficher le détail d'une recette");
            Console.WriteLine("6. Supprimer une recette");
            Console.WriteLine("7. Afficher l'ingrédient le plus utilisé");
            Console.WriteLine("8. Afficher la recette avec le plus d'ingrédients");
            Console.WriteLine("0. Quitter");
            Console.Write("Votre choix : ");
        }


        static void AfficherToutesLesRecettes()
        {
            Console.WriteLine("LISTE DES RECETTES :");

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string requete = "SELECT recette_id, nom, description FROM Recette ORDER BY nom";
                using (SqlCommand commande = new SqlCommand(requete, connexion))
                {
                    using (SqlDataReader lecteur = commande.ExecuteReader())
                    {
                        while (lecteur.Read())
                        {
                            int id = lecteur.GetInt32(0);
                            string nom = lecteur.GetString(1);
                            string description = lecteur.GetString(2);

                            Console.WriteLine($"[{id}] {nom}");
                            Console.WriteLine($"    {description}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }


        static void AfficherTousLesIngredients()
        {
            Console.WriteLine("LISTE DES INGRÉDIENTS :");

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string requete = "SELECT ingredient_id, nom, description FROM Ingredient ORDER BY nom";
                using (SqlCommand commande = new SqlCommand(requete, connexion))
                {
                    using (SqlDataReader lecteur = commande.ExecuteReader())
                    {
                        while (lecteur.Read())
                        {
                            int id = lecteur.GetInt32(0);
                            string nom = lecteur.GetString(1);
                            string description = lecteur.GetString(2);

                            Console.WriteLine($"[{id}] {nom} - {description}");
                        }
                    }
                }
            }
        }


        static void AjouterUnIngredient()
        {
            Console.WriteLine("AJOUT D'UN INGRÉDIENT");

            Console.Write("Nom de l'ingrédient : ");
            string nom = Console.ReadLine();

            Console.Write("Description : ");
            string description = Console.ReadLine();

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string requete = "INSERT INTO Ingredient (nom, description) VALUES (@nom, @description)";
                using (SqlCommand commande = new SqlCommand(requete, connexion))
                {
                    commande.Parameters.AddWithValue("@nom", nom);
                    commande.Parameters.AddWithValue("@description", description);

                    int lignesAffectees = commande.ExecuteNonQuery();

                    if (lignesAffectees > 0)
                    {
                        Console.WriteLine("Ingrédient ajouté avec succès !");
                    }
                    else
                    {
                        Console.WriteLine("Erreur lors de l'ajout");
                    }
                }
            }
        }


        static void AjouterUneRecette()
        {
            Console.WriteLine("AJOUT D'UNE NOUVELLE RECETTE");

            Console.Write("Nom de la recette : ");
            string nom = Console.ReadLine();

            Console.Write("Description courte : ");
            string description = Console.ReadLine();

            Console.Write("Instructions (tout le texte) : ");
            string instructions = Console.ReadLine();

            int nouvelleRecetteId = -1;

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string requeteRecette =
                    "INSERT INTO Recette (nom, description, instructions) " +
                    "OUTPUT INSERTED.recette_id " +
                    "VALUES (@nom, @description, @instructions)";

                using (SqlCommand commande = new SqlCommand(requeteRecette, connexion))
                {
                    commande.Parameters.AddWithValue("@nom", nom);
                    commande.Parameters.AddWithValue("@description", description);
                    commande.Parameters.AddWithValue("@instructions", instructions);

                    nouvelleRecetteId = (int)commande.ExecuteScalar();
                }
                

                Console.WriteLine("Maintenant ajoutez les ingrédients (tapez 0 pour terminer)");

                while (true)
                {
                    Console.Write("ID de l'ingrédient (0 = fin) : ");
                    string saisie = Console.ReadLine();

                    if (saisie == "0")
                        break;

                    if (!int.TryParse(saisie, out int idIngredient))
                    {
                        Console.WriteLine("Ce n'est pas un nombre valide.");
                        continue;
                    }

                    Console.Write("Quantité (ex: 200g, 3, 1 pincée) : ");
                    string quantite = Console.ReadLine();

                    string requeteLien =
                        "INSERT INTO RecetteIngredient (recette_id, ingredient_id, quantite) " +
                        "VALUES (@recette_id, @ingredient_id, @quantite)";

                    using (SqlCommand cmdLien = new SqlCommand(requeteLien, connexion))
                    {
                        cmdLien.Parameters.AddWithValue("@recette_id", nouvelleRecetteId);
                        cmdLien.Parameters.AddWithValue("@ingredient_id", idIngredient);
                        cmdLien.Parameters.AddWithValue("@quantite", quantite);

                        cmdLien.ExecuteNonQuery();
                    }

                    Console.WriteLine("Ingrédient ajouté à la recette");
                }

                Console.WriteLine($"Recette {nom} créée avec succès ! (ID = {nouvelleRecetteId})");
            }
        }


        static void AfficherDetailRecette()
        {
            Console.Write("Entrez l'ID de la recette à afficher : ");
            string saisie = Console.ReadLine();

            if (!int.TryParse(saisie, out int idRecette))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

               
                string sqlRecette =
                    "SELECT nom, description, instructions FROM Recette WHERE recette_id = @id";

                using (SqlCommand cmd = new SqlCommand(sqlRecette, connexion))
                {
                    cmd.Parameters.AddWithValue("@id", idRecette);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Recette introuvable.");
                            return;
                        }

                        Console.WriteLine($"{reader.GetString(0)}");
                        Console.WriteLine(reader.GetString(1));
                        Console.WriteLine("Instructions :" + reader.GetString(2));
                    }
                }

               
                Console.WriteLine("Ingrédients :");
                string sqlIngredients =
                    @"SELECT i.nom, ri.quantite 
                      FROM RecetteIngredient ri
                      INNER JOIN Ingredient i ON ri.ingredient_id = i.ingredient_id
                      WHERE ri.recette_id = @id
                      ORDER BY i.nom";

                using (SqlCommand cmdIng = new SqlCommand(sqlIngredients, connexion))
                {
                    cmdIng.Parameters.AddWithValue("@id", idRecette);

                    using (SqlDataReader readerIng = cmdIng.ExecuteReader())
                    {
                        bool trouve = false;
                        while (readerIng.Read())
                        {
                            trouve = true;
                            Console.WriteLine($"• {readerIng.GetString(0)} → {readerIng.GetString(1)}");
                        }

                        if (!trouve)
                        {
                            Console.WriteLine("(aucun ingrédient pour le moment)");
                        }
                    }
                }
            }
        }


        static void SupprimerUneRecette()
        {
            Console.Write("ID de la recette à SUPPRIMER : ");
            string saisie = Console.ReadLine();

            if (!int.TryParse(saisie, out int idRecette))
            {
                Console.WriteLine("ID invalide.");
                return;
            }

            Console.Write($"Voulez-vous vraiment supprimer la recette {idRecette} ? (oui/non) : ");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation != "oui" && confirmation != "o")
            {
                Console.WriteLine("Suppression annulée.");
                return;
            }

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                
                string sqlSupprLiens = "DELETE FROM RecetteIngredient WHERE recette_id = @id";
                using (SqlCommand cmdLiens = new SqlCommand(sqlSupprLiens, connexion))
                {
                    cmdLiens.Parameters.AddWithValue("@id", idRecette);
                    cmdLiens.ExecuteNonQuery();
                }

                
                string sqlSupprRecette = "DELETE FROM Recette WHERE recette_id = @id";
                using (SqlCommand cmdRecette = new SqlCommand(sqlSupprRecette, connexion))
                {
                    cmdRecette.Parameters.AddWithValue("@id", idRecette);

                    int lignes = cmdRecette.ExecuteNonQuery();

                    if (lignes > 0)
                        Console.WriteLine("Recette et ses liens supprimés avec succès.");
                    else
                        Console.WriteLine("Aucune recette trouvée avec cet ID.");
                }
            }
        }


        static void AfficherIngredientLePlusUtilise()
        {
            Console.WriteLine("INGREDIENT LE PLUS UTILISÉ :");

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string sql =
                    @"SELECT TOP 1 i.nom, COUNT(ri.ingredient_id) AS nombre_recettes
                      FROM Ingredient i
                      INNER JOIN RecetteIngredient ri ON i.ingredient_id = ri.ingredient_id
                      GROUP BY i.nom
                      ORDER BY nombre_recettes DESC";

                using (SqlCommand cmd = new SqlCommand(sql, connexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Ingrédient : {reader.GetString(0)}");
                            Console.WriteLine($"Utilisé dans {reader.GetInt32(1)} recette(s)");
                        }
                        else
                        {
                            Console.WriteLine("Aucun ingrédient trouvé.");
                        }
                    }
                }
            }
        }


        static void AfficherRecetteAvecLePlusDIngredients()
        {
            Console.WriteLine("RECETTE AVEC LE PLUS D'INGRÉDIENTS :");

            using (SqlConnection connexion = new SqlConnection(connectionString))
            {
                connexion.Open();

                string sql =
                    @"SELECT TOP 1 r.nom, COUNT(ri.ingredient_id) AS nb_ingredients
                      FROM Recette r
                      INNER JOIN RecetteIngredient ri ON r.recette_id = ri.recette_id
                      GROUP BY r.nom
                      ORDER BY nb_ingredients DESC";

                using (SqlCommand cmd = new SqlCommand(sql, connexion))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Recette : {reader.GetString(0)}");
                            Console.WriteLine($"Contient {reader.GetInt32(1)} ingrédient(s)");
                        }
                        else
                        {
                            Console.WriteLine("Aucune recette trouvée.");
                        }
                    }
                }
            }
        }
    }
}