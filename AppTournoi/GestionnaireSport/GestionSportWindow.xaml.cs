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
    /// Logique d'interaction pour GestionSportWindow.xaml
    /// </summary>
        public partial class GestionSportWindow : Window
        {
            private bddtournoi bdd;
            private AppTournoi.Sport selectedSport;

            public GestionSportWindow()
            {
                InitializeComponent();
                bdd = new bddtournoi("adminTournois", "Password1234@", "localhost", "3306");
                LoadSports();
            }

            private void LoadSports()
            {
                ListeSports.ItemsSource = bdd.GetAllSports().Select(s => new AppTournoi.Sport
                {
                    IdSport = s.IdSport,
                    Intitule = s.Intitule
                }).ToList();
            }

            private void AjouterSport_Click(object sender, RoutedEventArgs e)
            {
                AjouterSportWindow ajouterSportWindow = new AjouterSportWindow(bdd);
                bool? result = ajouterSportWindow.ShowDialog();
                if (result == true)
                {
                    LoadSports();
                }
            }

            private void ModifierSport_Click(object sender, RoutedEventArgs e)
            {
                if (selectedSport != null)
                {
                    ModifierSportWindow modifierSportWindow = new ModifierSportWindow(bdd, selectedSport);
                    bool? result = modifierSportWindow.ShowDialog();

                    if (result == true)
                    {
                        LoadSports();
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un sport à modifier.");
                }
            }

            private void SupprimerSport_Click(object sender, RoutedEventArgs e)
            {
                if (selectedSport != null)
                {
                    bdd.DeleteSport(selectedSport.IdSport);
                    LoadSports();
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un sport à supprimer.");
                }
            }

            private void ListeSports_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
            {
                selectedSport = (AppTournoi.Sport)ListeSports.SelectedItem;
            }
        }
    }
