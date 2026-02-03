class Program
{
    static List<User> utilisateurs = new List<User>();
    static List<Lettre> lettres = new List<Lettre>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GESTION DE COURRIER ===");
            Console.WriteLine("1. Créer un utilisateur");
            Console.WriteLine("2. Lister les utilisateurs");
            Console.WriteLine("3. Rédiger une lettre");
            Console.WriteLine("4. Envoyer une lettre");
            Console.WriteLine("5. Lire une lettre");
            Console.WriteLine("6. Afficher une lettre");
            Console.WriteLine("0. Quitter");

            Console.Write("Choix : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": CreerUtilisateur(); break;
                case "2": ListerUtilisateurs(); break;
                case "3": RedigerLettre(); break;
                case "4": EnvoyerLettre(); break;
                case "5": LireLettre(); break;
                case "6": AfficherLettre(); break;
                case "0": return;
                default: Console.WriteLine("Erreur, choix invalide"); Attendre(); break;
            }
        }
    }

    static void CreerUtilisateur()
    {
        Console.Write("Nom : "); string nom = Console.ReadLine();
        Console.Write("Prénom : "); string prenom = Console.ReadLine();
        Console.Write("N° rue : "); int.TryParse(Console.ReadLine(), out int num);
        Console.Write("Nom rue : "); string rue = Console.ReadLine();
        Console.Write("Code postal : "); string cp = Console.ReadLine();
        Console.Write("Ville : "); string ville = Console.ReadLine();

        var adresse = new Adresse.Adresse(num, rue, ville, cp);
        var user = new User.User(nom, prenom, adresse);
        utilisateurs.Add(user);

        Console.WriteLine($"Utilisateur créé : {user.NomComplet}");
        Attendre();
    }

    static void ListerUtilisateurs()
    {
        if (utilisateurs.Count == 0)
        {
            Console.WriteLine("Aucun utilisateur enregistré.");
        }
        else
        {
            for (int i = 0; i < utilisateurs.Count; i++)
            {
                Console.WriteLine($"[{i}] {utilisateurs[i].NomComplet}");
            }
        }
        Attendre();
    }

    static void RedigerLettre()
    {
        if (utilisateurs.Count < 2)
        {
            Console.WriteLine("Il faut au moins 2 utilisateurs pour rédiger une lettre.");
            Attendre();
            return;
        }

        Console.Write("Expéditeur (numéro) : ");
        int expIdx = LireNumeroUtilisateur();
        if (expIdx == -1) return;

        Console.Write("Destinataire (numéro) : ");
        int destIdx = LireNumeroUtilisateur();
        if (destIdx == -1) return;

        Console.WriteLine("Contenu de la lettre (terminez par une ligne vide) :");
        string contenu = "";
        string ligne;
        while (!string.IsNullOrWhiteSpace(ligne = Console.ReadLine()))
        {
            contenu += ligne + "";
        }

        var lettre = new Lettre(utilisateurs[expIdx], utilisateurs[destIdx], contenu.Trim());
        lettres.Add(lettre);

        Console.WriteLine("Lettre créée (en brouillon) - ID : " + (lettres.Count - 1));
        Attendre();
    }

    static void EnvoyerLettre()
    {
        int idx = SelectionnerLettre();
        if (idx == -1) return;

        lettres[idx].Envoyer();
        lettres[idx].Recevoir();
        Attendre();
    }

    static void LireLettre()
    {
        int idx = SelectionnerLettre();
        if (idx == -1) return;

        lettres[idx].Lire();
        Attendre();
    }

    static void AfficherLettre()
    {
        int idx = SelectionnerLettre();
        if (idx == -1) return;

        Console.WriteLine(lettres[idx]);
        Attendre();
    }

    static int SelectionnerLettre()
    {
        if (lettres.Count == 0)
        {
            Console.WriteLine("Aucune lettre existante.");
            return -1;
        }

        Console.WriteLine("Lettres existantes :");
        for (int i = 0; i < lettres.Count; i++)
        {
            Console.WriteLine($"[{i}] {lettres[i].Expediteur.NomComplet} → {lettres[i].Destinataire.NomComplet} ({lettres[i].Statut})");
        }

        Console.Write("Numéro de la lettre : ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < lettres.Count)
            return idx;

        Console.WriteLine("Numéro invalide.");
        return -1;
    }

    static int LireNumeroUtilisateur()
    {
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < utilisateurs.Count)
            return idx;

        Console.WriteLine("Numéro invalide.");
        return -1;
    }

    static void Attendre()
    {
        Console.WriteLine("Appuyez sur une touche pour continuer");
        Console.ReadKey(true);
    }
}