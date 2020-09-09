using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Interview.Models
{
    public class Result
    {
        public int? StatusCode { get; set; }
        public string Message { get; set; }
        public Guid? Id { get; set; }
    }

    public class StaffDetails
    {
        public Guid StaffId { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string MobileNumber { get; set; }
        public string HomeContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public string BloodGroup { get; set; }
        public string PersonalEmail { get; set; }
        public string Designation { get; set; }
        public string DesignationName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Salary { get; set; }
        public int? Experience { get; set; }
        public Guid? BranchId { get; set; }
        public string BranchName { get; set; }
        public string Department { get; set; }
        public string DeaprtmentName { get; set; }
        public string PreviousCompany { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdcardType { get; set; }
        public string Idnumber { get; set; }
        public string UploadId { get; set; }
        public string CertificateTitle { get; set; }
        public string UserRole { get; set; }
        public string UserRoleName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class UserCred {
        public Guid? userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string BaseUrl { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public Guid? ConfigId { get; set; }
    }

    public class configDDL
    {
        public string configName { get; set; }
        public Guid configId { get; set; }
    }

    public class AdminUserDetails
    {
        public Guid? Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public Guid? ConfigSettings { get; set; }
        public string ConfigName { get; set; }
        public bool? Status { get; set; }
        public string Role { get; set; }
        public bool? AccountStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Baseurl { get; set; }
        public Guid? CreatedById { get; set; }
    }
    

    public class PostModel
    {
        public string Key { get; set; }
    }

    public class user
    {
        public Guid? EmpId { get; set; }
        public string EmpName { get; set; }
    }
    public class userDetails
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ConfiguratoinId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string EmailId { get; set; }
        public bool? AccountStatus { get; set; }
        public string BaseUrl { get; set; }
        public Guid? CreatedById { get; set; }
    }

    public partial class InConfigurationDetails
    {
        public Guid ConfId { get; set; }
        public string name { get; set; }
        public Guid? EmpId { get; set; }
        public string EmpName { get; set; }
        public int? Branch { get; set; }
        public int? UserCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual InUsers Emp { get; set; }
    }
    public class subUserDetails
    {
        public Guid? Id { get; set; }
        public Guid? ConfigId { get; set; }
        public string SubUserName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string EmailId { get; set; }
        public Guid? EmpId { get; set; }
    }

    public class BranchDetails
    {
        public Guid? Id { get; set; }
        public Guid? ConfigId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string Location { get; set; }
        public Guid? EmpId { get; set; }
    }
    public class ConfigurationDetail
    {
        public Guid? ConfId { get; set; }
        public Guid? EmpId { get; set; }
        public int? Branch { get; set; }
        public int? UserCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
    }

    public class FileUpload
    {
        public Guid? UploadID { get; set; }
        public Guid UserID { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string FileType { get; set; }
    }

    public class studentfile
    {
        public Guid? FileID { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }
    public class Student {
        public Guid? StudentID { get; set; }

        public Guid? AdditionalCourseID { get; set; }
        public Guid? mainCourseID { get; set; }
        public string CourseName { get; set; }
        public Guid? CourseID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DOB { get; set; }
        public string DiscountAmount { get; set; }
        public string ReferedPerson { get; set; }
        public string Gender { get; set; }
        public string ParentName { get; set; }
        public string ParentMobileNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string AlternateContactNo { get; set; }
        public string Location { get; set; }
        public string City { get; set; }

        public string Address { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Coutry { get; set; }
        public Guid? BranchID { get; set; }
        public string BranchName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public string Batch { get; set; }
        public string RegisterNo { get; set; }
        public string RollNumber { get; set; }
        public string SourceOfEnquiry { get; set; }
        public bool? FeeDiscountApplicable { get; set; }
        public string TypeofDiscount { get; set; }
        public string Comments { get; set; }
        public string IdProofType { get; set; }
        public string IdProofNo { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<studentfile> UploadedFile { get; set; }
    }



    public partial class InBranchDetails
    {
        public Guid? BranchId { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string BranchCode { get; set; }
        public string Gstin { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Smsapiurl { get; set; }
        public string Apikey { get; set; }
        public string SenderId { get; set; }
        public string BranchLogo { get; set; }
        public string PrintHeaderFile { get; set; }
        public string PrintFooterFile { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? ConfigId { get; set; }
        public Guid? EmpId { get; set; }
        public string ConfigName { get; set; }
        public string EmpName { get; set; }
    }

    public partial class InSubUserDetails
    {
        public Guid Id { get; set; }
        public Guid? ConfigId { get; set; }
        public string ConfigName { get; set; }
        public string SubUserName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string EmailId { get; set; }
        public Guid? EmpId { get; set; }
        public string EmpName { get; set; }
    }

    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string baseUrl { get; set; }
        public bool? IsSuperAdmin { get; set; }
    }


}
