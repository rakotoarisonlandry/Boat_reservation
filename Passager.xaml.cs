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
using System.Collections.ObjectModel;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour Passager.xaml
    /// </summary>
    public partial class Passager : Window
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        private ObservableCollection<EnregistrementP> listEnregistrer;
        private ObservableCollection<EnregistrementP> listrechercher;
        public Passager()
        {
            InitializeComponent();
            Bindgrid();
        }
        public void Bindgrid()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            con.Open();
            listEnregistrer = new ObservableCollection<EnregistrementP>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM passager", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string name = reader.GetString(1);
                string prenom = reader.GetString(2);
                string email = reader.GetString(3);
                string phone = reader.GetString(4);
                string cin = reader.GetString(5);
                string classe = reader.GetString(6);
                string voy = reader.GetString(7);
                string idres = reader.GetString(8);
                EnregistrementP register = new EnregistrementP { Id = id, Firstname = name, Lastname = prenom, Email = email, Phone = phone, Cin = cin, Classe = classe, Voyage = voy, Reservation = idres };
                listEnregistrer.Add(register);

            }
            reader.Close();
            dataGrid.ItemsSource = listEnregistrer;
            con.Close();


        }
        private void LogoutSection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tab = new MainWindow();
            tab.Show();
            this.Close();
        }

        private void HomeSection_Click(object sender, RoutedEventArgs e)
        {
            Window2 tab = new Window2();
            tab.Show();
            this.Close();
        }

        private void BoatSection_Click(object sender, RoutedEventArgs e)
        {
            Boat tab = new Boat();
            tab.Show();
            this.Close();
        }

        private void ReservationSection_Click(object sender, RoutedEventArgs e)
        {
            Reservation tab = new Reservation();
            tab.Show();
            this.Close();
        }

        private void ValidFiltre_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            con.Open();
            listrechercher = new ObservableCollection<EnregistrementP>();
            string search = Search.Text.ToString();
            string query = "SELECT * FROM passager WHERE nom LIKE '%" + search + "%' OR prenom LIKE '%" + search + "%'";

            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetString(0);
                    string name = reader.GetString(1);
                    string prenom = reader.GetString(2);
                    string email = reader.GetString(3);
                    string phone = reader.GetString(4);
                    string cin = reader.GetString(5);
                    string classe = reader.GetString(6);
                    string voy = reader.GetString(7);
                    string idres = reader.GetString(8);
                    EnregistrementP rechercher = new EnregistrementP { Id = id, Firstname = name, Lastname = prenom, Email = email, Phone = phone, Cin = cin, Classe = classe, Voyage = voy, Reservation = idres };
                    listrechercher.Add(rechercher);

                }
                reader.Close();
                dataGrid.ItemsSource = listrechercher;
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Bindgrid();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddPassenger tab = new AddPassenger();
            tab.Show();
        }

        private void buttonUpdat_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                EnregistrementP selectedRow = (EnregistrementP)dataGrid.SelectedItem;
                var id = selectedRow.Id;
                var firstname = selectedRow.Firstname;
                var lastname = selectedRow.Lastname;
                var email = selectedRow.Email;
                var phone = selectedRow.Phone;
                var cin = selectedRow.Cin;
                var idres = selectedRow.Reservation;
                var voy = selectedRow.Voyage;
                var classe = selectedRow.Classe;
                UpdatePassenger update = new UpdatePassenger();
                update.TextID.Text = id;
                update.FnameField.Text = firstname;
                update.LnameField.Text = lastname;
                update.EmailField.Text = email;
                update.TelField.Text = phone;
                update.CinField.Text = cin;
                update.ReseField.Text = idres;
                update.voyageField.Text = voy;
                update.classeField.Text = classe;
                update.Show();
            }
            else
            {
                MessageBox.Show("Veuillex selectionner une liste");
            }
        }


        public void executeQuery(string query)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItems != null)
            {
                var ligne = dataGrid.SelectedItems;
                foreach (EnregistrementP data in ligne)
                {
                  
                    MessageBoxResult resutl = MessageBox.Show("Voulez vous vraiment supprimer ?" + data.Id, "Confirmation", MessageBoxButton.YesNo);
                    if (resutl == MessageBoxResult.Yes)
                    {
                        int id;
                        int.TryParse(data.Id, out id);
                        string query = "DELETE FROM passager WHERE id_pass = " + id;
                        executeQuery(query);
                    }
                    else
                    {

                    }
                }
                Bindgrid();
            }
        }

        private void ReservationSection_Click_1(object sender, RoutedEventArgs e)
        {
            Reservation tab = new Reservation();
            tab.Show();
            this.Close();
        }

        private void VoyageSection_Click(object sender, RoutedEventArgs e)
        {
            Voyage tab = new Voyage();
            tab.Show();
            this.Close();
        }

        private void PassengerSection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
