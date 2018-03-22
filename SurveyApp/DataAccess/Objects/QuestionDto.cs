using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public List<string> Options { get; set; }
    }
}
