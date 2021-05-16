using System;

namespace DateCalculate
{
    public class Request
    {
        public DateTime DateTime1 { get; set; }
        public DateTime DateTime2 { get; set; }
        
        public ReturnUnit? Unit { get; set; }
    }

    public enum ReturnUnit
    {
        Seconds,
        Minutes,
        Hours,
        Years
    }
}
