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
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour AddPassenger.xaml
    /// </summary>
    public partial class AddPassenger : Window
    {
        public AddPassenger()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (FnameField.Text == "" || LnameField.Text ==  "" || CinField.Text == "" || EmailField.Text == "" || classeField.Text == "" || TelField.Text == "" || ReseField.Text == "" || voyageField.Text == "") {
                MessageBox.Show("Veillez Entrer les champ vides");
            } else {
                MySqlConnection con = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
                con.Open();
                int num;
                int idres;
                int voy;
                int.TryParse(TelField.Text, out num);
                int.TryParse(ReseField.Text, out idres);
                int.TryParse(voyageField.Text, out voy);
                string query = "INSERT INTO passager(nom,prenom,cin,email,tel,class,id_voyage,id_res) VALUES('" + FnameField.Text + "' , '" + LnameField.Text + "', '" + CinField.Text + "' , '" + EmailField.Text + "'  , '" + classeField.Text + "'  , '" + TelField.Text + "'  ," + voy + " , " + idres + " )";
                Passager register = new Passager();
                register.executeQuery(query);
                //string queryget = "SELECT id_pass FROM passager ORDER BY id_pass DESC LIMIT";
                MySqlCommand cmd = new MySqlCommand("SELECT id_pass FROM passager ORDER BY id_pass DESC LIMIT 1", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                string idpass = "";
                while (reader.Read())
                {
                    idpass = reader.GetString(0);
                }
                int id_pass;
                int.TryParse(idpass, out id_pass);
                string queryRes = "INSERT INTO passager_reservation(id_pass,id_res) VALUES(" + id_pass + "," + idres + ")";
                register.executeQuery(queryRes);
                register.Bindgrid();
                this.Close();
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
