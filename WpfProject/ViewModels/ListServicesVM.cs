using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.WebModels;
using WpfProject.Tools;

namespace WpfProject.ViewModels
{
    public class ListServicesVM : BaseTools
    {
        public Service SelectedItem { get; set; }

        private List<Service> services;

        public List<Service> Service
        {
            get => services;
            set
            {
                services = value;

                Signal();
            }
        }

        public CommandVM DeleteService { get; set; }

        public ListServicesVM()
        {
            Task.Run(async () =>
            {               
                var json2 = await HttpApi.Post("Services", "ListServices", null);
                Service = HttpApi.Deserialize<List<Service>>(json2);
            });

            DeleteService = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Services", "delete", SelectedItem.ServiceId);

                Task.Run(async () =>
                {
                    var json2 = await HttpApi.Post("Services", "ListServices", null);
                    Service = HttpApi.Deserialize<List<Service>>(json2);
                });
            });
        }
    }
}
