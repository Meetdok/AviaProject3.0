using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.WebModels;
using WpfProject.Windows;

namespace WpfProject.ViewModels
{
    public class ListAirplanesVM : BaseTools
    {
        public Airplane SelectedItem { get; set; }
        private List<AirplanesClass> airplanesClass;
        private List<Airplane> airplane;
        public List<AirplanesClass> airplanesClasses;

        public string NameAirplane { get; set; }
        public string  SeatsAirplane { get; set; }
        public AirplanesClass listAirplaneClass;

        public AirplanesClass ListAirplaneClass
        {
            get => listAirplaneClass;
            set
            {
                listAirplaneClass = value;
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

        public List<AirplanesClass> AirplanesClass
        {
            get => airplanesClass;
            set
            {
                airplanesClass = value;

                Signal();
            }
        }

        public CommandVM DeleteAirplane { get; set; }
        public CommandVM EditAirplane { get; set; }
        public CommandVM SaveAirplane { get; set; }

        public ListAirplanesVM(Airplane airplane)
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Airplanes", "ListAirplanes", null);
                Airplane = HttpApi.Deserialize<List<Airplane>>(json);

                var json2 = await HttpApi.Post("AirplanesClasses", "ListAirplanesClasses", null);
                AirplanesClass = HttpApi.Deserialize<List<AirplanesClass>>(json2);
            });

            EditAirplane = new CommandVM(async () =>
            {
                airplane = SelectedItem;
                new AirplaneEdit(airplane).Show();

            });

            SaveAirplane = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Airplanes", "put", new Airplane
                {

                    ClassId = ListAirplaneClass.AirplaneClassId,
                    AirplaneTitle = NameAirplane,
                    //Places = SeatsAirplane
                });
            });

            DeleteAirplane = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Airplanes", "delete", SelectedItem.AirplanesId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Airplanes", "ListAirplanes", null);
                    Airplane = HttpApi.Deserialize<List<Airplane>>(json);

                    var json2 = await HttpApi.Post("AirplanesClasses", "ListAirplanesClasses", null);
                    AirplanesClass = HttpApi.Deserialize<List<AirplanesClass>>(json);
                });
            });                    
        }
    }
}
