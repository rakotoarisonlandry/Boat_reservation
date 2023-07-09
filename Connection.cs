
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

namespace BoatReservation
{
    class Connection
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; user=root; port=3306; database=boatreservation; password=");
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySqlConnection Error" + ex.Message);
            }
            return connection;
        }
    }
}
