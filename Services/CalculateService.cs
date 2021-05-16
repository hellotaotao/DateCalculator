using System;

namespace DateCalculate.Services
{
    public static class CalculateService
    {
        public static int DaysCalculate(Request request)
        {
            var days = (request.dateTime1 - request.dateTime2).TotalDays;
            return (int)Math.Abs(days);
        }
        
        public static int WeekdaysCalculate(Request request)
        {
            var start = request.dateTime1;
            var end = request.dateTime2;

            var weekdays = 0;

            while (start < end)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    weekdays++;
                start = start.AddDays(1);
            }
            return Math.Abs(weekdays);
        }

        public static int CompleteWeeksCalculate(Request request)
        {
            var days = (request.dateTime1 - request.dateTime2).TotalDays;
            return (int) Math.Abs(days) / 7;
        }
    }
}