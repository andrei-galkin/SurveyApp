using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement
{
    public class SurveyMock
    {
        public static IEnumerable<Question>  Data()
        {
            var list = new List<Question>
            {
                new Question()
                {
                    Id = "q_1",
                    Type = 1,
                    Text = "Question 1",
                    Options = new List<string>() { "R1", "R2", "R3" }
                },
                new Question()
                {
                    Id = "q_2",
                    Type = 2,
                    Text = "Question 2",
                    Options = new List<string>() { "C1", "C2", "C3" }
                },
                new Question()
                {
                    Id = "q_3",
                    Type = 3,
                    Text = "Question 3",
                    Options = new List<string>(){""}
                }
            };

            return list;
        }
    }
}
