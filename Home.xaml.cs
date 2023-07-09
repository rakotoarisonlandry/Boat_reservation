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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void LogoutSection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tab = new MainWindow();
            tab.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Boat tab = new Boat();
            tab.Show();
            this.Close();
        }

        private void PassengerSection_Click(object sender, RoutedEventArgs e)
        {
            Passager form = new Passager();
            form.Show();
            this.Close();
        }

        private void ReservationSection_Click(object sender, RoutedEventArgs e)
        {
            Reservation tab = new Reservation();
            tab.Show();
            this.Close();
        }

        private void HomeSection_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Not workding");
        }
    }
}
