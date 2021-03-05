using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Webapp.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, FlightDetailsVM>()
               .ForMember(d => d.AvailableTickets, op => op.MapFrom(d => d.AvailableTickets))
               .ForMember(d => d.AvailableTickets, op => op.MapFrom(d => d.AvailableTickets));
            CreateMap<Flight, UpdateFlightDetailsVM>()
                .ForMember(d => d.AvailableTickets, op => op.MapFrom(d => d.AvailableTickets));

            

            CreateMap<FlightDetailsVM, Flight>()
            .ForMember(d => d.AvailableTickets, op => op.MapFrom(d => d.AvailableTickets));
            CreateMap<UpdateFlightDetailsVM, Flight>()
                .ForMember(d => d.AvailableTickets, op => op.MapFrom(d => d.AvailableTickets)); ;
        }
    }
}
