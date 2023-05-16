namespace ComfortWeather
{
    public interface IComfortWeather
    {
        public float MinTemperature { get; }
        public float MaxTemperature { get; }
        
        public float MinPressure { get; }
        public float MaxPressure { get; }
        
        public float MinRadiation { get; }
        public float MaxRadiation { get; }
        
        public float MinHumidity { get; }
        public float MaxHumidity { get; }
        
        public float MinWindSpeed { get; }
        public float MaxWindSpeed { get; }
        
        public float MinPreciptiation { get; }
        public float MaxPreciptiation { get; }
        
        public float MinAirQuality { get; }
        public float MaxAirQuality { get; }
        
        public float MinNoise { get; }
        public float MaxNoise { get; }
        
        public float MinSoilPurity { get; }
        public float MaxSoilPurity { get; }
        
        public float TemperatureWeather { get; }
        public float Pressure { get; }
        public float Radiation { get; }
        public float Humidity { get; }
        public float WindSpeed { get; }
        public float Preciptiation { get; }
    }
}