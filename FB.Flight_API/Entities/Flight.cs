using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Flight_API.Entities
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int FlightNumber { get; set; }
        //public string Flightname { get; set; }
        public string Intrument_Used { get; set; }
        public string From_Place { get; set; }
        public string To_Place { get; set; }
        public string AirLine { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int TotalBusinessClassSeats { get; set; }
        public int TotalNonBusinessClassSeats { get; set; }
        public int NoOfRows { get; set; }
        public string MealType { get; set; }

        //
        public string ScheduledDays { get; set; }
        public int Price { get; set; }
    }
}
