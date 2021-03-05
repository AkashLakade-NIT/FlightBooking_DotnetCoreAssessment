using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Booking.Models
{
    public class FlightDetailsViewModel
    {
        public int FlightId { get; set; }
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string FlightAmount { get; set; }
        public string AvailableTickets { get; set; }
        public DateTime FlightDate { get; set; }
    }
}
