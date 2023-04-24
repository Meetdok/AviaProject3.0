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
    /// Логика взаимодействия для AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    {
        public AddCompany()
        {
            InitializeComponent();
            DataContext = new ListCompanysVM();
        }

        private async void SaveCompany(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("FlightCompanies", "save", new FlightCompany
            {
                FlightCompanyName = txt_Name.Text,
                Service = new Service { ServiceType = txt_Service.Text }
            });
            Airplane result = HttpApi.Deserialize<Airplane>(json);

            MessageBox.Show("Сохранилось!");
        }
    }
}
