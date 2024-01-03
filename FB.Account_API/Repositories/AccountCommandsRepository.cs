using FB.Account_API.Database;
using FB.Account_API.Entities;
using FB.Account_API.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Repositories
{
    public class AccountCommandsRepository : IAccountCommandsRepository
    {
        private readonly FlightDBContext context;

        public AccountCommandsRepository(FlightDBContext context)
        {
            this.context = context;
        }
        public void Register(User user)
        {
            if (user.Email != string.Empty && user.Password != string.Empty)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                throw new UserValidationsException($"Email and Password are mandatory should not be blank");
            }
        }
    }
}
