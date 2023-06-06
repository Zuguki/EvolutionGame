namespace Weather
{
    public static class AirQuality
    {
        
        public static string Title = "Качество воздуха";

        public static string Details1 =
            "Индекс качества воздуха (AQI) — измерение концентрации загрязняющих веществ в атмосферном воздухе и связанных с ними рисков для здоровья, погоды и климата.";

        public static string Details2 = "AQI - число аки";

        public static string Details3 =
            $"Минимальное значение: {MinValue}AQI\nСреднее значение: {DefaultValue}AQI\nМаксимальное значение: {MaxValue}AQI";
        
        private static float _value;
        
        static AirQuality()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0;
        public static float MaxValue => 500;
        public static float DefaultValue => 90;
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