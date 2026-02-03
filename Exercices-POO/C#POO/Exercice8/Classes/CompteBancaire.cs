using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice8.Classes
{
    internal class CompteBancaire
    {
        public string Titulaire { get; private set; }
        public double Solde { get; private set; }
        public string Devise { get; private set; }

        public CompteBancaire(string titulaire, double soldeInitial, string devise)
        {
            Titulaire = titulaire;
            Solde = soldeInitial;
            Devise = devise;
        }

        public void Deposer(double montant)
        {
            if (montant > 0)
            {
                Solde += montant;
                Console.WriteLine($"Dépôt de {montant} {Devise} effectué.");
            }
            else
            {
                Console.WriteLine("Le montant à déposer doit être positif.");
            }
        }

        public virtual bool Retirer(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Le montant à retirer doit être positif.");
                return false;
            }

            if (montant <= Solde)
            {
                Solde -= montant;
                Console.WriteLine($"Retrait de {montant} {Devise} effectué.");
                return true;
            }
            else
            {
                Console.WriteLine("Solde insuffisant.");
                return false;
            }
        }

        public void AfficherSolde()
        {
            Console.WriteLine($"Solde du compte de {Titulaire} : {Solde} {Devise}");
        }
    }

    public class CompteEpargne : CompteBancaire
    {
        public double TauxInteret { get; private set; }

        public CompteEpargne(string titulaire, double soldeInitial, string devise, double tauxInteret)
            : base(titulaire, soldeInitial, devise)
        {
            TauxInteret = tauxInteret;
        }

        public void CalculerInterets()
        {
            double interets = Solde * (TauxInteret / 100);
            Solde += interets;
            Console.WriteLine($"Intérêts calculés ({TauxInteret}) : +{interets} {Devise}");
        }
    }

    public class CompteCourant : CompteBancaire
    {
        public double DecouvertAutorise { get; private set; }

        public CompteCourant(string titulaire, double soldeInitial, string devise, double decouvertAutorise)
            : base(titulaire, soldeInitial, devise)
        {
            DecouvertAutorise = decouvertAutorise;
        }

        public bool RetirerAvecDecouvert(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Le montant à retirer doit être positif.");
                return false;
            }

            double soldeDisponible = Solde + DecouvertAutorise;

            if (montant <= soldeDisponible)
            {
                Solde -= montant;
                Console.WriteLine($"Retrait avec découvert de {montant} {Devise} effectué.");
                if (Solde < 0)
                {
                    Console.WriteLine($"Vous êtes à découvert de {Solde} {Devise}");
                }
                return true;
            }
            else
            {
                Console.WriteLine($"Retrait impossible : dépassement du découvert autorisé {DecouvertAutorise} {Devise}");
                return false;
            }
        }
        public override bool Retirer(double montant)
        {
            Console.WriteLine("Pour un compte courant, préférez utiliser RetirerAvecDecouvert.");
            return base.Retirer(montant);
        }Console.ReadLine();
    }
}

