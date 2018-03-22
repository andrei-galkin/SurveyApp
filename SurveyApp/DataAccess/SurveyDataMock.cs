using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class SurveyDataMock
    {
        public static IEnumerable<StatDto> GetDataStats()
        {
            var list = new List<StatDto>
            {
                new StatDto()
                {
                    Id = 1,
                    Type = 1,
                    Text = "Question 1",
                    Count = 2,
                    Data = "R1"
                },
                new StatDto()
                {
                    Id = 1,
                    Type = 1,
                    Text = "Question 1",
                    Count = 1,
                    Data = "R2"
                },
                new StatDto()
                {
                    Id = 2,
                    Type = 2,
                    Text = "Question 2",
                    Count = 2,
                    Data = "C1"
                },
                 new StatDto()
                {
                    Id = 2,
                    Type = 2,
                    Text = "Question 2",
                    Count = 1,
                    Data = "C2"
                },
                  new StatDto()
                {
                    Id = 3,
                    Type = 3,
                    Text = "Question 3",
                    Count = 1,
                    Data = "C2"
                }
            };

            return list;
        }
    }
}
