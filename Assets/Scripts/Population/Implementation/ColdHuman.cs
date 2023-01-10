using System;
using ComfortWeather;
using ComfortWeather.Implementation;
using Weather;

namespace Population.Implementation
{
    public class ColdHuman : IUnionPopulation
    {
        public string Name => "ColdHuman";
        public int DaysAlive { get; set; } = 0;
        
        public float BodyTemperature
        {
            get => _bodyTemperature;
            set
            {
                _bodyTemperature = _bodyTemperature switch
                {
                    < 30 => 30,
                    > 40 => 40,
                    _ => value
                };
            }
        }

        public (float, float) ArterialPressure
        {
            get => _arterialPressure;
            set
            {
                if (_arterialPressure.Item1 < 70 && _arterialPressure.Item2 < 55)
                    _arterialPressure = (70f, 55f);
                if (_arterialPressure.Item1 > 220 && _arterialPressure.Item2 > 95)
                    _arterialPressure = (110f, 75f);
                else
                    _arterialPressure = value;
            }
        }

        public float WaterInBody { get; set; } = .6f;

        public float BloodInBody { get; set; } = 5;

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

        private float _bodyTemperature = 34;
        private (float, float) _arterialPressure = (110f, 75f);
        private float _radiation = 70;

        private const float StartBodyTemperature = 38;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (150f, 85f);
        private readonly IComfortWeather _comfortWeather = new ColdHumanComfortWeather();

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
        }

        // TODO: Change
        public bool IsAlive =>
            BodyTemperature is > 24 and < 40 && Radiation < 2000 && BloodInBody >= 3;

        private void UpdateTemperature()
        {
            if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
                BodyTemperature += 1.5f / IterationDays;
            if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
                BodyTemperature -= 2f / IterationDays;
            
            if (WindSpeed.Value is > 5 and < 20 && Temperature.Value < -10)
                BodyTemperature -= 1f / IterationDays;
            if (WindSpeed.Value is >= 20 and < 30 && Temperature.Value < -10)
                BodyTemperature -= 2f / IterationDays;
            if (WindSpeed.Value > 30 && Temperature.Value < -10)
                BodyTemperature -= 3f / IterationDays;

            if (Humidity.Value is > 0 and < 30 && Temperature.Value < -10)
                BodyTemperature -= 1f / IterationDays;
            if (Humidity.Value is > 30 and < 60 && Temperature.Value < -10)
                BodyTemperature -= 2f / IterationDays;
            if (Humidity.Value is > 60 and < 100 && Temperature.Value < -10)
                BodyTemperature -= 3f / IterationDays;
            
            if (Humidity.Value is > 0 and < 30 && Temperature.Value > 10)
                BodyTemperature += 1f / IterationDays;
            if (Humidity.Value is > 30 and < 60 && Temperature.Value > 10)
                BodyTemperature += 2f / IterationDays;
            if (Humidity.Value is > 60 and < 100 && Temperature.Value > 10)
                BodyTemperature += 3f / IterationDays;
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
            if (BodyTemperature >= 36)
                WaterInBody -= .1f / IterationDays;
            if (BodyTemperature is > 33.5f and < 34.5f)
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
                && currentPopulation.BodyTemperature > 34 && currentPopulation.BodyTemperature < 35
                && currentPopulation.Radiation is > 400 and < 590
                && currentPopulation.ArterialPressure.Item1 > 110 && currentPopulation.ArterialPressure.Item2 > 75
                && currentPopulation.ArterialPressure.Item1 < 130 && currentPopulation.ArterialPressure.Item2 < 90)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}