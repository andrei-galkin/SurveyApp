using System.Data;
using System.Data.SqlClient;
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
            const string sql = @"SELECT
                                    a.question_id as id
                                     ,b.text
                                     ,b.question_type as type
                                     ,a.data
                                        ,COUNT(a.data) as count
                                 FROM dbo.SurveyResponses a
                                 INNER JOIN dbo.SurveyQuestions b ON a.question_id = b.id
                                 GROUP BY question_id, data, b.text, b.question_type
                                 ORDER BY question_id";

            var list = await _db.QueryAsync<StatDto>(sql).ConfigureAwait(false);
            return list;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
