namespace Population
{
    public interface IPopulationCantBe
    {
        public float MinTemperature { get; }
        public float MaxTemperature { get; }
        
        public float MinPressure { get; }
        public float MaxPressure { get; }
        
        public float MaxRadiation { get; }
        
        public float MaxAirQuality { get; }
        
        public float MinSoilPurity { get; }
        
        public float MaxNoise { get; }
        
        public float MaxWindSpeed { get; }
    }
}