//using FB.Flight_API.Entities;
using FB.Ticket_API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Database
{
    public class FlightDBContext : DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<FlightForTicket> flightforticket { get; set; }
    }
}
