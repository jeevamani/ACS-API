using System;
using System.Collections.Generic;

namespace Interview.Models
{
    public partial class InFileUpload
    {
        public Guid UploadId { get; set; }
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string FileType { get; set; }
    }
}
