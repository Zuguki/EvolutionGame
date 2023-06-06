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

        private static float _value;

        static WindSpeed()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0;
        public static float MaxValue => 80;
        public static float DefaultValue => 4;
        public static float Value
        {
            get => _value;
            set
            {
                if (value >= MaxValue)
                    _value = MaxValue;
                else if (value <= MinValue)
                    _value = MinValue;
                else
                    _value = value;
            }
        }
    }
}