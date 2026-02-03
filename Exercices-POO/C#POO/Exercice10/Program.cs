
class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle("Rectangle A", 12.5, 7.0);
        Cercle cercle = new Cercle("Cercle B", 8.5);

        Console.WriteLine("Informations des formes");

        rect.Infos();
        cercle.Infos();

        Console.WriteLine("Version polymorphique");

        Forme[] formes = { rect, cercle };

        foreach (Forme forme in formes)
        {
            forme.Infos();
        }
    }
}