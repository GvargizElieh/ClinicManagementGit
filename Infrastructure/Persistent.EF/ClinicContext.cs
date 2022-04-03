using Domain.Financials;
using Domain.People;
using Domain.Reports;
using Domain.Schedules;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent.EF
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Financial> Financials { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
