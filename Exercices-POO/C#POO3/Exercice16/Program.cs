namespace Exercice16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> mots = new List<string>();
            Console.WriteLine("Saisir des mots");
            Console.WriteLine();

            string saisie;

            do
            {
                Console.WriteLine("Entrez un mot");
                saisie = Console.ReadLine();

                if (saisie != "stop")
                {
                    mots.Add(saisie);
                }

            } while (saisie != "stop");

            Console.WriteLine($"Résultat du nombre total de mots saisis : {mots.Count}");

            if (mots.Count > 0)
            {
                Console.WriteLine("Les mots saisis sont les suivants :");

                for (int i = 0; i < mots.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {mots[i]}");
                }
            }
            else
            {
                Console.WriteLine("Erreur : Aucun mot n'a été saisi.");
            }

            Console.WriteLine("Appuyez sur une touche pour quitter");
            Console.ReadLine();
        }
    }
}
