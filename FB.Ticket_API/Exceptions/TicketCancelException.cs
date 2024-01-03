using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Exceptions
{
    public class TicketCancelException : ApplicationException
    {
        public TicketCancelException()
        {

        }
        public TicketCancelException(string message) : base(message)
        {

        }
    }
}
