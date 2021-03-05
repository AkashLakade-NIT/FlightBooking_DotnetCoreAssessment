using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Booking.Models
{
    public class FlightBookingViewModel
    {
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfJourney { get; set; }
        public int FlightId { get; set; }
    }
}
