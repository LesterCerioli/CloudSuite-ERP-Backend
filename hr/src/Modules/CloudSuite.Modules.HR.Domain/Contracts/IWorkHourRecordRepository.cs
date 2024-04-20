using CloudSuite.Modules.HR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Contracts
{
	public interface IWorkHourRecordRepository
	{
		Task<WorkHourRecord> GetByMonth(int? month);

		Task<WorkHourRecord> GetByYear(int? year);

		Task<WorkHourRecord> GetByWorkedHours(double? workHour);

		Task<IEnumerable<WorkHourRecord>> GetList();

		Task Add(WorkHourRecord record);

		void Update(WorkHourRecord record);

		void Remove(WorkHourRecord record);
	}
}
