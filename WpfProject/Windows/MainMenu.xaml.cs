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
using WpfProject.ViewModels;

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            SettingsUsers settingsUsers = new SettingsUsers();
            settingsUsers.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void nav_flights(object sender, RoutedEventArgs e)
        {
            MainMenu m = new MainMenu();
            m.Show();
            this.Close();
        }

        private void FlightOrder(object sender, RoutedEventArgs e)
        {
            FlightsOrder f = new FlightsOrder();
            f.Show();
        }
    }
}
