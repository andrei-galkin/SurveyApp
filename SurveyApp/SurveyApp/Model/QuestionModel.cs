using System.Collections.Generic;

namespace SurveyApp.Model
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public List<string> Options { get; set; }
    }
}
