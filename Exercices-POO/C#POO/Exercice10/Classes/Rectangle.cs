using System;

public class Rectangle : Forme
{
    public double Longueur { get; set; }
    public double Largeur { get; set; }

    public Rectangle(string nom, double longueur, double largeur)
        : base(nom)
    {
        Longueur = longueur;
        Largeur = largeur;
    }

    public override double CalculerAire()
    {
        return Longueur * Largeur;
    }

    public override double CalculerPerimetre()
    {
        return 2 * (Longueur + Largeur);
    }


    public override void Infos()
    {
        Console.WriteLine($"Forme : {Nom} (Rectangle)");
        Console.WriteLine($"Longueur : {Longueur} cm");
        Console.WriteLine($"Largeur : {Largeur} cm");
        Console.WriteLine($"Aire : {CalculerAire()}");
        Console.WriteLine($"Périmètre: {CalculerPerimetre()}");

    }
}


