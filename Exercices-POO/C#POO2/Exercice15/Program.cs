using CPOO.Classes;
using Exercice15.Interface;

class Program
{
    static List<Personnage> personnages = new List<Personnage>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        InitialiserPersonnages();

        while (true)
        {
            Console.Clear();
            AfficherPersonnages();

            Console.WriteLine("Actions possibles :");
            Console.WriteLine(" 1) Attaque normale");
            Console.WriteLine(" 2) Attaque spéciale (Guerrier / GuerrierMage)");
            Console.WriteLine(" 3) Lancer un sort (Mage / GuerrierMage)");
            Console.WriteLine(" 0) Quitter");

            Console.Write("Choix : ");
            string choix = Console.ReadLine();

            if (choix == "0") break;

            if (choix == "1" || choix == "2" || choix == "3")
            {
                var attaquant = ChoisirPersonnage("Attaquant");
                if (attaquant == null) continue;

                var cible = ChoisirPersonnage("Cible");
                if (cible == null) continue;

                switch (choix)
                {
                    case "1":
                        attaquant.Attaquer(cible);
                        break;

                    case "2":
                        if (attaquant is IAttaqueSpeciale gs)
                            gs.AttaqueSpeciale(cible);
                        else
                            Console.WriteLine("Ce personnage ne peut pas faire d'attaque spéciale !");
                        break;

                    case "3":
                        if (attaquant is IMagie mage)
                            mage.LancerSort(cible);
                        else
                            Console.WriteLine("Ce personnage ne peut pas lancer de sort !");
                        break;
                }
            }

            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey(true);
        }
    }

    static void InitialiserPersonnages()
    {
        var epee = new Arme("Épée Rilleuse", 6, 12);
        var hache = new Arme("Hache du Minotot", 9, 8);
        var baton = new Arme("Bâton Champmanique", 4, 20);
        var dague = new Arme("Dague Moh", 5, 15);

        personnages.Add(new Guerrier("Rhazor", "d'Amakna", 120, 18, epee));
        personnages.Add(new Guerrier("Morkhan", "Coeur-de-Pierre", 140, 22, hache));
        personnages.Add(new Mage("Lunaena", "Astrelune", 80, 12, baton));
        personnages.Add(new Mage("Nyxara", "l'Invocatrice", 90, 14, dague));
        personnages.Add(new GuerrierMage("Kryos", "Mage-de-Guerre", 110, 16, epee));
    }

    static void AfficherPersonnages()
    {
        Console.WriteLine("PERSONNAGES");
        for (int i = 0; i < personnages.Count; i++)
        {
            Console.WriteLine($"[{i}] {personnages[i]}");
        }
    }

    static Personnage ChoisirPersonnage(string role)
    {
        Console.Write($"{role} (numéro) : ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < personnages.Count)
        {
            var p = personnages[idx];
            if (!p.EstVivant)
            {
                Console.WriteLine("Ce personnage est mort !");
                return null;
            }
            return p;
        }

        Console.WriteLine("Numéro invalide.");
        return null;
    }
}