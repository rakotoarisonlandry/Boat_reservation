using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using BoatReservation.classes;

namespace BoatReservation
{
    static class Sauvegarde
    {
        static private string _dossier = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\boatReservation";
        static private string _fichier = "Voyage.csv";
        static private string _chemin = Path.Combine(_dossier, _fichier);

        //methode pour saubegarder les donnees

        public static void SauvegarderCSV(ObservableCollection<Voyageur> Voyage)
        {
            if (!Directory.Exists(_dossier))
            {
                Directory.CreateDirectory(_dossier);
            }

            StringBuilder ligne = new StringBuilder();

            using (StreamWriter fichier = new StreamWriter(_chemin, false, Encoding.UTF8, 1024))
            {
                foreach (Voyageur personne in Voyage)
                {
                    ligne.Append(personne.idVoyageur + " ");
                    ligne.Append(personne.Itineraire + " ");
                    ligne.Append(personne.DateDepart + " ");
                    ligne.Append(personne.Frais + " ");
                    ligne.Append(personne.Durer + " ");
                    ligne.Append(personne.IdBateau + " ");
                    fichier.WriteLine(ligne.ToString());
                    ligne.Clear();
                }
            }
        }

        public static ObservableCollection<Voyageur> ChargerCSV(ObservableCollection<Voyageur> Voyage)
        {
            if (File.Exists(_chemin))
            {

                using (StreamReader fichier = new StreamReader(_chemin, Encoding.UTF8))
                {
                    String ligne;

                    while ((ligne = fichier.ReadLine()) != null)
                    {
                        if (!String.IsNullOrWhiteSpace(ligne))
                        {
                            Voyageur voyageur = new Voyageur();

                            String[] Champs = ligne.Split(';');

                            //voyageur.idVoyageur = Champs[0];
                            //voyageur.Itineraire = Champs[1];
                            //voyageur.DateDepart = Champs[2];
                            //voyageur.Email = Champs[3];
                            //voyageur.Durer = Champs[3];
                            //voyageur.IdBateau = Champs[3];
                            Voyage.Add(voyageur);
                        }
                    }
                }
            }
            return Voyage;
        }

    }
}