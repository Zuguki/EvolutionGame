namespace ComfortWeather.Implementation
{
    public class HumanComfortWeather : IComfortWeather
    {
        public float TemperatureWeather => 15;
        public float Pressure => 760;
        public float Radiation => 1;
        public float Humidity => 20;
        public float WindSpeed => 5;
        public float Preciptiation => 300;
    }
}