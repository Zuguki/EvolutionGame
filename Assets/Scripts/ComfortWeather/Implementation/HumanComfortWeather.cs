namespace ComfortWeather.Implementation
{
    public class HumanComfortWeather : IComfortWeather
    {
        public float TemperatureWeather => 21;
        public float Pressure => 760;
        public float Radiation => 20;
        public float Humidity => 20;
        public float WindSpeed => 3;
        public float Preciptiation => 300;
    }
}