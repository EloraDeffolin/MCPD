using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelManagement.Models;

namespace HotelManagement.Services;

public class HotelService
{
    private List<Client> _clients = new();
    private List<Chambre> _chambres = new();
    private List<Reservation> _reservations = new();

    private int _nextClientId = 1;
    private int _nextReservationId = 1;

    public HotelService()
    {
       
        InitialiserDonneesTest();
    }

    private void InitialiserDonneesTest()
    {
        
        AjouterClient("Dupont", "Jean", "06 12 34 56 78");
        AjouterClient("Martin", "Sophie", "07 89 01 23 45");
        AjouterClient("Leroy", "Paul", "06 99 88 77 66");
        AjouterClient("Bernard", "Émilie", "06 55 44 33 22");

        
        AjouterChambre(101, 2, 89.90m);
        AjouterChambre(102, 2, 94.50m);
        AjouterChambre(201, 1, 69.00m);
        AjouterChambre(202, 3, 129.00m);
        AjouterChambre(203, 2, 99.00m);
    }

    
    public void AjouterClient(string nom, string prenom, string telephone)
    {
        _clients.Add(new Client
        {
            Id = _nextClientId++,
            Nom = nom,
            Prenom = prenom,
            Telephone = telephone
        });
    }

    public IEnumerable<Client> GetClientsAlphabetique()
    {
        return _clients.OrderBy(c => c.Nom).ThenBy(c => c.Prenom);
    }

    
    public void AjouterChambre(int numero, int nbLits, decimal tarif)
    {
        _chambres.Add(new Chambre
        {
            Numero = numero,
            NbLits = nbLits,
            TarifParNuit = tarif,
            Statut = StatutChambre.Libre
        });
    }

    public IEnumerable<Chambre> GetChambresLibres()
    {
        return _chambres.Where(c => c.Statut == StatutChambre.Libre)
                       .OrderBy(c => c.Numero);
    }

    public IEnumerable<Chambre> GetToutesLesChambres()
    {
        return _chambres.OrderBy(c => c.Numero);
    }

    
    public void CreerReservation(int idClient, int numeroChambre, DateTime arrivee, DateTime depart)
    {
        int client = _clients.FirstOrDefault(c => c.Id == idClient);
        int chambre = _chambres.FirstOrDefault(c => c.Numero == numeroChambre);

        if (client == null || chambre == null)
        {
            Console.WriteLine("Client ou chambre introuvable.");
            return;
        }

        if (chambre.Statut != StatutChambre.Libre)
        {
            Console.WriteLine("La chambre n'est pas libre.");
            return;
        }

        _reservations.Add(new Reservation
        {
            Id = _nextReservationId++,
            Client = client,
            Chambre = chambre,
            DateArrivee = arrivee,
            DateDepart = depart,
            Statut = StatutReservation.Prevu
        });

        chambre.Statut = StatutChambre.Occupe;
        Console.WriteLine("Réservation créée avec succès !");
    }

    public void AfficherToutesReservations()
    {
        foreach (int res in _reservations.OrderBy(r => r.DateArrivee))
        {
            Console.WriteLine(res);
        }
    }
}
