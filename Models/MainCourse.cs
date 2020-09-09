using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class MainCourse
    {
        public MainCourse()
        {
            Course = new HashSet<Course>();
            StudentDetails = new HashSet<StudentDetails>();
        }

        public Guid MainCourseId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}
