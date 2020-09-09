using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class CourseModule
    {
        public Guid CourseModuleId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string CourseDuration { get; set; }
        public string CourseFee { get; set; }
        public string FeeDiscountforjoin { get; set; }
        public string FeeDiscountforReference { get; set; }
        public string FeePaymentDuration { get; set; }
        public string FeeInstallment { get; set; }
        public string FeeRemainder { get; set; }
        public string CourseSubject { get; set; }
        public string CourseTopics { get; set; }
        public string CourseContent { get; set; }
        public string ContentDuration { get; set; }
        public string ContentMaterial { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
