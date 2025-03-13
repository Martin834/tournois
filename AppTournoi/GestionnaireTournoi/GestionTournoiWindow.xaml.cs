using System;
using System.Linq;
using System.Windows;
using DllTournois;
using BddtournoiContext;
using AppTournoi.GestionnaireTournoi;
using System.Configuration;

namespace AppTournoi
{
    public partial class GestionTournoiWindow : Window
    {
        private bddtournoi bdd;
        private AppTournoi.Tournoi selectedTournoi;

        public GestionTournoiWindow()
        {
            InitializeComponent();

            // Lire les paramètres de connexion de la configuration
            string ipAddress = ConfigurationManager.AppSettings["IpAddress"];
            string port = ConfigurationManager.AppSettings["Port"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];

            bdd = new bddtournoi(username, password, ipAddress, port);

            LoadTournois();
            LoadSports();
        }

        private void LoadTournois()
        {
            ListeTournois.ItemsSource = bdd.GetAllTournois().Select(t => new AppTournoi.Tournoi
            {
                IdTournoi = t.IdTournoi,
                Intitule = t.Intitule,
                DateTournoi = t.DateTournoi,
                Sport = t.Sport
            }).ToList();
        }

        private void LoadSports()
        {
            SportComboBox.ItemsSource = bdd.GetAllSports().Select(s => new AppTournoi.Sport
            {
                IdSport = s.IdSport,
                Intitule = s.Intitule
            }).ToList();
            SportComboBox.DisplayMemberPath = "Intitule";
        }

        private void AjouterTournoi_Click(object sender, RoutedEventArgs e)
        {
            AjouterTournoiWindow ajouterTournoiWindow = new AjouterTournoiWindow(bdd);
            bool? result = ajouterTournoiWindow.ShowDialog();
            if (result == true)
            {
                LoadTournois();
            }
        }

        private void ModifierTournoi_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTournoi != null)
            {
                ModifierTournoiWindow modifierTournoiWindow = new ModifierTournoiWindow(bdd, selectedTournoi);
                bool? result = modifierTournoiWindow.ShowDialog();

                if (result == true)
                {
                    LoadTournois();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un tournoi à modifier.");
            }
        }

        private void SupprimerTournoi_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTournoi != null)
            {
                bdd.DeleteTournoi(selectedTournoi.IdTournoi);
                LoadTournois();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un tournoi à supprimer.");
            }
        }

        private void ListeTournois_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedTournoi = (AppTournoi.Tournoi)ListeTournois.SelectedItem;
        }
    }

    public class Tournoi
    {
        public int IdTournoi { get; set; }
        public string Intitule { get; set; }
        public DateTime DateTournoi { get; set; }
        public int Sport { get; set; }

        public BddtournoiContext.Tournoi ToBddTournoi()
        {
            return new BddtournoiContext.Tournoi
            {
                IdTournoi = this.IdTournoi,
                Intitule = this.Intitule,
                DateTournoi = this.DateTournoi,
                Sport = this.Sport
            };
        }
    }
}