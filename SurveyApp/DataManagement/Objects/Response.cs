using System.Collections.Generic;

namespace DataManagement
{
    public class ResponseItem
    {
        public Dictionary<string, string> Responses{ get; set; }
        public string UserData { get; set; }
        public ResponseItem()
        {
            Responses = new Dictionary<string, string>();
        }
    }
}
