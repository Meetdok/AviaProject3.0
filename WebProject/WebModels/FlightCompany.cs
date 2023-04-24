using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class FlightCompany
    {
        public FlightCompany()
        {
            Flights = new HashSet<Flight>();
        }

        public int FlightCompanysId { get; set; }
        public string? FlightCompanyName { get; set; }
        public int? ServiceId { get; set; }

        public virtual Service? Service { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
