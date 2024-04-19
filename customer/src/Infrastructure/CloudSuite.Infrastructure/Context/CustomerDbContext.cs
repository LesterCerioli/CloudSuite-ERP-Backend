using CloudSuite.Infrastructure.Mapping.EFCore;
using CloudSuite.Modules.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Context
{
	public class CustomerDbContext : DbContext
	{
		public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			ChangeTracker.AutoDetectChangesEnabled = false;

		}

		public DbSet<Company> Companies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<ValidationResult>();

			modelBuilder.Ignore<Event>();

			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
					e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfiguration(new CompanyEFCoreMapping());

			modelBuilder.Entity<Company>(c =>
			{
				c.ToTable("Companies");
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
