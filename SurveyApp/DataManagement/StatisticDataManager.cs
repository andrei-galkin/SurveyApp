using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManagement
{
    public interface IStatisticDataManager<T>
    {
        Task<IDictionary<int, Stat>> GetDataAsync();
    }

    public class StatisticDataManager : IStatisticDataManager<IDictionary<int, Stat>>
    {
        private readonly IStatisticDataAccess<StatDto> _statisticDataAccess;

        public StatisticDataManager()
        {
            _statisticDataAccess = new StatisticDataAccess();
        }

        public StatisticDataManager(IStatisticDataAccess<StatDto> dataAccess)
        {
            _statisticDataAccess = dataAccess;
        }

        public async Task<IDictionary<int, Stat>> GetDataAsync()
        {
            var list = await _statisticDataAccess.GetDataAsync().ConfigureAwait(false);
            var statList = new Dictionary<int, Stat>();

            foreach(var s in list)
            {
                if(!statList.ContainsKey(s.Id))
                {
                    var stat = new Stat()
                    {
                        Id = s.Id,
                        Text = s.Text,
                        Type = s.Type,
                        Labels = new List<string> { s.Data },
                        Data = new List<int> { s.Count },
                        StatResult = new List<StatResult>()
                        {
                            new StatResult
                            {
                                Count = s.Count,
                                Text = s.Data
                            }
                        }
                    };
                    statList.Add(s.Id, stat);
                }
                else
                {
                    statList[s.Id].Labels.Add(s.Data);
                    statList[s.Id].Data.Add(s.Count);
                    statList[s.Id].StatResult.Add(
                        new StatResult
                        {
                            Count = s.Count,
                            Text = s.Data
                        }
                    );
                }               
            }

            return statList;
        }
    }
}
