using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class ServicesTicket
    {
        public int ServiceTicketsId { get; set; }
        public int IdService { get; set; }
        public int ItTicket { get; set; }

        public virtual Service IdServiceNavigation { get; set; } = null!;
        public virtual Ticket ItTicketNavigation { get; set; } = null!;
    }
}
