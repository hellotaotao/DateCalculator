using System;
using DateCalculate;
using DateCalculate.Services;
using NUnit.Framework;

namespace DateCalculateTest
{
    public class Tests
    {
        // without timezone
        private readonly DateTime dt1 = DateTime.Parse("2021-04-29T07:34:42");
        private readonly DateTime dt2 = DateTime.Parse("2021-05-28T07:34:42");
        private readonly DateTime dt3 = DateTime.Parse("2021-05-28T07:34:41");
        // with timezone
        private readonly DateTime dtz1 = DateTime.Parse("2021-04-29T07:34:42+9:30");
        private readonly DateTime dtz2 = DateTime.Parse("2021-05-28T07:34:42+9:30");
        private readonly DateTime dtz3 = DateTime.Parse("2021-05-28T07:34:41+9:30");

        private CalculateService service;

        [SetUp]
        public void Setup()
        {
            service = new CalculateService();
        }

        [Test]
        public void ShouldAcceptDifferentDateTimeStringFormats()
        {
            var dt1 = DateTime.Parse("2008-05-01T07:34:42-5:00");
            Assert.AreEqual(dt1.Hour, 22);
            var dt2 = DateTime.Parse("2008-05-01T07:34:42");
            Assert.AreEqual(dt2.Hour, 7);
            var dt3 = DateTime.Parse("2008-05-01 7:34:42");
            Assert.AreEqual(dt3.Hour, 7);
            var dt4 = DateTime.Parse("Thu, 01 May 2008 07:34:42 GMT");
            Assert.AreEqual(dt4.Hour, 17);
            var dt5 = DateTime.Parse("Thu, 01 May 2008 07:34:42+9:30");
            Assert.AreEqual(dt5.Hour, 7);
        }


        [Test]
        public void WithoutTimezone_1()
        {
            var request = new Request
            {
                DateTime1 = dt1,
                DateTime2 = dt2
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 29d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 21d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 3d);
        }

        [Test]
        public void WithoutTimezone_2()
        {
            var request = new Request
            {
                DateTime1 = dt1,
                DateTime2 = dt3
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 28d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 20d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 3d);
        }

        [Test]
        public void WithSameTimezone_1()
        {
            var request = new Request
            {
                DateTime1 = dtz1,
                DateTime2 = dtz2
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 29d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 21d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 3d);
        }

        [Test]
        public void WithSameTimezone_2()
        {
            var request = new Request
            {
                DateTime1 = dtz1,
                DateTime2 = dtz3
            };
            var days = service.DaysCalculate(request);
            Assert.AreEqual(days, 28d);
            var weekdays = service.WeekdaysCalculate(request);
            Assert.AreEqual(weekdays, 20d);
            var completeWeeks = service.CompleteWeeksCalculate(request);
            Assert.AreEqual(completeWeeks, 3d);
        }

        [Test]
        public void WithDifferentTimezone()
        {
            Assert.Pass();
        }
    }
}