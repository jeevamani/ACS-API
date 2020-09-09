using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InBranch
    {
        public InBranch()
        {
            InStaff = new HashSet<InStaff>();
            StudentDetails = new HashSet<StudentDetails>();
        }

        public Guid BranchId { get; set; }
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

        public virtual ICollection<InStaff> InStaff { get; set; }
        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}
