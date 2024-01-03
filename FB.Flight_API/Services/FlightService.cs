using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Flight_API.Entities;
using FB.Flight_API.Interface;
using FB.Flight_API.Database;
using FB.Admin_API.Exceptions;
using FB.Admin_API.Models;

namespace FB.Flight_API.Services
{
    public class FlightService : FlightInterface
    {
        private readonly FlightDBContext context;
        public static List<Flight> list = new List<Flight>();

        public FlightService(FlightDBContext context)
        {
            this.context = context;
        }

        public void Delete(int FlightId)
        {
            Flight flight = context.Flights.SingleOrDefault(i => i.FlightNumber == FlightId);
            if (flight != null)
            {
                context.Flights.Remove(flight);
                context.SaveChanges();
            }
            else
            {
                throw new DeleteFlightException($"Invalid Flight Number");
            }

        }

        public List<Flight> GetAllFlights()
        {
            return context.Flights.ToList();
        }

        public Flight GetFlightById(int FlightId)
        {
            Flight flight = context.Flights.SingleOrDefault(i => i.FlightNumber == FlightId);
            if (flight != null)
            {
                return flight;
            }
            else
            {
                throw new DeleteFlightException($"Invalid Flight Number");
            }

        }

        public void register(Flight flight)
        {
            if (flight.AirLine != string.Empty)
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidRegistrationException($"Invalid Details");
            }

        }


        public List<Flight> search(string FromPlace, string ToPlace)
        {

            //Flight flight = context.Flights.FirstOrDefault(i => i.From_Place == search.From_Place & i.To_Place == search.To_Place & i.StartDateTime == search.From_Date);
            //Flight flight = context.Flights.FirstOrDefault(i => i.From_Place == search.From_Place & i.To_Place == search.To_Place);
            //Flight flight = context.Flights.FirstOrDefault(i => i.From_Place == FromPlace & i.To_Place == ToPlace);
            if (FromPlace != null)
            {
                return context.Flights.ToList().FindAll(e => e.From_Place == FromPlace & e.To_Place == ToPlace);
            }
            else
            {
                throw new DeleteFlightException($"Invalid From Place and To Place");
            }
        }

        public void UpdateFlightDetails(Flight flight)
        {

            Flight flight1 = new Flight();
            Flight admin = context.Flights.Where(c => c.FlightNumber == flight.FlightNumber).Single<Flight>();
            if (admin != null)
            {
                admin.Intrument_Used = flight.Intrument_Used;
                admin.From_Place = flight.From_Place;
                admin.To_Place = flight.To_Place;
                admin.AirLine = flight.AirLine;
                admin.StartDateTime = flight.StartDateTime;
                admin.EndDateTime = flight.EndDateTime;

                admin.TotalBusinessClassSeats = flight.TotalBusinessClassSeats;
                admin.TotalNonBusinessClassSeats = flight.TotalNonBusinessClassSeats;
                admin.NoOfRows = flight.NoOfRows;
                admin.MealType = flight.MealType;
                admin.ScheduledDays = flight.ScheduledDays;
                admin.Price = flight.Price;

                context.SaveChanges();
            }
            else
            {
                throw new UpdateFlightDetailsException($"Invalid Flight Number");
            }

        }


    }
}
