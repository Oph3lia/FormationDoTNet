using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Veuillez saisir votre nom");
            string name = Console.ReadLine();
            Console.WriteLine("Votre prénom");
            string firstname = Console.ReadLine();
            Console.WriteLine(" Votre année de naissance");
            int birthdate = int.Parse(Console.ReadLine());// convertion de la variable en string. 
            int age = DateTime.Now.Year - birthdate; // datetime.now.year permet d'afficher l'année actuel.
            Console.WriteLine("\t - " + name);
            Console.WriteLine("\t - " + firstname);
            Console.WriteLine("\t - " + age);
            Console.ReadLine();
            // {environment.newline} permet d'aller à la ligne.
            // \n permet également d'aller à la ligne.
        }
    }
}
