using Interview.Interface;
using Interview.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Service
{
    public class UserService : IUser
    {
        public Result AddAdminUser(AdminUserDetails adminUsers)
        {
            try
            {
                AdminUsers adminUserDetails = new AdminUsers();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    adminUserDetails.Userid =Guid.NewGuid();
                    adminUserDetails.Username = adminUsers.Username;
                    adminUserDetails.Password = adminUsers.Password;
                    adminUserDetails.EmailId = adminUsers.EmailId;
                    adminUserDetails.ConfigSettings = adminUsers.ConfigSettings;
                    adminUserDetails.Status = adminUsers.Status;
                    adminUserDetails.AccountStatus = adminUsers.AccountStatus;
                    adminUserDetails.CreatedBy = adminUsers.CreatedBy;
                    adminUserDetails.CreatedDate = adminUsers.CreatedDate;
                    adminUserDetails.UpdatedBy = adminUsers.UpdatedBy;
                    adminUserDetails.UpdatedDate = adminUsers.UpdatedDate;
                    adminUserDetails.Role = adminUsers.Role;
                    adminUserDetails.Baseurl = adminUsers.Baseurl;
                    adminUserDetails.CreatedById = adminUsers.CreatedById;
                    db.AdminUsers.Add(adminUserDetails);
                    var result =  db.SaveChanges();
                    if(result == 1)
                    {
                        return new Result { StatusCode = 1, Message= "Added Successdully..!" };
                    } else
                    {
                        return new Result { StatusCode = -1, Message = "Adding Failed..!" };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result AddUser(userDetails inUsers)
        {
            try
            {
                InUsers inUsers1 = new InUsers();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    inUsers1.Username = inUsers.Username;
                    inUsers1.Password = inUsers.Password;
                    inUsers1.Role = inUsers.Role;
                    inUsers1.CreatedBy = inUsers.CreatedBy;
                    inUsers1.CreatedById = inUsers.CreatedById;
                    inUsers1.EmailId = inUsers.EmailId;
                    inUsers1.AccountStatus = inUsers.AccountStatus;
                    inUsers1.CreatedDate = DateTime.Now;
                    inUsers1.Configuration = inUsers.ConfiguratoinId;
                    inUsers1.BaseUrl = inUsers1.BaseUrl;
                    db.InUsers.Add(inUsers1);
                 var result =   db.SaveChanges();
                    if(result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "User Added Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "User Failed ..!"};
                    }
                }
               
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result DeleteAdminUser(string Id)
        {
            using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
            {
                var data = db.AdminUsers.Where(x => x.Userid.ToString() == Id).FirstOrDefault();
                data.Status = false;
                var result =  db.SaveChanges();
                if (result == 1)
                {
                    return new Result { StatusCode = 1, Message = "User Deleted Successfully ..!" };
                }
                else
                {
                    return new Result { StatusCode = -1, Message = "User Deleting Failed ..!" };
                }
            }
        }

        public Result DeleteUpload(string Id)
        {
            try
            {
                int result = 0;
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InFileUpload.Where(x => x.UploadId.ToString() == Id).FirstOrDefault();
                    data.IsActive = false;
                     result = db.SaveChanges();
                }
                if (result == 1)
                {
                    return new Result { StatusCode = 1, Message = "File Deleted Successfully ..!" };
                }
                else
                {
                    return new Result { StatusCode = -1, Message = "File Deleting Failed ..!" };
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result DeleteUser(string Id)
        {
            try
            {
               
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.InUsers.Where(x => x.Id.ToString() == Id).FirstOrDefault();
                    data.IsActive = false;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "User Deleted Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "User Deleting Failed ..!" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public List<InFileUpload> EditFileUpload(string Id)
        {
            try
            {
                List<InFileUpload> inFileUploads = new List<InFileUpload>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inFileUploads = db.InFileUpload.Where(x => x.UserId.ToString() == Id).Where(x => x.IsActive == true).ToList();
                }
                return inFileUploads;
            }
            catch (Exception ex)
            {
               
                throw;
            }
        }

        public List<AdminUserDetails> GetAdminUsers(string role)
        {
            try
            {
                List<AdminUserDetails> adminUsers = new List<AdminUserDetails>();
                List<ConfigurationMaster> configurationMasters = new DB_A3E3FF_scampusMaster2020Context().ConfigurationMaster.Where(x=> x.IsActive == true).ToList();
                List<AdminUsers> adminUsers1 = new DB_A3E3FF_scampus2020Context().AdminUsers.Where(x=> x.Status == true).ToList();
                List<InUsers> inUsers = new DB_A3E3FF_scampusMaster2020Context().InUsers.Where(x => x.IsActive == true).ToList();
                List<AdminUserDetails> user = new List<AdminUserDetails>(); //DB_A3E3FF_scampus2020Context().AdminUsers.Where(x => x.Role == "Admin" && x.Status == true).ToList();

                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    user = (from a in adminUsers1
                            from c in configurationMasters
                                 .Where(x => x.ConfigId == a.ConfigSettings).DefaultIfEmpty()
                            select new AdminUserDetails
                            {
                                Userid = a.Userid,
                                Username = a.Username,
                                Password = a.Password,
                                EmailId = a.EmailId,
                                ConfigSettings = a.ConfigSettings,
                                ConfigName = c.ConfigName,
                                Role = a.Role,
                                Status = a.Status,
                                AccountStatus = a.AccountStatus,
                                CreatedBy = a.CreatedBy,
                                CreatedDate = a.CreatedDate
                            }).Where(x => x.Status == true && x.Role == "Admin").ToList();
                }
                if (role == "Super Admin")
                {
                    adminUsers = (from a in inUsers
                                  from c in configurationMasters
                                            .Where(x => x.ConfigId == a.Configuration).DefaultIfEmpty()
                                  select new AdminUserDetails
                                  {
                                      Userid = a.Id,
                                      Username = a.Username,
                                      Password = a.Password,
                                      EmailId = a.EmailId,
                                      ConfigSettings = a.Configuration,
                                      ConfigName = c.ConfigName,
                                      Status = a.IsActive,
                                      Role = a.Role,
                                      Baseurl = a.BaseUrl,
                                      AccountStatus = a.AccountStatus,
                                      CreatedBy = a.CreatedBy,
                                      CreatedDate = a.CreatedDate
                                  }).OrderByDescending(x => x.CreatedDate).Where(x => x.Status == true).ToList();

                    adminUsers.AddRange(user);
                } else if (role == "Admin")
                {
                    adminUsers = (from a in adminUsers1
                                  from c in configurationMasters
                                            .Where(x => x.ConfigId == a.ConfigSettings).DefaultIfEmpty()
                                  select new AdminUserDetails
                                  {
                                      Userid = a.Userid,
                                      Username = a.Username,
                                      Password = a.Password,
                                      EmailId = a.EmailId,
                                      ConfigSettings = a.ConfigSettings,
                                      ConfigName = c.ConfigName,
                                      Status = a.Status,
                                      Role = a.Role,
                                      Baseurl = a.Baseurl,
                                      AccountStatus = a.AccountStatus,
                                      CreatedBy = a.CreatedBy,
                                      CreatedDate = a.CreatedDate
                                  }).OrderByDescending(x => x.CreatedDate).Where(x => x.Status == true).ToList();
                }
                //adminUsers = (from a in adminUsers1
                //              from c in configurationMasters
                //                        .Where(x => x.ConfigId == a.ConfigSettings).DefaultIfEmpty()
                //                  select new AdminUserDetails
                //                  {
                //                      Userid = a.Userid,
                //                      Username = a.Username,
                //                      Password = a.Password,
                //                      EmailId = a.EmailId,
                //                      ConfigSettings = a.ConfigSettings,
                //                      ConfigName = c.ConfigName,
                //                      Status = a.Status,
                //                      AccountStatus = a.AccountStatus,
                //                      CreatedBy = a.CreatedBy,
                //                      CreatedDate = a.CreatedDate
                //                  }).OrderByDescending(x => x.CreatedDate).Where(x => x.Status == true).ToList();
               // }
                return adminUsers;
            }
            catch (Exception ex)
            {
                    
                throw ex;
            }
        }

        public List<configDDL> GetConfigurationDDl()
        {
            try
            {
                List<configDDL> configDDLs = new List<configDDL>();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    configDDLs = db.ConfigurationMaster.Where(x => x.IsActive == true).Select(x=> new configDDL { 
                    configName = x.ConfigName,
                    configId = x.ConfigId
                    }).ToList();
                }
                return configDDLs;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InDepartment> GetDepartments()
        {
            try
            {
                List<InDepartment> inDepartments = new List<InDepartment>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inDepartments = db.InDepartment.Where(x => x.IsActive == true).ToList();
                }
                return inDepartments;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InDesignation> GetInDesignations()
        {
            try
            {
                List<InDesignation> inDesignations = new List<InDesignation>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inDesignations = db.InDesignation.Where(x => x.IsActive == true).ToList();
                }
                return inDesignations;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InUserRole> GetUserRoles()
        {
            try
            {
                List<InUserRole> inUserRoles = new List<InUserRole>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inUserRoles = db.InUserRole.Where(x => x.IsActive == true).ToList();
                }
                return inUserRoles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InUsers> GetUsers()
        {
            try
            {
                List<InUsers> inUsers = new List<InUsers>();
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    inUsers = db.InUsers.Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();
                    return inUsers;
                }
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result Login(string username, string password, bool? Role, string baseusrl)
        {
            try
            {
                if(Role == true) { 
                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.InUsers.Where(x => x.Username == username && x.Password == password && x.BaseUrl == baseusrl && x.IsActive == true ).FirstOrDefault();

                    if(data != null)
                    {
                        var  confdata  = db.ConfigurationMaster.Where(x => x.ConfigId.ToString() == data.Configuration.ToString() && x.IsActive == true).FirstOrDefault();
                           if(confdata != null)
                            {
                                return new Result { StatusCode = 1, Message = "Login success ..!" };
                            } else
                            {
                                return new Result { StatusCode = -1, Message = "Login Failed" };
                            }
                           
                    } else
                    {
                        return new Result { StatusCode = -1, Message = "Login Failed" };
                    }
                }
                } else
                {
                    List<ConfigurationMaster> configurationMaster = new DB_A3E3FF_scampusMaster2020Context().ConfigurationMaster.Where(x => x.IsActive == true).ToList();
                    using (DB_A3E3FF_scampus2020Context db1 =new DB_A3E3FF_scampus2020Context())
                    {
                        var data = db1.AdminUsers.Where(x => x.Username == username && x.Password == password && x.Baseurl ==baseusrl && x.Status == true).FirstOrDefault();
                        if (data != null)
                        {
                            var confdata = configurationMaster.Where(x => x.ConfigId.ToString() == data.ConfigSettings.ToString() && x.IsActive == true).FirstOrDefault();
                            if (confdata != null)
                            {
                                return new Result { StatusCode = 1, Message = "Login success ..!" };
                            }
                            else
                            {
                                return new Result { StatusCode = -1, Message = "Login Failed" };
                            }
                        }
                        else
                        {
                            return new Result { StatusCode = -1, Message = "Login Failed" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message};
                throw ex;
            }
        }

        public Result SaveFileUpload(string key)
        {
            try
            {
                int result = 0;
                FileUpload obj = JsonConvert.DeserializeObject<FileUpload>(key);
                InFileUpload inFileUpload = new InFileUpload();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InFileUpload.Where(x => x.FileName == obj.FileName && x.FileType == obj.FileType).FirstOrDefault();
                    if(data == null) { 
                    inFileUpload.UserId = obj.UserID;
                    inFileUpload.FileName = obj.FileName;
                    inFileUpload.FileTitle = obj.FileTitle;
                    inFileUpload.FileType = obj.FileType;
                    inFileUpload.CreatedBy = obj.CreatedBy;
                    db.InFileUpload.Add(inFileUpload);
                    result = db.SaveChanges();
                    if(result ==1)
                    {
                        return new Result { Message = "File Uploaded Successfully..!", StatusCode = 1 };
                    } else
                    {
                        return new Result { Message = "File Uploading Failed..!", StatusCode = -1 };
                    }
                    } else
                    {
                        return new Result { Message = "File Already Exists..!", StatusCode = -1 };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result UpdateAdminUser(AdminUsers adminUsers)
        {
            try
            {
                
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.AdminUsers.Where(x => x.Userid == adminUsers.Userid).FirstOrDefault();
                    data.Username  = adminUsers.Username;
                    data.Password = adminUsers.Password;
                    data.EmailId = adminUsers.EmailId;
                    data.UpdatedBy = adminUsers.CreatedBy;
                    data.UpdatedDate = adminUsers.CreatedDate;
                    data.AccountStatus = adminUsers.AccountStatus;
                    data.CreatedById = adminUsers.CreatedById;
                    data.ConfigSettings = adminUsers.ConfigSettings;
                    data.Baseurl = adminUsers.Baseurl;
                    data.Role = adminUsers.Role;
                    var reuslt =  db.SaveChanges();

                    if (data != null)
                    {
                        return new Result { StatusCode = 1, Message = "Admin user updated successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Admin user Updating  Failed ..!" };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result UpdateUser(userDetails inUsers)
        {
            try
            {

                using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
                {
                    var data = db.InUsers.Where(x => x.Id == inUsers.Id).FirstOrDefault();
                    data.Username = inUsers.Username;
                    data.Password = inUsers.Password;
                    data.EmailId = inUsers.EmailId;
                    data.Configuration = inUsers.ConfiguratoinId;
                    data.AccountStatus = inUsers.AccountStatus;
                    data.Role = inUsers.Role;
                    data.CreatedById = inUsers.CreatedById;
                    data.UpdatedBy = "Admin";
                    data.UpdatedDate = DateTime.Now;
                    data.BaseUrl = inUsers.BaseUrl;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "User Updated Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "User Failed ..!" };
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
