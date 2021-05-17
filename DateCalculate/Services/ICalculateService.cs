namespace DateCalculate.Services
{
    public interface ICalculateService
    {
        double DaysCalculate(Request request);
        double WeekdaysCalculate(Request request);
        double CompleteWeeksCalculate(Request request);
    }
}