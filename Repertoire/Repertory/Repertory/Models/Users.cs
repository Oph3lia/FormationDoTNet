using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertory.Models
{
    public class Users
    {
        public static void SaveInfo(string lastname, string firstname, string username, string mail, string password)
        {
            try
            {
                // Query.  
                string query = "INSERT INTO [Repertory].[dbo].[Users] ([lastname], [firstname], [username], [mail], [password])" +
                                " VALUES ('" + lastname + "','" + firstname + "','" + username +"','" + mail +"','" + password + "')";

                // Execute.  
                MainWindow.executeQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string VerifMail(string mail)
        {
            // Déclaration de la variable mailRegister en NULL
            string mailRegister = null;
            // Rêquete SQL
            string query = "SELECT [mail] FROM [Repertory].[dbo].[Users] AS [Users]" +
                    " WHERE [Users].[mail] = '" + mail + "'";
            // On stock le résultat de la rêquete dans la variable mailRegister
            mailRegister = MainWindow.ExecuteQueryString(query);
            // Retourne la variable mailRegister
            return mailRegister;
        }

    }
}
