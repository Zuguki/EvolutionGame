namespace ComfortWeather.Implementation
{
    public class FireHumanComfortWeather : IComfortWeather
    {
        public float TemperatureWeather => 25;
        public float Pressure => 710;
        public float Radiation => 2;
        public float Humidity => 20;
        public float WindSpeed => 5;
        public float Preciptiation => 200;
    }
}