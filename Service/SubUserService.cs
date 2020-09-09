using Interview.Interface;
using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Service
{
    public class SubUserService : ISubUser
    {
        public Result AddSubUser(subUserDetails inSubUser)
        {
            try
            {
                int? count = 0;
                using (DB_A3E3FF_scampusMaster2020Context db1 = new DB_A3E3FF_scampusMaster2020Context())
                {
                    count = db1.InConfiguration.Where(x => x.ConfId == inSubUser.ConfigId && x.EmpId == inSubUser.EmpId).Select(x => x.UserCount).FirstOrDefault();
                }

                InSubUser inSubUser1 = new InSubUser();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var Bcount = db.InSubUser.Where(x => x.ConfigId == inSubUser.ConfigId && x.EmpId == inSubUser.EmpId).Where(x => x.IsActive == true).Count();
                    if (Bcount < count)
                    {
                        inSubUser1.ConfigId = inSubUser.ConfigId;
                        inSubUser1.EmpId = inSubUser.EmpId;
                        inSubUser1.SubUserName = inSubUser.SubUserName;
                        inSubUser1.CreatedBy = inSubUser.CreatedBy;
                        inSubUser1.CreatedDate = inSubUser.CreatedDate;
                        inSubUser1.EmailId = inSubUser.EmailId;
                        db.InSubUser.Add(inSubUser1);
                        var result = db.SaveChanges();
                        if (result == 1)
                        {
                            return new Result { StatusCode = 1, Message = "Sub User Added successfully..!" };
                        }
                        else
                        {
                            return new Result { StatusCode = -1, Message = "Sub User Failed..!" };
                        }
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Sub User count cannot be more than Configuration Count.!" };
                    }

                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public Result DeleteInSubUser(string id)
        {
            try
            {

                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InSubUser.Where(x => x.Id.ToString() == id).FirstOrDefault();
                    data.IsActive = false;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Sub User Deleted Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Sub User Failed ..!" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public List<InSubUserDetails> GetSubUser()
        {
            try
            {
                List<InSubUserDetails> inSubUserDetails = new List<InSubUserDetails>();
                List<InSubUser> inSubUsers = new DB_A3E3FF_scampus2020Context().InSubUser.ToList();
                List<InUsers> inUsers = new DB_A3E3FF_scampusMaster2020Context().InUsers.ToList();
                List<InConfiguration> inConfigurations = new DB_A3E3FF_scampusMaster2020Context().InConfiguration.ToList();
                //using (DB_A3E3FF_scampus2020Context db = DB_A3E3FF_scampus2020Context())
                //{
                inSubUserDetails = (from b in inSubUsers
                                    from e in inUsers
                                         .Where(x => x.Id == b.EmpId).DefaultIfEmpty()
                                    from c in inConfigurations
                                            .Where(x => x.ConfId == b.ConfigId).DefaultIfEmpty()
                                    select new InSubUserDetails
                                    {
                                        Id = b.Id,
                                        ConfigId = b.ConfigId,
                                        ConfigName = c.Name,
                                        EmpName = e.Username,
                                        EmpId = b.EmpId,
                                        SubUserName = b.SubUserName,
                                        CreatedBy = b.CreatedBy,
                                        CreatedDate = b.CreatedDate,
                                        IsActive = b.IsActive
                                    }).Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();
                return inSubUserDetails;
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
            public Result UpdateSubUser(subUserDetails inSubUser)
        {
            try
            {
                int? count = 0;
                using (DB_A3E3FF_scampusMaster2020Context db1 = new DB_A3E3FF_scampusMaster2020Context())
                {
                    count = db1.InConfiguration.Where(x => x.ConfId == inSubUser.ConfigId && x.EmpId == inSubUser.EmpId).Select(x => x.Branch).FirstOrDefault();
                }

                InBranch inBranch1 = new InBranch();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var Bcount = db.InSubUser.Where(x => x.ConfigId == inSubUser.ConfigId && x.EmpId == inSubUser.EmpId && x.Id != inSubUser.Id).Count();
                    if (Bcount < count)
                    {
                        var data = db.InSubUser.Where(x => x.Id == inSubUser.Id && x.EmpId == inSubUser.EmpId).FirstOrDefault();
                        data.ConfigId = inSubUser.ConfigId;
                        data.SubUserName = inSubUser.SubUserName;
                        data.EmpId = inSubUser.EmpId;
                        data.EmailId = inSubUser.EmailId;
                        data.UpdatedBy = inSubUser.CreatedBy;
                        data.UpdatedDate = inSubUser.CreatedDate;
                        var result = db.SaveChanges();
                        if (result == 1)
                        {
                            return new Result { StatusCode = 1, Message = "Sub User Updated successfully..!" };
                        }
                        else
                        {
                            return new Result { StatusCode = -1, Message = "Sub User Failed..!" };
                        }
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Sub User count cannot be more than Configuration Count.!" };
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
