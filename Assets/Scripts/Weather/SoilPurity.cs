namespace Weather
{
    public class SoilPurity
    {
        public static string Title = "Чистота почвы";

        public static string Details1 =
            "Чистота почвы(soilPurity) — показатель состояния чистоты почвы, который характеризуется и выражается в санитарном числе.";

        public static string Details2 = "С - санитарное число";

        public static string Details3 =
            $"Минимальное значение: {MinValue}C\nСреднее значение: {DefaultValue}C\nМаксимальное значение: {MaxValue}C";

        private static float _value;

        static SoilPurity()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0.7f;
        public static float MaxValue => 0.98f;
        public static float DefaultValue => 0.85f;
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