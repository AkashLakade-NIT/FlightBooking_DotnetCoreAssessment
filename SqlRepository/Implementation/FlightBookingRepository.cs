using System;
using DAL;
using DAL.Entities;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlRepository.Abstraction;

namespace SqlRepository.Implementation
{
    class FlightBookingRepository : Repository<Flight_Book>, IFlightBooking
    {
        private MyDBContext _context;
    public FlightBookingRepository(MyDBContext context) : base(context)
    {
        _context = context;
    }

    public bool CheckFlight(DateTime dateOfJourney, int flightId)
    {
            var flightDetails = (from flight in _context.Flights
                                 join book in _context.Flight_Books on flight.FlightId equals book.FlightId
                                 where flight.FlightId == flightId && flight.FlightDate == dateOfJourney
                                 select book).ToList();
            if (flightDetails.Count == 0)
            {
                return true;
            }
            return false;
        }
}
}
