using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL
{
    public class MyDBContext : DbContext
    {

        public MyDBContext(DbContextOptions<MyDBContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasKey(f => f.FlightId);
            modelBuilder.Entity<Flight_Book>().HasKey(f => f.BookId);

            modelBuilder.Entity<Flight>().ToTable("tblFlight");
            modelBuilder.Entity<Flight_Book>().ToTable("tblFlightBook");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Flight_Book> Flight_Books { get; set; }

    }


}
