namespace Exercice21
{
    public class Program
    {

        public class InvalidArrayException : Exception
        {
            public InvalidArrayException(string message)
          : base(message)
            {
            }
        }

        public static double CalculMoyenne(double[] notes)
        {
            if (notes == null || notes.Length == 0)
            {
                throw new InvalidArrayException("Le tableau de notes ne peut pas être vide");
            }

            double somme = 0;

            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i] < 0 || notes[i] > 20)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(notes),
                        $"Les notes doivent être entre 0 et 20. La note invalide trouvée : {notes[i]}"
                        );
                }
                somme += notes[i];
            }

            return somme / notes.Length;
        }

        public static void Main()
        {
            try
            {
                double[] notes1 = { 10.5, 12, 6.5, 18 };
                Console.WriteLine($"Moyenne : {CalculMoyenne(notes1)}");

                double[] notes2 = { };
                CalculMoyenne(notes2);

                double[] notes3 = { 10, -1, 12 };
                CalculMoyenne(notes3); 

                double[] notes4 = { 5, 25 };
                CalculMoyenne(notes4);
            }
            catch (InvalidArrayException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur inattendue : " + ex.Message);
            }Console.ReadLine();
        }
    }
}