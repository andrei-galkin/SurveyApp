using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace DataManagement
{
    public interface ISurveyDataManager<T>
    {
        IEnumerable<T> GetQuestions();
    }

    public class SurveyDataManager : ISurveyDataManager<Question>
    {
        private readonly ISurveyDataAccess<QuestionDto> _surveyDataAccess;
        private readonly IQuestionOptionsDataAccess<string> _questionOptionsDataAccess;

        public SurveyDataManager()
        {
            _surveyDataAccess = new SurveyDataAccess();
            _questionOptionsDataAccess = new QuestionOptionsDataAccess();
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _surveyDataAccess.GetQuestions().Select(q => new Question()
            {
                Id = q.Id,
                Text = q.Text,
                Type = q.Type,
                Options = _questionOptionsDataAccess.GetQuestionOptions(q.Id).ToList()
            });
        }
    }
}
