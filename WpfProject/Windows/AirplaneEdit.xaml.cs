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
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.ViewModels;

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AirplaneEdit.xaml
    /// </summary>
    public partial class AirplaneEdit : Window
    {
        public AirplaneEdit(Airplane airplanes)
        {
            InitializeComponent();
            DataContext = new EditAirplaneVM(airplanes);
        }

    }        
}
