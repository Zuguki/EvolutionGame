using System;
using System.Linq;
using ComfortWeather;

namespace Weather
{
    public class Pressure
    {
        public static float MinValue => 641;
        public static float MaxValue => 854;
        public static float DefaultValue => 760;
        public static float Value { get; set; }
        
        private const int BoundOfDays = 90;

        private static readonly float[] Pressures = new float[BoundOfDays];
        private static int PressureCounter
        {
            get => _counter % 90;
            set => _counter = value;
        }
        
        private static int _counter;

        static Pressure()
        {
            Value = DefaultValue;
        }
        
        public static float GetMiddlePressure(IComfortWeather comfortWeather)
        {
            if (_counter < BoundOfDays)
                return comfortWeather.Pressure;

            return (float) Math.Round(Pressures.Sum() / BoundOfDays, 1);
        }

        public static void AddPressure() =>
            Pressures[PressureCounter++] = Value;
    }
}