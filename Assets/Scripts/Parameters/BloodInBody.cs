namespace Parameters
{
    public class BloodInBody
    {
        public static string Title = "Объем крови";

        public static string Details1 =
            "Объем крови — количество крови, внутри тела человека, которая снабжает все его органы кислородом и питательными веществами и поддерживает стабильное состояние человека.";

        public static string Details2 = "Л - литры";

        public static string Details3 =
            $"Минимальное значение: {MinValue}Л\nМаксимальное значение: {MaxValue}Л";

        public static float MinValue => 3;
        public static float MaxValue => 5;
        public static float DefaultValue => 5;
        public static float Value { get; set; }

        static BloodInBody()
        {
            Value = DefaultValue;
        }
    }
}