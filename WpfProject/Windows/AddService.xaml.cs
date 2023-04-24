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

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
        }

        private async void SaveService(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Services", "save", new Service
            {
               ServiceType = txt_Name.Text,
               ServiceCost = int.Parse(txt_Cost.Text)
            });
            Service result = HttpApi.Deserialize<Service>(json);

            MessageBox.Show("Сохранилось!");
        }
    }
}
