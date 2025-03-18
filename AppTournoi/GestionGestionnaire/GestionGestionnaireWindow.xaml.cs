using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace AppTournoi.GestionGestionnaire
{
    /// <summary>
    /// Logique d'interaction pour GestionGestionnaireWindow.xaml
    /// </summary>
    public partial class GestionGestionnaireWindow : Window
    {
        private bddtournoi bdd;
        private AppTournoi.Gestionnaire selectedGestionnaire;

        public GestionGestionnaireWindow()
        {
            InitializeComponent();

            string ipAddress = ConfigurationManager.AppSettings["IpAddress"];
            string port = ConfigurationManager.AppSettings["Port"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];

            bdd = new bddtournoi(username, password, ipAddress, port);
            LoadGestionnaires();
        }

        private void LoadGestionnaires()
        {
            ListeGestionnaires.ItemsSource = bdd.GetAllGestionnaires().Select(g => new AppTournoi.Gestionnaire
            {
                IdGestionnaire = g.IdGestionnaire,
                Login = g.Login,
                MotDpass = g.MotDpass
            }).ToList();
        }

        private void AjouterGestionnaire_Click(object sender, RoutedEventArgs e)
        {
            AjouterGestionnaireWindow ajouterGestionnaireWindow = new AjouterGestionnaireWindow(bdd);
            bool? result = ajouterGestionnaireWindow.ShowDialog();
            if (result == true)
            {
                LoadGestionnaires();
            }
        }

        private void ModifierGestionnaire_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGestionnaire != null)
            {
                ModifierGestionnaireWindow modifierGestionnaireWindow = new ModifierGestionnaireWindow(bdd, selectedGestionnaire);
                bool? result = modifierGestionnaireWindow.ShowDialog();

                if (result == true)
                {
                    LoadGestionnaires();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un gestionnaire à modifier.", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SupprimerGestionnaire_Click(object sender, RoutedEventArgs e)
        {
            if (selectedGestionnaire != null)
            {
                bdd.DeleteGestionnaire(selectedGestionnaire.IdGestionnaire);
                LoadGestionnaires();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un gestionnaire à supprimer.");
            }
        }

        private void ListeGestionnaires_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedGestionnaire = (AppTournoi.Gestionnaire)ListeGestionnaires.SelectedItem;
        }
    }
}
