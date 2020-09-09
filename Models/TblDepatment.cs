using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class TblDepatment
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? UpdatedBy { get; set; }
    }
}
