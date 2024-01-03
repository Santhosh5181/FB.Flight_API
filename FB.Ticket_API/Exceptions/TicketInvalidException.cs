using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Ticket_API.Exceptions
{
    public class TicketInvalidException: ApplicationException
    {
        public TicketInvalidException()
        {

        }
        public TicketInvalidException(string message): base (message)
        {

        }

    }
}
