namespace Weather
{
    public class WindSpeed
    {
        public static string Title = "Скорость ветра";

        public static string Details1 =
            "Базовое представление Скорость ветра(windSpeed) — величина скорости, которая характеризует перемещение потоков ветра(воздуха) на Земле.";

        public static string Details2 = "м/с - метры в секунду";

        public static string Details3 =
            $"Минимальное значение: {MinValue}м/с\nСреднее значение: {DefaultValue}м/с\nМаксимальное значение: {MaxValue}м/с";
        
        public static float MinValue => 0;
        public static float MaxValue => 80;
        public static float DefaultValue => 10;
        public static float Value { get; set; }

        static WindSpeed()
        {
            Value = DefaultValue;
        }
    }
}