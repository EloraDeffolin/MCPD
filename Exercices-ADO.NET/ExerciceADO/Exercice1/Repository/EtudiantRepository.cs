static string connectionString = "Server=localhost;Uid=root;Pwd=;Database=ado"; sing GestionEtudiantsAdoNet.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionEtudiantsAdoNet.Repositories
{
    public class EtudiantRepository
    {

        string connectionString = "Server=localhost;Uid=root;Pwd=;Database=ado";

        public List<Etudiant> AfficherTousLesEtudiants()
        {
            List<Etudiant> etudiants = new List<Etudiant>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Nom, Prenom, DateNaissance, Email FROM etudiant ORDER BY Nom, Prenom;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            etudiants.Add(new Etudiant
                            {
                                Id = reader.GetInt32("ID"),
                                Nom = reader.GetString("Nom"),
                                Prenom = reader.GetString("Prenom"),
                                DateNaissance = reader.GetDateTime("DateNaissance"),
                                Email = reader.GetString("Email")
                            });
                        }
                    }
                }
            }

            return etudiants;
        }

        public void AjouterUnEtudiant(Etudiant e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"INSERT INTO Etudiant (nom, prenom, datenaissance, email) " + $"VALUES (@nom,@prenom,@datenaissance,@email)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", e.Nom);
                    command.Parameters.AddWithValue("@prenom", e.Prenom);
                    command.Parameters.AddWithValue("@dateNaissance", e.DateNaissance);
                    command.Parameters.AddWithValue("@email", e.Email);
                    int nbInsertion = command.ExecuteNonQuery();
                    Console.WriteLine($"Étudiant ajouté, nouvel ID : {nbInsertion}");
                }
            }
        }

        public void ModifierUnEtudiant(Etudiant e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    UPDATE etudiant SET
                    Nom = @nom,
                    Prenom = @prenom,
                    DateNaissance = @dateNaissance,
                    Email = @email
                    WHERE ID = @id;";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", e.Id);
                    command.Parameters.AddWithValue("@nom", e.Nom);
                    command.Parameters.AddWithValue("@prenom", e.Prenom);
                    command.Parameters.AddWithValue("@dateNaissance", e.DateNaissance);
                    command.Parameters.AddWithValue("@email", e.Email);
                    int nbModifications = command.ExecuteNonQuery();
                    Console.WriteLine($"Étudiant(s) modifié(s) : {nbModifications}");
                }
            }
        }

        public void SupprimerUnEtudiant(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM etudiant WHERE ID = @id;";

                using(MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int nbSuppressions = command.ExecuteNonQuery();
                    Console.WriteLine($"Étudiant(s) supprimé(s) : {nbSuppressions}");
                }
            }
        }

        public Etudiant AfficherUnEtudiantParSonId(int id)
        {
            Etudiant etudiant;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ID, Nom, Prenom, DateNaissance, Email FROM etudiant WHERE ID = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Etudiant
                            {
                                Id = reader.GetInt32("ID"),
                                Nom = reader.GetString("Nom"),
                                Prenom = reader.GetString("Prenom"),
                                DateNaissance = reader.GetDateTime("DateNaissance"),
                                Email = reader.GetString("Email"))
                            };
                        }
                    }
                }
            }
            
            return null;
        }
    }

            public void CreateTableEtudiant()
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                     string query = $"INSERT INTO Etudiant (nom, prenom, datenaissance, email) " + $"VALUES (@nom,@prenom,@datenaissance,@email)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
    }