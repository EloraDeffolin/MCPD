using System;

public class Cercle : Forme
{
    public double Rayon { get; set; }

    public Cercle(string nom, double rayon)
        : base(nom)
    {
        Rayon = rayon;
    }

    public override double CalculerAire()
    {
        return Math.PI * Rayon * Rayon;
    }

    public override double CalculerPerimetre()
    {
        return 2 * Math.PI * Rayon;
    }

    public override void Infos()
    {
        Console.WriteLine($"Forme : {Nom}");
        Console.WriteLine($"Rayon : {Rayon}");
        Console.WriteLine($"Aire : {CalculerAire()}");
        Console.WriteLine($"Circonférence : {CalculerPerimetre()}");
    }
}
