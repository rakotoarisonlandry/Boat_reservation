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
using System.Data;
using MySql.Data.MySqlClient;
using BoatReservation;

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void FnameField_TextChanged(object sender, RoutedEventArgs e)
        {

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Confitme_button_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            connection.Open();
            int id;
            int.TryParse(TextID.Text, out id);
            string result = StatutField.Text;
            string query = "UPDATE reservation SET fini = '" + result + "'  WHERE id_res = " + id;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                Window2 register = new Window2();
                register.Bindgrid();
                this.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void FnameField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
