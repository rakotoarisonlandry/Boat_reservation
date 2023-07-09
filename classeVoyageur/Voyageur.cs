using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace BoatReservation.classes
{
    public class Voyageur : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;



        public Voyageur()
        {

        }

        private void NotifyPropertyChanged(string property)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public Voyageur(DataRow row )    
        {
            int code;
            string fr;
            idVoyageur = (int)row["code_voyage"];
            Itineraire = row["itinéraire"] as string ?? string.Empty;
            Durer = (String)row["Durée"];
            DateDepart = (DateTime)row["date_depart"];
            Frais = (int)row["frais"];
            Finitude = (bool)row["finitude"];
        IdBateau = (int)row["code_bat"];
        }


        private int _idVoyageur;
        public int idVoyageur
        {
            get { return _idVoyageur; }
            set { _idVoyageur = value; NotifyPropertyChanged("idVoyageur"); }
        }
        private string _Itineraire;
        public string Itineraire
        {
            get { return _Itineraire; }
            set { _Itineraire = value;NotifyPropertyChanged("Itineraire"); }
        }

        private string _Durer;


        public string Durer
        {
            get { return _Durer; }
            set { _Durer = value; NotifyPropertyChanged(Durer); NotifyPropertyChanged("Durer"); }
        }

        private int _Frais;
        public int Frais
        {
            get { return _Frais; }
            set { _Frais = value; NotifyPropertyChanged("Frais"); }
        }

        private DateTime _DateDepart;
        public DateTime DateDepart
        {
            get { return _DateDepart; }
            set { _DateDepart = value; NotifyPropertyChanged("DateDepart"); }
        }

        private int _IdBateau;
        public int IdBateau
        {
            get { return _IdBateau; }
            set { _IdBateau = value; NotifyPropertyChanged("IdBateau"); }
        }

        private bool _Finitude;
        public bool Finitude
        {
            get { return _Finitude; }
            set { _Finitude = value; NotifyPropertyChanged("Finitude"); }
        }

      
    }
}
