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
        private readonly IStatisticDataManager<IDictionary<int, Stat>> _StatisticDataManager;

        public StatisticDataController()
        {
            try
            {
                _StatisticDataManager = new StatisticDataManager();
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
                var list = await _StatisticDataManager.GetDataAsync().ConfigureAwait(false);

                return list.Select(q => new StatModel()
                {
                    Id = q.Key,
                    Text = q.Value.Text,
                    Type = q.Value.Type,
                    StatResult = q.Value.StatResult.Select( 
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
