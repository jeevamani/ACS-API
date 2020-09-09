using Interview.Interface;
using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Service
{
    public class StaffService : IStaff
    {
        public Result AddStaff(StaffDetails inStaff)
        {
            try
            {
                InStaff inStaff1 = new InStaff();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    inStaff1.Name = inStaff.Name;
                    inStaff1.Dob = inStaff.Dob;
                    inStaff1.Gender = inStaff.Gender;
                    inStaff1.Address = inStaff.Address;
                    inStaff1.ContactNumber = inStaff.ContactNumber;
                    inStaff1.MobileNumber = inStaff.MobileNumber;
                    inStaff1.HomeContactNumber = inStaff.HomeContactNumber;
                    inStaff1.ContactPerson = inStaff.ContactPerson;
                    inStaff1.BloodGroup = inStaff.BloodGroup;
                    inStaff1.PersonalEmail = inStaff.PersonalEmail;
                    inStaff1.Designation = inStaff.Designation;
                    inStaff1.JoiningDate = inStaff.JoiningDate;
                    inStaff1.Salary = inStaff.Salary;
                    inStaff1.Experience = inStaff.Experience;
                    inStaff1.BranchId = inStaff.BranchId;
                    inStaff1.Department = inStaff.Department;
                    inStaff1.PreviousCompany = inStaff.PreviousCompany;
                    inStaff1.UserName = inStaff.UserName;
                    inStaff1.Password = inStaff.Password;
                    inStaff1.IdcardType = inStaff.IdcardType;
                    inStaff1.Idnumber = inStaff.Idnumber;
                    inStaff1.UploadId = inStaff.UploadId;
                    inStaff1.CertificateTitle = inStaff.CertificateTitle;
                    inStaff1.UserRole = inStaff.UserRole;
                    inStaff1.CreatedBy = inStaff.CreatedBy;
                    inStaff1.CreatedDate = inStaff.CreatedDate;
                    db.InStaff.Add(inStaff1);
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Staff Added Successfully..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Staff Adding Failed..!" };
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result DeleteStaff(string Id)
        {
            try
            {
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InStaff.Where(x => x.StaffId.ToString() == Id.ToString()).FirstOrDefault();
                    data.IsActive = false;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Staff Added Successfully..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Staff Adding Failed..!" };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<StaffDetails> GetInStaffs()
        {
            try
            {
                List<StaffDetails> staffDetails = new List<StaffDetails>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    staffDetails = (from s in db.InStaff
                                    from c in db.InDesignation
                                         .Where(x => x.DesignationId.ToString() == s.Designation).DefaultIfEmpty()
                                    from d in db.InDepartment
                                         .Where(x => x.DeptId.ToString() == s.Department).DefaultIfEmpty()
                                    from u in db.InUserRole
                                         .Where(x => x.RoleId.ToString() == s.UserRole).DefaultIfEmpty()
                                    from b in db.InBranch
                                         .Where(x => x.BranchId.ToString() == s.BranchId.ToString()).DefaultIfEmpty()
                                    select new StaffDetails
                                    {
                                        StaffId = s.StaffId,
                                        Name = s.Name,
                                        Dob = s.Dob,
                                        Gender = s.Gender,
                                        Address = s.Address,
                                        ContactNumber = s.ContactNumber,
                                        MobileNumber = s.MobileNumber,
                                        HomeContactNumber = s.HomeContactNumber,
                                        ContactPerson = s.ContactPerson,
                                        BloodGroup = s.BloodGroup,
                                        PersonalEmail = s.PersonalEmail,
                                        Designation = s.Designation,
                                        DesignationName = c.Name,
                                        JoiningDate = s.JoiningDate,
                                        Salary = s.Salary,
                                        Experience = s.Experience,
                                        BranchId = s.BranchId,
                                        BranchName = b.BranchName,
                                        Department = s.Department,
                                        DeaprtmentName = d.Name,
                                        PreviousCompany = s.PreviousCompany,
                                        UserName = s.UserName,
                                        Password = s.Password,
                                        IdcardType = s.IdcardType,
                                        Idnumber = s.Idnumber,
                                        UploadId = s.UploadId,
                                        CertificateTitle = s.CertificateTitle,
                                        UserRole = s.UserRole,
                                        IsActive = s.IsActive,
                                        CreatedDate = s.CreatedDate,
                                        UserRoleName = u.Name,
                                        UpdatedBy = s.CreatedBy,
                                        UpdatedDate = s.CreatedDate
                                    }).Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();

                }

                return staffDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result UpdateStaff(StaffDetails inStaff)
        {
            try
            {
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.InStaff.Where(x => x.StaffId == inStaff.StaffId).FirstOrDefault();
                    data.Name = inStaff.Name;
                    data.Dob = inStaff.Dob;
                    data.Gender = inStaff.Gender;
                    data.Address = inStaff.Address;
                    data.ContactNumber = inStaff.ContactNumber;
                    data.MobileNumber = inStaff.MobileNumber;
                    data.HomeContactNumber = inStaff.HomeContactNumber;
                    data.ContactPerson = inStaff.ContactPerson;
                    data.BloodGroup = inStaff.BloodGroup;
                    data.PersonalEmail = inStaff.PersonalEmail;
                    data.Designation = inStaff.Designation;
                    data.JoiningDate = inStaff.JoiningDate;
                    data.Salary = inStaff.Salary;
                    data.Experience = inStaff.Experience;
                    data.BranchId = inStaff.BranchId;
                    data.Department = inStaff.Department;
                    data.PreviousCompany = inStaff.PreviousCompany;
                    data.UserName = inStaff.UserName;
                    data.Password = inStaff.Password;
                    data.IdcardType = inStaff.IdcardType;
                    data.Idnumber = inStaff.Idnumber;
                    data.UploadId = inStaff.UploadId;
                    data.CertificateTitle = inStaff.CertificateTitle;
                    data.UserRole = inStaff.UserRole;
                    data.UpdatedBy = inStaff.CreatedBy;
                    data.UpdatedDate = inStaff.CreatedDate;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        return new Result { StatusCode = 1, Message = "Staff Added Successfully..!" };
                    }
                    else
                    {
                        return new Result { StatusCode = -1, Message = "Staff Adding Failed..!" };
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
