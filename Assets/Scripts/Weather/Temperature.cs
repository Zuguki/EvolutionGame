namespace Weather
{
    public static class Temperature
    {
        public static string Title = "Температура";

        public static string Details1 =
            "Температура окружающей среды(temperature) — температура воздуха на Земле, которая оказывает температурное влияние на все предметы на Земле (изменение внутренней энергии предмета, изменение агрегатного состояния, процесс обмена энергии между воздухом и окружающей средой)";

        public static string Details2 = "°C - градус цельсия";

        public static string Details3 =
            $"Минимальное значение: {MinValue}°C\nСреднее значение: {DefaultValue}°C\nМаксимальное значение: {MaxValue}°C";

        public static float MinValue => -82.2f;
        public static float MaxValue => 56.7f;
        public static float DefaultValue => 15;
        public static float Value { get; set; }
        
        static Temperature()
        {
            Value = DefaultValue;
        }
    }
}