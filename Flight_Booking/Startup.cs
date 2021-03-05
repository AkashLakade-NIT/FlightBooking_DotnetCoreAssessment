using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using security = DAL.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Flight_Booking.Configuration;
using Flight_Booking.Extensions;
using System.Text;


namespace Flight_Booking
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("conn");
            services.AddDbContext<MyDBContext>(
               op => op.UseSqlServer(conn));

            var authconn = Configuration.GetConnectionString("authconn");
            services.AddDbContext<ApplicationAuthContext>(
                op => op.UseSqlServer(authconn));

            services.AddIdentity<security.User, security.Role>()
                .AddEntityFrameworkStores<ApplicationAuthContext>()
                .AddDefaultTokenProviders();

            ApplicationSetup.RegisterServices(services);
            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddLogging();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight_Booking", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight_Booking v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
