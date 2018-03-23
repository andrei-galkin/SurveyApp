using System.Collections.Generic;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DataManagement.Tests
{
    [TestClass]
    public class StatisticDataManagerTests
    {
        private IStatisticDataManager<IDictionary<int, Stat>> _statisticDataManager;

        [TestMethod]
        public void WhenWeStoredThreeQuestion_ThenWeGetStats()        {

            var mock = new Mock<IStatisticDataAccess<StatDto>>();
            mock.Setup(x => x.GetDataAsync()).ReturnsAsync(SurveyDataMock.GetDataStats());
            _statisticDataManager = new StatisticDataManager(mock.Object);

            IDictionary<int, Stat> list =  _statisticDataManager.GetDataAsync().Result;
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(1, list[1].Id);
            Assert.AreEqual("Question 1", list[1].Text);
            Assert.AreEqual(2, list[1].StatResult.Count);

            Assert.AreEqual(2, list[2].Id);
            Assert.AreEqual("Question 2", list[2].Text);
            Assert.AreEqual(3, list[3].Id);
            Assert.AreEqual("Question 3", list[3].Text);

        }
    }
}
