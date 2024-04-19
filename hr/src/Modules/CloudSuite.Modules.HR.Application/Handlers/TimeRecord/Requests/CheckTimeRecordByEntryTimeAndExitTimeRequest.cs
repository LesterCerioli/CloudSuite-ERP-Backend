using CloudSuite.Modules.HR.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.TimeRecord.Requests
{
    internal class CheckTimeRecordByEntryTimeAndExitTimeRequest : Response
    {
        public CheckTimeRecordByEntryTimeAndExitTimeRequest(Guid id, DateTime entryTime, DateTime? exitTime, DateTime? lunchEntryTime, DateTime? lunchReturnTime, DateTime? lunchExitTime)
        {
            this.id = id;
            EntryTime = entryTime;
            ExitTime = exitTime;
            LunchEntryTime = lunchEntryTime;
            LunchReturnTime = lunchReturnTime;
            LunchExitTime = lunchExitTime;
        }

        public Guid id { get; private set; }

        public DateTime EntryTime { get; set; }

        public DateTime? ExitTime { get; set; }

        public DateTime? LunchEntryTime { get; set; }

        public DateTime? LunchReturnTime { get; set; }

        public DateTime? LunchExitTime { get; set; }
    }
}
