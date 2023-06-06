namespace Weather
{
    public class Noise
    {
        public static string Title = "ШУМ";

        public static string Details1 =
            "Шум(noise) — беспорядочные колебания различной физической природы, отличающиеся сложностью временной и спектральной структуры. Колебания, воспринимаемые человеческим ухом и влияющие на нервную систему и состояние человека.";

        public static string Details2 = "дБ - децибелы";

        public static string Details3 =
            $"Минимальное значение: {MinValue}дб\nСреднее значение: {DefaultValue}дб\nМаксимальное значение: {MaxValue}дб";

        private static float _value;
        
        static Noise()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0;
        public static float MaxValue => 150;
        public static float DefaultValue => 50;
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