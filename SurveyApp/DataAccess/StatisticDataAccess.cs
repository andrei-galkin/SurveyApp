using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess
{
    public interface IStatisticDataAccess<T>
    {
        Task<IEnumerable<T>> GetDataAsync();
    }
    public class StatisticDataAccess : IStatisticDataAccess<StatDto>, IDisposable
    {
        private readonly IDbConnection _db;

        public StatisticDataAccess()
        {
            _db = new SqlConnection(ConfigProvider.DbConnectionString());
        }

        public async Task<IEnumerable<StatDto>> GetDataAsync()
        {
            var list = await _db.QueryAsync<StatDto>(@"SELECT
                                                          a.question_id as id
	                                                      ,b.text
	                                                      ,b.question_type as type
	                                                      ,a.data
                                                          ,COUNT(a.data) as count
                                                      FROM dbo.SurveyResponses a
                                                      INNER JOIN dbo.SurveyQuestions b ON a.question_id = b.id
                                                      GROUP BY question_id, data, b.text, b.question_type
                                                      ORDER BY question_id").ConfigureAwait(false);
            return list;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
