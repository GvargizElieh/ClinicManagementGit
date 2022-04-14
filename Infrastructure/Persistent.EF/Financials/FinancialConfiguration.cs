using Domain.Financials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EF.Financials
{
    public class FinancialConfiguration : IEntityTypeConfiguration<Financial>
    {
        public void Configure(EntityTypeBuilder<Financial> builder)
        {
            builder.ToTable("Financials", "financial");
            builder.HasKey(financial => financial.Id);
            builder.Property(financial => financial.Payment).IsRequired().HasMaxLength(100);
            builder.Property(financial => financial.PaymentAmount).IsRequired();
            builder.HasOne(financial => financial.Person).WithMany(person => person.Financials).HasForeignKey(financial => financial.PersonId);
        }
    }
}
