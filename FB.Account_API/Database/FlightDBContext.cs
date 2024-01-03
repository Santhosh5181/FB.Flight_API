using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Account_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FB.Account_API.Database
{
    public class FlightDBContext: DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
