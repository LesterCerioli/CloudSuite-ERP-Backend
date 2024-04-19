using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Models
{
	public class WorkHourRecord : Entity, IAggregateRoot
	{
        private string? employee;

        public WorkHourRecord(int? month, int? year, double? workedHours, string? employee)
        {
            Month = month;
            Year = year;
            WorkedHours = workedHours;
            this.employee = employee;
        }

        public int? Month { get; private set; }

		public int? Year { get; private set; }

		public double? WorkedHours { get; private set; }

		public virtual Employee Employee { get; private set; }

	}
}
