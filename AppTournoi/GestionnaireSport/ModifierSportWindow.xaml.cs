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
    /// Logique d'interaction pour ModifierSportWindow.xaml
    /// </summary>
    public partial class ModifierSportWindow : Window
    {
        private bddtournoi bdd;
        private AppTournoi.Sport sport;

        public ModifierSportWindow(bddtournoi bdd, AppTournoi.Sport sport)
        {
            InitializeComponent();
            this.bdd = bdd;
            this.sport = sport;
            LoadSportDetails();
        }

        private void LoadSportDetails()
        {
            NomTextBox.Text = sport.Intitule;
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            sport.Intitule = NomTextBox.Text;
            bdd.UpdateSport(sport.ToBddSport());
            this.DialogResult = true;
            this.Close();
        }
    }
}
