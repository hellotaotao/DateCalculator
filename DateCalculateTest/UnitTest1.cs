using System;
using NUnit.Framework;
using DateCalculate;
using DateCalculate.Services;

namespace DateCalculateTest
{
    public class Tests
    {
        // without timezone
        private readonly DateTime dt1 = DateTime.Parse("2021-04-29T07:34:42");
        private readonly DateTime dt2 = DateTime.Parse("2021-05-28T07:34:42");
        // with timezone
        private readonly DateTime dt3 = DateTime.Parse("2021-04-29T07:34:42+9:30");
        private readonly DateTime dt4 = DateTime.Parse("2021-05-28T07:34:42+9:30");

        private CalculateService service;
        
        [SetUp]
        public void Setup()
        {
            service = new CalculateService();
        }
        
        // TODO: Test with different DateTime string formats
        
        
        [Test]
        public void WithoutTimezone()
        {
            var request = new Request
            {
                DateTime1 = dt1,
                DateTime2 = dt2
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 29d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 20d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 4d);
        }

        [Test]
        public void WithSameTimezone()
        {
            var request = new Request
            {
                DateTime1 = dt3,
                DateTime2 = dt4
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 29d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 20d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 4d);
        }
        
        [Test]
        public void WithDifferentTimezone()
        {
            Assert.Pass();
        }
    }
}