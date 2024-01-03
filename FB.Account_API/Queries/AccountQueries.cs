using FB.Account_API.Database;
using FB.Account_API.Entities;
using FB.Account_API.Exceptions;
using FB.Account_API.Models;
using FB.Account_API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Queries
{
    public class AccountQueries 
    {
        private readonly IAccountQueriesRepository _repository;
        private readonly FlightDBContext context;

        public AccountQueries(FlightDBContext context)
        {
            this.context = context;
        }
        public AccountQueries(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }
        public User FindByID(int UserId)
        {
            User user = _repository.GetUserByID(UserId);
            return user;
        }


    }
}
