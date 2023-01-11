using System;
using ComfortWeather;
using ComfortWeather.Implementation;
using UnityEngine;
using Weather;

namespace Population.Implementation
{
    public class Human : IPopulation
    {
        public string Name => "Human";
        public Sprite PopulationSprite => SpritesManager.HumanSprite;
        public int DaysAlive { get; set; } = 0;

        public float BodyTemperature
        {
            get => _bodyTemperature;
            set
            {
                _bodyTemperature = _bodyTemperature switch
                {
                    < 26 => 26,
                    > 42 => 42,
                    _ => value
                };
            }
        }

        public (float, float) ArterialPressure
        {
            get => _arterialPressure;
            set
            {
                if (_arterialPressure.Item1 < 80 && _arterialPressure.Item2 < 60)
                    _arterialPressure = (80f, 60f);
                if (_arterialPressure.Item1 > 240 && _arterialPressure.Item2 > 100)
                    _arterialPressure = (240f, 100f);
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

        private float _bodyTemperature = 36;
        private (float, float) _arterialPressure = (120f, 80f);
        private float _radiation = 100;

        private const float StartBodyTemperature = 36;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (120f, 80f);
        private readonly IComfortWeather _comfortWeather = new HumanComfortWeather();

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
        }

        // TODO: Change Pressure value
        public bool IsAlive =>
            BodyTemperature is > 26 and < 42 && Radiation < 3000 && Pressure.Value is > 700 and < 800 &&
            BloodInBody >= 3 && Radiation < 4000;

        private void UpdateTemperature()
        {
            if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
                BodyTemperature += 1.5f / IterationDays;
            if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
                BodyTemperature -= 2f / IterationDays;
            
            if (WindSpeed.Value > 20 && Temperature.Value < 10 && WindSpeed.Value < 40)
                BodyTemperature -= 1f / IterationDays;
            if (WindSpeed.Value > 40 && Temperature.Value < 10 && WindSpeed.Value < 70)
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
                BodyTemperature += 2f / IterationDays;
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
    }
}