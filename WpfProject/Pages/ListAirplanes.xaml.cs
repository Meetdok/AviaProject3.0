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
using WebProject.WebModels;
using WpfProject.ViewModels;
using WpfProject.Windows;

namespace WpfProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListAirplanes.xaml
    /// </summary>
    public partial class ListAirplanes : Page
    {
        public ListAirplanes( )
        {
            InitializeComponent();
            DataContext = new ListAirplanesVM();
        }      
    }
}
