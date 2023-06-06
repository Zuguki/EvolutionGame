namespace Weather
{
    public class Radiation
    {
        public static string Title = "Радиация";

        public static string Details1 =
            "Радиация(radiation) — это совокупность излучений, способных ионизировать вещество, тем самым вызывая в нем спонтанный распад атомов. Нельзя вызвать с помощью химических реакций.";

        public static string Details2 = "мЗв/д - микрозиверт в день";

        public static string Details3 =
            $"Минимальное значение: {MinValue}мЗв/д\nСреднее значение: {DefaultValue}мЗв/д\nМаксимальное значение: {MaxValue}мЗв/д";

        private static float _value;
        
        static Radiation()
        {
            Value = DefaultValue;
        }
        
        public static float MinValue => 0;
        public static float MaxValue => 7_000_000;
        public static float DefaultValue => 0;
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