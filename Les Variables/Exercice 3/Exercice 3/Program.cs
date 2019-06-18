using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_25_Mars
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            Console.WriteLine("Veuillez renseigner la valeur a");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez renseigner la valeur b");
            b = int.Parse(Console.ReadLine());
            a += 33; // a = a + 33
            b = ++b; // b = b + 1 ou b++
            int result = a / b;
            Console.WriteLine(" la division de votre premier chiffre plus 33 avec votre deuxième chiffre plus 1 est de : " + result);
            Console.ReadLine();
    }
}
