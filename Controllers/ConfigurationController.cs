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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Super Admin")]
    public class ConfigurationController : Controller
    {
        IConfigurationss _configurationss;
        public ConfigurationController(IConfigurationss configurationss)
        {
            _configurationss = configurationss;
        }

        [HttpGet]
        [Route("api/Configuration/GetConfiguration")]

        public IActionResult GetConfiguration()
        {
            try
            {
                var result = _configurationss.GetConfiguration();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Configuration/GetConfigurationMasters")]

        public IActionResult GetConfigurationMasters()
        {
            try
            {
                var result = _configurationss.GetConfigurationMasters();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("api/Configuration/AddConfiguration")]

        public IActionResult AddUser([FromBody] PostModel inconfig)
        {
            ConfigurationDetail obj = JsonConvert.DeserializeObject<ConfigurationDetail>(inconfig.Key);
            try
            {
                var result = _configurationss.AddConfiguration(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Configuration/UpdateConfiguration")]

        public IActionResult UpdateConfiguration([FromBody] PostModel inUsers)
        {
            ConfigurationDetail obj = JsonConvert.DeserializeObject<ConfigurationDetail>(inUsers.Key);
            try
            {
                var result = _configurationss.UpdateConfiguration(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Configuration/DeleteConfiguration")]

        public IActionResult DeleteConfiguration(string Id)
        {
            try
            {
                var result = _configurationss.DeleteConfiguration(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Configuration/AddConfigurationMaster")]

        public IActionResult AddConfigurationMaster([FromBody] PostModel inconfig)
        {
            ConfigurationMaster obj = JsonConvert.DeserializeObject<ConfigurationMaster>(inconfig.Key);
            try
            {
                var result = _configurationss.AddConfigurationMaster(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("api/Configuration/UpdateConfigurationMaster")]

        public IActionResult UpdateConfigurationMaster([FromBody] PostModel inUsers)
        {
            ConfigurationMaster obj = JsonConvert.DeserializeObject<ConfigurationMaster>(inUsers.Key);
            try
            {
                var result = _configurationss.UpdateConfigurationMaster(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/Configuration/DeleteConfigurationMaster")]

        public IActionResult DeleteConfigurationMaster(string Id)
        {
            try
            {
                var result = _configurationss.DeleteConfigurationMaster(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}