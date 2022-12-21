namespace Weather
{
    public class WindSpeed
    {
        public static float MinValue => 0;
        public static float MaxValue => 80;
        public static float DefaultValue => 10;
        public static float Value { get; set; }

        static WindSpeed()
        {
            Value = DefaultValue;
        }
    }
}