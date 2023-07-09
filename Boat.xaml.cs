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
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour Boat.xaml
    /// </summary>
    public partial class Boat : Window
    {

        // Setting connection state
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        private ObservableCollection<BoatModel> BoatModel;
        public Boat()
        {
            InitializeComponent();
            BindGrid();
        }

        public void BindGrid()
        {

            connection.Open();
            BoatModel = new ObservableCollection<BoatModel>();
            string query = "SELECT * from bateaux ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                string id = reader["code_bat"].ToString();
                string design = reader["design"].ToString();
                string status = reader["disponibilité"].ToString();
                string vip = reader["class_a"].ToString();
                string premium = reader["class_b"].ToString();
                string classique = reader["class_c"].ToString();

                /*int classique = Convert.ToInt32(reader["class_a"]);
                int premium = Convert.ToInt32(reader["class_b"]);
                int vip = Convert.ToInt32(reader["class_c"]);*/

                BoatModel boatItem = new BoatModel
                {
                    ID = id,
                    Design = design,
                    Status = status,
                    VIP = vip,
                    Premium = premium,
                    Classique = classique,
                };

                BoatModel.Add(boatItem);
            }
            reader.Close();
            dataGrid.ItemsSource = BoatModel;
            connection.Close();
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

        private void PassengerSection_Click(object sender, RoutedEventArgs e)
        {
            Passager tab = new Passager();
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
            string search = Search.Text.ToString();
            string query = "SELECT * FROM bateaux WHERE design LIKE " + "'%" + search + "%'";
            BoatModel = new ObservableCollection<BoatModel>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["code_bat"].ToString();
                    string design = reader["design"].ToString();
                    string status = reader["disponibilité"].ToString();
                    string vip = reader["class_a"].ToString();
                    string premium = reader["class_b"].ToString();
                    string classique = reader["class_c"].ToString();

                    /*int classique = Convert.ToInt32(reader["class_a"]);
                    int premium = Convert.ToInt32(reader["class_b"]);
                    int vip = Convert.ToInt32(reader["class_c"]);*/

                    BoatModel boatItem = new BoatModel
                    {
                        ID = id,
                        Design = design,
                        Status = status,
                        VIP = vip,
                        Premium = premium,
                        Classique = classique,
                    };

                    BoatModel.Add(boatItem);

                }
                reader.Close();
                dataGrid.ItemsSource = BoatModel;
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex.Message);
            }
        }


        private void FiltreBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            AddBoat tab = new AddBoat();
            tab.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Voulez vous vraiment supprimer ?","Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    connection.Open();
                    while (dataGrid.SelectedItem != null)
                    {
                        BoatModel selectedItem = (BoatModel)dataGrid.SelectedItem;
                        int id = Convert.ToInt32(selectedItem.ID);
                        Console.WriteLine(id);
                        string query = "DELETE FROM bateaux WHERE code_bat = " + id+ ";";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        BoatModel.Remove(selectedItem);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a boat to delete", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dataGrid_Initialized(object sender, EventArgs e)
        {

        }

        private void adddata(object sender, EventArgs e)
        {

        }

        private void update_click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItem != null)
            {
                BoatModel selectedRow = (BoatModel)dataGrid.SelectedItem;
                var id = selectedRow.ID;
                var design = selectedRow.Design;
                var classique = selectedRow.Classique;
                var premium = selectedRow.Premium;
                var vip = selectedRow.VIP;
                UpdateBoat update = new UpdateBoat();

                update.TextID.Text = id;
                update.DesignField.Text = design;
                update.ClassiqueField.Text = classique;
                update.PremiumField.Text = premium;
                update.VipField.Text = vip;
                update.Show();
            }
            else
            {
                MessageBox.Show("Veuillex selectionner une liste");
            }
        }

        private void VoyageSection_Click(object sender, RoutedEventArgs e)
        {
            Voyage tab = new Voyage();
            tab.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /*private void Loaded(object sender, RoutedEventArgs e)
        {

        }*/
    }
}
