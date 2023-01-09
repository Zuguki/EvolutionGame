using System;
using ComfortWeather;
using ComfortWeather.Implementation;
using Weather;

namespace Population.Implementation
{
    public class FireHuman : IPopulation, ITryOpenPopulation
    {
        public int DaysAlive { get; set; } = 0;
        
        public float BodyTemperature
        {
            get => _bodyTemperature;
            set
            {
                _bodyTemperature = _bodyTemperature switch
                {
                    < 32 => 32,
                    > 44 => 44,
                    _ => value
                };
            }
        }

        public (float, float) ArterialPressure
        {
            get => _arterialPressure;
            set
            {
                if (_arterialPressure.Item1 < 90 && _arterialPressure.Item2 < 75)
                    _arterialPressure = (90f, 75f);
                if (_arterialPressure.Item1 > 250 && _arterialPressure.Item2 > 105)
                    _arterialPressure = (250f, 105f);
                else
                    _arterialPressure = value;
            }
        }

        public float WaterInBody { get; set; } = .45f;

        public float BloodInBody
        {
            get => _bloodInBody;
            set
            {
                _bloodInBody = _bloodInBody switch
                {
                    < 3 => 3,
                    _ => value
                };
            }
        }

        public float Radiation
        {
            get => _radiation;
            set
            {
                _radiation = _radiation switch
                {
                    < 0 => 0,
                    > 7000 => 7000,
                    _ => value
                };
            }
        }

        private float _bodyTemperature = 38;
        private (float, float) _arterialPressure = (150f, 85f);
        private float _bloodInBody = 5;
        private float _radiation = 200;

        private const float StartBodyTemperature = 38;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (150f, 85f);
        private readonly IComfortWeather _comfortWeather = new FireHumanComfortWeather();

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
        }

        public bool IsAlive =>
            BodyTemperature is > 32 and < 44 && Radiation < 3000 && Pressure.Value is > 700 and < 800 &&
            BloodInBody >= 3 && Radiation < 4000;

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

        private void UpdateBloodInBody()
        {
            if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 20)
                BloodInBody -= .5f / IterationDays;
            if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) <= 10)
                BloodInBody += .1f / IterationDays;
            
            if (BloodInBody >= 5f)
                BloodInBody = 5f;
        }

        private void UpdateRadiation()
        {
            if (Weather.Radiation.Value < 500)
                Radiation -= 500f / IterationDays;
            if (Weather.Radiation.Value > 1000)
                Radiation += 500f / IterationDays;

            if (Radiation <= 0)
                Radiation = 0;
            if (Radiation >= 7000)
                Radiation = 7000;
        }


        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.BodyTemperature > 37.8 && currentPopulation.BodyTemperature < 38.2
                && currentPopulation.Radiation is > 500 and < 600
                && currentPopulation.ArterialPressure.Item1 > 150 && currentPopulation.ArterialPressure.Item2 < 170
                && currentPopulation.ArterialPressure.Item2 > 85 && currentPopulation.ArterialPressure.Item2 < 90)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}