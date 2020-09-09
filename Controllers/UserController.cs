using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Interview.Interface;
using Interview.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Interview.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        IUser _IUser;
        public UserController(IUser user)
        {
            _IUser = user;
        }

        [HttpPost]
        [Route("api/User/login")]

        public IActionResult Login([FromBody] PostModel inUsers)
        {
            try
            {
                Login obj = JsonConvert.DeserializeObject<Login>(inUsers.Key);
                var result = _IUser.Login(obj.username, obj.password, obj.IsSuperAdmin, obj.baseUrl);
               return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/GetDepartment")]
        public IActionResult GetDepartment()
        {
            try
            {
                var result = _IUser.GetDepartments();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("api/GetInDesignations")]
        public IActionResult GetInDesignations()
        {
            try
            {
                var result = _IUser.GetInDesignations();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/GetUserRoles")]
        public IActionResult GetUserRoles()
        {
            try
            {
                var result = _IUser.GetUserRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("api/upload")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public IActionResult UploadFiles([FromForm]IFormFile file, string foldername)
        {
            Result objstatus = new Result();
            if (!string.IsNullOrEmpty(file.FileName))
            {
                var filename = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles",foldername, file.FileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            objstatus.StatusCode = 1;
            objstatus.Message = "Successfully Uploaded";


            return (ActionResult)Ok(objstatus);
        }

        [HttpGet]
        [Route("api/User/AdminUser")]

        public IActionResult AdminUser(string role)
        {
            try
            {
                var result =  _IUser.GetAdminUsers(role);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpGet]
        [Route("api/User/GetUser")]

        public IActionResult GetUser()
        {
            try
            {
                var result = _IUser.GetUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/User/GetAdminUser")]

        public IActionResult GetAdminUser(string role)
        {
            try
            {
                var result = _IUser.GetAdminUsers(role);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/User/GetConfigurationDDl")]

        public IActionResult GetConfigurationDDl()
        {
            try
            {
                var result = _IUser.GetConfigurationDDl();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/User/DeleteFileUpload")]

        public IActionResult DeleteFileUpload(string Id)
        {
            try
            {
                var result = _IUser.DeleteUpload(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/User/EditFileUpload")]

        public IActionResult EditFileUpload(string Id)
        {
            try
            {
                var result = _IUser.EditFileUpload(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("api/User/AddUser")]

        public IActionResult AddUser([FromBody] PostModel inUsers)
        {
            userDetails obj = JsonConvert.DeserializeObject<userDetails>(inUsers.Key);
            try
            {
                var result = _IUser.AddUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/User/FileUploadData")]
        public IActionResult FileUploadData([FromBody] PostModel inUsers)
        {   
            
            try
            {
                var result = _IUser.SaveFileUpload(inUsers.Key);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/User/AddAdminUser")]

        public IActionResult AddAdminUser([FromBody] PostModel inUsers)
        {
            AdminUserDetails obj = JsonConvert.DeserializeObject<AdminUserDetails>(inUsers.Key);
            try
            {
                var result = _IUser.AddAdminUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/User/UpdateUser")]

        public IActionResult UpdateUser([FromBody] PostModel inUsers)
        {
            userDetails obj = JsonConvert.DeserializeObject<userDetails>(inUsers.Key);
            try
            {
                var result = _IUser.UpdateUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/User/UpdateAdminUser")]

        public IActionResult UpdateAdminUser([FromBody] PostModel inUsers)
        {
            AdminUsers obj = JsonConvert.DeserializeObject<AdminUsers>(inUsers.Key);
            try
            {
                var result = _IUser.UpdateAdminUser(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("api/User/DeleteUser")]

        public IActionResult DeleteUser(string Id)
        {
            try
            {
                var result = _IUser.DeleteUser(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/User/DeleteAdminUser")]

        public IActionResult DeleteAdminUser(string Id)
        {
            try
            {
                var result = _IUser.DeleteAdminUser(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}