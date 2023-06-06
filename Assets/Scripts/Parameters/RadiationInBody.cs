namespace Parameters
{
    public class RadiationInBody
    {
        public static string Title = "Радиация в организме";

        public static string Details1 =
            "Радиация в организме — это количество ионизированных частиц(радиации) в теле человека.";

        public static string Details2 = "мкЗв / с - микрозиверт в сутки";

        public static string Details3 =
            $"Минимальное значение: {MinValue}мкЗв / с\nСреднее значение: {DefaultValue}мкЗв / с\nМаксимальное значение: {MaxValue}мкЗв / с";

        public static float MinValue => 0;
        public static float MaxValue => 10_000_000;
        public static float DefaultValue => 20;
        public static float Value { get; set; }

        static RadiationInBody()
        {
            Value = DefaultValue;
        }
    }
}