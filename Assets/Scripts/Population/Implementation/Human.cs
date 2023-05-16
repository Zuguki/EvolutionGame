using System;
using System.Collections.Generic;
using System.Linq;
using ComfortWeather;
using ComfortWeather.Implementation;
using UnityEngine;
using Weather;

namespace Population.Implementation
{
    public class Human : IPopulation, IPopulationDescription
    {
        public string Name => "Human";
        public PopulationEnum PopulationEnum => PopulationEnum.Human;
        public Sprite SpriteOfMenu => SpritesManager.HumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.HumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.HumanPopulationSprite;

        public List<string> DeadMessages { get; set; } = new List<string>();
        
        public int DaysAlive { get; set; } = 0;
        public float BodyTemperature { get; set; } = 36.6f;
        public (float, float) ArterialPressure { get; set; } = (120f, 80f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public long Count { get; set; } = Parameters.PopulationCount.Value;
        public float Radiation { get; set; } = 100;
        
        public string Title => "Человек";

        public string Details1 =>
            "Человек - живое существо, обладающее мышлением и речью.";

        public string Details2 => "Две ноги, две руки, прямохождение, короткий волосяной покров, передвижение на двух конечностях(ногах), пять пальцев на ногах и руках, глаза расположены с передней части головы.";

        public string Details3 =>
            $@"1. температура воздуха: 18 - 24 °C
2. атмосферное давление: 740 - 760 мм. рт. ст.
3. радиация: <=20 мкЗв / сутки
4. влажность воздуха: 55-70 %
5. скорость ветра: 0-5 м/с
6. количество осадков: 100 - 500 мм/год
7. качество воздуха: 0 - 100 AQI
8. чистота почвы(санитарное число): 0,85-0,98 C
9. шум: 40-55 дБ";

        private const float StartBodyTemperature = 36.5f;
        private const int IterationDays = 90;
        private readonly (float, float) _startArterialPressure = (120f, 80f);
        private readonly IComfortWeather _comfortWeather = new HumanComfortWeather();
        private readonly IPopulationParamsUpdater _populationParamsUpdater = new PopulationParamsUpdater();
        private readonly IPopulationDeadParams _deadParams = new HumanDeadParams();
        
        private readonly float[] _temperatures = new float[IterationDays];
        private readonly float[] _pressures = new float[IterationDays];
        private int DaysCounter => DaysAlive % IterationDays;
        private double bnr;
        private double dnr;

        public void UpdateParams()
        {
            UpdateTemperature();
            UpdateArterialPressure();
            UpdateWaterInBody();
            UpdateBloodInBody();
            UpdateRadiation();
            UpdatePopulationCount();
            
            TryAddDeadMessage(out var list);
            DeadMessages = DeadMessages.Union(list).ToList();
        }

        public bool IsAlive => Count > 0;

        private void UpdateBnrDnr()
        {
            if (TryAddDeadMessage(out var list) && list.Count == 4)
            {
                bnr = 0;
                dnr = 1_000;
            }
            else if (TryAddDeadMessage(out _))
            {
                bnr = 0.01;
                dnr = 100;
            }
            else if (TryAddDiscomfortParams(out _))
            {
                bnr = 0.015;
                dnr = 0.015;
            }
            else
            {
                bnr = 0.025;
                dnr = 0.015;
            }
        }

        private void UpdatePopulationCount()
        {
            // N = N0*e^((BNR-DNR)*t)/365
            //
            // N– численность популяции
            // N0– начальная численность популяции
            //     BNR– темп рождаемости 
            // DNR– темп смертности 
            // t– время итерации
            UpdateBnrDnr();
            Count = (long) (Count * Math.Pow(Math.E, (bnr - dnr) / 365));
        }

        private bool TryAddDiscomfortParams(out List<string> messages)
        {
            messages = new List<string>();
            if (Temperature.Value < _comfortWeather.MinTemperature)
                messages.Add($"Температура окружающей среды ниже нормы: {_comfortWeather.MinTemperature}");
            if (Temperature.Value > _comfortWeather.MaxTemperature)
                messages.Add($"Температура окружающей среды выше нормы: {_comfortWeather.MaxTemperature}");
            
            if (Pressure.Value < _comfortWeather.MinPressure)
                messages.Add($"Атмосферное давление окружающей среды ниже нормы: {_comfortWeather.MinPressure}");
            if (Pressure.Value > _comfortWeather.MaxPressure)
                messages.Add($"Атмосферное давление окружающей среды выше нормы: {_comfortWeather.MaxPressure}");
            
            if (Weather.Radiation.Value > _comfortWeather.MaxRadiation)
                messages.Add($"Радиация окружающей среды выше нормы: {_comfortWeather.MaxRadiation}");
            
            if (Humidity.Value < _comfortWeather.MinHumidity)
                messages.Add($"Влажность окружающей среды ниже нормы: {_comfortWeather.MinHumidity}");
            if (Humidity.Value > _comfortWeather.MaxHumidity)
                messages.Add($"Влажность окружающей среды выше нормы: {_comfortWeather.MaxHumidity}");
            
            if (WindSpeed.Value < _comfortWeather.MinWindSpeed)
                messages.Add($"Скорость ветра окружающей среды ниже нормы: {_comfortWeather.MinWindSpeed}");
            if (WindSpeed.Value > _comfortWeather.MaxWindSpeed)
                messages.Add($"Скорость ветра окружающей среды выше нормы: {_comfortWeather.MaxWindSpeed}");
            
            if (Preciptiation.Value < _comfortWeather.MinPressure)
                messages.Add($"Количество осадков окружающей среды ниже нормы: {_comfortWeather.MinPreciptiation}");
            if (Preciptiation.Value > _comfortWeather.MaxPreciptiation)
                messages.Add($"Количество осадков окружающей среды выше нормы: {_comfortWeather.MaxPreciptiation}");
            
            if (AirQuality.Value < _comfortWeather.MinAirQuality)
                messages.Add($"Качество воздуха окружающей среды ниже нормы: {_comfortWeather.MinAirQuality}");
            if (AirQuality.Value > _comfortWeather.MaxAirQuality)
                messages.Add($"Качество воздуха окружающей среды выше нормы: {_comfortWeather.MaxAirQuality}");
            
            if (SoilPurity.Value < _comfortWeather.MinSoilPurity)
                messages.Add($"Чистота почвы окружающей среды ниже нормы: {_comfortWeather.MinSoilPurity}");
            if (SoilPurity.Value > _comfortWeather.MaxSoilPurity)
                messages.Add($"Чистота почвы окружающей среды выше нормы: {_comfortWeather.MaxSoilPurity}");
            
            if (Noise.Value < _comfortWeather.MinNoise)
                messages.Add($"Влажность окружающей среды ниже нормы: {_comfortWeather.MinNoise}");
            if (Noise.Value > _comfortWeather.MaxNoise)
                messages.Add($"Влажность окружающей среды выше нормы: {_comfortWeather.MaxNoise}");

            return messages.Count != 0;
        }

        private bool TryAddDeadMessage(out List<string> messages)
        {
            messages = new List<string>();
            if (BodyTemperature < _deadParams.MinTemperature)
                messages.Add($"Температура тела должна быть больше чем {_deadParams.MinTemperature}");
            if (BodyTemperature > _deadParams.MaxTemperature)
                messages.Add($"Температура тела должна быть меньше чем {_deadParams.MaxTemperature}");

            if (ArterialPressure.Item1 < _deadParams.MinArterialPressure.Item1 &&
                ArterialPressure.Item2 < _deadParams.MinArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление должно быть больше чем {_deadParams.MinArterialPressure.ToCustomString()}");
            
            if (ArterialPressure.Item1 > _deadParams.MaxArterialPressure.Item1 &&
                ArterialPressure.Item2 > _deadParams.MaxArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление должно быть меньше чем {_deadParams.MinArterialPressure.ToCustomString()}");
            
            if (WaterInBody < _deadParams.MinWaterInBody)
                messages.Add($"Объем жидкости должен быть больше чем {_deadParams.MinWaterInBody * 100}");
            
            if (Radiation >= _deadParams.MaxRadiationInBody)
                messages.Add($"Радиации в организме должно быть меньше чем {_deadParams.MaxRadiationInBody}");

            return messages.Count != 0;
        }

        private void UpdateTemperature()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
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