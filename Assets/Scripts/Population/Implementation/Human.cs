using System.Collections.Generic;
using ComfortWeather;
using ComfortWeather.Implementation;
using UnityEngine;
using Weather;

namespace Population.Implementation
{
    public class Human : IPopulation
    {
        public string Name => "Human";
        public Sprite SpriteOfMenu => SpritesManager.HumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.HumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.HumanPopulationSprite;

        public List<string> DeadMessages { get; set; } = new List<string>();
        
        public int DaysAlive { get; set; } = 0;
        public float BodyTemperature { get; set; } = 36.6f;
        public (float, float) ArterialPressure { get; set; } = (120f, 80f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public float Radiation { get; set; } = 100;

        private const float StartBodyTemperature = 36.5f;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (120f, 80f);
        private readonly IComfortWeather _comfortWeather = new HumanComfortWeather();
        private readonly IPopulationParamsUpdater _populationParamsUpdater = new PopulationParamsUpdater();
        private readonly IPopulationDeadParams _deadParams = new HumanDeadParams();
        
        private readonly float[] _temperatures = new float[IterationDays];
        private readonly float[] _pressures = new float[IterationDays];
        private int DaysCounter => DaysAlive % IterationDays;

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
            TryAddDeadMessage();
        }

        public bool IsAlive => DeadMessages.Count == 0;

        private void TryAddDeadMessage()
        {
            if (BodyTemperature < _deadParams.MinTemperature)
                DeadMessages.Add($"Температура тела должна быть больше чем {_deadParams.MinTemperature}");
            if (BodyTemperature > _deadParams.MaxTemperature)
                DeadMessages.Add($"Температура тела должна быть меньше чем {_deadParams.MaxTemperature}");

            if (ArterialPressure.Item1 < _deadParams.MinArterialPressure.Item1 &&
                ArterialPressure.Item2 < _deadParams.MinArterialPressure.Item2)
                DeadMessages.Add(
                    $"Артериальное давление должно быть больше чем {_deadParams.MinArterialPressure.ToCustomString()}");
            
            if (ArterialPressure.Item1 > _deadParams.MaxArterialPressure.Item1 &&
                ArterialPressure.Item2 > _deadParams.MaxArterialPressure.Item2)
                DeadMessages.Add(
                    $"Артериальное давление должно быть меньше чем {_deadParams.MinArterialPressure.ToCustomString()}");
            
            if (WaterInBody < _deadParams.MinWaterInBody)
                DeadMessages.Add($"Объем жидкости должен быть больше чем {_deadParams.MinWaterInBody * 100}");
            
            if (Radiation >= _deadParams.MaxRadiationInBody)
                DeadMessages.Add($"Радиации в организме должно быть меньше чем {_deadParams.MaxRadiationInBody}");
        }

        private void UpdateTemperature()
        {
            BodyTemperature += (_populationParamsUpdater.GetBodyTemperature() - BodyTemperature) / TimeController.DaysLeft;
            // if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
            //     BodyTemperature += 1.5f * ((Temperature.Value - _comfortWeather.TemperatureWeather) / 5) /
            //                        IterationDays;
            // if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
            //     BodyTemperature -= 1.5f * ((_comfortWeather.TemperatureWeather - Temperature.Value) / 5) /
            //                        IterationDays;
            //
            // if (WindSpeed.Value is > 10 and < 30 && Temperature.Value < 10)
            //     BodyTemperature -= 1f / IterationDays;
            // if (WindSpeed.Value is >= 30 and < 50 && Temperature.Value < 10)
            //     BodyTemperature -= 2f / IterationDays;
            // if (WindSpeed.Value >= 50 && Temperature.Value < 10)
            //     BodyTemperature -= 3f / IterationDays;
            //
            // if (Humidity.Value is > 0 and < 50 && Temperature.Value < 10)
            //     BodyTemperature -= 1f / IterationDays;
            // if (Humidity.Value >= 50 && Temperature.Value < 10)
            //     BodyTemperature -= 2.5f / IterationDays;
            // if (Humidity.Value is > 0 and < 50 && Temperature.Value > 20)
            //     BodyTemperature += 1f / IterationDays;
            // if (Humidity.Value >= 50 && Temperature.Value > 20)
            //     BodyTemperature += 2f / IterationDays;
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
            if (BodyTemperature >= 39)
                WaterInBody -= .1f / IterationDays;
            if (BodyTemperature is > 36 and < 37)
                WaterInBody = .6f;
        }

        private void UpdateBloodInBody()
        {
            BloodInBody = _populationParamsUpdater.GetBloodInBody(DaysAlive, BloodInBody);
            // if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 20)
            //     BloodInBody -= .5f / IterationDays;
            // if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 50)
            //     BloodInBody -= 1f / IterationDays;
            // if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) <= 10)
            //     BloodInBody += .1f / IterationDays;
            //
            // if (BloodInBody >= 5f)
            //     BloodInBody = 5f;
        }
        
        private void UpdateRadiation()
        {
            Radiation = _populationParamsUpdater.GetRadiationInBody(DaysAlive, _comfortWeather.Radiation);
        }

        public void AddTemperature() =>
            _temperatures[DaysCounter] = Temperature.Value;

        public void AddPressure() =>
            _pressures[DaysCounter] = Pressure.Value;
    }
}