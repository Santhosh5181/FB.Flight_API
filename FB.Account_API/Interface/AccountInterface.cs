using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FB.Account_API.Entities;
using FB.Account_API.Models;

namespace FB.Account_API.Interface
{
    public interface AccountInterface
    {
        void Register(User user);
        User Validate(Login login);
    }
}
