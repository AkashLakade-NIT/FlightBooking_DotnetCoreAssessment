using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using ViewModels;

namespace SqlRepository.Abstraction
{
   public interface IFlightDetails : IRepository<Flight>
    {
        bool DuplicateCheck(string flightName);
        IEnumerable<Flight> Search(string filters);
    }
}
