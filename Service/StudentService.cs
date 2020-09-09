using Interview.Interface;
using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Service
{
    public class StudentService : IStudent
    {
        public Result UpdateStudent(Student data)
        {
            try
            {
                StudentDetails studentDetails = new StudentDetails();
                Course course = new Course();
                int res = 0;
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data1 = db.StudentDetails.Where(x => x.StudentId == data.StudentID).FirstOrDefault();
                  
                    data1.StudentFname = data.FirstName;
                    data1.StudentLname = data.LastName;
                    data1.StudentMname = data.MiddleName;
                    data1.Dob = data.DOB;
                    data1.Gender = data.Gender;
                    data1.ParentName = data.ParentName;
                    data1.ParentMobile = data.ParentMobileNo;
                    data1.Email = data.Email;
                    data1.UserName = data.UserName;
                    data1.Password = data.Password;
                    data1.Mobile = data.ContactNo;
                    data1.AlternateMobile = data.AlternateContactNo;
                    data1.Location = data.Location;
                    data1.City = data.City;
                    data1.Address = data.Address;
                    data1.Pincode = data.PinCode;
                    data1.State = data.State;
                    data1.Country = data.Coutry;
                    data1.BranchId = data.BranchID;
                    data1.UpdatedBy = data.CreatedBy;
                    data1.UpdatedDate = data.CreatedDate;
                    data1.Comments = data.Comments;
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                       var  data2 = db.Course.Where(x => x.StudentId == data.StudentID).FirstOrDefault();
                       
                        data2.MainCourseId = data.mainCourseID;
                        data2.AdditionalCourseId = data.AdditionalCourseID;
                        data2.RegistrationDate = data.RegistrationDate;
                        data2.CourseStartDate = data.CourseStartDate;
                        data2.Batch = data.Batch;
                        data2.RegistratioinNumber = data.RegisterNo;
                        data2.RollNo = data.RollNumber;
                        data2.SourceOfEnquiry = data.SourceOfEnquiry;
                        data2.FeeDiscountApplicable = data.FeeDiscountApplicable;
                        data2.DiscountAmount = data.DiscountAmount;
                        data2.ReferredPerson = data.ReferedPerson;
                        data2.TypeOfDiscount = data.TypeofDiscount;
                        data2.IdproofType = data.IdProofType;
                        data2.IdproofNumber = data.IdProofNo;
                        data2.UpdatedBy = data.CreatedBy;
                        data2.UpdatedDate = data.CreatedDate;
                        res = db.SaveChanges();
                    }
                    if (res == 1)
                    {
                        return new Result { Message = "Student Updated Successfully..!", StatusCode = 1 ,Id= data.StudentID};
                    }
                    else
                    {
                        return new Result { Message = "Student Updating Failed..!", StatusCode = -1 };
                    }

                }
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, StatusCode = -1 };
                throw ex;
            }
        }

        public Result DeleteStudent(string ID )
        {
            try
            {
                int resutl = 0;
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var data = db.StudentDetails.Where(x => x.StudentId.ToString() == ID).FirstOrDefault();
                    data.IsActive = false;
                    db.SaveChanges();
                    var data1 = db.Course.Where(x => x.StudentId == data.StudentId).ToList();
                    foreach (var item in data1)
                    {
                        item.IsActive = false;
                      resutl =   db.SaveChanges();
                    }
                }
                if (resutl == 1)
                {
                    return new Result { Message = "Student Deleted Successfully..!", StatusCode = 1 };
                }
                else
                {
                    return new Result { Message = "Student Deleting Failed..!", StatusCode = -1 };
                }
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, StatusCode = -1 };
                throw ex;
            }
        }

        public List<MainCourse> GetMainCourses()
        {
            try
            {
                List<MainCourse> mainCourses = new List<MainCourse>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    mainCourses = db.MainCourse.Where(x => x.IsActive == true).ToList();
                }

                return mainCourses;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Student> GetStudentDetails()
        {
            try
            {
                List<Student> students = new List<Student>();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    students = (from s in db.StudentDetails
                                from c in db.Course
                                      .Where(x => x.StudentId == s.StudentId && s.IsActive == true).DefaultIfEmpty()
                                from b in db.InBranch
                                        .Where(x => x.BranchId == s.BranchId).DefaultIfEmpty()
                                from m in db.MainCourse
                                        .Where(x => x.MainCourseId == s.MainCourseId).DefaultIfEmpty()
                                from mc in db.MainCourse
                                        .Where(x=> x.MainCourseId == c.MainCourseId).DefaultIfEmpty()
                                select new Student
                                {
                                    StudentID = s.StudentId,
                                    CourseID = c.CourseId,
                                    CourseName = mc.Name,
                                    mainCourseID = mc.MainCourseId,
                                    FirstName = s.StudentFname,
                                    LastName = s.StudentLname,
                                    MiddleName = s.StudentMname,
                                    DOB = s.Dob,
                                    Gender = s.Gender,
                                    ParentName = s.ParentName,
                                    ParentMobileNo = s.ParentMobile,
                                    Email = s.Email,
                                    UserName = s.UserName,
                                    Password = s.Password,
                                    ContactNo = s.Mobile,
                                    AlternateContactNo = s.AlternateMobile,
                                    Location = s.Location,
                                    City = s.City,
                                    Address = s.Address,
                                    PinCode = s.Pincode,
                                    State = s.State,
                                    Coutry = s.Country,
                                    BranchID = s.BranchId,
                                    BranchName = b.BranchName,
                                    RegistrationDate = c.RegistrationDate,
                                    CourseStartDate = c.CourseStartDate,
                                    Batch = c.Batch,
                                    RegisterNo = c.RegistratioinNumber,
                                    RollNumber = c.RollNo,
                                    SourceOfEnquiry = c.SourceOfEnquiry,
                                    FeeDiscountApplicable = c.FeeDiscountApplicable,
                                    TypeofDiscount = c.TypeOfDiscount,
                                    Comments = s.Comments,
                                    IdProofType = c.IdproofType,
                                    IdProofNo = c.IdproofNumber,
                                    IsActive = s.IsActive,
                                    CreatedDate = s.CreatedDate
                                }
                                ).Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).ToList();
                }

                return students;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result AddStudent(Student data)
        {
            try
            {
                StudentDetails studentDetails = new StudentDetails();
                Course course = new Course();
                int res = 0;
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    var guid = Guid.NewGuid();
                    studentDetails.StudentId = guid;
                    studentDetails.StudentFname = data.FirstName;
                    studentDetails.StudentLname = data.LastName;
                    studentDetails.StudentMname = data.MiddleName;
                    studentDetails.Dob = data.DOB;
                    studentDetails.Gender = data.Gender;
                    studentDetails.ParentName = data.ParentName;
                    studentDetails.ParentMobile = data.ParentMobileNo;
                    studentDetails.Email = data.Email;
                    studentDetails.UserName = data.UserName;
                    studentDetails.Password = data.Password;
                    studentDetails.Mobile = data.ContactNo;
                    studentDetails.AlternateMobile = data.AlternateContactNo;
                    studentDetails.Location = data.Location;
                    studentDetails.City = data.City;
                    studentDetails.Address = data.Address;
                    studentDetails.Pincode = data.PinCode;
                    studentDetails.State = data.State;
                    studentDetails.Country = data.Coutry;
                    studentDetails.BranchId = data.BranchID;
                    studentDetails.CreatedBy = data.CreatedBy;
                    studentDetails.CreatedDate = data.CreatedDate;
                    studentDetails.Comments = data.Comments;
                    db.StudentDetails.Add(studentDetails);
                    var result = db.SaveChanges();
                    if (result == 1)
                    {
                        course.StudentId = guid;
                        course.MainCourseId = data.mainCourseID;
                        course.AdditionalCourseId = data.AdditionalCourseID;
                        course.RegistrationDate = data.RegistrationDate;
                        course.CourseStartDate = data.CourseStartDate;
                        course.Batch = data.Batch;
                        course.RegistratioinNumber = data.RegisterNo;
                        course.RollNo = data.RollNumber;
                        course.DiscountAmount = data.DiscountAmount;
                        course.ReferredPerson = data.ReferedPerson;
                        course.SourceOfEnquiry = data.SourceOfEnquiry;
                        course.FeeDiscountApplicable = data.FeeDiscountApplicable;
                        course.TypeOfDiscount = data.TypeofDiscount;
                        course.IdproofType = data.IdProofType;
                        course.IdproofNumber = data.IdProofNo;
                        course.CreatedBy = data.CreatedBy;
                        course.CreatedDate = data.CreatedDate;
                        db.Course.Add(course);
                        res = db.SaveChanges();
                    }

                    if (res == 1)
                    {
                        return new Result { Message = "Student Registered Successfully..!", StatusCode = 1, Id=guid };
                    }
                    else
                    {
                        return new Result { Message = "Student Registered Failed..!", StatusCode = -1 };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, StatusCode = -1 };
                throw ex;
            }
        }

        public Student GetStudentByID(string Id)
        {
            try
            {
                Student student = new Student();
                List<studentfile> studentfiles = new List<studentfile>();
                List<studentfile> studentfiles1 = new List<studentfile>();
                List<studentfile> studentfiles2 = new List<studentfile>();
                studentfile studentfiles3 = new studentfile();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                   
                    student = (from s in db.StudentDetails
                                          from c in db.Course
                                                .Where(x => x.StudentId.ToString() == Id && s.IsActive == true).DefaultIfEmpty()
                                          from b in db.InBranch
                                                  .Where(x => x.BranchId == s.BranchId).DefaultIfEmpty()
                                          from m in db.MainCourse
                                                  .Where(x => x.MainCourseId == s.MainCourseId).DefaultIfEmpty()
                                          from mc in db.MainCourse
                                                  .Where(x => x.MainCourseId == c.MainCourseId).DefaultIfEmpty()
                                          select new Student
                                          {
                                              StudentID = s.StudentId,
                                              CourseID = c.CourseId,
                                              CourseName = mc.Name,
                                              mainCourseID = mc.MainCourseId,
                                              FirstName = s.StudentFname,
                                              LastName = s.StudentLname,
                                              MiddleName = s.StudentMname,
                                              DOB = s.Dob,
                                              Gender = s.Gender,
                                              ParentName = s.ParentName,
                                              ParentMobileNo = s.ParentMobile,
                                              Email = s.Email,
                                              UserName = s.UserName,
                                              Password = s.Password,
                                              ContactNo = s.Mobile,
                                              AlternateContactNo = s.AlternateMobile,
                                              Location = s.Location,
                                              City = s.City,
                                              Address = s.Address,
                                              PinCode = s.Pincode,
                                              State = s.State,
                                              Coutry = s.Country,
                                              BranchID = s.BranchId,
                                              BranchName = b.BranchName,
                                              RegistrationDate = c.RegistrationDate,
                                              CourseStartDate = c.CourseStartDate,
                                              Batch = c.Batch,
                                              RegisterNo = c.RegistratioinNumber,
                                              RollNumber = c.RollNo,
                                              DiscountAmount = c.DiscountAmount,
                                              ReferedPerson = c.ReferredPerson,
                                              SourceOfEnquiry = c.SourceOfEnquiry,
                                              FeeDiscountApplicable = c.FeeDiscountApplicable,
                                              TypeofDiscount = c.TypeOfDiscount,
                                              Comments = s.Comments,
                                              IdProofType = c.IdproofType,
                                              IdProofNo = c.IdproofNumber,
                                              IsActive = s.IsActive,
                                              CreatedDate = s.CreatedDate,
                                              UploadedFile = studentfiles
                                          }
                                ).Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                }
                return student;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<studentfile> GetUploadedFile(string Id)
        {
            try
            {
                
                List<studentfile> studentfiles = new List<studentfile>();
                List<studentfile> studentfiles1 = new List<studentfile>();
                List<studentfile> studentfiles2 = new List<studentfile>();
                studentfile studentfiles3 = new studentfile();
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    studentfiles1 = db.StudentIdupload.Where(x => x.StudentId.ToString() == Id && x.IsActive == true).Select(x => new studentfile
                    {
                        FileID = x.StudentUploadId,
                        FileName = x.UploadFileName,
                        FileType = x.UploadFileTitile
                    }).ToList();
                    studentfiles.AddRange(studentfiles1);
                    studentfiles2 = db.CertificateUpload.Where(x => x.StudentId.ToString() == Id && x.IsActive == true).Select(x => new studentfile
                    {
                        FileID = x.CertificteUploadId,
                        FileName = x.UploadFileName,
                        FileType = x.UploadFileTitile
                    }).ToList();
                    studentfiles.AddRange(studentfiles2);
                    var data = db.StudentDetails.Where(x => x.StudentId.ToString() == Id && x.IsActive == true).FirstOrDefault();
                    var d = data.StudentPhoto.Split("\\");
                    studentfiles3 = new studentfile { FileID = data.StudentId, FileName = d[8], FileType = "UploadPhoto" };
                    studentfiles.Add(studentfiles3);
                }
                return studentfiles;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Result DeleteUploadedFile(string Id, string Type)
        {
            try
            {
                int result = 0;
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    if (Type == "UploadID")
                    {
                        var data = db.StudentIdupload.Where(x => x.StudentUploadId.ToString() == Id).FirstOrDefault();
                        data.IsActive = false;
                        result = db.SaveChanges();
                    } else
                    {
                        var data1 = db.CertificateUpload.Where(x => x.CertificteUploadId.ToString() == Id).FirstOrDefault();
                        data1.IsActive = false;
                        result = db.SaveChanges();
                    }
                }
                if (result == 1)
                {
                    return new Result { Message = "Student File Deleted Successfully..!", StatusCode = 1};
                }
                else
                {
                    return new Result { Message = "Student File Deleting Failed..!", StatusCode = -1 };
                }

            }
            catch (Exception ex)
            {
                return new Result { Message = ex.Message, StatusCode = -1 };
                throw ex;
            }
        }
    }
}
