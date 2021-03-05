using Flight_Booking.ResultTypes;
using Microsoft.AspNetCore.Mvc;
using SqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Flight_Booking.Security;

namespace Flight_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingController : Controller
    {

        private readonly MyDBContext context;
        IUnitofWork uow;
        
        public FlightBookingController(MyDBContext _context, IUnitofWork _uow)
        {
            context = _context;
            uow = _uow;
        }

        [HttpPost]
        //[CustomAuthorize(Role = "User")]

        public IActionResult FlightBook(Flight_Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (uow.FlightBookingRepo.CheckFlight(book.DateOfJourney, book.FlightId))
            {
                uow.FlightBookingRepo.Add(book);
                uow.Commit();
            }
            else
            {
                return Ok(new InsertResult() { NewId = book.BookId, Message = "Flights  are not available" });
            }

            return Ok(new InsertResult() { NewId = book.BookId, Message = "Flight booked successfully" });
        }

    }
}
