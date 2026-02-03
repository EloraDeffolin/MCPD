namespace Exercice17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> temperatures = new List<int>();
            int nbInvalides = 0;

            Console.WriteLine("Saisir des températures (entrez -999 pour terminer");

            while (true)
            {
                Console.WriteLine("Temperature : ");
                string saisie = Console.ReadLine();

                if (!int.TryParse(saisie, out int temperature))
                {
                    Console.WriteLine("Erreur : valeur ignorée");
                    nbInvalides++;
                    continue;
                }

                if (temperature == -999)
                {
                    break;
                }

                if (temperature >= -50 && temperature <= 50)
                {
                    temperature.Add(temperature);
                }
                else
                {
                    Console.WriteLine($" {temperature} °C (-50 à 50) sont ignorée");
                    nbInvalides++;
                }
            }

            int nbValides = temperatures.Count;
            Console.WriteLine($"Nombre de températures valides : {nbValides}");
            Console.WriteLine($"Nombre de températures invalides : {nbInvalides}");

            if (nbValides > 0)
            {   

                int min = temperatures[0];
                int max = temperatures[0];

                foreach (int t in temperatures)
                {
                    if (t < min) min = t;
                    if (t > max) max = t;
                }

                Console.WriteLine($"Température minimale : {min} °C");
                Console.WriteLine($"Température maximale : {max} °C");
            }
            else
            {
                Console.WriteLine("Aucune température valide n'a été enregistrer.");
            }
            Console.ReadLine();
        }
    }
}