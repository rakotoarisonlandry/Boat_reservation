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
    /// Logique d'interaction pour UpdateBoat.xaml
    /// </summary>
    public partial class UpdateBoat : Window
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
        public UpdateBoat()
        {
            InitializeComponent();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            int classique;
            int premium;
            int vip;
            int id;
            int.TryParse(ClassiqueField.Text, out classique);
            int.TryParse(PremiumField.Text, out premium);
            int.TryParse(VipField.Text, out vip);
            int.TryParse(TextID.Text, out id);
            string design = DesignField.Text;
            try
            {

                connection.Open();
                string query = "UPDATE bateaux SET design ='" + design + "', class_a= "+ vip + ", class_b =" + premium + ", class_c=" + classique + " WHERE code_bat= "+ id +"; ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur: " + ex.Message);
                }

                connection.Close();
                MessageBox.Show("Bateaux Crée avec succès!. Veuiller actualiser pour voir le résultat.");
                this.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);

            }


        }
    }
}
