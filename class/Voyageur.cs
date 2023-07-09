using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatReservation
{
    class Voyageur
{
        private string _idVoyageur;
        public string idVoyageur
        {
            get { return _idVoyageur; }
            set { _idVoyageur = value; }
        }

        //fonction prend en paramatre idVoyageur
        public Voyageur(string idVoyageur)
        {
            _idVoyageur = idVoyageur;
        }

        private string  _Itineraire;
        public string Itineraire
        {
            get { return _Itineraire; }
            set { _Itineraire = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _DateDepart;
        public string DateDepart
        {
            get { return _DateDepart; }
            set { _DateDepart = value; }
        }
    }
}
