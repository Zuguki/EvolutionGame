namespace Parameters
{
    public static class ArterialPressure
    {
        public static string Title = "Артериальное давление";

        public static string Details1 =
            "Артериальное давление — давление, которое кровь оказывает на стенки кровеносных сосудов, иначе говоря, превышение давления жидкости в кровеносной системе над атмосферным.";

        public static string Details2 = "мм рт ст - миллиметры ртутного столба";

        public static string Details3 =
            $"Минимальное значение: {MinValue.ToCustomString()}мм рт ст\nСреднее значение: {DefaultValue.ToCustomString()}мм рт ст\nМаксимальное значение: {MaxValue.ToCustomString()}мм рт ст";
        
        public static (float, float) MinValue => (0, 0);
        public static (float, float) MaxValue => (300, 300);
        public static (float, float) DefaultValue => (120, 80);
        public static (float, float) Value { get; set; }

        static ArterialPressure()
        {
            Value = DefaultValue;
        }
    }
}