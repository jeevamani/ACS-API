using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InConfiguration
    {
        public Guid ConfId { get; set; }
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
}
