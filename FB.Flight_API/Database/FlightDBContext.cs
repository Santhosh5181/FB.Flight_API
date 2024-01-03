using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Flight_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FB.Flight_API.Database
{
    public class FlightDBContext: DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {

        }
        public DbSet<Flight> Flights { get; set; }
    }
}
