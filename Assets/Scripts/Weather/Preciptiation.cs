namespace Weather
{
    public class Preciptiation
    {
        public static string Title = "Количество Осадков";

        public static string Details1 =
            "Атмосферные осадки, количество осадков(precipitation) — атмосферные явления, связанные с присутствием в атмосфере воды в жидком или твёрдом состоянии, выпадающей из облаков или осаждающейся из воздуха на земную поверхность и какие-либо предметы.";

        public static string Details2 = "мм/год - миллиметры в год";

        public static string Details3 =
            $"Минимальное значение: {MinValue}мм/год\nСреднее значение: {DefaultValue}мм/год\nМаксимальное значение: {MaxValue}мм/год";
        
        public static float MinValue => 100;
        public static float MaxValue => 8000;
        public static float DefaultValue => 1000;
        public static float Value { get; set; }

        static Preciptiation()
        {
            Value = DefaultValue;
        }
    }
}