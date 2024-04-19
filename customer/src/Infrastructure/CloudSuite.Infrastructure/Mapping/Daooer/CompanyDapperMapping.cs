using CloudSuite.Modules.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.Daooer
{
	public class CompanyDapperMapping
	{
		private readonly IDbConnection _connection;

		public CompanyDapperMapping(IDbConnection connection)
		{
			_connection = connection;
		}

		public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
		{
			var query = @"
                SELECT 
                    Id,
                    SocialName,
                    FantasyName,
                    FundationDate,
                    CNPJNumber,
                    StreetOrValue AS StreetAvenue,
                    District,
                    Complement,
                    City,
                    State,
                    UF
                FROM
                    Companies";

			return await _connection.QueryAsync<Company>(query);
		}

		public async Task<Company> GetCompanyByIdAsync(int companyId)
		{
			var query = @"
                SELECT 
                    Id,
                    SocialName,
                    FantasyName,
                    FundationDate,
                    CNPJNumber,
                    StreetOrValue AS StreetAvenue,
                    District,
                    Complement,
                    City,
                    State,
                    UF
                FROM
                    Companies
                WHERE
                    Id = @CompanyId";

			return await _connection.QueryFirstOrDefaultAsync<Company>(query, new { CompanyId = companyId });
		}

	}
}
