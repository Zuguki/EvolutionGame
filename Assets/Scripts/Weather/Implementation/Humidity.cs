namespace Weather.Implementation
{
    public class Humidity
    {
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