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
    /// Логика взаимодействия для MainMenuEmployee.xaml
    /// </summary>
    public partial class MainMenuEmployee : Window
    {
        public MainMenuEmployee()
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM();
        }

        private void EditFlight(object sender, RoutedEventArgs e)
        {
            FlightsOrderEdit o = new FlightsOrderEdit();
            o.Show();
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
            MainMenuEmployee m = new MainMenuEmployee();
            m.Show();
            this.Close();
        }

        private void DeleteFlight(object sender, RoutedEventArgs e)
        {

        }
    }
}
