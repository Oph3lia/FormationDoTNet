using Repertory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Profil()
        {
            InitializeComponent();
        }
        private void Profil_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dataSet = Log.selectConnectedUserQuery();
                // si la première table du dataSet contient au moins une ligne, récupérer les informations stockée dedans, sinon message d'erreur
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    // stockage des données du tableau du dataSet dans des variables
                    string userLastname = dataSet.Tables[0].Rows[0]["lastname"].ToString();
                    string userFirstname = dataSet.Tables[0].Rows[0]["firstname"].ToString();
                    string username = dataSet.Tables[0].Rows[0]["username"].ToString();
                    string usermail = dataSet.Tables[0].Rows[0]["mail"].ToString();

                    // affichage des données dans leurs textBlock
                    textBoxName.Text = userLastname;
                    textBoxFirstName.Text = userFirstname;
                    textBoxUserName.Text = username;
                    textBoxMail.Text = usermail;
                    ProfilTextBoxUsername.Text += username;
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Une erreur s'est produite, veuillez réessayer SVP.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Add_Contact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.Show();
            this.Close();
        }

        private void Button_List_Click(object sender, RoutedEventArgs e)
        {
            ListContact listContact = new ListContact();
            listContact.Show();
            this.Close();
        }
    }
}
