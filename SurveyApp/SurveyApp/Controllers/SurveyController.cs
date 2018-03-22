using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SurveyApp.Model;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    public class SurveyDataController : Controller
    {
        private readonly ISurveyDataManager<Question, Answer> _surveyDataManager;

        public SurveyDataController()
        {
            try
            {
                _surveyDataManager = new SurveyDataManager();
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
                return _surveyDataManager.GetQuestions().Select(q => new QuestionModel()
                {
                    Id = q.Id,
                    Index = q.Index,
                    Text = q.Text,
                    Type = q.Type,
                    Options = q.Options
                });
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                return new List<QuestionModel>();
            }
        }

        [Produces("application/json")]
        [HttpPost("[action]")]
        public IActionResult SaveAnswer([FromBody]JObject json)
        {
            try
            {
                var answer = new Answer();
                foreach (KeyValuePair<string, JToken> pair in json)
                {
                    answer.Answers.Add(pair.Key, json.GetValue(pair.Key).ToString());
                }

                _surveyDataManager.SaveAnswer(answer);
                OkResult result = Ok();
                return result;
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                StatusCodeResult result = BadRequest();
                return result;
            }
        }
    }
}
