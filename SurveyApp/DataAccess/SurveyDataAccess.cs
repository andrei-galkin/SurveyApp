using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataAccess
{
    public interface ISurveyDataAccess<Q, A>
    {
        Task<IEnumerable<Q>> GetQuestions();
        Task SaveAnswerAsync(A response);
    }
    public class SurveyDataAccess : ISurveyDataAccess<QuestionDto, ResponserDto>, IDisposable
    {
        private readonly IDbConnection _db;

        public SurveyDataAccess()
        {
            _db = new SqlConnection(ConfigProvider.DbConnectionString());
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            var list = await _db.QueryAsync<QuestionDto>(@"SELECT id
                                                      ,text
                                                      ,question_type AS type
                                                  FROM dbo.SurveyQuestions
                                                  ORDER BY id").ConfigureAwait(false);
            return list;
        }

        public IEnumerable<string> GetQuestionOptions(int questionId)
        {
            var list = _db.Query<string>(string.Format(@"SELECT id
                                                                  ,question_id
                                                                  ,question_type
                                                                  ,data
                                                              FROM dbo.SurveyQuestionsInfo
                                                              WHERE question_id = @questionId
                                                              ORDER BY id", questionId)).ToList();
            return list;
        }

        public async Task SaveAnswerAsync(ResponserDto response)
        {
            await _db.ExecuteAsync(@"INSERT INTO SurveyResponses (question_id, data, user_data) 
                                     VALUES (@Id, @Data, @UserData)", response).ConfigureAwait(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
