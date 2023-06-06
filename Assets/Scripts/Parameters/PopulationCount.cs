namespace Parameters
{
    public class PopulationCount
    {
        public static string Title = "Температура тела";

        public static string Details1 =
            "Температура тела — комплексный показатель теплового состояния организма, определяемый с помощью всех органов человека, сосудов, нервной системой.";

        public static string Details2 = "°C - градус цельсия";

        public static string Details3 =
            $"Минимальное значение: {MinValue}°C\nСреднее значение: {DefaultValue}°C\nМаксимальное значение: {MaxValue}°C";

        private static long _value;

        static PopulationCount()
        {
            Value = DefaultValue;
        }
        
        public static int MinValue => 1;
        public static long MaxValue => 10_000_000_000;
        public static int DefaultValue => 1_000_000;
        public static long Value
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