namespace Weather
{
    public static class Temperature
    {
        public static float MinValue => -82.2f;
        public static float MaxValue => 56.7f;
        public static float DefaultValue => 15;
        public static float Value { get; set; }
        
        static Temperature()
        {
            Value = DefaultValue;
        }
    }
}