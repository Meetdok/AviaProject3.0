using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class AirplaneClassFlight
    {
        public int Idflight { get; set; }
        public int? ClassId { get; set; }
        public long? SeatCost { get; set; }
        public int? FlightId { get; set; }

        public virtual AirplanesClass? Class { get; set; }
        public virtual Flight? Flight { get; set; }
    }
}
