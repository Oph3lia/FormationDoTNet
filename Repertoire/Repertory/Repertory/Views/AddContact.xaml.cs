using Repertory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Repertory.Views
{
    /// <summary>
    /// Logique d'interaction pour AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        //Déclaration du booléen qui permettra la validation du formulaire d'ajout de contact
        bool isValid = true;
        //Déclaration des regex
        readonly string regexName = @"^[A-Za-zéàèêëïîç\- ]+$";
        readonly string regexMail = @"^[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}$";

        public AddContact()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string lastname = textBoxName.Text;
            string firstname = textBoxFirstName.Text;
            string phonenumber = textBoxPhoneNumber.Text;
            string mail = textBoxMail.Text;
            string adress = textBoxAdress.Text;
            string id = Log.idConnectedUser;

            if (!String.IsNullOrEmpty(lastname))
            {
                if (!Regex.IsMatch(lastname, regexName))
                {
                    MessageBox.Show("Saisie non valide");
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Le champ est vide");
                isValid = false;
            }
            if (!String.IsNullOrEmpty(firstname))
            {
                if (!Regex.IsMatch(firstname, regexName))
                {
                    MessageBox.Show("Saisie non valide");
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Le champ est vide");
                isValid = false;
            }
            if (String.IsNullOrEmpty(phonenumber))
            {
                MessageBox.Show("Le champ est vide");
                isValid = false;
            }
            if (!String.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, regexMail))
                {
                    MessageBox.Show("Saisie non valide");
                    isValid = false;
                }
            }
            else
            {
                MessageBox.Show("Le champ est vide");
                isValid = false;
            }
            if (String.IsNullOrEmpty(adress))
            {
                MessageBox.Show("Le champ est vide");
                isValid = false;
            }
            if (isValid)
            {
                //Si le formulaire est valide, 
                Contact.Register(lastname, firstname, mail, phonenumber, adress, id);
                MessageBox.Show("Le contact a bien été ajouté", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
                textBoxName.Text = null;
                textBoxFirstName.Text = null;
                textBoxMail.Text = null;
                textBoxPhoneNumber.Text = null;
                textBoxAdress.Text = null;
            }

        }
        private void Button_List_Click(object sender, RoutedEventArgs e)
        {
            ListContact listContact = new ListContact();
            listContact.Show();
            this.Close();
        }
    }
}
