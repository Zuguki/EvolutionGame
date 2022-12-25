using ComfortWeather;

namespace Population
{
    public interface IPopulation
    {
        public int DaysAlive { get; set; }
        public float MinBodyTemperature { get; }
        public float BodyTemperature { get; set; }
        public float MaxBodyTemperature { get; }
        
        public (float, float) MinArterialPressure { get; }
        public (float, float) ArterialPressure { get; set; }
        public (float, float) MaxArterialPressure { get; }
        
        public float MinWaterInBody { get; }
        public float WaterInBody { get; set; }
        public float MaxWaterInBody { get; }
        
        public float MinRadiation { get; }
        public float Radiation { get; set; }
        public float MaxRadiation { get; }
        public bool IsAlive { get; }
        
        public void UpdateParams();
    }
}