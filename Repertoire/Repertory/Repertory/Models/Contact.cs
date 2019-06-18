using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repertory.Models
{
    class Contact
    {
        public static void Register(string lastname, string firstname, string mail, string phonenumber, string adress, string idUser)
        {
            try
            {
                string query = "INSERT INTO [dbo].[Contact]([lastname], [firstname], [mail], [phonenumber], [adress], [idUser])" +
                    "VALUES('" + lastname + "','" + firstname + "','" + mail + "','" + phonenumber + "','" + adress + "','" + idUser + "')";
                MainWindow.executeQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
