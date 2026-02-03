using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Exercice1.Classes;

namespace Exercice1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Chaise C1 = new Chaise(4, "Plastique", "Noir");
            Console.WriteLine(C1);

            Chaise C2 = new Chaise(4, "Bois", "Blanche");
            Console.WriteLine(C2);

            foreach (Chaise chaise in chaises)
            {
                Console.WriteLine(chaise);
            }
        }
    }
}