using BoatReservation.classes;
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
    /// Logique d'interaction pour WindowVoyage.xaml
    /// </summary>
    public partial class WindowVoyage : Window
    {

        private Voyageur _voyage;
        public WindowVoyage(Voyageur voyage)
        {
            InitializeComponent();
            _voyage = voyage;
            this.DataContext = _voyage;
            this.textBox_itineraire.Focus();
        }

        private void button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void button_Enregister_Click(object sender, RoutedEventArgs e)
        {
            int frais = 0;
            int idBateau = 0;
            int.TryParse(textBox_frais.Text, out frais);
            int.TryParse(textBoxIdBateau.Text, out idBateau);
            
           


            if (Convert.ToString(frais) != textBox_frais.Text)
            {
                MessageBox.Show("Vous Devez entrer des chiffres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBox_frais.Focus();


            }
            if (Convert.ToString(idBateau) != textBoxIdBateau.Text)
            {
                MessageBox.Show("Vous Devez entrer des chiffres ", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxIdBateau.Focus();
            }

            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void textBox_itineraire_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
