using System;

namespace DateCalculate.Services
{
    public static class CalculateService
    {
        public static double DaysCalculate(Request request)
        {
            var days = (int)Math.Abs((request.DateTime1 - request.DateTime2).TotalDays);
            return Convert(days, request.Unit);
        }

        public static double WeekdaysCalculate(Request request)
        {
            var start = request.DateTime1;
            var end = request.DateTime2;
            if (start > end)
            {
                start = request.DateTime2;
                end = request.DateTime1;
            }

            var weekdays = 0;

            while (start < end)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    weekdays++;
                start = start.AddDays(1);
            }

            return Convert(weekdays, request.Unit);
        }

        public static double CompleteWeeksCalculate(Request request)
        {
            var days = (int)Math.Abs((request.DateTime1 - request.DateTime2).TotalDays);
            return Convert(days / 7, request.Unit);
        }

        private static double Convert(int days, ReturnUnit? unit)
        {
            switch (unit)
            {
                case ReturnUnit.Seconds:
                    return days * 24 * 3600;
                case ReturnUnit.Minutes:
                    return days * 24 * 60;
                case ReturnUnit.Hours:
                    return days * 24;
                case ReturnUnit.Years:
                    return days / 365.0;
                default:
                    return days;
            }
        }
    }
}