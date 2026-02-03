using System;

namespace TravailleurScientifique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de l'application Travailleur & Scientifique");

            Scientifique scientifique = new Scientifique(
                nom: "Dupont",
                prenom: "Marie",
                telephone: "0612345678",
                email: "marie.dupont@email.com",
                nomEntreprise: "CNRS",
                adresseEntreprise: "Paris",
                telephoneProfessionnel: "0145678901",
                discipline: "Physique",
                typeScientifique: "Experimental"
            );

            Console.WriteLine(scientifique);

            Console.ReadLine();
        }
    }
}
