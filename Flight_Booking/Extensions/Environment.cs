using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Flight_Booking.Extensions
{
    public static class Environment
    {
        public static bool IsUAT(this IWebHostEnvironment webenv)
        {
            if (webenv.EnvironmentName == "UAT")
                return true;
            else
                return false;
        }
    }
}
