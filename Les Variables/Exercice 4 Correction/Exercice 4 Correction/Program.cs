using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_4_Correction
{
    class Program
    {
        static void Main(string[] args)
        {
            string civility = "Monsieur"; // Déclaration d'une variable civility de type string à qui on attribue la valeur monsieur
            string name = "Vincent"; // Déclaration d'une variable name de type string à qui on attribue la valeur vincent
            int number = 1; // déclaration d'une  variable number de type int à qui on attribue la valeur 1
            // affichage de la phrase avec les valeurs définies
            Console.WriteLine("Bonjour " + civility + " " + name + ", vous êtes venu nous rendre visite " + number + " seule fois");
            Console.ReadLine();
        }
    }
}
