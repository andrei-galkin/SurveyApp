using System;
using System.Collections.Generic;
using System.Linq;
using DataManagement;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Model;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    public class SurveyDataController : Controller
    {
        private readonly ISurveyDataManager<Question> _surveyDataAccess;

        public SurveyDataController()
        {
            try
            {
                _surveyDataAccess = new SurveyDataManager();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<QuestionModel> GetQuestions()
        {
            try
            {
                return _surveyDataAccess.GetQuestions().Select(q => new QuestionModel()
                {
                    Id = q.Id,
                    Text = q.Text,
                    Type = q.Type,
                    Options = q.Options
                });
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
            }

            return null;
        }
    }
}
