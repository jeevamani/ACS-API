using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class AdminUsers
    {
        public Guid Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public Guid? ConfigSettings { get; set; }
        public bool? Status { get; set; }
        public bool? AccountStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Role { get; set; }
        public string Baseurl { get; set; }
        public Guid? CreatedById { get; set; }
    }
}
