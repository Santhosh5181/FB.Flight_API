using FB.Account_API.Database;
using FB.Account_API.Entities;
using FB.Account_API.Exceptions;
using FB.Account_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Repositories
{
    public class AccountQueriesRepository : IAccountQueriesRepository
    {
        private readonly FlightDBContext context;

        public AccountQueriesRepository()
        {
        }

        public AccountQueriesRepository(FlightDBContext context)
        {
            this.context = context;
        }
        public User GetUserByID(int UserId)
        {
            User user = context.Users.FirstOrDefault(i => i.UserId == UserId);
            return user;
        }

        public User Validate(Login login)
        //public User Validate(string Email, string Password)
        {
            if (login.Email != string.Empty && login.Password != string.Empty)
            {
                User user = context.Users.SingleOrDefault(item => item.Email == login.Email && item.Password == login.Password);
                return user;
            }
            else
            {
                throw new UserValidationsException($"Email and Password are mandatory should not be blank");
            }

        }
    }
}
