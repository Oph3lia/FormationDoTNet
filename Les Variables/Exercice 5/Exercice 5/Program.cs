using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrer votre nom et prénom");
            string name = Console.ReadLine();
            string nickname = Console.ReadLine();
            DateTime date = DateTime.Now;
            // date est le nom de la variable.
            Console.WriteLine(" Bonjour" + " " + name + " " + nickname + ", nous sommes le " + date.ToString("dd/MM/yyyy") + " comment allez vous ?");
            Console.ReadLine();
            // le datetime est pour préciser que c'est une date et datetime.now permet d'afficher l'heure actuel et le jour.
            // le date.tostring permet de convertir la date en chaine de caractère.
        }
    }
}
