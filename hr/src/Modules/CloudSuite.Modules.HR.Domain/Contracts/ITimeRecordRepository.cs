using CloudSuite.Modules.HR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Contracts
{
	public interface ITimeRecordRepository
	{
		Task<TimeRecord> GetByEntryTime(DateTime? entryTime);

		Task<TimeRecord> GetByExitTime(DateTime? exitTime);

		Task<TimeRecord> GetByLunchEntryTime(DateTime? lunchTime);

		Task<TimeRecord> GetByLunchReturnTime(DateTime? lunchReturnTime);

		Task<TimeRecord> GetByLunchExitTime(DateTime? lunchExitTime);

		Task<IEnumerable<TimeRecord>> GetList();

		Task Add(TimeRecord record);

		void Update(TimeRecord record);

		void Remove(TimeRecord record);

		
	}
}
