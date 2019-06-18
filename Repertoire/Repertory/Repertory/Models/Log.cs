using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertory.Models
{
    class Log
    {
        public static void SaveUserInfo(string lastName, string firstName, string userName, string mail, string password)
        {
            try
            {
                // création et stockage de la requete sql
                string query = "INSERT INTO [dbo].[Users]([lastName], [firstName], [username], [mail], [password])" +
                    "VALUES ('" + lastName + "', '" + firstName + "', '" + userName + "', '" + mail + "', '" + password + "')";

                // execute la requete
                MainWindow.executeQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // méthode permettant de chercher dans la base si le mail saisi pas l'utilisateur est déjà enregistré 
        public static string SearchForMail(string mail)
        {
            // requete sql
            string query = "SELECT [idUser] FROM [dbo].[Users] WHERE [mail] = '" + mail + "';";

            return MainWindow.ExecuteQueryString(query);
        }

        public static string idConnectedUser = "0";

        // méthode permettant de chercher dans la base l'utilisateur qui essaye de se connecter
        public static string SearchForUser(string mail, string password)
        {
            try
            {
                string query = "SELECT [idUser] FROM [dbo].[Users] WHERE [mail] = '" + mail + "' AND [password] = '" + password + "';";

                idConnectedUser = MainWindow.ExecuteQueryString(query);

                return idConnectedUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // sélectionne l'utilisateur connécté
        public static DataSet selectConnectedUserQuery()
        {
            try
            {
                string query = "SELECT [lastname], [firstname], [username], [mail] FROM [dbo].[Users] WHERE [idUser] = '" + idConnectedUser + "';";
                return MainWindow.ExecuteDataSetQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // saveContactInfo
        public static int SaveContactInfo(string lastname, string firstname, string mail, string phone, string address)
        {
            try
            {
                // query
                string query = "INSERT INTO [dbo].[contacts]([lastname], [firstname], [mail], [phoneNumber], [address], [idUser]) VALUES ('" + lastname + "', '" + firstname + "', '" + mail + "', '" + phone + "', '" + address + "', '" + idConnectedUser + "');";

                return MainWindow.executeQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // searchForContacts
        public static DataSet SearchForContacts(string idConnectedUser)
        {
            try
            {
                string query = "SELECT [lastname], [firstname], [mail], [phonenumber], [adress] FROM [dbo].[Contact] WHERE [idUser] = '" + idConnectedUser + "';";
                return MainWindow.ExecuteDataSetQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
