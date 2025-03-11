using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BddtournoiContext;
using DllTournois;

namespace AppTournoi
{
    public partial class MainWindow : Window
    {
        private bddtournoi dbContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DatabaseSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseSettingsWindow settingsWindow = new DatabaseSettingsWindow();
                settingsWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR CRITIQUE : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void ConnexionBDD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lire les paramètres de connexion de la configuration
                string ipAddress = ConfigurationManager.AppSettings["IpAddress"];
                string port = ConfigurationManager.AppSettings["Port"];
                string username = ConfigurationManager.AppSettings["Username"];
                string password = ConfigurationManager.AppSettings["Password"];

                // Utiliser les paramètres pour établir une connexion à la base de données
                dbContext = new bddtournoi(username, password, ipAddress, port);

                // Charger la liste des sports
                var sports = dbContext.GetAllSports();
                ListeSports.ItemsSource = sports;

                MessageBox.Show("Connexion réussie !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        private void SelectionListeSports(object sender, SelectionChangedEventArgs e)
        {
            if (ListeSports.SelectedItem != null)
            {
                var selectedSport = (Sport)ListeSports.SelectedItem;

                try
                {
                    // Récupérer les tournois en fonction du sport sélectionné
                    var tournoisBySport = dbContext.GetAllTournoisBySport(selectedSport.IdSport);

                    List<string> ListeTournois1 = new List<string>();

                    if (tournoisBySport.Any())
                    {
                        ListeTournois1.AddRange(tournoisBySport);
                        this.ListeTournois.ItemsSource = ListeTournois1;
                    }
                    else
                    {
                        MessageBox.Show("Aucun tournoi n'est lié à ce sport !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de récupération des informations : " + ex.Message);
                }
            }
        }

        private void SelectionListeTournois(object sender, SelectionChangedEventArgs e)
        {
            if (ListeTournois.SelectedItem != null)
            {
                var selectedTournoi = ListeTournois.SelectedItem.ToString();

                try
                {
                    var tournoi = dbContext.GetTournoiByName(selectedTournoi);

                    if (tournoi != null)
                    {
                        var participantsByTournoi = dbContext.GetAllParticipantsByTournoi(tournoi.IdTournoi);

                        List<string> ListeParticipants1 = new List<string>();

                        if (participantsByTournoi.Any())
                        {
                            ListeParticipants1.AddRange(participantsByTournoi);
                            this.ListeParticipants.ItemsSource = ListeParticipants1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le tournoi sélectionné est introuvable !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur de récupération des informations : " + ex.Message);
                }
            }
            else
            {
                // Si aucun tournoi n'est sélectionné, videz la liste des participants
                this.ListeParticipants.ItemsSource = null;
            }
        }


        private void ListeParticipantsMenuClick(object sender, EventArgs e)
        {
            Window w = new ListeParticipantsWindow();
            w.Show();
        }
    }
}
