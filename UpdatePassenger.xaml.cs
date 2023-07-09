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
    /// Logique d'interaction pour UpdatePassenger.xaml
    /// </summary>
    public partial class UpdatePassenger : Window
    {
        public UpdatePassenger()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Passager register = new Passager();
            register.Bindgrid();

        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {

            if (FnameField.Text == "" || LnameField.Text == "" || CinField.Text == "" || EmailField.Text == "" || classeField.Text == "" || TelField.Text == "" || ReseField.Text == "" || voyageField.Text == "") {
                MessageBox.Show("Veillez Entrer les champ vides");
            } else {
                MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
                connection.Open();
                int id;
                int idres;
                int voy;
                int.TryParse(voyageField.Text, out voy);
                int.TryParse(TextID.Text, out id);
                int.TryParse(ReseField.Text, out idres);
                string query = "UPDATE passager SET nom = '" + FnameField.Text + "', prenom = '" + LnameField.Text + "', tel = '" + TelField.Text + "',cin = '" + CinField.Text + "', email = '" + EmailField.Text + "', class = '" + classeField.Text + "', id_res = " + idres + ", id_voyage = " + voy + " WHERE id_pass = " + id;
                string queryRes = "INSERT INTO passager_reservation(id_pass,id_res) VALUES(" + id + "," + idres + ")";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd2 = new MySqlCommand(queryRes, connection);
                cmd.CommandType = CommandType.Text;
                cmd2.CommandType = CommandType.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    Passager register = new Passager();
                    register.Bindgrid();
                    this.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }
    }
}
