using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement
{
    public interface ISurveyDataManager<Q, A>
    {
        Task<IEnumerable<Q>> GetQuestionsAsync();
        Task SaveAnswerAsync(A answer);
    }

    public class SurveyDataManager : ISurveyDataManager<Question, Answer>
    {
        private readonly ISurveyDataAccess<QuestionDto, AnswerDto> _surveyDataAccess;
        private readonly IQuestionOptionsDataAccess<string> _questionOptionsDataAccess;

        public SurveyDataManager()
        {
            _surveyDataAccess = new SurveyDataAccess();
            _questionOptionsDataAccess = new QuestionOptionsDataAccess();
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            var list = await _surveyDataAccess.GetQuestions().ConfigureAwait(false);
            var questions = list.Select((q, index) => new Question()
            {
                Id = BuildQuestionId(q.Id),
                Index = index + 1,
                Text = q.Text,
                Type = q.Type,
                Options = _questionOptionsDataAccess.GetQuestionOptions(q.Id).ToList()
            });

            return questions;
            //return SurveyMock.Data();
        }

        public async Task SaveAnswerAsync(Answer answer)
        {
            try
            {
                foreach (var a in answer.Answers)
                {
                    string[] keyList = a.Key.Split('_');

                    // this logic is required for multy checklist questions
                    int questionId = Convert.ToInt32(keyList[1]);
                    string questionValue = keyList.Length > 2 ? keyList[2] : a.Value;

                    var answerDto = new AnswerDto()
                    {
                        Id = questionId,
                        Data = questionValue,
                        UserData = answer.UserData
                    };

                    await _surveyDataAccess.SaveAnswerAsync(answerDto).ConfigureAwait(false);
                }
            }
            catch(Exception ex)
            {
                throw;
            }                
        }

        private string BuildQuestionId(int id)
        {
            string prefix = "q_";
            return prefix + id;
        }
    }
}
