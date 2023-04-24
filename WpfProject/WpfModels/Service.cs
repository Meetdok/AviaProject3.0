using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class Service
    {
        public Service()
        {
            FlightCompanies = new HashSet<FlightCompany>();
            ServicesTickets = new HashSet<ServicesTicket>();
        }

        public int ServiceId { get; set; }
        public string? ServiceType { get; set; }
        public decimal? ServiceCost { get; set; }

        public virtual ICollection<FlightCompany> FlightCompanies { get; set; }
        public virtual ICollection<ServicesTicket> ServicesTickets { get; set; }
    }
}
