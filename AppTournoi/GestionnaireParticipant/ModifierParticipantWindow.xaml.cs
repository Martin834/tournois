using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using DllTournois;

namespace AppTournoi.GestionnaireParticipant
{
    public partial class ModifierParticipantWindow : Window
    {
        private bddtournoi bdd;
        private BddtournoiContext.Participant participant;

        public ModifierParticipantWindow(bddtournoi bdd, BddtournoiContext.Participant participant)
        {
            InitializeComponent();
            this.bdd = bdd;
            this.participant = participant;
            LoadParticipantDetails();
        }

        private void LoadParticipantDetails()
        {
            NomTextBox.Text = participant.Nom;
            PrenomTextBox.Text = participant.Prenom;
            DateNaissancePicker.SelectedDate = participant.DateNaissance;
            SexeTextBox.Text = participant.Sexe;
            TournoiTextBox.Text = participant.Tournoi.ToString();
        }

        private void ChoisirPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                participant.Photo = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            participant.Nom = NomTextBox.Text;
            participant.Prenom = PrenomTextBox.Text;
            participant.DateNaissance = DateNaissancePicker.SelectedDate ?? DateTime.Now;
            participant.Sexe = SexeTextBox.Text;
            participant.Tournoi = int.Parse(TournoiTextBox.Text);
            bdd.UpdateParticipant(participant);
            this.DialogResult = true;
            this.Close();
        }
    }
}