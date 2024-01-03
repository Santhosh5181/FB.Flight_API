using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public string PNR { get; set; }
        //[Key]
        //public int PNR { get; set; }
        public string Email { get; set; }
        public int FlightID { get; set; }//Flight Number

        //[ForeignKey("FlightID")]
        //public FlightForTicket Flights { get; set; }
        public string BookingStatus { get; set; }
        //
        public int NoOfSeats { get; set; }
        public DateTime? BookingDate { get; set; }

        //
        public int TotalPrice { get; set; }
    }
}
