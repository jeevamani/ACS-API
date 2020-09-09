using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InDepartment
    {
        public Guid DeptId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
