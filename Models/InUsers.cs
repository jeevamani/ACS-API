using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InUsers
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string BaseUrl { get; set; }
        public Guid? Configuration { get; set; }
        public Guid? CreatedById { get; set; }
        public string EmailId { get; set; }
        public bool? AccountStatus { get; set; }
    }
}
