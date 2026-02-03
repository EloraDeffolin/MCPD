using Exercice13.Classes;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            AfficherMenu();

            if (choix == "0") break;

            switch (choix)
            {
                case "1": AjouterCarre(figures); break;
                case "2": AjouterRectangle(figures); break;
                case "3": AjouterTriangle(figures); break;
                case "4": DeplacerFigure(figures); break;
                case "5": AfficherToutesFigures(figures); break;
                default:
                    Console.WriteLine("Choix non valide...");
                    break;
            }

            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.WriteLine(true);
        }
    }

    static void AfficherMenu()
    {
        Console.WriteLine("=== Gestion de figures ===");
        Console.WriteLine("1. Ajouter un Carré");
        Console.WriteLine("2. Ajouter un Rectangle");
        Console.WriteLine("3. Ajouter un Triangle isocèle");
        Console.WriteLine("4. Déplacer une figure");
        Console.WriteLine("5. Afficher toutes les figures");
        Console.WriteLine("0. Quitter");
        Console.Write("Votre choix");
    }

    static void AjouterCarre(List<Figure> figures)
    {
        Console.Write("Côté : "); double cote = LireDoublePositif();
        Console.Write("Position X : "); double x = LireDouble();
        Console.Write("Position Y : "); double y = LireDouble();

        figures.Add(new Carre(cote, x, y));
        Console.WriteLine("Carré ajouté.");
    }

    static void AjouterRectangle(List<Figure> figures)
    {
        Console.Write("Longueur : "); double lon = LireDoublePositif();
        Console.Write("Largeur : "); double lar = LireDoublePositif();
        Console.Write("Position X : "); double x = LireDouble();
        Console.Write("Position Y : "); double y = LireDouble();

        figures.Add(new Rectangle(lon, lar, x, y));
        Console.WriteLine("Rectangle ajouté.");
    }

    static void AjouterTriangle(List<Figure> figures)
    {
        Console.Write("Base : "); double b = LireDoublePositif();
        Console.Write("Hauteur : "); double h = LireDoublePositif();
        Console.Write("Position X : "); double x = LireDouble();
        Console.Write("Position Y : "); double y = LireDouble();

        figures.Add(new Triangle(b, h, x, y));
        Console.WriteLine("Triangle ajouté.");
    }

    static void DeplacerFigure(List<Figure> figures)
    {
        if (figures.Count == 0)
        {
            Console.WriteLine("Aucune figure à déplacer.");
            return;
        }

        AfficherToutesFigures(figures, numerote: true);

        Console.Write("Numéro de la figure à déplacer : ");
        if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num >

        figures.Count)
        {
            Console.WriteLine("Numéro invalide.");
            return;
        }

        Console.Write("Déplacement X : "); double dx = LireDouble();
        Console.Write("Déplacement Y : "); double dy = LireDouble();

        figures[num - 1].Deplacement(dx, dy);
        Console.WriteLine("Figure déplacée.");
    }

    static void AfficherToutesFigures(List<Figure> figures, bool numerote = false)
    {
        if (figures.Count == 0)
        {
            Console.WriteLine("Aucune figure pour le moment.");
            return;
        }

        Console.WriteLine("Liste des figures :");
        Console.WriteLine(new string('-', 60));

        for (int i = 0; i < figures.Count; i++)
        {
            string prefix = numerote ? $"{i + 1,2}. " : "   ";
            Console.WriteLine($"{prefix}{figures[i]}");
        }
    }

    static double LireDouble(string message = "")
    {
        while (true)
        {
            if (!string.IsNullOrEmpty(message))
                Console.Write(message);

            if (double.TryParse(Console.ReadLine()?.Replace('.', ','), out double valeur))
                return valeur;

            Console.WriteLine("Veuillez entrer un nombre valide.");
        }
    }

    static double LireDoublePositif(string message = "")
    {
        while (true)
        {
            double val = LireDouble(message);
            if (val > 0) return val;
            Console.WriteLine("La valeur doit être strictement positive.");
        }
    }
}