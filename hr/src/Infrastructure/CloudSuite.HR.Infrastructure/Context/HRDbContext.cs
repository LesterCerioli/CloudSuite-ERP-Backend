using CloudSuite.HR.Infrastructure.Mappings.EFCore;
using CloudSuite.Modules.HR.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.HR.Infrastructure.Context
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<LunchTimeExceededEvent> LunchTimeExceededEvents { get; set; }

        public DbSet<TimeRecord> TimeRecords { get; set; }

        public DbSet<WorkHourRecord> WorkHourRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                // Adjust column type and length as needed
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfiguration(new EmployeeEFCoreMapping());

            //modelBuilder.ApplyConfiguration(new LunchTimeExceededEventEFCoreMapping());

            modelBuilder.ApplyConfiguration(new TimeRecordEFCoremapping());

            modelBuilder.ApplyConfiguration(new WorkHourRecordEFCoreMapping());

            modelBuilder.Entity<Employee>(t =>
            {
                t.ToTable("Employees");
            });

            //modelBuilder.Entity<LunchTimeExceededEvent>(t =>
            //{
                //t.ToTable("LunchTimeExceededEvents");
            //});

            modelBuilder.Entity<WorkHourRecord>(t =>
            {
                t.ToTable("WorkHourRecords");
            });

            modelBuilder.Entity<TimeRecord>(t =>
            {
                t.ToTable("TimeRecords");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
