using System.Collections.Generic;

namespace DataManagement
{
    public class Question
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public List<string> Options { get; set; }
    }
}
