namespace Parameters
{
    public class WaterInBody
    {
        public static string Title = "Объем жидкости";

        public static string Details1 =
            "Объем жидкости — жидкость, которая направлена в организме на поддержание водного баланса в теле. Регулирует работоспособность всех органов.";

        public static string Details2 = "% - процент";

        public static string Details3 =
            $"Минимальное значение: {MinValue * 100}%\nСреднее значение: {DefaultValue * 100}%\nМаксимальное значение: {MaxValue * 100}%";

        public static float MinValue => 0.3f;
        public static float MaxValue => 0.75f;
        public static float DefaultValue => 0.6f;
        public static float Value { get; set; }

        static WaterInBody()
        {
            Value = DefaultValue;
        }
    }
}