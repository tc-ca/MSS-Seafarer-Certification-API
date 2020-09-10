using System.Collections.Generic;

#nullable disable

namespace SeafarersAPI.Data.Models
{
    public partial class CertificateType
    {
        public CertificateType()
        {
            Submissions = new HashSet<Submission>();
        }

        public int CertificateTypeId { get; set; }
        public string CertificateTypeCd { get; set; }
        public string NameEnglish { get; set; }
        public string NameFrench { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
