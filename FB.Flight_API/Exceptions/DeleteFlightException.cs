using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Admin_API.Exceptions
{
    public class DeleteFlightException : ApplicationException
    {
        public DeleteFlightException()
        {

        }
        public DeleteFlightException(string message) : base(message)
        {

        }
    }
}

