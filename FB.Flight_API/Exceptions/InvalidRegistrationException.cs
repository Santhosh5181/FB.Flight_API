using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Admin_API.Exceptions
{
    public class InvalidRegistrationException : ApplicationException
    {
        public InvalidRegistrationException()
        {

        }
        public InvalidRegistrationException(string message) : base(message)
        {

        }
    }
}
