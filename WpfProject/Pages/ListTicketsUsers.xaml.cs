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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject.ViewModels;
using WpfProject.Windows;

namespace WpfProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListTicketsUsers.xaml
    /// </summary>
    public partial class ListTicketsUsers : Page
    {
        public ListTicketsUsers()
        {
            InitializeComponent();
            DataContext = new ListTicketsVM();
        }

        private void FlightOrder(object sender, RoutedEventArgs e)
        {
           
        }

       
    }
}
