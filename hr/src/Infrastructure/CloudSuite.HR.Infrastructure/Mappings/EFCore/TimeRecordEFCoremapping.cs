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
    public class TimeRecordEFCoremapping : IEntityTypeConfiguration<TimeRecord>
    {
        public void Configure(EntityTypeBuilder<TimeRecord> builder)
        {
            throw new NotImplementedException();
        }
    }
}
