using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InStaff
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
        public DateTime? JoiningDate { get; set; }
        public string Salary { get; set; }
        public int? Experience { get; set; }
        public Guid? BranchId { get; set; }
        public string Department { get; set; }
        public string PreviousCompany { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdcardType { get; set; }
        public string Idnumber { get; set; }
        public string UploadId { get; set; }
        public string CertificateTitle { get; set; }
        public string UserRole { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual InBranch Branch { get; set; }
    }
}
