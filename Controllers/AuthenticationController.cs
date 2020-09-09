using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Interface;
using Interview.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class AuthenticationController : Controller
    {
        IAuthentication _authentication;
        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpPost]
        [Route("api/Authentication")]
        public IActionResult UserAuth([FromBody] UserCred userCred)
        {
            var user = _authentication.Authenticate(userCred);
           
           return Ok(user);
        }
    }
}