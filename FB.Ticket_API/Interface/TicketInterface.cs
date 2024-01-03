using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Ticket_API.Models;
//using FB.Flight_API.Entities;
using FB.Ticket_API.Entities;

namespace FB.Ticket_API.Interface
{
    public interface TicketInterface
    {
      
        void Cancel(string PNR);
       // FlightForTicket BookFlight(Ticket ticket);
        FlightForTicket BookFlight(BookTickets book);
        List<Ticket> MyBookings(string Email);
    }
}
