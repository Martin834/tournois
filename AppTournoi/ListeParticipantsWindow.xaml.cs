using System;
using System.Collections.Generic;
using System.Windows;
using DllTournois;
using System.Configuration;
using BddtournoiContext;
using System.Windows.Controls;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace AppTournoi
{
    public partial class ListeParticipantsWindow : Window
    {
        private bddtournoi bdd;
        private List<Participant> allParticipants;
        public ListeParticipantsWindow()
        {
            InitializeComponent();

            string ipAddress = ConfigurationManager.AppSettings["IpAddress"];
            string port = ConfigurationManager.AppSettings["Port"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];

            bdd = new bddtournoi(username, password, ipAddress, port);

            allParticipants = bdd.GetAllParticipants().Select(p => new Participant
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom,
                DateNaissance = p.DateNaissance,
                Sexe = p.Sexe,
                Photo = p.Photo,
                Tournoi = p.Tournoi
            }).ToList();

            ParticipantsInfo.ItemsSource = allParticipants;
        }

        private void SearchBox_TextChanged(Object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();

            if (Regex.IsMatch(searchText, @"\d"))
            {
                SearchBox.Background = new SolidColorBrush(Colors.LightCoral);

                ErrorMessage.Text = "Il n'est pas possible d'écrire des chiffres !";
                ErrorMessage.Visibility = Visibility.Visible;
            }
            else
            {
                SearchBox.Background = new SolidColorBrush(Colors.White);

                ErrorMessage.Visibility = Visibility.Collapsed;
            }

            var filteredParticipants = bdd.GetParticipantByName(searchText).Select(p => new Participant
            {
                Nom = p.Nom,
                Prenom = p.Prenom,
                DateNaissance = p.DateNaissance,
                Sexe = p.Sexe,
                Photo = p.Photo,
                Tournoi = p.Tournoi
            }).ToList();
            ParticipantsInfo.ItemsSource = filteredParticipants;
        }

    }
}
