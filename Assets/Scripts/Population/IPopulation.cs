using ComfortWeather;

namespace Population
{
    public interface IPopulation
    {
        public int DaysAlive { get; set; }
        public float BodyTemperature { get; set; }
        public (float, float) ArterialPressure { get; set; }
        public float WaterInBody { get; set; }
        public float Radiation { get; set; }
        public float BloodInBody { get; set; }
        public bool IsAlive { get; }
        
        public void UpdateParams();
    }
}