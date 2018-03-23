using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManagement;
using Microsoft.AspNetCore.Mvc;

namespace StatisticApp.Controllers
{
    [Route("api/[controller]")]
    public class StatisticDataController : Controller
    {
        private readonly IStatisticDataManager<IDictionary<int, Stat>> _statisticDataManager;

        public StatisticDataController()
        {
            try
            {
                _statisticDataManager = new StatisticDataManager();
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
            }
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<StatModel>> GetData()
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
                    StatResult = i.Value.StatResult.Select( 
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
                return new List<StatModel>();
            }
        }
    }
}
