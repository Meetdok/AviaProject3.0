using System;
using System.Collections.Generic;

namespace WebProject.WebModels
{
    public partial class AirplanesClass
    {
        public AirplanesClass()
        {
            AirplaneClassFlights = new List<AirplaneClassFlight>();
            Airplanes = new List<Airplane>();
        }

        public int AirplaneClassId { get; set; }
        public string? ClassName { get; set; }

        public virtual List<AirplaneClassFlight> AirplaneClassFlights { get; set; }
        public virtual List<Airplane> Airplanes { get; set; }
    }

}
