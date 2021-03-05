using System;

namespace ViewModels
{
    public class FlightDetailsVM
    {
        public int FlightId { get; set; }
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string FlightAmount { get; set; }
        public string AvailableTickets { get; set; }
        public DateTime FlightDate { get; set; }
    }
}
