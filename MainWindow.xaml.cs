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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void frame1_Navigated(object sender, NavigationEventArgs e)
        {

        }


        private void SubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameField.Text.ToString();
            string password = PasswordField.Password.ToString();

            if (username == "admin" && password == "admin")
            {
                Boat MainTab = new Boat();
                MainTab.Show();
                this.Close();
            } else
            {
                MessageBox.Show("Identification Incorrecte");
            }

        }

        private void CloseMW_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UsernameField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
