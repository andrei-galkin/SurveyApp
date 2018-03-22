using DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManagement
{
    public interface ISurveyDataManager<Q, A>
    {
        IEnumerable<Q> GetQuestions();
        void SaveAnswer(A answer);
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

        public IEnumerable<Question> GetQuestions()
        {
            var questions = _surveyDataAccess.GetQuestions().Select((q, index) => new Question()
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

        public void SaveAnswer(Answer answer)
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
                        UserData = ""
                    };

                    _surveyDataAccess.SaveAnswer(answerDto);
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
