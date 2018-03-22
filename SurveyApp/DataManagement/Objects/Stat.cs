using System.Collections.Generic;

namespace DataManagement
{
    public class StatResult
    {
        public string Text { get; set; }
        public int Count { get; set; }
    }
    public class Stat
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public IList<StatResult> StatResult { get; set; }
        
    }
}
