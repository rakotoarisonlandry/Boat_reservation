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
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        // Setting connection state
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        private ObservableCollection<HistoriqueP> listEnregistrer;
        public Window2()
        {
            InitializeComponent();
            Bindgrid();
        }
        public void Bindgrid()
        {
            MySqlConnection con = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            con.Open();
            listEnregistrer = new ObservableCollection<HistoriqueP>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM reservation", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string id_res = reader.GetString(0);
                string id_voyage = reader.GetString(1);
                string class_A = reader.GetString(2);
                string class_b = reader.GetString(3);
                string class_c = reader.GetString(4);
                string prenom = reader.GetString(5);
                string numero = reader.GetString(6);
                string payement = reader.GetString(7);
                string somme_paye = reader.GetString(8);
                string reste_paye = reader.GetString(9);
                string fini = reader.GetString(10);
                HistoriqueP register = new HistoriqueP { IdReservation = id_res, IdVoyage = id_voyage, classA = class_A, classB = class_b, classC = class_c, Firstname = prenom, Phone = numero, Paiement = payement, SommePayée = somme_paye, Reste = reste_paye, Statut = fini };
                listEnregistrer.Add(register);

            }
            reader.Close();
            dataGrid.ItemsSource = listEnregistrer;
            con.Close();


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Bindgrid();
        }

        private void HomeSection_Click(object sender, RoutedEventArgs e)
        {
            Home tab = new Home();
            tab.Show();
            this.Close();
        }

        private void BoatSection_Click(object sender, RoutedEventArgs e)
        {
            Boat tab = new Boat();
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

        private void LogoutSection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tab = new MainWindow();
            tab.Show();
            this.Close();
        }
        

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                HistoriqueP selectedRow = (HistoriqueP)dataGrid.SelectedItem;
                var fini = selectedRow.Statut;

                /*Window3 update = new Window3();
                update.StatutField.Text = fini;
                update.Show();*/

                if (fini != "True")
                {
                    string id = selectedRow.IdReservation;
                    MessageBoxResult result = MessageBox.Show("Etes-vous sur de vouloir validé le réservation n°"+ id +" ?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        connection.Open();
                        string query = "UPDATE reservation SET fini = 1  WHERE id_res = " + id;
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

                        connection.Close();
                        MessageBox.Show("Validation effectuer !");
                        Bindgrid();
                    }
                    
                } else
                {
                    MessageBox.Show("Ce réservation est déja valider");
                }

                
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
            connection.Close();
        }
        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid.SelectedItems != null)
            {
                var ligne = dataGrid.SelectedItems;
                foreach (HistoriqueP data in ligne)
                {
                    MessageBoxResult resutl = MessageBox.Show("Supprimer " + data.IdReservation, "Confirmation", MessageBoxButton.YesNo);
                    if (resutl == MessageBoxResult.Yes)
                    {
                        int id_res;
                        int.TryParse(data.IdReservation, out id_res);
                        string query = "DELETE FROM reservation WHERE id_res = " + id_res;
                        executeQuery(query);
                    }
                    else
                    {

                    }
                }
                Bindgrid();
            }
            /*dataGrid.SelectedItems != null)
            {
                var ligne = dataGrid.SelectedItems;
                foreach (HistoriqueP data in ligne)
                {
                    MessageBoxResult resutl = MessageBox.Show("Supprimer " + data.IdReservation, "Confirmation", MessageBoxButton.YesNo);
                    if (resutl == MessageBoxResult.Yes)
                    {
                        int id_res;
                        int.TryParse(data.IdReservation, out id_res);
                        string query = "DELETE FROM reservation WHERE id_res = " + id_res;
                        executeQuery(query);
                        Bindgrid();
                    }
                }
            }*/
        }

        private void Validation_button_Click(object sender, RoutedEventArgs e)
        {
            string id = SearchBar.Text;

            if (id != "")
            {
                int ID;

                bool res = int.TryParse(id, out ID);
                if(res)
                {
                    try
                    {
                        string query = "SELECT * FROM reservation WHERE id_res = "+ID+";";

                        connection.Open();
                        listEnregistrer = new ObservableCollection<HistoriqueP>();
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string id_res = reader.GetString(0);
                            string id_voyage = reader.GetString(1);
                            string class_A = reader.GetString(2);
                            string class_b = reader.GetString(3);
                            string class_c = reader.GetString(4);
                            string prenom = reader.GetString(5);
                            string numero = reader.GetString(6);
                            string payement = reader.GetString(7);
                            string somme_paye = reader.GetString(8);
                            string reste_paye = reader.GetString(9);
                            string fini = reader.GetString(10);
                            HistoriqueP register = new HistoriqueP { IdReservation = id_res, IdVoyage = id_voyage, classA = class_A, classB = class_b, classC = class_c, Firstname = prenom, Phone = numero, Paiement = payement, SommePayée = somme_paye, Reste = reste_paye, Statut = fini };
                            listEnregistrer.Add(register);
                        }
                        reader.Close();
                        dataGrid.ItemsSource = listEnregistrer;
                        connection.Close();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Veuiller ne saisir que les numéro de réservation.");
                }

            } else
            {
                MessageBox.Show("Veuiller saisir le numéro de réservation dans le billet.");
            }
        }

        private void VoyageSection_Click(object sender, RoutedEventArgs e)
        {
            Voyage tab = new Voyage();
            tab.Show();
            this.Close();
        }
    }
}
