using CloudSuite.Modules.HR.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.HR.Infrastructure.Mappings.EFCore
{
    public class WorkHourRecordEFCoreMapping : IEntityTypeConfiguration<WorkHourRecord>
    {
        public void Configure(EntityTypeBuilder<WorkHourRecord> builder)
        {
            throw new NotImplementedException();
        }
    }
}
