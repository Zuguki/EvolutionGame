namespace Population.ComfortWeather.Implementation
{
    public class ColdHumanComfortWeather : IComfortWeather
    {
        public float MinTemperature => 0;
        public float MaxTemperature => 18;

        public float MinPressure => 770;
        public float MaxPressure => 790;

        public float MinRadiation => 0;
        public float MaxRadiation => 15;

        public float MinHumidity => 0.2f;
        public float MaxHumidity => 0.5f;

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
        
        public float TemperatureWeather => 0;
        public float Pressure => 780;
        public float Radiation => 70;
        public float Humidity => 35;
        public float WindSpeed => 5;
        public float Preciptiation => 200;
    }
}