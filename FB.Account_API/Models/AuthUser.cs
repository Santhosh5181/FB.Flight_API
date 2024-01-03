using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Models
{
    public class AuthUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
