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

namespace AppTournoi
{
    public partial class AuthenticationWindow : Window
    {

        private bddtournoi bdd;
        public AuthenticationWindow()
        {
            InitializeComponent();
            bdd = new bddtournoi("adminTournois", "Password1234@", "localhost", "3306");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Valider les informations d'authentification ici
            if (username == bdd.GetGestionnaireById(1).Login && password == bdd.GetGestionnaireById(1).MotDpass)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }

        private void AnnulerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
