using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccess
{
    public interface IQuestionOptionsDataAccess<T>
    {
        IEnumerable<string> GetQuestionOptions(int questionId);
    }
    public class QuestionOptionsDataAccess : IQuestionOptionsDataAccess<string>, IDisposable
    {
        private readonly IDbConnection _db;

        public QuestionOptionsDataAccess()
        {
            _db = new SqlConnection(ConfigProvider.DbConnectionString());
        }
        
        public IEnumerable<string> GetQuestionOptions(int questionId)
        {
            var list = _db.Query<string>(string.Format(@"SELECT [data]
                                                              FROM [dbo].[SurveyQuestionsInfo]
                                                              WHERE [question_id] = {0}", questionId)).ToList();
            return list;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
