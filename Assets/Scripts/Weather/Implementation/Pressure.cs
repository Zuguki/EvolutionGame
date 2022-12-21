namespace Weather.Implementation
{
    public class Pressure
    {
        public static float MinValue => 641;
        public static float MaxValue => 854;
        public static float DefaultValue => 760;
        public static float Value { get; set; }

        static Pressure()
        {
            Value = DefaultValue;
        }
    }
}