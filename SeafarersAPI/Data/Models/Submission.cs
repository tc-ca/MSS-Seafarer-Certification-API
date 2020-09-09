using System;
using System.Collections.Generic;

#nullable disable

namespace SeafarersAPI.Data.Models
{
    public partial class Submission
    {
        public Submission()
        {
            Documents = new HashSet<Document>();
        }

        public int SubmissionId { get; set; }
        public string CdnNumber { get; set; }
        public int CertificateTypeId { get; set; }
        public string MtaServiveRequestId { get; set; }
        public int ConfirmationNumber { get; set; }
        public string Note { get; set; }
        public DateTime SubmissionDate { get; set; }

        public virtual CertificateType CertificateType { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
