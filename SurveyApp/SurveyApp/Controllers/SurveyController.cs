using DataManagement;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Model;

namespace SurveyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyDataManager<Question, ResponseItem> _surveyDataManager;
        private readonly ILogger<SurveyController> _logger;
        public SurveyController(ILogger<SurveyController> logger)
        {
            _surveyDataManager = new SurveyDataManager(); 
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionModel>> Get()
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
                _logger.LogError(exception);
                return new List<QuestionModel>();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Dictionary<string,string> questionnaire)
        {
            try
            {
                var answer = new ResponseItem();
                answer.UserData = Request.Host.Host;

                foreach (KeyValuePair<string, string> pair in questionnaire)
                {
                    string value = pair.Value.ToString().Trim();
                    if (value != string.Empty)
                    {
                        answer.Responses.Add(pair.Key, value);
                    }
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
