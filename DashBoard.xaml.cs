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

namespace BoatReservation
{
    /// <summary>
    /// Logique d'interaction pour DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void LogoutSection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow tab = new MainWindow();
            tab.Show();
            this.Close();
        }
    }
}
