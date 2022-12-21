namespace Weather.Implementation
{
    public class Preciptiation
    {
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