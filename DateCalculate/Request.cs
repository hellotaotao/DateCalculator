using System;
using System.ComponentModel.DataAnnotations;

namespace DateCalculate
{
    public class Request
    {
        [Required]
        public DateTime DateTime1 { get; set; }
        
        [Required]
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
