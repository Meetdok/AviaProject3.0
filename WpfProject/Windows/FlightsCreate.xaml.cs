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
    /// Логика взаимодействия для FlightsCreate.xaml
    /// </summary>
    public partial class FlightsCreate : Window
    {
        public FlightsCreate()
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM();
        }

        private async void CreateFlight(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Flights", "save", new Flight
            {
                FlightTitle = txt_NameFlight.Text,
                FlightCityDeparture = txt_DepartureFlight.Text,
                FlightCityArrival = txt_ArrivalFlight.Text,
                FlightDate = DateTime.Parse(txt_DateFlight.Text),
                Airplane = new Airplane { AirplaneTitle = txt_AirplaneFlight.Text },
                FlightCompany = new FlightCompany { FlightCompanyName = txt_CompanyFlight.Text },
                NumberOfSeats = int.Parse(txt_SeatsFlight.Text),
            });
            Flight result = HttpApi.Deserialize<Flight>(json);

            MessageBox.Show("Сохранилось!");
        }
    }
}
