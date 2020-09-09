using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class StudentIdupload
    {
        public Guid StudentUploadId { get; set; }
        public Guid? StudentId { get; set; }
        public string UploadFileType { get; set; }
        public string UploadFileTitile { get; set; }
        public string UploadPath { get; set; }
        public string RefNumber { get; set; }
        public string UploadFileName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
