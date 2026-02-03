using System;

namespace GestionSalaries
{

    class Salarie
    {
        private string nom;
        private string service;
        private double salaire;

        private static int nombreEmployes = 0;
        private static double masseSalarialeTotale = 0.0;

        public Salarie(string nom, string service, double salaire)
        {
            this.nom = nom;
            this.service = service;
            this.salaire = salaire;

            nombreEmployes++;
            masseSalarialeTotale += salaire;
        }

        public void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {nom} est de {salaire} euros.");
        }


        public static int GetNombreEmployes()
        {
            return nombreEmployes;
        }

        public static double GetMasseSalarialeTotale()
        {
            return masseSalarialeTotale;
        }

        public static void ResetNombreEmployes()
        {
            nombreEmployes = 0;

            Console.WriteLine("Le compteur du nombre d'employés a été remis à zéro.");
        }

        public static void AfficherStatistiquesGlobales()
        {
            Console.WriteLine($"Il y a actuellement {nombreEmployes} employé(s) dans l'entreprise.");
            Console.WriteLine($"Masse salariale totale : {masseSalarialeTotale:F0} euros.");
            Console.WriteLine();
        }
    }
}