using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccess
{
    public interface ISurveyDataAccess<T>
    {
        IEnumerable<T> GetQuestions();
    }
    public class SurveyDataAccess : ISurveyDataAccess<QuestionDto>, IDisposable
    {
        private readonly IDbConnection _db;

        public SurveyDataAccess()
        {
            _db = new SqlConnection(ConfigProvider.DbConnectionString());
        }

        public IEnumerable<QuestionDto> GetQuestions()
        {
            var list = _db.Query<QuestionDto>(@"SELECT [id]
                                                      ,[text]
                                                      ,[question_type] AS type
                                                  FROM [dbo].[SurveyQuestions]").ToList();
            return list;
        }

        public IEnumerable<string> GetQuestionOptions(int questionId)
        {
            var list = _db.Query<string>(string.Format(@"SELECT [id]
                                                                  ,[question_id]
                                                                  ,[question_type]
                                                                  ,[data]
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
