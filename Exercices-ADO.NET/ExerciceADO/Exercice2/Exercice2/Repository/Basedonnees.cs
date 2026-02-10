using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class DatabaseService
{
    string connectionString = "Server=localhost;Uid=root;Pwd=;Database=ado";

    public List<Client> GetAllClients()
    {
        List<Clients> clients = new List<Clients>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            string sql = "SELECT ID, Nom, Prenom, Adresse, CodePostal, Ville, Telephone FROM Clients";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (SqlDataReader lecteur = commande.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Client c = new Client();
                        c.Id = lecteur.GetInt32(0);
                        c.Nom = lecteur.GetString(1);
                        c.Prenom = lecteur.GetString(2);
                        c.Adresse = lecteur.IsDBNull(3) ? "" : lecteur.GetString(3);
                        c.CodePostal = lecteur.IsDBNull(4) ? "" : lecteur.GetString(4);
                        c.Ville = lecteur.IsDBNull(5) ? "" : lecteur.GetString(5);
                        c.Telephone = lecteur.IsDBNull(6) ? "" : lecteur.GetString(6);

                        clients.Add(c);
                    }
                }
            }
        }

        return clients;
    }

   
    public bool AjouterClient(Client nouveauClient)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            string sql = @"INSERT INTO Clients 
                          (Nom, Prenom, Adresse, CodePostal, Ville, Telephone)
                          VALUES 
                          (@nom, @prenom, @adresse, @cp, @ville, @tel)";

            using (SqlCommand commande = new SqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@nom", nouveauClient.Nom);
                commande.Parameters.AddWithValue("@prenom", nouveauClient.Prenom);
                commande.Parameters.AddWithValue("@adresse", (object)nouveauClient.Adresse ?? DBNull.Value);
                commande.Parameters.AddWithValue("@cp", (object)nouveauClient.CodePostal ?? DBNull.Value);
                commande.Parameters.AddWithValue("@ville", (object)nouveauClient.Ville ?? DBNull.Value);
                commande.Parameters.AddWithValue("@tel", (object)nouveauClient.Telephone ?? DBNull.Value);

                int lignesAffectees = commande.ExecuteNonQuery();
                return lignesAffectees == 1;
            }
        }
    }

   
    public bool ModifierClient(Client clientModifie)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            string sql = @"UPDATE Clients SET 
                           Nom = @nom,
                           Prenom = @prenom,
                           Adresse = @adresse,
                           CodePostal = @cp,
                           Ville = @ville,
                           Telephone = @tel
                           WHERE ID = @id";

            using (SqlCommand commande = new SqlCommand(sql, connexion))
            {
                commande.Parameters.AddWithValue("@id", clientModifie.Id);
                commande.Parameters.AddWithValue("@nom", clientModifie.Nom);
                commande.Parameters.AddWithValue("@prenom", clientModifie.Prenom);
                commande.Parameters.AddWithValue("@adresse", (object)clientModifie.Adresse ?? DBNull.Value);
                commande.Parameters.AddWithValue("@cp", (object)clientModifie.CodePostal ?? DBNull.Value);
                commande.Parameters.AddWithValue("@ville", (object)clientModifie.Ville ?? DBNull.Value);
                commande.Parameters.AddWithValue("@tel", (object)clientModifie.Telephone ?? DBNull.Value);

                int lignes = commande.ExecuteNonQuery();
                return lignes == 1;
            }
        }
    }

    
    public bool SupprimerClient(int idClient)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            
            using (SqlTransaction transaction = connexion.BeginTransaction())
            {
                try
                {
                    
                    string sqlCmd = "DELETE FROM Commandes WHERE ClientID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlCmd, connexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", idClient);
                        cmd.ExecuteNonQuery();
                    }

                    
                    string sqlClient = "DELETE FROM Clients WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(sqlClient, connexion, transaction))
                    {
                        cmd.Parameters.AddWithValue("@id", idClient);
                        int lignes = cmd.ExecuteNonQuery();

                        transaction.Commit();
                        return lignes == 1;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }

    
    public void AfficherDetailClient(int idClient)
    {
        Client client = null;
        List<Commande> commandes = new List<Commande>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            
            string sqlClient = "SELECT * FROM Clients WHERE ID = @id";
            using (SqlCommand cmd = new SqlCommand(sqlClient, connexion))
            {
                cmd.Parameters.AddWithValue("@id", idClient);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        client = new Client();
                        client.Id = r.GetInt32(r.GetOrdinal("ID"));
                        client.Nom = r.GetString(r.GetOrdinal("Nom"));
                        client.Prenom = r.GetString(r.GetOrdinal("Prenom"));
                        client.Adresse = r.IsDBNull(r.GetOrdinal("Adresse")) ? "" : r.GetString(r.GetOrdinal("Adresse"));
                        client.CodePostal = r.IsDBNull(r.GetOrdinal("CodePostal")) ? "" : r.GetString(r.GetOrdinal("CodePostal"));
                        client.Ville = r.IsDBNull(r.GetOrdinal("Ville")) ? "" : r.GetString(r.GetOrdinal("Ville"));
                        client.Telephone = r.IsDBNull(r.GetOrdinal("Telephone")) ? "" : r.GetString(r.GetOrdinal("Telephone"));
                    }
                }
            }

            
            string sqlCmd = "SELECT ID, Date, Total FROM Commandes WHERE ClientID = @id ORDER BY Date DESC";
            using (SqlCommand cmd = new SqlCommand(sqlCmd, connexion))
            {
                cmd.Parameters.AddWithValue("@id", idClient);
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Commande c = new Commande();
                        c.Id = r.GetInt32(0);
                        c.DateCommande = r.GetDateTime(1);
                        c.Total = r.GetDecimal(2);
                        commandes.Add(c);
                    }
                }
            }
        }

        if (client == null)
        {
            Console.WriteLine("Client introuvable.");
            return;
        }

        Console.WriteLine("\n=== DÉTAIL CLIENT ===");
        Console.WriteLine($"ID       : {client.Id}");
        Console.WriteLine($"Nom      : {client.Nom} {client.Prenom}");
        Console.WriteLine($"Adresse  : {client.Adresse}");
        Console.WriteLine($"CP/Ville : {client.CodePostal} {client.Ville}");
        Console.WriteLine($"Téléphone: {client.Telephone}");
        Console.WriteLine("\nCOMMANDES :");

        if (commandes.Count == 0)
        {
            Console.WriteLine("  Aucune commande pour ce client.");
        }
        else
        {
            foreach (Commande cmd in commandes)
            {
                Console.WriteLine($"  N°{cmd.Id,-6} | {cmd.DateCommande:dd/MM/yyyy} | {cmd.Total,10:F2} €");
            }
        }
        Console.WriteLine();
    }

    
    public bool AjouterCommande(int clientId, DateTime date, decimal total)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connexion.Open();

            string sql = @"INSERT INTO Commandes (ClientID, Date, Total)
                           VALUES (@clientId, @date, @total)";

            using (SqlCommand cmd = new SqlCommand(sql, connexion))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@total", total);

                int lignes = cmd.ExecuteNonQuery();
                return lignes == 1;
            }
        }
    }
}
