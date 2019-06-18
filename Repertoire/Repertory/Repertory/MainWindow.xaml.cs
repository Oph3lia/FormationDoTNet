using Repertory.Models;
using Repertory.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Repertory
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int executeQuery(string query)
        {
            int rowCount = 0;
            string sqlCon = "data source=dotnet4\\SQLEXPRESS;initial catalog=Repertory;integrated security=True;";
            SqlConnection sqlConnection = new SqlConnection(sqlCon);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                // Paramètres  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600; //// Définition du délai d'expiration pour les requêtes plus longues sur 12 heures.  

                // connexion ouverte avec la base de données 
                sqlConnection.Open();

                // retourne le nombre de lignes grâce à la variable rowcount  
                rowCount = sqlCommand.ExecuteNonQuery();

                // fermeture de la connexion avec la base de données
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // fermeture de la connexion 
                sqlConnection.Close();

                throw ex;
            }
            return rowCount;
        }
        public static string ExecuteQueryString(string query)
        {
            // Initialisation. 
            object result = null;
            string resultString = null;
            string strConn = "data source=dotnet4\\SQLEXPRESS;initial catalog=Repertory;integrated security=True;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                // Parametres.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600;
                // Open la connexion.   
                sqlConnection.Open();
                // on stock le résultat de l'execution. .  
                result = sqlCommand.ExecuteScalar();
                if(result != null)
                {
                    resultString = result.ToString();
                }
                // Ferme la connexion..  
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                // Ferme la connexion..  
                sqlConnection.Close();
                throw ex;
            }
            // Retourne la variable string result
            return resultString;
        }
        public static DataSet ExecuteDataSetQuery(string query)
        {
            string strConn = "data source=dotnet4\\SQLEXPRESS;initial catalog=Repertory;integrated security=True;";

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
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string regexName = "[A-Z-a-z-0-9]?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]+[-']?[a-záàâäãåçéèêëíìîïñóòôöõúùûüýÿæœ]";
            string regexMail = "[A-Z-a-z-0-9-.éàèîÏôöùüûêëç]{2,}@[A-Z-a-z-0-9éèàêâùïüëç]{2,}[.][a-z]{2,6}";
            bool isValid = true;
            try
            {
                // Initialization.  
                string lastname = textBoxName.Text;
                string firstname = textBoxFirstName.Text;
                string username = textBoxUserName.Text;
                string mail = textBoxMail.Text;
                string password = textBoxPasseWord.Password.ToString();
                string passwordC = passeWordConfirm.Password.ToString();

                // Verification.  
                if (!String.IsNullOrEmpty(lastname))
                {
                    if (!Regex.IsMatch(lastname, regexName))
                    {
                        isValid = false;
                        // message d'erreur  
                        MessageBox.Show("Veuillez entrer un nom valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    isValid = false;
                    // message d'erreur  
                    MessageBox.Show("Ce champ est requis, veuillez entrer un nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (!String.IsNullOrEmpty(firstname))
                {
                    if (!Regex.IsMatch(firstname, regexName))
                    {
                        isValid = false;
                        // message d'erreur  
                        MessageBox.Show("Veuillez entrer un prénom valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    isValid = false;
                    // message d'erreur  
                    MessageBox.Show("Ce champ est requis, veuillez entrer un prénom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (!String.IsNullOrEmpty(username))
                {
                    if (!Regex.IsMatch(username, regexName))
                    {
                        isValid = false;
                        // message d'erreur  
                        MessageBox.Show("Veuillez entrer un nom d'utilisateur valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    isValid = false;
                    // message d'erreur  
                    MessageBox.Show("Ce champ est requis, veuillez entrer un nom d'utilisateur", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (!String.IsNullOrEmpty(mail))
                {
                    if (!Regex.IsMatch(mail, regexMail))
                    {
                        isValid = false;
                        // message d'erreur  
                        MessageBox.Show("Veuillez entrer une adresse mail valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // verif si le mail existe
                        if(!String.IsNullOrEmpty(Users.VerifMail(mail)))
                        {
                            MessageBox.Show("Ce mail existe déjà !", "erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            textBoxPasseWord.Password = string.Empty;
                            passeWordConfirm.Password = string.Empty;
                            isValid = false;
                        }
                    }
                }
                else
                {
                    isValid = false;
                    // message d'erreur  
                    MessageBox.Show("Ce champ est requis, veuillez entrer un mail", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Vérification du mot de passe 
                if (!String.IsNullOrEmpty(password)) // vérification si le mot de passe n'est pas null ou vide
                {
                    if (!String.IsNullOrEmpty(passwordC)) // Vérification si la confirmation n'est pas null ou vide
                    {
                        if (password != passwordC) // Si les mot de passe ne correspondent pas affichage d'un message d'erreur
                        {
                                MessageBox.Show("La confirmation du mot de passe ne correspond pas au mot de passe saisi", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                isValid = false;
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer un mot d epasse valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValid = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le champ est requis, veuillez saisir un mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        isValid = false;
                    }
                }
                else
                {
                    MessageBox.Show("Le champ est requis, veuillez saisir un mot de passe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    isValid = false;
                }

                if (isValid)
                {
                    // sauvegarde des informations  
                    Users.SaveInfo(lastname, firstname, username, mail, password);
                    // message de succès
                    MessageBox.Show("Vous êtes enregisté !", "Félicitation", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBoxName.Text = string.Empty;
                    textBoxFirstName.Text = string.Empty;
                    textBoxUserName.Text = string.Empty;
                    textBoxMail.Text = string.Empty;
                    textBoxPasseWord.Password = string.Empty;
                    passeWordConfirm.Password = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                // message d'echec 
                MessageBox.Show("Quelque chose ne va pas, s'il vous plaît réessayer plus tard.", "Echec", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // nouvelle instance d'un objet window 
            Login Connexion = new Login();
            // ouverture de ce nouvel objet Inscription
            Connexion.Show();
            // fermeture de la fenêtre
            this.Close();
        }
    }
}

