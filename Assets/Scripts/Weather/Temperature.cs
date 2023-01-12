using System;
using System.Linq;
using ComfortWeather;
using Population;

namespace Weather
{
    public static class Temperature
    {
        public static float MinValue => -82;
        public static float MaxValue => 56;
        public static float DefaultValue => 0;
        public static float Value { get; set; }
        
        static Temperature()
        {
            Value = DefaultValue;
        }
    }
}