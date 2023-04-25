using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebProject.WebModels;
using WpfProject.Tools;

namespace WpfProject.ViewModels
{
    public class EditAirplaneVM : BaseTools
    {
        public CommandVM SaveAirplane { get; set; }
       

        public string NameAirplane { get; set; }
        public int SeatsAirplane { get; set; }

        private List<Airplane> airplane;

        private List<AirplanesClass> listAirplaneClass;
        private AirplanesClass airplanesClass;

        public List<AirplanesClass> ListAirplaneClass
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

        public AirplanesClass AirplanesClass {
            get => airplanesClass;
            set => airplanesClass = value; }

        public EditAirplaneVM(Airplane airplane)
        {


            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Airplanes", "ListAirplanes", null);
                Airplane = HttpApi.Deserialize<List<Airplane>>(json);

                var json2 = await HttpApi.Post("AirplanesClasses", "ListAirplanesClasses", null);
                ListAirplaneClass = HttpApi.Deserialize<List<AirplanesClass>>(json2);
            });


            SaveAirplane = new CommandVM(async () =>
            {
                var json3 = await HttpApi.Post("Airplanes", "put", new Airplane
                {
                    AirplanesId = airplane.AirplanesId,                    
                    ClassId = AirplanesClass.AirplaneClassId,
                    AirplaneTitle = NameAirplane,
                    Places = SeatsAirplane
                });
                
                MessageBox.Show("Сохранилось!");
            });
        }           
    }
}
