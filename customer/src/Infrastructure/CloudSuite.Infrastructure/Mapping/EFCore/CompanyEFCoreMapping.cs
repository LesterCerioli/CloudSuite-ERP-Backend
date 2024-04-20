using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.EFCore
{
	public class CompanyEFCoreMapping : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.HasColumnName("Id");

			builder.Property(c => c.SocialName)
				.HasColumnName("SocialName")
				.HasColumnType("varchar(100)")
				.IsRequired();

			builder.Property(c => c.FantasyName)
				.HasColumnName("fantasyname")
				.HasColumnType("varchar(100")
				.IsRequired();

			builder.Property(c => c.FundationDate)
				.HasColumnName("fundationname")
				.HasColumnType("date")
				.IsRequired();

			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CNPJNumber").HasMaxLength(11).IsRequired();

			builder.OwnsOne(p => p.Address)
							.Property(p => p.StreetAvenue).HasColumnName("streetorvalue").HasMaxLength(100).IsRequired();
			
			builder.OwnsOne(p => p.Address)
							.Property(p => p.District).HasColumnName("district").HasMaxLength(40).IsRequired();

			builder.OwnsOne(p => p.Address)
							.Property(p => p.Complement).HasColumnName("complement").HasMaxLength(40).IsRequired();

			builder.OwnsOne(p => p.Address)
							.Property(p => p.City).HasColumnName("city").HasMaxLength(40).IsRequired();

			builder.OwnsOne(p => p.Address)
							.Property(p => p.State).HasColumnName("state").HasMaxLength(40).IsRequired();

			builder.OwnsOne(p => p.Address)
							.Property(p => p.UF).HasColumnName("uf").HasMaxLength(2).IsRequired();
		}
	}
}
