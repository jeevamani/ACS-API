using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
  public  interface IAuthentication
    {
        public UserCred Authenticate(UserCred userCred);
    }
}
