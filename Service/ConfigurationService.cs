using Interview.Interface;
using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Service
{
    public class ConfigurationService : IConfigurationss
    {
        public Result AddConfiguration(ConfigurationDetail inConfiguration)
        {
            try
            {
                InConfiguration inConfiguration1 = new InConfiguration();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    inConfiguration1.EmpId = inConfiguration.EmpId;
                    inConfiguration1.Name = inConfiguration.Name;
                    inConfiguration1.Branch = inConfiguration.Branch;
                    inConfiguration1.UserCount = inConfiguration.UserCount;
                    inConfiguration1.CreatedBy = "Admin";
                    inConfiguration1.CreatedDate = DateTime.Now;

                    db.InConfiguration.Add(inConfiguration1);
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Configuration Added Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Configuration Failed ..!" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result AddConfigurationMaster(ConfigurationMaster configurationMaster)
        {
            try
            {
                ConfigurationMaster configurationMaster1 = new ConfigurationMaster();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    configurationMaster1.ConfigName = configurationMaster.ConfigName;
                    configurationMaster1.NoOfBranches = configurationMaster.NoOfBranches;
                    configurationMaster1.NoOfStaff = configurationMaster.NoOfStaff;
                    configurationMaster1.NoOfStudent = configurationMaster.NoOfStudent;
                    configurationMaster1.NoOfVideoConferenceDaily = configurationMaster.NoOfVideoConferenceDaily;
                    configurationMaster1.MaxDurationOfConference = configurationMaster.MaxDurationOfConference;
                    configurationMaster1.MaxNoOfVideoRecording = configurationMaster.MaxNoOfVideoRecording;
                    configurationMaster1.MaxParticipantInConference = configurationMaster.MaxParticipantInConference;
                    configurationMaster1.BaseUrl = configurationMaster.BaseUrl;
                    configurationMaster1.BrandLogo = configurationMaster.BrandLogo;
                    configurationMaster1.PageTitle = configurationMaster.PageTitle;
                    configurationMaster1.AccoutExpiryDate = configurationMaster.AccoutExpiryDate;
                    configurationMaster1.BrandName = configurationMaster.BrandName;
                    configurationMaster1.BrandCode = configurationMaster.BrandCode;
                    configurationMaster1.PageTitle = configurationMaster.PageTitle;
                    configurationMaster1.UpdatedBy = configurationMaster.CreatedBy;
                    configurationMaster1.UpdatedDate = configurationMaster.CreatedDate;

                    db.ConfigurationMaster.Add(configurationMaster1);
                    var result = db.SaveChanges();
                    if(result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Added Successfully..!" };
                    } else
                    {
                        return new Result { StatusCode = -1, Message = "Added Failed..!" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result DeleteConfiguration(string Id)
        {
            try
            {

                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.InConfiguration.Where(x => x.ConfId.ToString() == Id).FirstOrDefault();
                    data.IsActive = false;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Configuration Added Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Configuration Failed ..!" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result DeleteConfigurationMaster(string ConfigId)
        {
            try
            {
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.ConfigurationMaster.Where(x => x.ConfigId.ToString() == ConfigId).FirstOrDefault();
                    data.IsActive = false;
                    var result =  db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Configuration Added Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Configuration Failed ..!" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public List<InConfigurationDetails> GetConfiguration()
        {
            try
            {
                List<InConfigurationDetails> inConfigurationDetails = new List<InConfigurationDetails>();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    inConfigurationDetails = (from c in db.InConfiguration
                                              from e in db.InUsers
                                                    .Where(x => x.Id == c.EmpId).DefaultIfEmpty()
                                              select new InConfigurationDetails
                                              {
                                                  name = c.Name,
                                                  ConfId = c.ConfId,
                                                  EmpId = c.EmpId,
                                                  EmpName = e.Username,
                                                  Branch = c.Branch,
                                                  UserCount = c.UserCount,
                                                  CreatedBy = c.CreatedBy,
                                                  CreatedDate = c.CreatedDate,
                                                  IsActive = c.IsActive
                                              }).Where(x=> x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();
                }
                return inConfigurationDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConfigurationMaster> GetConfigurationMasters()
        {
            try
            {
                List<ConfigurationMaster> configurationMasters = new List<ConfigurationMaster>();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    configurationMasters = db.ConfigurationMaster.Where(x => x.IsActive == true).ToList();
                }
                return configurationMasters;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result UpdateConfiguration(ConfigurationDetail inConfiguration)
        {
            try
            {

                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.InConfiguration.Where(x => x.ConfId == inConfiguration.ConfId).FirstOrDefault();
                    data.EmpId = inConfiguration.EmpId;
                    data.Name = inConfiguration.Name;
                    data.Branch = inConfiguration.Branch;
                    data.UserCount = inConfiguration.UserCount;
                    data.UpdatedBy = "Admin";
                    data.UpdatedDate = DateTime.Now;
                    
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Configuration Updated Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Configuration Failed ..!" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result UpdateConfigurationMaster(ConfigurationMaster configurationMaster)
        {
            try
            {

                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.ConfigurationMaster.Where(x => x.ConfigId == configurationMaster.ConfigId).FirstOrDefault();
                    data.ConfigName = configurationMaster.ConfigName;
                    data.NoOfBranches = configurationMaster.NoOfBranches;
                    data.NoOfStaff = configurationMaster.NoOfStaff;
                    data.NoOfStudent = configurationMaster.NoOfStudent;
                    data.NoOfVideoConferenceDaily = configurationMaster.NoOfVideoConferenceDaily;
                    data.MaxDurationOfConference = configurationMaster.MaxDurationOfConference;
                    data.MaxNoOfVideoRecording = configurationMaster.MaxNoOfVideoRecording;
                    data.MaxParticipantInConference = configurationMaster.MaxParticipantInConference;
                    data.BaseUrl = configurationMaster.BaseUrl;
                    data.BrandLogo = configurationMaster.BrandLogo;
                    data.PageTitle = configurationMaster.PageTitle;
                    data.AccoutExpiryDate = configurationMaster.AccoutExpiryDate;
                    data.BrandName = configurationMaster.BrandName;
                    data.BrandCode = configurationMaster.BrandCode;
                    data.PageTitle = configurationMaster.PageTitle;
                    data.UpdatedBy = configurationMaster.CreatedBy;
                    data.UpdatedDate = configurationMaster.CreatedDate;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Configuration Updated Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Configuration Failed ..!" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }
    }
}
