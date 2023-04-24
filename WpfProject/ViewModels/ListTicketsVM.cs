using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.WebModels;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.ViewModels
{
    public class ListTicketsVM : BaseTools
    {

        public Ticket SelectedItem { get; set; }
        private List<Ticket> ticket;
        private List<User> user;

        public List<Ticket> Ticket
        {
            get => ticket;
            set
            {
                ticket = value;

                Signal();
            }
        }

        public List<User> User
        {
            get => user;
            set
            {
                user = value;

                Signal();
            }
        }

        public CommandVM DeleteTicket { get; set; }

        public ListTicketsVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Tickets", "ListTickets", null);
                Ticket = HttpApi.Deserialize<List<Ticket>>(json);

                var json2 = await HttpApi.Post("Users", "ListUsers", null);
                User = HttpApi.Deserialize<List<User>>(json2);
            });

            DeleteTicket = new CommandVM(async () =>
            {
                var json = await HttpApi.Post("Tickets", "delete", SelectedItem.TicketId);

                Task.Run(async () =>
                {
                    var json = await HttpApi.Post("Tickets", "ListTickets", null);
                    Ticket = HttpApi.Deserialize<List<Ticket>>(json);

                    var json2 = await HttpApi.Post("Users", "ListUsers", null);
                    User = HttpApi.Deserialize<List<User>>(json2);
                });
            });

        }
    }
}
