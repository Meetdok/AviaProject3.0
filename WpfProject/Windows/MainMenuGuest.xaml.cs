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
    /// Логика взаимодействия для MainMenuGuest.xaml
    /// </summary>
    public partial class MainMenuGuest : Window
    {
        public MainMenuGuest()
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void nav_flights(object sender, RoutedEventArgs e)
        {
            MainMenuGuest g = new MainMenuGuest();
            g.Show();
            this.Close();
        }
    }
}
