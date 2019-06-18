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
    /// Logique d'interaction pour ListContact.xaml
    /// </summary>
    public partial class ListContact : Window
    {
        public ListContact()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string idConnectedUser = Log.idConnectedUser;
            try
            {
                DataSet dataSet = Log.SearchForContacts(idConnectedUser);
                contactDataGrid.DataContext = dataSet.Tables[0];
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
