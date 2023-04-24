using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class Ticket
    {
        public Ticket()
        {
            ServicesTickets = new HashSet<ServicesTicket>();
        }

        public int TicketId { get; set; }
        public string? TicketTitle { get; set; }
        public decimal? TicketCost { get; set; }
        public DateTime? TicketDate { get; set; }
        public int? UserId { get; set; }
        public string? TicketStatus { get; set; }
        public long? Seats { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ServicesTicket> ServicesTickets { get; set; }
    }
}
