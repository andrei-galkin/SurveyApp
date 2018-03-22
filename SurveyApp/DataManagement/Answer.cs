using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement
{
    public class Answer
    {
        public Dictionary<string, string> Answers { get; set; }
        public Answer()
        {
            Answers = new Dictionary<string, string>();
        }
    }
}
