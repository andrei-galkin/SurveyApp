using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SurveyApp.Model;

namespace SurveyApp.Controllers
{
    [Route("api/[controller]")]
    public class SurveyDataController : Controller
    {
        private readonly ISurveyDataManager<Question, ResponseItem> _surveyDataManager;

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
        public async Task<IEnumerable<QuestionModel>> GetQuestions()
        {
            try
            {
                var list = await _surveyDataManager.GetQuestionsAsync().ConfigureAwait(false);

                return list.Select(q => new QuestionModel()
                {
                    Id = q.Id,
                    Index = q.Index,
                    Text = q.Text,
                    Type = q.Type,
                    Options = q.Options.ToList()
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
        public async Task<IActionResult> SaveAnswer([FromBody]JObject json)
        {
            try
            {
                var answer = new ResponseItem();
                answer.UserData = Request.Host.Host;

                foreach (KeyValuePair<string, JToken> pair in json)
                {
                    answer.Responses.Add(pair.Key, json.GetValue(pair.Key).ToString());
                }

                await _surveyDataManager.SaveAnswerAsync(answer).ConfigureAwait(false);
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
