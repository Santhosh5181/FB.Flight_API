using FB.Ticket_API.Entities;
using FB.Ticket_API.Models;
using FB.Ticket_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Authorize(Roles = "Admin,User", AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    
    public class BookingController : ControllerBase
    {
        private readonly TicketService service;

        public BookingController(TicketService service)
        {
            this.service = service;
        }
        [Route("Book")]
        [HttpPost]
        
       // public IActionResult Book(Ticket ticket)
            public IActionResult Book(BookTickets book)
        {
            //service.BookFlight(book);//
            //return Ok();
            try
            {
                service.BookFlight(book);//
                                          return Ok(book);
                //return CreatedAtRoute("",new {PNR= });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("Cancel")]
        [HttpGet]
        public IActionResult Cancel(string PNR)
        {
            try
            {
                service.Cancel(PNR);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("MyBookings")]
        public IActionResult MyBookings(string Email)
        {
            try
            {
                List<Ticket> ticket = service.MyBookings(Email);
                return Ok(ticket);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
