using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice_7
{
    class Program
    {
        static void Main(string[] args)
        {   // je déclare les variables avec double pour avoir un chiffre à virgule et être plus précis.
            double AB;
            double BC;
            double CA;
            Console.WriteLine("Veuillez renseigner les valeurs de BC"); // je demande à l'utilisateur de renseigner une valeur pour BC.
            BC = double.Parse( Console.ReadLine()); // je converti l'information contenu dans les parenthèses.
            Console.WriteLine("Veuillez renseigner les valeurs de CA"); // je demande une valeur pour CA.
            CA = double.Parse(Console.ReadLine());
            AB = Math.Round(Math.Sqrt(Math.Pow(BC, 2) + Math.Pow(CA, 2)),2); // j'applique ma formule de Pithagore AB2 = BC2 + CA2.
            // math.round sert à arrondir, math.sqrt sert pour la racine carré, math.pow met la valeur au carré.
            // le ,2 sert à arrondir à deux chiffres après la virgule.
            Console.WriteLine(" Selon le théorème de Pithagore, AB est égale à " + AB);
            Console.ReadLine();
        }
    }
}
