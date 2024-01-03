using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Flight_API.Entities;
using FB.Flight_API.Interface;
using FB.Flight_API.Services;
using Microsoft.AspNetCore.Authorization;
using FB.Admin_API.Models;
using Microsoft.AspNetCore.Cors;

namespace FB.Flight_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Authorize(Roles = "Admin,User", AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class FlightController : ControllerBase
    {
        private readonly FlightService service;

        public FlightController(FlightService service)
        {
            this.service = service;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(Flight flight)
        {
            try
            {
                service.register(flight);//adding new airline
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAllFlights")]
        [HttpGet]

        public IActionResult GetAllFlights()
        {
            List<Flight> books = service.GetAllFlights();
            return Ok(books);
        }
        //[HttpGet]
        //[Route("Get/{FlightId}")]
        [HttpGet]
        [Route("GetFlightById")]
        public IActionResult GetFlightById(int FlightId)
        {
            try
            {
                Flight flight = service.GetFlightById(FlightId);
                return Ok(flight);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int FlightId)
        {
            try
            {
                service.Delete(FlightId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
       
        }
        [HttpPut]
        [Route("UpdateFlightDetails")]

        public IActionResult UpdateFlightDetails(Flight flight)
        {
            try
            {
                service.UpdateFlightDetails(flight);//update flight details
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        //[HttpPost]
        //[Route("Search")]

        //public IActionResult Search(SearchFlight search)
        //{
        //    try
        //    {
        //        Flight flight = new Flight();
        //        service.search(search);
        //        return Ok(flight);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }


        //}

        [HttpGet]
        [Route("Search")]

        public IActionResult Search(string FromPlace,string ToPlace)
        {
            try
            {
                List<Flight> flights = service.search(FromPlace,ToPlace);
                return Ok(flights);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
