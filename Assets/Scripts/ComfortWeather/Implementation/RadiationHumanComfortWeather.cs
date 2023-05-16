namespace ComfortWeather.Implementation
{
    public class RadiationHumanComfortWeather : IComfortWeather
    {
        public float MinTemperature => 19;
        public float MaxTemperature => 27;

        public float MinPressure => 710;
        public float MaxPressure => 730;

        public float MinRadiation => 0;
        public float MaxRadiation => 30;

        public float MinHumidity => 0.1f;
        public float MaxHumidity => 0.3f;

        public float MinWindSpeed => 0;
        public float MaxWindSpeed => 10;

        public float MinPreciptiation => 100;
        public float MaxPreciptiation => 350;

        public float MinAirQuality => 0;
        public float MaxAirQuality => 100;

        public float MinNoise => 40;
        public float MaxNoise => 55;

        public float MinSoilPurity => 0.85f;
        public float MaxSoilPurity => 0.98f;
        
        public float TemperatureWeather => 20;
        public float Pressure => 710;
        public float Radiation => 300;
        public float Humidity => 15;
        public float WindSpeed => 5;
        public float Preciptiation => 275;
    }
}