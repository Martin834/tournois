using System;
using System.Configuration;
using System.Windows;

namespace AppTournoi
{
    public partial class DatabaseSettingsWindow : Window
    {
        public DatabaseSettingsWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string ipAddress = IpAddressTextBox.Text;
            string port = PortTextBox.Text;
            string username = UsernameTextBox.Text;
            string encryptedPassword = PasswordBox.Password;

            // Sauvegarder les paramètres de connexion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("IpAddress");
            config.AppSettings.Settings.Remove("Port");
            config.AppSettings.Settings.Remove("Username");
            config.AppSettings.Settings.Remove("Password");

            config.AppSettings.Settings.Add("IpAddress", ipAddress);
            config.AppSettings.Settings.Add("Port", port);
            config.AppSettings.Settings.Add("Username", username);
            config.AppSettings.Settings.Add("Password", encryptedPassword);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Paramètres enregistrés avec succès !", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            LoadSettings();
            this.Close();
        }

        private void LoadSettings()
        {
            IpAddressTextBox.Text = ConfigurationManager.AppSettings["IpAddress"];
            PortTextBox.Text = ConfigurationManager.AppSettings["Port"];
            UsernameTextBox.Text = ConfigurationManager.AppSettings["Username"];
            PasswordBox.Password = ConfigurationManager.AppSettings["Password"];
        }
    }
}