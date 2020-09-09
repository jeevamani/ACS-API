using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class AdditionalCourse
    {
        public AdditionalCourse()
        {
            Course = new HashSet<Course>();
            StudentDetails = new HashSet<StudentDetails>();
        }

        public Guid AditionalCourseId { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? CourseId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public bool? CourseStatus { get; set; }
        public DateTime? CourseEndDate { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<StudentDetails> StudentDetails { get; set; }
    }
}
