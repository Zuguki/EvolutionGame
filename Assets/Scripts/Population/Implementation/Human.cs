using ComfortWeather;
using ComfortWeather.Implementation;
using Weather;

namespace Population.Implementation
{
    public class Human : IPopulation
    {
        public int DaysAlive { get; set; } = 0;
        
        public float MinBodyTemperature => 26;
        public float BodyTemperature { get; set; } = 36;
        public float MaxBodyTemperature => 42;

        public (float, float) MinArterialPressure => (80, 60);
        public (float, float) ArterialPressure { get; set; } = (120f, 80f);
        public (float, float) MaxArterialPressure => (240, 100);

        public float MinWaterInBody => 0.4f;
        public float WaterInBody { get; set; } = 0.6f;
        public float MaxWaterInBody => 0.8f;
        
        public float MinRadiation { get; }
        public float Radiation { get; set; }
        public float MaxRadiation { get; }

        private const float StartBodyTemperature = 36;
        private const int IterationDays = 90;
        private readonly IComfortWeather _comfortWeather = new HumanComfortWeather();

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
        }

        public bool IsAlive =>
            BodyTemperature is > 26 and < 42 && Radiation < 3000 && Pressure.Value is > 700 and < 800;

        private void UpdateTemperature()
        {
            if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
                BodyTemperature += 1.5f / IterationDays;
            if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
                BodyTemperature -= 2f / IterationDays;
            
            if (WindSpeed.Value > 20 && Temperature.Value < 10)
                BodyTemperature -= 1f / IterationDays;
            if (WindSpeed.Value > 40 && Temperature.Value < 10)
                BodyTemperature -= 2f / IterationDays;
            if (WindSpeed.Value > 70 && Temperature.Value < 10)
                BodyTemperature -= 3f / IterationDays;

            if (Humidity.Value is > 0 and < 50 && Temperature.Value < 10)
                BodyTemperature -= 1f / IterationDays;
            if (Humidity.Value is > 50 and < 100 && Temperature.Value < 10)
                BodyTemperature -= 2.5f / IterationDays;
            if (Humidity.Value is > 0 and < 50 && Temperature.Value > 20)
                BodyTemperature += 1f / IterationDays;
            if (Humidity.Value is > 0 and < 50 && Temperature.Value > 20)
                BodyTemperature += 1f / IterationDays;
        }

        private void UpdateArterialPressure()
        {
            var upgrade = (BodyTemperature - StartBodyTemperature) / 0.5f;
            var downgrade = (StartBodyTemperature - BodyTemperature) / 1f;

            if (upgrade > 0)
                ArterialPressure = (ArterialPressure.Item1 + 8f * upgrade / IterationDays,
                    ArterialPressure.Item2 + 1 * upgrade / IterationDays);
            else if (downgrade > 0)
                ArterialPressure = (ArterialPressure.Item1 - 4 * downgrade / IterationDays,
                    ArterialPressure.Item2 - 2 * upgrade / IterationDays);
        }

        private void UpdateWaterInBody()
        {
            if (BodyTemperature >= 39)
                WaterInBody -= .1f / IterationDays;
            if (BodyTemperature is > 36 and < 37)
                WaterInBody = .6f;
        }
    }
}