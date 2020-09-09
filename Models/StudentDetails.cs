using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class StudentDetails
    {
        public Guid StudentId { get; set; }
        public string StudentFname { get; set; }
        public string StudentMname { get; set; }
        public string StudentLname { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? MainCourseId { get; set; }
        public Guid? AdditionalCourseId { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistratioinNumber { get; set; }
        public string RollNo { get; set; }
        public bool? StudentStatus { get; set; }
        public bool? StudentProfileStatus { get; set; }
        public bool? MainCourseStatus { get; set; }
        public bool? AdditionalCourseStatus { get; set; }
        public string StudentPhoto { get; set; }
        public string Comments { get; set; }
        public string SourceOfEnquiry { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual AdditionalCourse AdditionalCourse { get; set; }
        public virtual InBranch Branch { get; set; }
        public virtual MainCourse MainCourse { get; set; }
    }
}
