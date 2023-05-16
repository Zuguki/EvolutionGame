using System;
using System.Linq;
using ComfortWeather;

namespace Weather
{
    public class Pressure
    {
        public static string Title = "Давление";

        public static string Details1 =
            "Атмосферное давление(pressure) — сила, которая давит на все предметы, находящиеся на Земле и на саму земную поверхность со стороны атмосферы.";

        public static string Details2 = "мм рт ст - миллиметры ртутного столба";

        public static string Details3 =
            $"Минимальное значение: {MinValue}мм рт ст\nСреднее значение: {DefaultValue}мм рт ст\nМаксимальное значение: {MaxValue}мм рт ст";
        
        public static float MinValue => 700;
        public static float MaxValue => 800;
        public static float DefaultValue => 750;
        public static float Value { get; set; }

        static Pressure()
        {
            Value = DefaultValue;
        }
    }
}