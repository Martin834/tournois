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

namespace AppTournoi.GestionGestionnaire
{
    /// <summary>
    /// Logique d'interaction pour ModifierGestionnaireWindow.xaml
    /// </summary>
    public partial class ModifierGestionnaireWindow : Window
    {
        private bddtournoi bdd;
        private AppTournoi.Gestionnaire gestionnaire;

        public ModifierGestionnaireWindow(bddtournoi bdd, Gestionnaire gestionnaire)
        {
            InitializeComponent();
            this.bdd = bdd;
            this.gestionnaire = gestionnaire;
            LoadGestionnaireDetails();
        }

        private void LoadGestionnaireDetails()
        {
            LoginTextBox.Text = gestionnaire.Login;
            MotDpassBox.Password = gestionnaire.MotDpass;
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            gestionnaire.Login = LoginTextBox.Text;
            gestionnaire.MotDpass = MotDpassBox.Password;
            bdd.UpdateGestionnaire(gestionnaire.ToBddGestionnaire());
            this.DialogResult = true;
            this.Close();
        }
    }
}
