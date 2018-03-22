﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess
{
    public interface ISurveyDataAccess<Q, A>
    {
        Task<IEnumerable<Q>> GetQuestions();
        Task SaveAnswerAsync(A answer);
    }
    public class SurveyDataAccess : ISurveyDataAccess<QuestionDto, AnswerDto>, IDisposable
    {
        private readonly IDbConnection _db;

        public SurveyDataAccess()
        {
            _db = new SqlConnection(ConfigProvider.DbConnectionString());
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestions()
        {
            var list = await _db.QueryAsync<QuestionDto>(@"SELECT [id]
                                                      ,[text]
                                                      ,[question_type] AS type
                                                  FROM [dbo].[SurveyQuestions]").ConfigureAwait(false);
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

        public async Task SaveAnswerAsync(AnswerDto answer)
        {
            await _db.ExecuteAsync(@"INSERT INTO [SurveyAnswers] ([question_id], [data], [user_data]) 
                                     VALUES (@Id, @Data, @UserData)", answer).ConfigureAwait(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
