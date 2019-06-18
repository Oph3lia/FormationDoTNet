using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez renseigner le rayon R d'un cercle"); // je demande à l'utilisateur de renseigner la valeur du rayon.
            int R = int.Parse(Console.ReadLine());
            double perimeter = 2 * Math.PI * R;
            Console.WriteLine(" Le périmètre est de " + perimeter); // affichage de la réponse
            double air = Math.PI * Math.Pow(R,2);
            Console.WriteLine("L'air est de  " + air); // affichage de la réponse
            Console.ReadLine();
        }
    }
}