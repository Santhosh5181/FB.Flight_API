using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Models
{
    public class BookTickets
    {
        public int FlightID { get; set; }
       // public string Flightname { get; set; }
        public string From_Place { get; set; }
        public string To_Place { get; set; }
      //  public string AirLine { get; set; }
        public DateTime StartDateTime { get; set; }
       // public DateTime EndDateTime { get; set; }
        public string Email { get; set; }
        public int NoOfSeats { get; set; }
        //public string PNR { get; set; }
        //public int TotalPrice { get; set; }
        //public string BookingStatus { get; set; }
    }
}
