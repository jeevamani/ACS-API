using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class Course
    {
        public Guid CourseId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? MainCourseId { get; set; }
        public Guid? AdditionalCourseId { get; set; }
        public string Batch { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistratioinNumber { get; set; }
        public string RollNo { get; set; }
        public bool? FeeDiscountApplicable { get; set; }
        public string IdproofType { get; set; }
        public string IdproofNumber { get; set; }
        public string TypeOfDiscount { get; set; }
        public string ReferredPerson { get; set; }
        public string DiscountAmount { get; set; }
        public string SourceOfEnquiry { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual AdditionalCourse AdditionalCourse { get; set; }
        public virtual MainCourse MainCourse { get; set; }
    }
}
