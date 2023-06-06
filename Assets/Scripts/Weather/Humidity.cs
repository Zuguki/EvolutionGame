namespace Weather
{
    public class Humidity
    {
        public static string Title = "Влажность воздуха";

        public static string Details1 =
            "Влажность(humidity) — показатель содержания воды в физических телах или средах.  Величина, характеризующая содержание водяных паров в атмосфере Земли — одна из наиболее существенных характеристик погоды и климата.";

        public static string Details2 = "% - проценты";

        public static string Details3 =
            $"Минимальное значение: {MinValue}%\nСреднее значение: {DefaultValue}%\nМаксимальное значение: {MaxValue}%";

        private static float _value;
        
        static Humidity()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0;
        public static float MaxValue => 100;
        public static float DefaultValue => 60;
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