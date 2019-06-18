using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // je demande à l'utilisateur de renseigner son poids.
            Console.WriteLine("Veuillez renseigner votre poids svp");
            // j'essaie de convertir la saisie en double si ca marche weightNum prend la valeur true sinon ça prend false
            bool weightUser = double.TryParse(Console.ReadLine(), out double weight);

            // Utilisation de la boucle while, tant que l'utilisateur ne saisi pas de nombre compris entre 0 et 400 le message continu de s'afficher
            while (weightUser != true && weight > 0 && weight <= 400)
            // je vérifie si le poids est bien compris entre 0 et 400
            {
                // affichage d'un message pour que l'utilisateur saisisse bien un nombre entre 0 et 400
                Console.WriteLine("Veuillez saisir un nombre correct");
                // je convertie la saisie de l'utilisateur
                weightUser = double.TryParse(Console.ReadLine(), out weight);
            }

            // je demande à l'utilisateur de renseigner sa taille
            Console.WriteLine("Veuillez renseigner votre taille en mètre svp");
            // j'essaie de convertir la saisie en double si ca marche sizeNum prend la valeur true sinon ça prend false
            bool sizeUser = double.TryParse(Console.ReadLine(), out double size);

            // Utilisation de la boucle while, tant que l'utilisateur ne saisi pas de nombre compris entre 0 et 2.50 le message continu de s'afficher
            while (sizeUser != true || size > 0 || size <= 2.50)
            {
                // affichage d'un message afin que l'utilisateur saisisse bien un nombre entre 0 et 2.50
                Console.WriteLine("Veuillez saisir un nombre correct");
                // je convertie la saisie de l'utilisateur
                sizeUser = double.TryParse(Console.ReadLine(), out size);
            }
            // utilisation de la formule pour calculer l'IMC qui est égale à la taille divisé par le poids au carré
            double imc = Math.Round(weight / Math.Pow(size, 2), 2);

            // si IMC est infèrieur à 16.50
            if (imc < 16.50)
            {
                // affichage du message correspondant aux résultat
                Console.WriteLine(" Vous êtes en Dénutrition");
            }
            // sinon si IMC est supèrieur ou égale 16.5 et  infèrieur à 18.50
            else if (imc >= 16.50 && imc < 18.50)
            {
                // affichage du message
                Console.WriteLine(" Vous êtes dans la catégorie Maigreur");
            }
            // sinon si IMC est supèrieur ou égale à 18.50 et infèrieur 25
            else if (imc >= 18.50 && imc < 25)
            {
                // affichage du message
                Console.WriteLine("Vous êtes en Corpulence normale");
            }
            // sinon si IMC est supèrieur ou égale à 25 et infèrieur 30
            else if (imc >= 25 && imc < 30)
            {
                // affichage du message
                Console.WriteLine("Vous êtes en Surpoids");
            }
            // sinon si IMC est supèrieur ou égale à 30 et infèrieur 35
            else if (imc >= 30 && imc < 35)
            {
                // affichage du message
                Console.WriteLine("Vous êtes en Obésité modérée");
            }
            // sinon si IMC est supèrieur ou égale à 35 et infèrieur 40
            else if (imc >= 35 && imc < 40)
            {
                // affichage du message
                Console.WriteLine("Vous êtes en Obésité sévère");
            }
            // sinon si IMC est supèrieur à 40
            else if (imc > 40)
            {
                // affichage du message
                Console.WriteLine("Vous êtes en Obésité morbide ou massive");
            }
        }
    }
}
