namespace Weather
{
    public class SoilPurity
    {
        public static float MinValue => 0.7f;
        public static float MaxValue => 0.98f;
        public static float DefaultValue => 0.85f;
        public static float Value { get; set; }

        static SoilPurity()
        {
            Value = DefaultValue;
        }
    }
}