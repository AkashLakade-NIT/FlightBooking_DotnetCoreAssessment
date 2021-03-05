using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;
using SqlRepository.Abstraction;
using System.Linq;



namespace SqlRepository.Implementation
{
    public class FlightDetailsRepository : Repository<Flight>, IFlightDetails
    {
        private MyDBContext _context;
        public FlightDetailsRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }


        public bool DuplicateCheck(string flight)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> Search(string filters)
        {
            var flightDetails = _context.Flights.Where(f => f.SourceLocation.Contains(filters) ||
                                   f.DestinationLocation.Contains(filters)).ToList();

            return flightDetails;
        }

    }
}
