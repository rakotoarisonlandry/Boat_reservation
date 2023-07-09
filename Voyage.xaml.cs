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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.ComponentModel;
using BoatReservation.classes;

namespace BoatReservation
{
    public partial class Voyage : Window
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        ObservableCollection<Voyageur> listsVoyageurs = new ObservableCollection<Voyageur>();


        //DataTemplate listsVoyageur = new DataTemplate();
        public Voyage()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");

            InitializeComponent();
            LoadData(string.Empty);
        }

        private void Add(Voyageur voyage)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password="))
            {
                connection.Open();

                string commande = " INSERT INTO voyage (code_voyage,itinéraire,durée,date_depart,frais,finitude,code_bat) VALUES(@voyage,@itineraire,@durée,@date_depart,@frais,@finitude,@code_bat)";
                MySqlCommand cd = new MySqlCommand(commande, connection);


                cd.Parameters.AddWithValue("@voyage", voyage.idVoyageur);
                cd.Parameters.AddWithValue("@itineraire", voyage.Itineraire);
                cd.Parameters.AddWithValue("@durée", voyage.Durer);
                cd.Parameters.AddWithValue("@date_depart", voyage.DateDepart);
                cd.Parameters.AddWithValue("@frais", voyage.Frais);
                cd.Parameters.AddWithValue("@finitude", voyage.Finitude);
                cd.Parameters.AddWithValue("@code_bat", voyage.IdBateau);

               cd.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void Update(Voyageur voyage)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password="))
            {
                connection.Open();

                string commande = " UPDATE  voyage SET itinéraire =@itineraire , durée =@durée,date_depart =@date_depart,frais=@frais,finitude =@finitude, code_bat=@code_bat WHERE code_voyage =@IdVoyage ";
                MySqlCommand cd = new MySqlCommand(commande, connection);

                cd.Parameters.AddWithValue("@IdVoyage", voyage.idVoyageur);
                cd.Parameters.AddWithValue("@itineraire", voyage.Itineraire);
                cd.Parameters.AddWithValue("@durée", voyage.Durer);
                cd.Parameters.AddWithValue("@date_depart", voyage.DateDepart);
                cd.Parameters.AddWithValue("@frais", voyage.Frais);
                cd.Parameters.AddWithValue("@finitude", voyage.Finitude);
                cd.Parameters.AddWithValue("@code_bat", voyage.IdBateau);
                
                cd.ExecuteNonQuery();
                connection.Close();
            }
        }


        private void Delete(Voyageur voyage)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password="))
            {
                connection.Open();

                string commande = " DELETE FROM reservation   WHERE id_voyage =@IdVoyage ";


                MySqlCommand cd = new MySqlCommand(commande, connection);

                cd.Parameters.AddWithValue("@IdVoyage", voyage.idVoyageur);

                cd.ExecuteNonQuery();

                string commande1 = " DELETE FROM passager   WHERE id_voyage =@IdVoyage ";


                MySqlCommand cd1 = new MySqlCommand(commande1, connection);

                cd1.Parameters.AddWithValue("@IdVoyage", voyage.idVoyageur);

                cd1.ExecuteNonQuery();


                string cmd = " DELETE FROM voyage   WHERE code_voyage =@IdVoyage ";


                MySqlCommand msc = new MySqlCommand(cmd, connection);

                msc.Parameters.AddWithValue("@IdVoyage", voyage.idVoyageur);

                msc.ExecuteNonQuery();

                connection.Close();
            }
        }

        private void LoadData(string filtre)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password="))
            {

                connection.Open();

                if (string.IsNullOrWhiteSpace(filtre))
                {
                    string Commande = "SELECT * FROM  voyage";

                    MySqlCommand cd = new MySqlCommand(Commande, connection);

                    MySqlDataAdapter sa = new MySqlDataAdapter(cd);

                    sa.Fill(dt);
                }
                else
                {
                    string Commande = "SELECT * FROM  voyage WHERE itinéraire LIKE  @filtre OR code_voyage  LIKE  @filtre OR durée  LIKE  @filtre OR date_depart  LIKE  @filtre OR frais  LIKE  @filtre OR finitude  LIKE  @filtre OR code_bat  LIKE  @filtre";

                    MySqlCommand cd = new MySqlCommand(Commande, connection);

                    cd.Parameters.AddWithValue("@filtre", "%" + filtre + "%");

                    MySqlDataAdapter sa = new MySqlDataAdapter(cd);

                    sa.Fill(dt);
                }




                connection.Close();
            }

            listsVoyageurs = new ObservableCollection<Voyageur>();

            foreach (DataRow row in dt.Rows)
            {
                Voyageur voyage = new Voyageur(row);

                listsVoyageurs.Add(voyage);

            }

            listsVoyageurs.CollectionChanged += ListsVoyageurs_CollectionChanged;
            foreach (Voyageur voyage in listsVoyageurs)
            {
                voyage.PropertyChanged += Voyage_PropertyChanged;
            }


            dataGridVoyage.ItemsSource = listsVoyageurs;
        }

        private void Voyage_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Voyageur Voyage = sender as Voyageur;
            if (Voyage != null)
            {
                Update(Voyage);
            }


        }

        private void ListsVoyageurs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:

                    foreach (Voyageur voyage in e.NewItems)
                    {
                        Add(voyage);
                    }

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:

                    foreach (Voyageur voyage in e.OldItems)
                    {
                        Delete(voyage);
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }

        }

        private void buttonSupprimerLigne_Click(object sender, RoutedEventArgs e)
        {
            Voyageur LigneSelectionner = dataGridVoyage.SelectedItem as Voyageur;

            if (LigneSelectionner != null)
            {
                if (MessageBox.Show("Voulez-vous Vraiment supprimer ?", "Confirmation ", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    listsVoyageurs.Remove(LigneSelectionner);
                }
            }
        }




        private void PassengerSection_Click(object sender, RoutedEventArgs e)
        {
            Passager tab = new Passager();
            tab.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void LogoutSection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tab = new MainWindow();
            tab.Show();
            this.Close();
        }




        private void button_Modifier_Click(object sender, RoutedEventArgs e)
        {
            //    string Connection = "server=localhost; user=root; port=3306; database=boatreservation; password=";
            //    string requette = "UPDATE voyage SET  itineraire='" + textBox_itineraire.Text + "',durée='" + textBox_durée.Text + "',date_depart='" + textBox_Date.Text+ "',frais='" + textBox_frais.Text + "',finitude='" + textBox_finitude.Text + "',code_bat='" + textBox_idBateau.Text + "' WHERE code_voyage ='" + textBox_idVoyageur.Text + "',";
        }

        private void HomeSection_Click(object sender, RoutedEventArgs e)
        {

            Window2 tab = new Window2();
            tab.Show();
            this.Close();
        }


        private void button_Modifier_Click_1(object sender, RoutedEventArgs e)
        {

            Voyageur personne = dataGridVoyage.SelectedItem as Voyageur;
            Update(personne);
            MessageBox.Show("modification réeussit", "Confirmation ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            LoadData(textBox_research.Text);
        }

        private void textBox_research_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadData(this.textBox_research.Text);

                textBox_research.SelectAll();
            }
        }

        private void button_Nouveau_Click(object sender, RoutedEventArgs e)
        {
            Voyageur newvoyage = new Voyageur();

            Editer(newvoyage, true);
        }



        private void button_Editer_Click(object sender, RoutedEventArgs e)
        {

            Voyageur voyage = dataGridVoyage.SelectedItem as Voyageur;


            if (voyage != null)
            {
                Editer(voyage, false);
            }

        }

        private Voyageur GetPersonne(int Id)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password="))
            {

                connection.Open();

                string Commande = "SELECT * FROM  voyage WHERE code_voyage =@Id";

                MySqlCommand cd = new MySqlCommand(Commande, connection);

                MySqlDataAdapter sa = new MySqlDataAdapter(cd);


                cd.Parameters.AddWithValue("@Id", Id);
                sa.Fill(dt);
                connection.Close();

                if (dt.Rows.Count > 0)
                {
                    return new Voyageur(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }
        private void Editer(Voyageur voyage, bool newVoyage)
        {
            if (voyage != null)
            {
                WindowVoyage win = new WindowVoyage(voyage);
                if (win.ShowDialog() == true)
                {
                    if (newVoyage)
                    {
                        listsVoyageurs.Add(voyage);
                    }
                    else
                    {
                        Update(voyage);
                    }

                }

                else
                {
                    if (!newVoyage)
                    {
                        Voyageur old = GetPersonne(voyage.idVoyageur);

                        listsVoyageurs[listsVoyageurs.IndexOf(voyage)] = old;
                    }
                }
            }
        }

        private void dataGridVoyage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Voyageur voyage = dataGridVoyage.SelectedItem as Voyageur;

            if (voyage != null)
            {
                Editer(voyage, false);
            }
        }

        private void buttonActualiser_Click(object sender, RoutedEventArgs e)
        {
            LoadData(string.Empty);
        }

        private void BoatSection_Click(object sender, RoutedEventArgs e)
        {
    
            Boat tab = new Boat();
            tab.Show();
            this.Close();
    }
    }
}
