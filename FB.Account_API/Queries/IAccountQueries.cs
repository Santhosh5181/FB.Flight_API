using FB.Account_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FB.Account_API.Queries
{
    public interface IAccountQueries
    {
        User FindByID(int UserId);
    }
}
