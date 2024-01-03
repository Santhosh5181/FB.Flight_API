using FB.Account_API.Entities;
using FB.Account_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Repositories
{
    public interface IAccountQueriesRepository
    {
        User GetUserByID(int UserId);
        User Validate(Login login); 
       // User Validate(string Email, string Password);
    }
}
