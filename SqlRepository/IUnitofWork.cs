using System;
using System.Collections.Generic;
using System.Text;
using SqlRepository.Abstraction;

namespace SqlRepository
{
    public interface IUnitofWork
    {
        IFlightDetails FlightDetailsRepo { get;  }
        IFlightBooking FlightBookingRepo { get; }
        void Commit();
    }
}
