using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace correction_exercice2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 2;
            int z = 3;
            Console.WriteLine("le nombre x vaut " + x + " le nombre y vaut " + y + " le nombre z vaut " + z);
            int result = (x + y) * z;
            Console.WriteLine(" la somme de " + x + " et de " + y + " vaut " + (x + y) + " et le produit du resultat vaut " + ((x + y) * z));
            Console.ReadLine();
        }
    }
}
