namespace ComfortWeather
{
    public interface IComfortWeather
    {
        public float TemperatureWeather { get; }
        public float Pressure { get; }
        public float Radiation { get; }
        public float Humidity { get; }
        public float WindSpeed { get; }
        public float Preciptiation { get; }
    }
}