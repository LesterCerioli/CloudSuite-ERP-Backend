using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Models
{
	public class TimeRecord : Entity, IAggregateRoot
	{
        private string? employee;

        public TimeRecord(DateTime entryTime, DateTime? exitTime, DateTime? lunchEntryTime, DateTime? lunchReturnTime, DateTime? lunchExitTime)
		{
			EntryTime = entryTime;
			ExitTime = exitTime;
			LunchEntryTime = lunchEntryTime;
			LunchReturnTime = lunchReturnTime;
			LunchExitTime = lunchExitTime;
        }

        public TimeRecord(DateTime entryTime, DateTime? exitTime, DateTime? lunchEntryTime, DateTime? lunchReturnTime, string? employee)
        {
            EntryTime = entryTime;
            ExitTime = exitTime;
            LunchEntryTime = lunchEntryTime;
            LunchReturnTime = lunchReturnTime;
            this.employee = employee;
        }

        public DateTime EntryTime { get; private set; }

		public DateTime? ExitTime { get; private set; }

		public DateTime? LunchEntryTime { get; private set; }

		public DateTime? LunchReturnTime { get; private set; }

		public DateTime? LunchExitTime { get; private set; }

		public virtual Employee Employee { get; private set; }
	}
}
