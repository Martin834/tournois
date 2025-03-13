using System;
using System.Linq;
using System.Windows;
using DllTournois;
using BddtournoiContext;
using AppTournoi.GestionnaireParticipant;

namespace AppTournoi.GestionnaireParticipant
{
    public partial class GestionParticipantWindow : Window
    {
        private bddtournoi bdd;
        private BddtournoiContext.Participant selectedParticipant;

        public GestionParticipantWindow()
        {
            InitializeComponent();
            bdd = new bddtournoi("adminTournois", "Password1234@", "localhost", "3306");
            LoadParticipants();
        }

        private void LoadParticipants()
        {
            ListeParticipants.ItemsSource = bdd.GetAllParticipants().Select(p => new BddtournoiContext.Participant
            {
                Id = p.Id,
                Prenom = p.Prenom,
                Nom = p.Nom,
                DateNaissance = p.DateNaissance,
                Sexe = p.Sexe,
                Photo = p.Photo,
                Tournoi = p.Tournoi
            }).ToList();
        }

        private void AjouterParticipant_Click(object sender, RoutedEventArgs e)
        {
            AjouterParticipantWindow ajouterParticipantWindow = new AjouterParticipantWindow(bdd);
            bool? result = ajouterParticipantWindow.ShowDialog();
            if (result == true)
            {
                LoadParticipants();
            }
        }

        private void ModifierParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (selectedParticipant != null)
            {
                ModifierParticipantWindow modifierParticipantWindow = new ModifierParticipantWindow(bdd, selectedParticipant);
                bool? result = modifierParticipantWindow.ShowDialog();

                if (result == true)
                {
                    LoadParticipants();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un participant à modifier.");
            }
        }

        private void SupprimerParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (selectedParticipant != null)
            {
                bdd.DeleteParticipant(selectedParticipant.Id);
                LoadParticipants();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un participant à supprimer.");
            }
        }

        private void ListeParticipants_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedParticipant = (BddtournoiContext.Participant)ListeParticipants.SelectedItem;
            if (selectedParticipant != null)
            {
                NomTextBox.Text = selectedParticipant.Nom;
                PrenomTextBox.Text = selectedParticipant.Prenom;
                DateNaissancePicker.SelectedDate = selectedParticipant.DateNaissance;
                SexeTextBox.Text = selectedParticipant.Sexe;
                TournoiTextBox.Text = selectedParticipant.Tournoi.ToString();
            }
        }
    }
}