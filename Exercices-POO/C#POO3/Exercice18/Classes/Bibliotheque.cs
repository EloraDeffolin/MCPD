using System;
using System.Collections.Generic;

public class Bibliotheque
{
    class Bibliotheque()
    {
        private List<Livre> livres = new List<Livre>();
        private int prochainNumero = 1;

        public void AjouterLivre(string titre, string auteur, int exemplaires)
        {
            Livre nouveau = new Livre(prochainNumero++, titre, auteur, exemplaires);
            livres.Add(nouveau);
            Console.WriteLine($"Livre ajouté : {nouveau.Titre} {nouveau.Auteur}");
        }

        public bool SupprimerLivre(int numero)
        {
            Livre aSupprimer = livres.Find(l => l.Numero == numero);
            if (aSupprimer == null)
            {
                Console.WriteLine($"\nAucun livre trouvé avec le numéro {numero}");
                return false;
            }

            livres.Remove(aSupprimer);
            Console.WriteLine($"Livre supprimé : {aSupprimer.Titre} {aSupprimer.Auteur}");
            return true;
        }

        public void AfficherTousLesLivres()
        {
            if (livres.Count == 0)
            {
                Console.WriteLine("La bibliothèque est vide.");
                return;
            }

            Console.WriteLine("Liste des livres :");
            Console.WriteLine("N°");
            Console.WriteLine(" Titre");
            Console.WriteLine("Auteur");
            Console.WriteLine("Dispo");

            foreach (var livre in livres)
            {
                Console.WriteLine(livre);
            }
            Console.WriteLine($"Total : {livres.Count} livre(s)");
        }

        public void RechercherParTitre(string recherche)
        {
            string rechercheLower = recherche?.Trim().ToLower() ?? "";
            if (string.IsNullOrWhiteSpace(rechercheLower))
            {
                Console.WriteLine("Veuillez entrer un titre valide.");
                return;
            }

            var resultats = livres.FindAll(l => l.Titre.ToLower().Contains(rechercheLower));

            Console.WriteLine($"Résultats pour {recherche} :");
            if (resultats.Count == 0)
            {
                Console.WriteLine("Aucun livre trouvé.");
                return;
            }

            foreach (var livre in resultats)
            {
                Console.WriteLine(livre);
            }
            Console.WriteLine();
        }

        public void RechercherParAuteur(string recherche)
        {
            string rechercheLower = recherche?.Trim().ToLower() ?? "";
            if (string.IsNullOrWhiteSpace(rechercheLower))
            {
                Console.WriteLine("\nVeuillez entrer un auteur valide.");
                return;
            }

            var resultats = livres.FindAll(l => l.Auteur.ToLower().Contains(rechercheLower));

            Console.WriteLine($"Résultats pour auteur contenant {recherche} :");
            if (resultats.Count == 0)
            {
                Console.WriteLine(" Aucun livre trouvé.");
                return;
            }

            foreach (var livre in resultats)
            {
                Console.WriteLine(livre);
            }
            Console.WriteLine();
        }
    }
}
