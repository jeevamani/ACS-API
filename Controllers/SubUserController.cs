using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Interface;
using Interview.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Interview.Controllers
{
    public class SubUserController : Controller
    {
        ISubUser _subUser;
        public SubUserController(ISubUser subUser)
        {
            _subUser = subUser;
        }

        [HttpGet]
        [Route("api/SubUser/GetSubUser")]

        public IActionResult GetSubUser()
        {
            try
            {
                var result = _subUser.GetSubUser();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/SubUser/AddSubUser")]

        public IActionResult AddSubUser([FromBody] PostModel inUsers)
        {
            subUserDetails obj = JsonConvert.DeserializeObject<subUserDetails>(inUsers.Key);
            try
            {
                var result = _subUser.AddSubUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/SubUser/UpdateSubUser")]

        public IActionResult UpdateSubUser([FromBody] PostModel inUsers)
        {
            subUserDetails obj = JsonConvert.DeserializeObject<subUserDetails>(inUsers.Key);
            try
            {
                var result = _subUser.UpdateSubUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/SubUser/DeleteSubUser")]

        public IActionResult DeleteSubUser(string Id)
        {
            try
            {
                var result = _subUser.DeleteInSubUser(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}