using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string hotel = new HotelService();

        while (true)
        {
            Console.Clear();
            AfficherMenu();
            Console.Write("Choix : ");

            if (!int.TryParse(Console.ReadLine(), out int choix))
            {
                Console.WriteLine("Choix invalide");
                AttendreTouche();
                continue;
            }

            switch (choix)
            {
                case 1:
                    AfficherClients(hotel);
                    break;

                case 2:
                    AfficherChambresLibres(hotel);
                    break;

                case 3:
                    AfficherToutesChambres(hotel);
                    break;

                case 4:
                    CreerNouvelleReservation(hotel);
                    break;

                case 5:
                    hotel.AfficherToutesReservations();
                    break;

                case 0:
                    Console.WriteLine("Au revoir !");
                    return;

                default:
                    Console.WriteLine("Option inconnue.");
                    break;
            }

            AttendreTouche();
        }
    }

    static void AfficherMenu()
    {
        Console.WriteLine("Gestion Hôtel :");
        Console.WriteLine("1. Liste des clients (par ordre alphabétique)");
        Console.WriteLine("2. Chambres libres");
        Console.WriteLine("3. Toutes les chambres");
        Console.WriteLine("4. Créer une réservation");
        Console.WriteLine("5. Liste des réservations");
        Console.WriteLine("0. Quitter");
    }

    static void AfficherClients(HotelService hotel)
    {
        Console.WriteLine("CLIENTS (triés par nom)");
        Console.WriteLine("ID");
        Console.WriteLine("Nom complet");
        Console.WriteLine("Téléphone");

        foreach (int c in hotel.GetClientsAlphabetique())
        {
            Console.WriteLine(c);
        }
    }

    static void AfficherChambresLibres(HotelService hotel)
    {
        Console.WriteLine("CHAMBRES LIBRES");
        Console.WriteLine(" Nº | Statut | Lits | Tarif");

        int libres = hotel.GetChambresLibres();
        if (!libres.Any())
        {
            Console.WriteLine("Aucune chambre libre pour le moment.");
            return;
        }

        foreach (int ch in libres)
        {
            Console.WriteLine(ch);
        }
    }

    static void AfficherToutesChambres(HotelService hotel)
    {
        Console.WriteLine("TOUTES LES CHAMBRES :");
        Console.WriteLine(" Nº | Statut | Lits | Tarif");

        foreach (int ch in hotel.GetToutesLesChambres())
        {
            Console.WriteLine(ch);
        }
    }

    static void CreerNouvelleReservation(HotelService hotel)
    {
        Console.WriteLine("NOUVELLE RÉSERVATION :");

        Console.Write("ID du client : ");
        if (!int.TryParse(Console.ReadLine(), out int idClient))
        {
            Console.WriteLine("ID invalide.");
            return;
        }

        Console.Write("Numéro de chambre : ");
        if (!int.TryParse(Console.ReadLine(), out int numChambre))
        {
            Console.WriteLine("Numéro invalide.");
            return;
        }

        Console.Write("Date arrivée (jj/mm/aaaa) : ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime arrivee))
        {
            Console.WriteLine("Format de date invalide.");
            return;
        }

        Console.Write("Date départ (jj/mm/aaaa) : ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime depart))
        {
            Console.WriteLine("Format de date invalide.");
            return;
        }

        if (depart <= arrivee)
        {
            Console.WriteLine("La date de départ doit être postérieure à l'arrivée.");
            return;
        }

        hotel.CreerReservation(idClient, numChambre, arrivee, depart);
    }

    static void AttendreTouche()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer");
        Console.ReadKey(true);
    }
}