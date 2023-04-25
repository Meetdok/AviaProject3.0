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

namespace WpfProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListService.xaml
    /// </summary>
    public partial class ListService : Page
    {
        public ListService()
        {
            InitializeComponent();
            DataContext = new ListServicesVM();
        }
    }
}
