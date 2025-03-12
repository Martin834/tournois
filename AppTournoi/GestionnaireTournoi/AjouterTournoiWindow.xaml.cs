using System.Linq;
using System.Windows;
using DllTournois;

namespace AppTournoi
{
    public partial class AjouterTournoiWindow : Window
    {
        private bddtournoi bdd;

        public AjouterTournoiWindow(bddtournoi bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
            LoadSports();
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

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            var tournoi = new AppTournoi.Tournoi
            {
                Intitule = NomTextBox.Text,
                DateTournoi = DatePicker.SelectedDate.Value,
                Sport = ((AppTournoi.Sport)SportComboBox.SelectedItem).IdSport
            };
            bdd.AddTournoi(tournoi.ToBddTournoi());
            this.DialogResult = true;
            this.Close();
        }
    }

    public class Sport
    {
        public int IdSport { get; set; }
        public string Intitule { get; set; }

        public static Sport FromBddSport(BddtournoiContext.Sport bddSport)
        {
            return new Sport
            {
                IdSport = bddSport.IdSport,
                Intitule = bddSport.Intitule
            };
        }

        public BddtournoiContext.Sport ToBddSport()
        {
            return new BddtournoiContext.Sport
            {
                IdSport = this.IdSport,
                Intitule = this.Intitule
            };
        }
    }
}