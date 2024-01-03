using FB.Account_API.Database;
using FB.Account_API.Entities;
using FB.Account_API.Exceptions;
using FB.Account_API.Interface;
using FB.Account_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Services
{
    public class AccountService : AccountInterface
    {
        private readonly FlightDBContext context;

        public AccountService(FlightDBContext context)
        {
            this.context = context;
        }
        public void Register(User user)
        {
            if (user.Email != string.Empty && user.Password !=string.Empty)
            {
                //context.Users.Add(user);
                //context.SaveChanges();
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                throw new UserValidationsException($"Email and Password are mandatory should not be blank");
            }


        }

        public User Validate(Login login)
        {
            if (login.Email !=string.Empty && login.Password !=string.Empty)
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
