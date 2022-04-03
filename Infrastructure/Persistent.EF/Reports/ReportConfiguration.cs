using Domain.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EF.Reports
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports", "report");
            builder.HasKey(report => report.Id);
            builder.Property(report => report.Issue).IsRequired().HasMaxLength(100);
            builder.Property(report => report.Content).IsRequired();
            builder.Property(report => report.ReportType).IsRequired();
            builder.Property(report => report.ReportDate).IsRequired();
            builder.HasOne(report => report.Person).WithMany(person => person.Reports).HasForeignKey(report => report.PersonId);
        }
    }
}
