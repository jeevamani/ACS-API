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
    public class BranchController : Controller
    {
        IBranch _branch;
        IStaff _IStaff;
        public BranchController(IBranch branch, IStaff staff)
        {
            _branch = branch;
            _IStaff = staff;
        }


        
        [HttpGet]
        [Route("api/Branch/GetBranch")]

        public IActionResult GetBranch()
        {
            try
            {
                var result = _branch.GetBranch();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Branch/AddBranch")]

        public IActionResult AddBranch([FromBody] PostModel inUsers)
        {
            InBranchDetails obj = JsonConvert.DeserializeObject<InBranchDetails>(inUsers.Key);
            try
            {
                var result = _branch.AddBranch(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Branch/UpdateBranch")]

        public IActionResult UpdateBranch([FromBody] PostModel inUsers)
        {
            InBranchDetails obj = JsonConvert.DeserializeObject<InBranchDetails>(inUsers.Key);
            try
            {
                var result = _branch.UpdateBranch(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw  ex;
            }
        }

        [HttpGet]
        [Route("api/Branch/GetState")]
        public IActionResult GetState()
        {
            try
            {
                var result = _branch.GetState();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("api/Branch/DeleteBranch")]

        public IActionResult DeleteBranch(string Id)
        {
            try
            {
                var result = _branch.DeleteBranch(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}