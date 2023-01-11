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
        private const int BoundOfDays = 90;

        private static readonly float[] Temperatures = new float[BoundOfDays];
        private static int TemperatureCounter
        {
            get => _counter % 90;
            set => _counter = value;
        }
        
        private static int _counter;
        
        static Temperature()
        {
            Value = DefaultValue;
        }

        public static float GetMiddleTemperature(IComfortWeather comfortWeather)
        {
            if (_counter < BoundOfDays)
                return comfortWeather.TemperatureWeather;

            return (float) Math.Round(Temperatures.Sum() / BoundOfDays, 1);
        }

        public static void AddTemperature() =>
            Temperatures[TemperatureCounter++] = Value;
    }
}