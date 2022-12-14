using System;
using ComfortWeather;
using ComfortWeather.Implementation;
using UnityEngine;
using Weather;

namespace Population.Implementation
{
    public class ColdHuman : IUnionPopulation
    {
        public string Name => "ColdHuman";
        public Sprite SpriteOfMenu => SpritesManager.ColdHumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.ColdHumanPopulationSprite;
        public int DaysAlive { get; set; } = 0;
        public float BodyTemperature { get; set; } = 34f;
        public (float, float) ArterialPressure { get; set; } = (110f, 75f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public float Radiation { get; set; } = 70;

        private const float StartBodyTemperature = 34f;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (110f, 75f);
        private readonly IComfortWeather _comfortWeather = new ColdHumanComfortWeather();

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
        }

        public bool IsAlive =>
            BodyTemperature is >= 24 and <= 40 &&
            ArterialPressure.Item1 is >= 70 and <= 220 && ArterialPressure.Item2 is >= 55 and <= 95 &&
            (WaterInBody > .35 || WaterInBody <= .35 && Temperature.Value < 35) &&
            Temperature.GetMiddleTemperature(_comfortWeather) is <= 20 and >= -20 &&
            Radiation <= 2000 &&
            Pressure.GetMiddlePressure(_comfortWeather) is >= 750 and <= 820 &&
            BloodInBody >= 3;

        private void UpdateTemperature()
        {
            if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
                BodyTemperature += 1.5f * ((Temperature.Value - _comfortWeather.TemperatureWeather) / 5) /
                                   IterationDays;
            if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
                BodyTemperature -= 1.5f * ((_comfortWeather.TemperatureWeather - Temperature.Value) / 5) /
                                   IterationDays;
            
            if (WindSpeed.Value is > 5 and < 20 && Temperature.Value < 15)
                BodyTemperature -= 1f / IterationDays;
            if (WindSpeed.Value is >= 20 and < 30 && Temperature.Value < 15)
                BodyTemperature -= 2f / IterationDays;
            if (WindSpeed.Value >= 30 && Temperature.Value < 15)
                BodyTemperature -= 3f / IterationDays;

            if (Humidity.Value is > 0 and < 30 && Temperature.Value < 15)
                BodyTemperature -= 1f / IterationDays;
            if (Humidity.Value is >= 30 and < 60 && Temperature.Value < 15)
                BodyTemperature -= 2f / IterationDays;
            if (Humidity.Value >= 60 && Temperature.Value < 15)
                BodyTemperature -= 3f / IterationDays;
            if (Humidity.Value is >= 0 and < 30 && Temperature.Value > 30)
                BodyTemperature += 1f / IterationDays;
            if (Humidity.Value is >= 30 and < 60 && Temperature.Value > 30)
                BodyTemperature += 2f / IterationDays;
            if (Humidity.Value >= 60 && Temperature.Value > 30)
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
                    ArterialPressure.Item2 - 2 * downgrade / IterationDays);
        }

        private void UpdateWaterInBody()
        {
            if (BodyTemperature is >= 40 or <= 37)
                WaterInBody -= .1f / IterationDays;
            if (BodyTemperature is > 37.5f and < 38.5f)
                WaterInBody = .6f;
        }

        private void UpdateBloodInBody()
        {
            if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 20)
                BloodInBody -= .5f / IterationDays;
            if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 50)
                BloodInBody -= 1f / IterationDays;
            if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) <= 10)
                BloodInBody += .1f / IterationDays;
            
            if (BloodInBody >= 5f)
                BloodInBody = 5f;
        }

        private void UpdateRadiation()
        {
            if (Weather.Radiation.Value == 0)
                Radiation -= 400f / IterationDays;
            else if (Weather.Radiation.Value <= 400)
                Radiation -= (400f - Weather.Radiation.Value) / IterationDays;
            else if (Weather.Radiation.Value > 400)
                Radiation += Weather.Radiation.Value / IterationDays;

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