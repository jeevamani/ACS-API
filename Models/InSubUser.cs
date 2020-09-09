using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InSubUser
    {
        public Guid Id { get; set; }
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
}
