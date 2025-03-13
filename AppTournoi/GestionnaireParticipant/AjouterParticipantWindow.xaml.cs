using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using DllTournois;
using AppTournoi; // Assurez-vous que cet espace de noms est inclus

namespace AppTournoi.GestionnaireParticipant
{
    public partial class AjouterParticipantWindow : Window
    {
        private bddtournoi bdd;
        private byte[] photo;

        public AjouterParticipantWindow(bddtournoi bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
        }

        private void ChoisirPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                photo = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifiez que tous les champs obligatoires sont remplis
                if (string.IsNullOrWhiteSpace(NomTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PrenomTextBox.Text) ||
                    !DateNaissancePicker.SelectedDate.HasValue ||
                    string.IsNullOrWhiteSpace(SexeTextBox.Text) ||
                    string.IsNullOrWhiteSpace(TournoiTextBox.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Vérifiez que le champ Tournoi contient un entier valide
                if (!int.TryParse(TournoiTextBox.Text, out int tournoiId))
                {
                    MessageBox.Show("Veuillez entrer un identifiant de tournoi valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newParticipant = new AppTournoi.Participant
                {
                    Nom = NomTextBox.Text,
                    Prenom = PrenomTextBox.Text,
                    DateNaissance = DateNaissancePicker.SelectedDate.Value,
                    Sexe = SexeTextBox.Text,
                    Photo = photo,
                    Tournoi = tournoiId
                };

                // Utilisez la méthode ToBddParticipant() pour convertir l'objet
                var bddParticipant = newParticipant.ToBddParticipant();
                bdd.AddParticipant(bddParticipant);

                MessageBox.Show("Participant ajouté avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}