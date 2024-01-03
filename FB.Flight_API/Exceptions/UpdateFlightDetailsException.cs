using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Admin_API.Exceptions
{
    public class UpdateFlightDetailsException : ApplicationException
    {
        public UpdateFlightDetailsException()
        {

        }
        public UpdateFlightDetailsException(string message) : base(message)
        {

        }
    }
}