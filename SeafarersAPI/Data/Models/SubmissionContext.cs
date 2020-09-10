using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace SeafarersAPI.Data.Models
{
    public partial class SubmissionContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public SubmissionContext()
        {
        }

        public SubmissionContext(DbContextOptions<SubmissionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CertificateType> CertificateTypes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                //You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. 
                //For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=tcp:seafarer-certificates.database.windows.net,1433;Initial Catalog=SeafarerDocumentSubmission;Persist Security Info=False;User ID=scadmin;Password=skPvPaq1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_configuration.GetConnectionString("AzureSQL"));

            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CertificateType>(entity =>
            {
                entity.ToTable("CertificateType");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.CertificateTypeId).ValueGeneratedNever();

                entity.Property(e => e.CertificateTypeCd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CertificateTypeCD");

                entity.Property(e => e.NameEnglish).IsUnicode(false);

                entity.Property(e => e.NameFrench).IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.DocumentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DocumentID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FileTypeExtention).HasMaxLength(50);

                entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(x => x.SubmissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Submission");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.ToTable("Submission");

                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(e => e.SubmissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubmissionID");

                entity.Property(e => e.CdnNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CDN_Number");

                entity.Property(e => e.CertificateTypeId).HasColumnName("CertificateTypeID");

                entity.Property(e => e.MtaServiveRequestId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MTA_ServiveRequestID")
                    .IsFixedLength(true);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("datetime")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.HasOne(d => d.CertificateType)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(x => x.CertificateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Submission_CertificateType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
