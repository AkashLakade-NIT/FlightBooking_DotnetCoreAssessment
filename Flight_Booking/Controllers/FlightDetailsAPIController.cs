using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlRepository;
using SqlRepository.Abstraction;
using System.Collections.Generic;
using ViewModels;
using Flight_Booking.ResultTypes;
using Flight_Booking.Security;
using Flight_Booking.Models;


namespace Flight_Booking.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FlightDetailsAPIController : Controller
    {
        IUnitofWork uow;
        IMapper _mapper;
        ILogger _logger;
       
        public FlightDetailsAPIController(IUnitofWork _uow, IMapper mapper, ILogger<FlightDetailsAPIController> logger)
        {
            uow = _uow; 
            _mapper = mapper;
            _logger = logger;
        }

        [Route("searchFlight/{filter}")]
        [HttpGet]
        public IEnumerable<Flight> SearchFlightDetails(string filter)
        {
            return uow.FlightDetailsRepo.Search(filter);
        }

        [Route("flight/{id:int}")]
        [HttpGet]
        public IActionResult getProduct(int id)
        {

            var flight = uow.FlightDetailsRepo.GetById(id);
            var pvm = _mapper.Map<FlightDetailsVM>(flight);

            return Ok(pvm);
        }

        [HttpPost]
        [Route("add")]
       //[CustomAuthorize(Role = "Admin")]

        public IActionResult AddProduct([FromBody] FlightDetailsVM flightToInsert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _logger.LogError("Error Logging: Flight Info=" + flightToInsert.FlightId);


            var flight = _mapper.Map<Flight>(flightToInsert);
            uow.FlightDetailsRepo.Add(flight);

            uow.Commit();

            InsertResult result = new InsertResult()
            {
                NewId = flight.FlightId,
                Message = "Flight added"
            };

            return StatusCode(201, result);
        }


        [HttpGet]
        [Route("getall")]
        //[CustomAuthorize(Role = "User")]

        public IEnumerable<FlightDetailsVM> GetAll()
        {
            var result = uow.FlightDetailsRepo.GetAll();
            List<FlightDetailsVM> flight = _mapper.Map<List<FlightDetailsVM>>(result);
            _logger.LogInformation("GetAll Executed");

            return flight;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var isDelete = uow.FlightDetailsRepo.Delete(id);
            uow.Commit();
            return Ok(isDelete);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateFlightDetailsVM FlightToUpdate)
        {
            var product = _mapper.Map<Flight>(FlightToUpdate);

            uow.FlightDetailsRepo.Update(product);
            uow.Commit();

            return Ok(true);

        }

    }
}
