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
    /// Logique d'interaction pour AddBoat.xaml
    /// </summary>
    public partial class AddBoat : Window

    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        public AddBoat()
        {
            InitializeComponent();
        }

        private void LnameField_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancel Button");
            this.Close();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            int classique;
            int premium;
            int vip;
            int.TryParse(ClassiqueField.Text, out classique);
            int.TryParse(PremiumField.Text, out premium);
            int.TryParse(VipField.Text, out vip);
            string design = DesignField.Text;
            try
            {
                
                connection.Open();
                string query = "INSERT INTO bateaux(design , class_a, class_b, class_c) VALUES('" + design + "'," + vip + "," + premium + "," + classique + "); ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur: "+ex.Message);
                }

                connection.Close();
                MessageBox.Show("Bateaux Crée avec succès!. Veuiller actualiser pour voir le résultat.");
                this.Close();
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);

            }
            
           
        }
    }
}
