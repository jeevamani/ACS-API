using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class StudentFee
    {
        public Guid StudentFeeId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? CourseId { get; set; }
        public string FeeAmmount { get; set; }
        public bool? FeeDiscountApplicablt { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountType { get; set; }
        public string ReferedPerson { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
