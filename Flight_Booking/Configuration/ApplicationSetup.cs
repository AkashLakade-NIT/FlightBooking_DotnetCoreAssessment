using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlRepository;
using SqlRepository.Abstraction;
using SqlRepository.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Flight_Booking.Configuration
{
    public class ApplicationSetup
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFlightDetails, FlightDetailsRepository>();
            serviceCollection.AddScoped<IUnitofWork, UnitOfWork>();
            //serviceCollection.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        }
    }
}
