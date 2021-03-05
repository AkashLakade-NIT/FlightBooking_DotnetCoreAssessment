using DAL;
using SqlRepository.Abstraction;
using SqlRepository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlRepository
{
    public class UnitOfWork : IUnitofWork
    {
        private MyDBContext _context;
        public UnitOfWork(MyDBContext context)
        {
            _context = context;
        }
        private IFlightDetails _flightDetailsRepo;
        private IFlightBooking _flightBookingRepo;
        public IFlightDetails FlightDetailsRepo
        {
            get
            {
                if (_flightDetailsRepo == null)
                    _flightDetailsRepo = new FlightDetailsRepository(_context);

                return _flightDetailsRepo;
            }
        }

        public IFlightBooking FlightBookingRepo
        {
            get
            {
                if (_flightBookingRepo == null)
                    _flightBookingRepo = new FlightBookingRepository(_context);

                return _flightBookingRepo;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
