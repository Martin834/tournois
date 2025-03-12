using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DllTournois;

namespace AppTournoi.GestionnaireSport
{
    /// <summary>
    /// Logique d'interaction pour AjouterSportWindow.xaml
    /// </summary>
    public partial class AjouterSportWindow : Window
    {
        private bddtournoi bdd;

        public AjouterSportWindow(bddtournoi bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            var sport = new AppTournoi.Sport
            {
                Intitule = NomTextBox.Text
            };
            bdd.AddSport(sport.ToBddSport());
            this.DialogResult = true;
            this.Close();
        }
    }

    public class Sport
    {
        public int IdSport { get; set; }
        public string Intitule { get; set; }

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
