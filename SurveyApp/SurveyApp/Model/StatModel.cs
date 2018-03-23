using System.Collections.Generic;

namespace DataManagement
{
    public class StatResultModel
    {
        public string Text { get; set; }
        public int Count { get; set; }
    }
    public class StatModel
    {
        public int Index { get; set; }
        public int Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public IList<StatResultModel> StatResult { get; set; }
        
    }
}
