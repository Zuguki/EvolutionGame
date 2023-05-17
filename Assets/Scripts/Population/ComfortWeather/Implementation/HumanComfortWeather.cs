namespace Population.ComfortWeather.Implementation
{
    public class HumanComfortWeather : IComfortWeather
    {
        public float MinTemperature => 18;
        public float MaxTemperature => 24;

        public float MinPressure => 740;
        public float MaxPressure => 760;

        public float MinRadiation => 0;
        public float MaxRadiation => 20;

        public float MinHumidity => 0.55f;
        public float MaxHumidity => 0.7f;

        public float MinWindSpeed => 0;
        public float MaxWindSpeed => 5;

        public float MinPreciptiation => 100;
        public float MaxPreciptiation => 500;

        public float MinAirQuality => 0;
        public float MaxAirQuality => 100;

        public float MinNoise => 40;
        public float MaxNoise => 55;

        public float MinSoilPurity => 0.85f;
        public float MaxSoilPurity => 0.98f;
        
        public float TemperatureWeather => 21;
        public float Pressure => 760;
        public float Radiation => 20;
        public float Humidity => 20;
        public float WindSpeed => 3;
        public float Preciptiation => 300;
    }
}