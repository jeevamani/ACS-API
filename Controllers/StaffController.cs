using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Interface;
using Interview.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Interview.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class StaffController : Controller
    {
        IStaff _IStaff;
        public StaffController(IStaff staff)
        {
            _IStaff = staff;
        }

        [HttpGet]
        [Route("api/Staff/GetStaff")]
        public IActionResult GetStaff()
        {
            try
            {
                var result = _IStaff.GetInStaffs();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("api/Staff/AddStaff")]
        public IActionResult AddStaff([FromBody] PostModel inStaff)
        {
            StaffDetails obj = JsonConvert.DeserializeObject<StaffDetails>(inStaff.Key);
            try
            {
                var result = _IStaff.AddStaff(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Staff/UpdateStaff")]
        public IActionResult UpdateStaff([FromBody] PostModel inUsers)
        {
            StaffDetails obj = JsonConvert.DeserializeObject<StaffDetails>(inUsers.Key);
            try
            {
                var result = _IStaff.UpdateStaff(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Staff/DeleteStaff")]
        public IActionResult DeleteStaff(string Id)
        {
            try
            {
                var result = _IStaff.DeleteStaff(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}