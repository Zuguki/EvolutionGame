namespace Parameters
{
    public class BodyTemperature
    {
        public static string Title = "Температура тела";

        public static string Details1 =
            "Температура тела — комплексный показатель теплового состояния организма, определяемый с помощью всех органов человека, сосудов, нервной системой.";

        public static string Details2 = "°C - градус цельсия";

        public static string Details3 =
            $"Минимальное значение: {MinValue}°C\nСреднее значение: {DefaultValue}°C\nМаксимальное значение: {MaxValue}°C";

        public static float MinValue => 26;
        public static float MaxValue => 42;
        public static float DefaultValue => 36.6f;
        public static float Value { get; set; }

        static BodyTemperature()
        {
            Value = DefaultValue;
        }
    }
}