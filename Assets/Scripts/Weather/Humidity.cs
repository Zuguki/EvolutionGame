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
        
        public static float MinValue => 0;
        public static float MaxValue => 100;
        public static float DefaultValue => 60;
        public static float Value { get; set; }

        static Humidity()
        {
            Value = DefaultValue;
        }
    }
}