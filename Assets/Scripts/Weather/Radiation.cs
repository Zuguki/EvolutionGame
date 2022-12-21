namespace Weather
{
    public class Radiation
    {
        public static float MinValue => 0;
        public static float MaxValue => 1000;
        public static float DefaultValue => 0;
        public static float Value { get; set; }

        static Radiation()
        {
            Value = DefaultValue;
        }
    }
}