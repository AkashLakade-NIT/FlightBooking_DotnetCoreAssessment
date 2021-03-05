using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace SqlRepository.Abstraction
{
    public interface IFlightBooking : IRepository<Flight_Book>
    {
        bool CheckFlight(DateTime dateOfJourney, int flightId);
    }
}
