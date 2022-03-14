using DataManagement;
using Microsoft.AspNetCore.Mvc;

namespace StatisticApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticDataManager<IDictionary<int, Stat>> _statisticDataManager;
        private readonly ILogger<StatisticController> _logger;

        public StatisticController(ILogger<StatisticController> logger)
        {
            _statisticDataManager = new StatisticDataManager();
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<StatModel>> Get()
        {
            try
            {
                var list = await _statisticDataManager.GetDataAsync().ConfigureAwait(false);
                return list.Select((i, index)=> new StatModel()
                {
                    Index = index + 1,
                    Id = i.Key,
                    Text = i.Value.Text,
                    Type = i.Value.Type,
                    Labels = i.Value.Labels,
                    Data = i.Value.Data,
                    Result = i.Value.StatResult.Select( 
                            r => new StatResultModel() {
                                Count = r.Count,
                                Text = r.Text
                            }
                        ).ToList()
                });
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                _logger.LogError(exception);
                return new List<StatModel>();
            }
        }
    }
}
