using System;

namespace DateCalculate.Services
{
    public class CalculateService : ICalculateService
    {
        public double DaysCalculate(Request request)
        {
            var days = (int) Math.Abs((request.DateTime1 - request.DateTime2).TotalDays);
            return Convert(days, request.Unit);
        }

        public double WeekdaysCalculate(Request request)
        {
            var (start, end) = GetStartAndEnd(request);

            if ((end - start).TotalDays < 1) return 0;

            double value = 0;

            // if start is in weekend, find the next Monday 12:00am
            value += (start.Date.AddDays(1) - start).TotalDays;
            start = start.Date.AddDays(1);

            // if end is in weekend, find the previous Saturday 12:00am
            value += (end - end.Date).TotalDays;
            end = end.Date;

            while (start < end)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                    value++;
                start = start.AddDays(1);
            }

            int weekdays = (int) Math.Abs(value);

            return Convert(weekdays, request.Unit);
        }

        // The system for numbering weeks is the ISO week date system, which is included in ISO 8601. This system dictates that each week begins on a Monday (https://en.wikipedia.org/wiki/Week)
        public double CompleteWeeksCalculate(Request request)
        {
            var (start, end) = GetStartAndEnd(request);

            if ((end - start).TotalDays < 7) return 0;
            
            // find the first Monday 12:00:00 am after start
            // unless start is already Monday 12:00:00 am
            if (!(start.DayOfWeek == DayOfWeek.Monday && start == start.Date))
            {
                start = start.Date;
                while (start.DayOfWeek != DayOfWeek.Monday)
                {
                    start = start.AddDays(1);
                }
            }
            
            // find the last Monday 12:00:00 am before end
            // unless end is already Monday 12:00:00 am
            if (!(end.DayOfWeek == DayOfWeek.Monday && end == end.Date))
            {
                end = end.Date;
                while (end.DayOfWeek != DayOfWeek.Monday)
                {
                    end = end.AddDays(-1);
                }
            }

            var completeWeeks = (int)((end - start).TotalDays / 7);

            if (request.Unit == null)
                return completeWeeks;

            return Convert(completeWeeks * 7, request.Unit);
        }

        private double Convert(int days, ReturnUnit? unit)
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

        private static (DateTime, DateTime) GetStartAndEnd(Request request)
        {
            var start = request.DateTime1;
            var end = request.DateTime2;
            if (start > end)
            {
                start = request.DateTime2;
                end = request.DateTime1;
            }

            return (start, end);
        }
    }
}