using System;
using System.Collections.Generic;
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

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour PassengerDeleteDialog.xaml
    /// </summary>
    public partial class PassengerDeleteDialog : Window
    {
        public PassengerDeleteDialog()
        {
            InitializeComponent();

            TextConfirm.Content = "Etes vous sure de vouloir supprimer\n ces ... passager ?";
        }

        private void ConfirmB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
