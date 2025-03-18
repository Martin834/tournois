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
    /// Logique d'interaction pour AjouterGestionnaireWindow.xaml
    /// </summary>
    public partial class AjouterGestionnaireWindow : Window
    {
        private bddtournoi bdd;

        public AjouterGestionnaireWindow(bddtournoi bdd)
        {
            InitializeComponent();
            this.bdd = bdd;
        }

        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            var gestionnaire = new AppTournoi.Gestionnaire
            {
                Login = LoginTextBox.Text,
                MotDpass = MotDpassBox.Password
            };
            bdd.AddGestionnaire(gestionnaire.ToBddGestionnaire());
            this.DialogResult = true;
            this.Close();
        }
    }

    public class Gestionnaire
    {
        public int IdGestionnaire { get; set; }
        public string Login { get; set; }
        public string MotDpass { get; set; }

        public BddtournoiContext.Gestionnaire ToBddGestionnaire()
        {
            return new BddtournoiContext.Gestionnaire
            {
                IdGestionnaire = this.IdGestionnaire,
                Login = this.Login,
                MotDpass = this.MotDpass
            };
        }
    }
}
