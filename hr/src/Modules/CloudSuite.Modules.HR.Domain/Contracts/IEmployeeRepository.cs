using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Domain.Contracts
{
	public interface IEmployeeRepository
	{
		Task<Employee> GetByCpf(Cpf cpf);

		Task<Employee> GetByFullname(string fullname);

		Task<Employee> GetByEmail(string emailAddress);

		Task<IEnumerable<Employee>> GetList();

		Task  Add(Employee employee);

		void Update(Employee employee);

		void Remove(Employee employee);


	}
}
