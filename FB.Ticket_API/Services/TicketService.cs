using FB.Ticket_API.Models;
//using FB.Flight_API.Entities;
using FB.Ticket_API.Database;
using FB.Ticket_API.Entities;
using FB.Ticket_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Ticket_API.Exceptions;

namespace FB.Ticket_API.Services
{
    public class TicketService : TicketInterface
    {
        private readonly FlightDBContext context;
        public static List<Ticket> booking = new List<Ticket>();

        public TicketService(FlightDBContext context)
        {
            this.context = context;
        }


        public FlightForTicket BookFlight(BookTickets book)
        //public FlightForTicket BookFlight(Ticket book)
        {
            FlightForTicket ticket = context.flightforticket.SingleOrDefault(i => i.FlightNumber == book.FlightID);
            if (ticket != null)
            {
                var std = new Ticket()
                {
                    PNR = System.Guid.NewGuid().ToString().ToUpper(),
                    FlightID = ticket.FlightNumber,
                    Email = book.Email,
                    BookingStatus = "Booked",
                    NoOfSeats = book.NoOfSeats,
                    BookingDate = System.DateTime.Now,
                    TotalPrice= book.NoOfSeats * ticket.Price
                };
                context.Tickets.Add(std);
                context.SaveChanges();
            }
            else
            {
                throw new TicketInvalidException($"Invalid Flight Details");
            }

            return ticket;
        }
        public void Cancel(string PNR)
        {
            //if()
            //Flight flight1 = new Flight();
            Ticket admin = context.Tickets.Where(c => c.PNR == PNR).Single<Ticket>();
            //
            FlightForTicket ticket = context.flightforticket.SingleOrDefault(i => i.FlightNumber == admin.FlightID);
            DateTime DepartureDate = ticket.StartDateTime;

            //if(DepartureDate > admin.BookingDate)
            //{
                admin.BookingStatus = "Cancelled";
                context.SaveChanges();
            //}
            //
            //else
            //{
            //    throw new TicketCancelException($"Tickets should be cancel atleast one day before the journey Date");
            //    // return ("Tickets should be cancel atleast one day before the journey Date");
            //}
            
        }

        public List<Ticket> MyBookings(string Email)
        {
            // ileList.Where(item => filterList.Contains(item))

            //fileList.Where(item => filterList.Contains(item))
            return context.Tickets.ToList().FindAll(e=> e.Email==Email);

            //return ticket;       


        }
    }
}
