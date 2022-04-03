using Domain.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EF.Schedules
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules", "schedule");
            builder.HasKey(schedule => schedule.Id);
            builder.Property(schedule => schedule.Title).IsRequired().HasMaxLength(50);
            builder.Property(schedule => schedule.Description).IsRequired().HasMaxLength(200);
            builder.Property(schedule => schedule.StartTime).IsRequired();
            builder.HasOne(schedule => schedule.Person).WithMany(person => person.Schedules).HasForeignKey(schedule => schedule.PersonId);
        }
    }
}
