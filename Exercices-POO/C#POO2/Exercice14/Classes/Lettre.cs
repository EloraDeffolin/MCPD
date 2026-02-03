using System;

public class Lettre
{
    public object Expediteur { get; internal set; }

    public class Lettre()
    {
        public User Expediteur { get; private set; }
        public User Destinataire { get; private set; }
        public string Contenu { get; private set; }
        public StatutLettre Statut { get; private set; }
        public DateTime? DateEnvoi { get; private set; }
        public DateTime? DateLecture { get; private set; }

        public Lettre(User expediteur, User destinataire, string contenu)
        {
            Expediteur = expediteur ?? throw new ArgumentNullException(nameof(expediteur));
            Destinataire = destinataire ?? throw new ArgumentNullException(nameof(destinataire));
            Contenu = contenu ?? "";
            Statut = StatutLettre.Brouillon;
        }

        public void Envoyer()
        {
            if (Statut == StatutLettre.Brouillon || Statut == StatutLettre.EnAttente)
            {
                Statut = StatutLettre.Envoyee;
                DateEnvoi = DateTime.Now;
                Console.WriteLine($"Lettre envoyée de {Expediteur.NomComplet} à {Destinataire.NomComplet}");
            }
            else
            {
                Console.WriteLine("Cette lettre a déjà été envoyée ou est dans un autre état.");
            }
        }

        public void Recevoir()
        {
            if (Statut == StatutLettre.Envoyee)
            {
                Statut = StatutLettre.Recue;
                Console.WriteLine($"Lettre reçue par {Destinataire.NomComplet}");
            }
        }

        public void Lire()
        {
            if (Statut == StatutLettre.Recue)
            {
                Statut = StatutLettre.Lue;
                DateLecture = DateTime.Now;
                Console.WriteLine($"Lettre lue par {Destinataire.NomComplet}");
            }
            else if (Statut == StatutLettre.Lue)
            {
                Console.WriteLine("Cette lettre a déjà été lue.");
            }
            else
            {
                Console.WriteLine("La lettre n'a pas encore été reçue.");
            }
        }

        public override string ToString()
        {
            string statutTexte = Statut switch
            {
                StatutLettre.Brouillon => "Brouillon",
                StatutLettre.EnAttente => "En attente",
                StatutLettre.Envoyee => $"Envoyée le {DateEnvoi:dd/MM/yyyy HH:mm}",
                StatutLettre.Recue => "Reçue (non lue)",
                StatutLettre.Lue => $"Lue le {DateLecture:dd/MM/yyyy HH:mm}",
                _ => Statut.ToString()
            };

            return $@"LETTRE                                           
             De : {Expediteur.NomComplet,-36} À : {Destinataire.NomComplet,-36} Statut : {statutTexte,-36} {Contenu,-44} ";
        }
    }

    public enum StatutLettre
    {
        Brouillon,
        EnAttente,
        Envoyee,
        Recue,
        Lue
    }

    internal void Envoyer()
    {
        throw new NotImplementedException();
    }

    internal void Recevoir()
    {
        throw new NotImplementedException();
    }

    internal void Lire()
    {
        throw new NotImplementedException();
    }
}
