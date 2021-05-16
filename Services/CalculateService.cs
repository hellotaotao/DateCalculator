using System;

namespace DateCalculate.Services
{
    public static class CalculateService
    {
        public static int DaysCalculate(Request request)
        {
            var days = (request.DateTime1 - request.DateTime2).TotalDays;
            return (int)Math.Abs(days);
        }
        
        public static int WeekdaysCalculate(Request request)
        {
            var start = request.DateTime1;
            var end = request.DateTime2;

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
            var days = (request.DateTime1 - request.DateTime2).TotalDays;
            return (int) Math.Abs(days) / 7;
        }
    }
}