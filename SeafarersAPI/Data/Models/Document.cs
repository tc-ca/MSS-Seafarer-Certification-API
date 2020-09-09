using System;
using System.Collections.Generic;

#nullable disable

namespace SeafarersAPI.Data.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int SubmissionId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FileTypeExtention { get; set; }
        public byte[] Data { get; set; }

        public virtual Submission Submission { get; set; }
    }
}
