using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebProject.WebModels;
using WpfProject.Pages;
using WpfProject.Tools;
using WpfProject.WebModels;
using WpfProject.Windows;

namespace WpfProject.ViewModels
{
    public class MainMenuGuestVM : BaseTools
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }

        public Flight SelectedItem { get; set; }

        private List<Airplane> airplane;
        private List<Flight> flight;
        private List<FlightCompany> flightCompanie;

        public List<Flight> Flight
        {
            get => flight;
            set
            {
                flight = value;

                Signal();
            }
        }

        public List<FlightCompany> FlightCompanie
        {
            get => flightCompanie;
            set
            {
                flightCompanie = value;

                Signal();
            }
        }

        public List<Airplane> Airplane
        {
            get => airplane;
            set
            {
                airplane = value;

                Signal();
            }
        }

        public CommandVM DeleteFlight { get; set; }

        public CommandVM nav_airplanes { get; set; }

        public CommandVM nav_companys { get; set; }  

        public CommandVM nav_service { get; set; }


        public CommandVM nav_tickets { get; set; }
       
        public CommandVM nav_companysEmploy { get; set; }

        public CommandVM nav_companysServices { get; set; }

        public CommandVM nav_airplanesEmploy { get; set; }

        public CommandVM nav_usersEmploy { get; set; }

        public CommandVM nav_ticketsUsers { get; set; }

        public MainMenuGuestVM()
        {

            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Flights", "ListFlights", null);
                Flight = HttpApi.Deserialize<List<Flight>>(json);

                var json2 = await HttpApi.Post("Airplanes", "ListAirplanes", null);
                Airplane = HttpApi.Deserialize<List<Airplane>>(json2);

                var json3 = await HttpApi.Post("FlightCompanies", "ListFlightCompanys", null);
                FlightCompanie = HttpApi.Deserialize<List<FlightCompany>>(json3);

            });


            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;


            DeleteFlight = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Flights", "delete", SelectedItem.FlightsId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Flights", "ListFlights", null);
                    Flight = HttpApi.Deserialize<List<Flight>>(json);

                    var json2 = await HttpApi.Post("Airplanes", "ListAirplanes", null);
                    Airplane = HttpApi.Deserialize<List<Airplane>>(json2);

                    var json3 = await HttpApi.Post("FlightCompanies", "ListFlightCompanys", null);
                    FlightCompanie = HttpApi.Deserialize<List<FlightCompany>>(json3);
                });
            });

            nav_airplanes = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListAirplanes());
            });

            nav_airplanesEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListAirplanesEmploy(null));
            });

            nav_service = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListService());
            });

            nav_companys = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListCompanys());
            });

            nav_companysServices = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListServices());
            });

            nav_companysEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListCompanysEmploy());
            });

            nav_tickets = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListTickets());
            });

            nav_ticketsUsers = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListTicketsUsers());
            });

            nav_usersEmploy = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListUsers ());
            });
        }

    }
}
