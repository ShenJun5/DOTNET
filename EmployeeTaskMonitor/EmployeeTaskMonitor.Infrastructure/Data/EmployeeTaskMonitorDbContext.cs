using EmployeeTaskMonitor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTaskMonitor.Infrastructure.Data
{
    public class EmployeeTaskMonitorDbContext: DbContext
    {
        public EmployeeTaskMonitorDbContext(DbContextOptions<EmployeeTaskMonitorDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(ConfigureTask);
            modelBuilder.Entity<Employee>(ConfigureEmployee);
        }

        private void ConfigureTask(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TaskName).HasMaxLength(512);
            builder.Property(t => t.StartTime).HasDefaultValueSql("getdate()");
        }

        private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).HasMaxLength(256);
            builder.Property(e => e.LastName).HasMaxLength(256);
            builder.Property(t => t.HiredDate).HasDefaultValueSql("getdate()");
        }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
