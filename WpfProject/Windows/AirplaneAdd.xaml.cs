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
    /// Логика взаимодействия для AirplaneAdd.xaml
    /// </summary>
    public partial class AirplaneAdd : Window
    {
        public AirplaneAdd()
        {
            InitializeComponent();
            DataContext = new ListAirplanesVM(null);
        }

        private async void SaveAirplane(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Airplanes", "save", new Airplane
            {
                AirplaneTitle = txt_Name.Text,
                Places = int.Parse(txt_Seats.Text),           
                Class = new AirplanesClass { ClassName = txt_Class.Text}
            });
            User result = HttpApi.Deserialize<User>(json);

            MessageBox.Show("Сохранилось!");

            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
