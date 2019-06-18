using Repertory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public object WelcomeUserName { get; private set; }

        public Login()
        {
            InitializeComponent();
        }
        //méthode permettant d'afficher la fenêtre d'inscription
        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            // nouvelle instance d'un objet window 
            MainWindow Inscrption = new MainWindow();
            // ouverture de ce nouvel objet Inscription
            Inscrption.Show();
            // fermeture de la fenêtre
            this.Close();
        }
        public static DataSet ExecuteDataSetQuery(string query)
        {
            string strConn = "data source=dotnet3\\SQLEXPRESS; initial catalog=repertory; integrated security=True; multipleactiveresultsets=True; database=repertory; integrated security=SSPI;";

            // instanciation d'un objet de type sqlConnection
            SqlConnection sqlConnection = new SqlConnection(strConn);

            // ouverture de la connexion
            sqlConnection.Open();

            // id de l'utilisateur actuellement connécté
            string idConnectedUser = Log.idConnectedUser;
            //query
            SqlCommand sqlCommand = new SqlCommand();

            // attribution de valeurs aux attributs de l'objet sqlCommand
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandTimeout = 2 * 3600;

            // instanciation d'un objet adapter de la classe SqlDataAdaptateur
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            // instanciation d'un objet dataSet de la classe DataSet
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet); // remplis l'objet adapter avec l'objet dataSet 

            // fermeture de la connexion
            sqlConnection.Close();

            return dataSet;
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            // booléens de validation
            bool connexionIsValid = true;

            // si le champ mail est vide, message d'erreur
            if (string.IsNullOrEmpty(textBoxMail.Text))
            {
                connexionIsValid = false;
                MessageBox.Show("Ce champ est requis.");
            }

            // si le champ password est vide, message d'erreur
            if (string.IsNullOrEmpty(textBoxPasseWord.Password))
            {
                connexionIsValid = false;
                MessageBox.Show("Ce champ est requis");
            }

            if (connexionIsValid)
            {
                // si la requete select retourne un id, l'utilisateur est connécté, sinon message d'erreur
                if (string.IsNullOrEmpty(Log.SearchForUser(textBoxMail.Text, textBoxPasseWord.Password)))
                {
                    MessageBox.Show("Le Mail ou le mot de passe est incorrect, veuillez recommencer.");
                }
                else
                {
                    MessageBox.Show("Vous êtes maintenant connécté!", "Connexion", MessageBoxButton.OK);
                    // instanciation et affichage d'une nouvelle fenêtre Profil et fermeture de LogInWindow
                    Profil profilWindow = new Profil();
                    profilWindow.Show();
                    this.Close();
                }
            }

        }
    }
}