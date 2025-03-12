using System;
using System.Linq;
using System.Windows;
using DllTournois;

namespace AppTournoi.GestionnaireTournoi
{
    public partial class ModifierTournoiWindow : Window
    {
        private bddtournoi bdd;
        private AppTournoi.Tournoi tournoi;

        public ModifierTournoiWindow(bddtournoi bdd, AppTournoi.Tournoi tournoi)
        {
            InitializeComponent();
            this.bdd = bdd;
            this.tournoi = tournoi;
            LoadSports();
            LoadTournoiDetails();
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

        private void LoadTournoiDetails()
        {
            NomTextBox.Text = tournoi.Intitule;
            DatePicker.SelectedDate = tournoi.DateTournoi;
            SportComboBox.SelectedItem = SportComboBox.Items.Cast<AppTournoi.Sport>().FirstOrDefault(s => s.IdSport == tournoi.Sport);
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            tournoi.Intitule = NomTextBox.Text;
            tournoi.DateTournoi = DatePicker.SelectedDate.Value;
            tournoi.Sport = ((AppTournoi.Sport)SportComboBox.SelectedItem).IdSport;
            bdd.UpdateTournoi(tournoi.ToBddTournoi());
            this.DialogResult = true;
            this.Close();
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