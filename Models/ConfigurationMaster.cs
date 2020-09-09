using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class ConfigurationMaster
    {
        public Guid ConfigId { get; set; }
        public string ConfigName { get; set; }
        public int? NoOfBranches { get; set; }
        public int? NoOfStaff { get; set; }
        public int? NoOfStudent { get; set; }
        public int? NoOfVideoConferenceDaily { get; set; }
        public string MaxDurationOfConference { get; set; }
        public int? MaxNoOfVideoRecording { get; set; }
        public int? MaxParticipantInConference { get; set; }
        public string BaseUrl { get; set; }
        public string BrandLogo { get; set; }
        public string PageTitle { get; set; }
        public DateTime? AccoutExpiryDate { get; set; }
        public string BrandName { get; set; }
        public string BrandCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
