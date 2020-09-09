using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class TblEmployee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? EmployeeDob { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeGender { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
