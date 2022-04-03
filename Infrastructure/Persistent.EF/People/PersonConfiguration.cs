using Domain.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EF.People
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "person");
            builder.HasKey(person => person.Id);
            builder.Property(person => person.Name).IsRequired().HasMaxLength(100);
            builder.Property(person => person.Family).IsRequired().HasMaxLength(100);
            builder.Property(person => person.NationalId).IsRequired().HasMaxLength(10);
            builder.HasIndex(person => person.NationalId).IsUnique();
            builder.HasMany(person => person.Financials).WithOne(financial => financial.Person);
            builder.HasMany(person => person.Reports).WithOne(report => report.Person);
            builder.HasMany(person => person.Schedules).WithOne(schedule => schedule.Person);
        }
    }
}
