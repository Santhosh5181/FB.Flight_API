using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Admin_API.Models;
using FB.Flight_API.Entities;

namespace FB.Flight_API.Interface
{
    public interface FlightInterface
    {
        void register(Flight flight);
        List<Flight> GetAllFlights();
        Flight GetFlightById(int FlightId);//FlightId is a Flight Number
        void Delete(int FlightId);//FlightId is a Flight Number
        List<Flight> search(string FromPlace, string ToPlace);
        void UpdateFlightDetails(Flight flight);

    }
}
