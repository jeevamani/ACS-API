using Interview.Interface;
using Interview.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Service
{
    public class BranchService : IBranch
    {
        public Result AddBranch(InBranchDetails inBranch)
        {
            try
            {
                int? count = 0;
                using (DB_A3E3FF_scampusMaster2020Context db1 = new DB_A3E3FF_scampusMaster2020Context())
                {
                    count = db1.ConfigurationMaster.Where(x => x.ConfigId == inBranch.ConfigId).Select(x=>x.NoOfBranches).FirstOrDefault();
                }

                InBranch inBranch1 = new InBranch();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var Bcount = db.InBranch.Where(x => x.ConfigId == inBranch.ConfigId && x.EmpId == inBranch.EmpId && x.BranchId != inBranch.BranchId).Where(x=> x.IsActive == true).Count();
                    if(Bcount < count)
                    {
                        inBranch1.BranchName = inBranch.BranchName;
                        inBranch1.Location = inBranch.Location;
                        inBranch1.Address = inBranch.Address;
                        inBranch1.ContactNumber1 = inBranch.ContactNumber1;
                        inBranch1.ContactNumber2 = inBranch.ContactNumber2;
                        inBranch1.Email = inBranch.Email;
                        inBranch1.ContactPerson = inBranch.ContactPerson;
                        inBranch1.BranchCode = inBranch.BranchCode;
                        inBranch1.Gstin = inBranch.Gstin;
                        inBranch1.State = inBranch.State;
                        inBranch1.District = inBranch.District;
                        inBranch1.Smsapiurl = inBranch.Smsapiurl;
                        inBranch1.Apikey = inBranch.Apikey;
                        inBranch1.SenderId = inBranch.SenderId;
                        inBranch1.BranchLogo = inBranch.BranchLogo;
                        inBranch1.PrintHeaderFile = inBranch.PrintHeaderFile;
                        inBranch1.PrintFooterFile = inBranch.PrintFooterFile;
                        inBranch1.CreatedBy = inBranch.CreatedBy;
                        inBranch1.CreatedDate = inBranch.CreatedDate;
                        inBranch1.EmpId = inBranch.EmpId;
                        inBranch1.ConfigId = inBranch.ConfigId;
                        db.InBranch.Add(inBranch1);
                      var result =   db.SaveChanges();
                        if(result == 1)
                        {
                            return new Result { StatusCode = 1, Message = "Branch Added successfully..!" };
                        } else
                        {
                            return new Result { StatusCode = -1, Message = "Branch Failed..!" };
                        }
                    } else
                    {
                        return new Result { StatusCode = -1, Message = "Branch count cannot be more than Configuration Count.!" };
                    }

                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message};
                throw ex;
            }
        }

        public Result DeleteBranch(string id)
        {
            try
            {

                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InBranch.Where(x => x.BranchId.ToString() == id).FirstOrDefault();
                    data.IsActive = false;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Branch Deleted Successfully ..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Branch Failed ..!" };
                    }
                }

            }
            catch (Exception ex)
            {
                return new Result { StatusCode = -1, Message = ex.Message };
                throw ex;
            }
        }

        public List<InBranchDetails> GetBranch()
        {
            try
            {
                List<InBranchDetails> inBranchDetails = new List<InBranchDetails>();
                List<InBranch> inBranches = new DB_A3E3FF_scampus2020Context().InBranch.ToList();
                List<user> inUsers = new DB_A3E3FF_scampusMaster2020Context().InUsers.Where(x=> x.IsActive == true).Select(x=> new user { 
                EmpId = x.Id,
                EmpName = x.Username
                }).ToList();
                List<user> inusers1 = new DB_A3E3FF_scampus2020Context().AdminUsers.Where(x=> x.Status == true).Select(x=> new user { 
                    EmpId = x.Userid,
                    EmpName = x.Username
                }).ToList();
                inUsers.AddRange(inusers1);
                List<ConfigurationMaster> inConfigurations = new DB_A3E3FF_scampusMaster2020Context().ConfigurationMaster.ToList();
                //using (DB_A3E3FF_scampus2020Context db = DB_A3E3FF_scampus2020Context())
                //{
                inBranchDetails = (from b in inBranches
                                   from e in inUsers
                                         .Where(x => x.EmpId == b.EmpId).DefaultIfEmpty()
                                   from c in inConfigurations
                                           .Where(x => x.ConfigId == b.ConfigId).DefaultIfEmpty()
                                   select new InBranchDetails
                                   {
                                       BranchId = b.BranchId,
                                       BranchName = b.BranchName,
                                       Location = b.Location,
                                       Address = b.Address,
                                       ContactNumber1 = b.ContactNumber1,
                                       ContactNumber2 = b.ContactNumber2,
                                       Email = b.Email,
                                       ContactPerson = b.ContactPerson,
                                       BranchCode = b.BranchCode,
                                       Gstin = b.Gstin,
                                       State = b.State,
                                       District = b.District,
                                       Smsapiurl = b.Smsapiurl,
                                       Apikey = b.Apikey,
                                       SenderId = b.SenderId,
                                       BranchLogo = b.BranchLogo,
                                       PrintHeaderFile = b.PrintHeaderFile,
                                       PrintFooterFile = b.PrintFooterFile,
                                       ConfigId = b.ConfigId,
                                       EmpName = e.EmpName,
                                       EmpId = b.EmpId,
                                       ConfigName = c.ConfigName,
                                       CreatedBy = b.CreatedBy,
                                       CreatedDate = b.CreatedDate,
                                       IsActive = b.IsActive
                                   }).Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();
                return inBranchDetails;
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InState> GetState()
        {
            try
            {
                List<InState> inStates = new List<InState>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inStates = db.InState.ToList();
                }
                return inStates;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result UpdateBranch(InBranchDetails inBranch)
        {
            try
            {
                int? count = 0;
                using (DB_A3E3FF_scampusMaster2020Context db1 = new DB_A3E3FF_scampusMaster2020Context())
                {
                    count = db1.ConfigurationMaster.Where(x => x.ConfigId == inBranch.ConfigId ).Select (x=> x.NoOfBranches).FirstOrDefault();
                }

                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var Bcount = db.InBranch.Where(x => x.ConfigId == inBranch.ConfigId && x.EmpId == inBranch.EmpId).Count();
                    //if (Bcount < count)
                    //{
                        var inBranch1 = db.InBranch.Where(x => x.BranchId == inBranch.BranchId && x.EmpId == inBranch.EmpId).FirstOrDefault();
                        inBranch1.BranchName = inBranch.BranchName;
                        inBranch1.Location = inBranch.Location;
                        inBranch1.Address = inBranch.Address;
                        inBranch1.ContactNumber1 = inBranch.ContactNumber1;
                        inBranch1.ContactNumber2 = inBranch.ContactNumber2;
                        inBranch1.Email = inBranch.Email;
                        inBranch1.ContactPerson = inBranch.ContactPerson;
                        inBranch1.BranchCode = inBranch.BranchCode;
                        inBranch1.Gstin = inBranch.Gstin;
                        inBranch1.State = inBranch.State;
                        inBranch1.District = inBranch.District;
                        inBranch1.Smsapiurl = inBranch.Smsapiurl;
                        inBranch1.Apikey = inBranch.Apikey;
                        inBranch1.SenderId = inBranch.SenderId;
                        inBranch1.BranchLogo = inBranch.BranchLogo;
                        inBranch1.PrintHeaderFile = inBranch.PrintHeaderFile;
                        inBranch1.PrintFooterFile = inBranch.PrintFooterFile;
                        inBranch1.UpdatedBy = inBranch.CreatedBy;
                        inBranch1.UpdatedDate = inBranch.CreatedDate;
                        inBranch1.EmpId = inBranch.EmpId;
                        inBranch1.ConfigId = inBranch.ConfigId;
                        var result = db.SaveChanges();
                        if (result == 1)
                        {
                            return new Result { StatusCode = 1, Message = "Branch Updated successfully..!" };
                        }
                        else
                        {
                            return new Result { StatusCode = -1, Message = "Branch Failed..!" };
                        }
                    //}
                    //else
                    //{
                    //    return new Result { StatusCode = -1, Message = "Branch count cannot be more than Configuration Count.!" };
                    //}

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
