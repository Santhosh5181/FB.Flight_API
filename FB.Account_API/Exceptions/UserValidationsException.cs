using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Exceptions
{
    public class UserValidationsException : ApplicationException
    {
        public UserValidationsException()
        {

        }
        public UserValidationsException(string message) : base(message)
        {

        }
    }
}

