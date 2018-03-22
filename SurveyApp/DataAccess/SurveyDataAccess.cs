using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccess
{
    public interface ISurveyDataAccess<Q, A>
    {
        IEnumerable<Q> GetQuestions();
        void SaveAnswer(A answer);
    }
    public class SurveyDataAccess : ISurveyDataAccess<QuestionDto, AnswerDto>, IDisposable
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
                                                              WHERE [question_id] = @questionId", questionId)).ToList();
            return list;
        }

        public void SaveAnswer(AnswerDto answer)
        {
            _db.Execute(@"INSERT INTO [SurveyAnswers] ([question_id], [data], [user_data]) VALUES (@Id, @Data, @UserData)", answer);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
