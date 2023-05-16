using System;
using System.Collections.Generic;
using System.Linq;
using ComfortWeather;
using ComfortWeather.Implementation;
using UnityEngine;
using Weather;

namespace Population.Implementation
{
    public class RadiationHuman : IUnionPopulation
    {
//         public string Name => "RadiationHuman";
//         public PopulationEnum PopulationEnum => PopulationEnum.RadiationHuman;
//         public Sprite SpriteOfMenu => SpritesManager.RadiationHumanSprite;
//         public Sprite LockSpriteMenu => SpritesManager.LockRadiationHumanSprite;
//         public Sprite SpriteOfPopulationMenu => SpritesManager.RadiationHumanPopulationSprite;
//         public List<string> DeadMessages { get; set; } = new List<string>();
//         public int DaysAlive { get; set; } = 0;
//         public float BodyTemperature { get; set; } = 37f;
//         public (float, float) ArterialPressure { get; set; } = (110f, 75f);
//         public float WaterInBody { get; set; } = .6f;
//         public float BloodInBody { get; set; } = 5;
//         public long Count { get; set; } = Parameters.PopulationCount.Value;
//         public float Radiation { get; set; } = 70;
//         
//         public string Title => "Радиационный человек";
//
//         public string Details1 =>
//             "Радиационный человек - живое существо, обладающее мышлением и речью, приспособленное к выживанию в среде обитания, с повышенным радиационным фоном.";
//
//         public string Details2 => "Цвет кожи более насыщенный(темно-оранжевого цвета или ярко-красного, как пример), волосяной покров практически отсутствует, прямохождение, остальные конечности остаются, но могут видоизмениться или вовсе могут появиться новые конечности.";
//
//         public string Details3 =>
//             $@"1. температура окружающей среды: 19 - 27 °C
// 2. атмосферное давление: 710-730 мм рт ст
// 3. радиация: <=30 мкЗв / сутки
// 4. влажность воздуха: 10-30 %
// 5. скорость ветра: 0-10 м/с
// 6. количество осадков: 100 - 350 мм/год
// 7. качество воздуха: 0 - 100 AQI
// 8. чистота почвы(санитарное число):  0,85-0,98 С
// 9. шум: 40-55 дБ";
//
//         private const float StartBodyTemperature = 37f;
//         private const int IterationDays = 90;
//         private readonly (float, float) _startArterialPressure = (110f, 75f);
//         private readonly IComfortWeather _comfortWeather = new RadiationHumanComfortWeather();
//         
//         private readonly float[] _temperatures = new float[IterationDays];
//         private readonly float[] _pressures = new float[IterationDays];
//         private int DaysCounter => DaysAlive % IterationDays;
//
//         public void UpdateParams()
//         {
//             UpdateTemperature();
//             UpdateArterialPressure();
//             UpdateWaterInBody();
//             UpdateBloodInBody();
//             UpdateRadiation();
//         }
//
//         public bool IsAlive =>
//             BodyTemperature is >= 31 and <= 43 &&
//             ArterialPressure.Item1 is >= 85 and <= 220 && ArterialPressure.Item2 is >= 75 and <= 100 &&
//             (WaterInBody > .3 || WaterInBody <= .3 && Temperature.Value < 25) &&
//             GetMiddleTemperature() is <= 35 and >= -5 &&
//             Radiation <= 5000 &&
//             GetMiddlePressure() is >= 690 and <= 740 &&
//             BloodInBody >= 3;
//
//         private void UpdateTemperature()
//         {
//             if (Temperature.Value - _comfortWeather.TemperatureWeather > 5)
//                 BodyTemperature += 1.5f * ((Temperature.Value - _comfortWeather.TemperatureWeather) / 5) /
//                                    IterationDays;
//             if (_comfortWeather.TemperatureWeather - Temperature.Value > 5)
//                 BodyTemperature -= 1.5f * ((_comfortWeather.TemperatureWeather - Temperature.Value) / 5) /
//                                    IterationDays;
//             
//             if (WindSpeed.Value is > 5 and < 20 && Temperature.Value < 10)
//                 BodyTemperature -= 1f / IterationDays;
//             if (WindSpeed.Value is >= 20 and < 30 && Temperature.Value < 10)
//                 BodyTemperature -= 2f / IterationDays;
//             if (WindSpeed.Value >= 30 && Temperature.Value < 10)
//                 BodyTemperature -= 3f / IterationDays;
//
//             if (Humidity.Value is > 0 and < 30 && Temperature.Value < 10)
//                 BodyTemperature -= 1f / IterationDays;
//             if (Humidity.Value is >= 30 and < 60 && Temperature.Value < 10)
//                 BodyTemperature -= 2f / IterationDays;
//             if (Humidity.Value >= 60 && Temperature.Value < 10)
//                 BodyTemperature -= 3f / IterationDays;
//             if (Humidity.Value is >= 0 and < 30 && Temperature.Value > 25)
//                 BodyTemperature += 1f / IterationDays;
//             if (Humidity.Value is >= 30 and < 60 && Temperature.Value > 25)
//                 BodyTemperature += 2f / IterationDays;
//             if (Humidity.Value >= 60 && Temperature.Value > 25)
//                 BodyTemperature += 3f / IterationDays;
//         }
//
//         private void UpdateArterialPressure()
//         {
//             var upgrade = (BodyTemperature - StartBodyTemperature) / 0.5f;
//             var downgrade = (StartBodyTemperature - BodyTemperature) / 1f;
//
//             if (upgrade > 0)
//                 ArterialPressure = (ArterialPressure.Item1 + 8f * upgrade / IterationDays,
//                     ArterialPressure.Item2 + 1 * upgrade / IterationDays);
//             else if (downgrade > 0)
//                 ArterialPressure = (ArterialPressure.Item1 - 4 * downgrade / IterationDays,
//                     ArterialPressure.Item2 - 2 * downgrade / IterationDays);
//         }
//
//         private void UpdateWaterInBody()
//         {
//             if (BodyTemperature is >= 40 or <= 37)
//                 WaterInBody -= .1f / IterationDays;
//             if (BodyTemperature is > 37.5f and < 38.5f)
//                 WaterInBody = .6f;
//         }
//
//         private void UpdateBloodInBody()
//         {
//             if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 20)
//                 BloodInBody -= .5f / IterationDays;
//             if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) >= 50)
//                 BloodInBody -= 1f / IterationDays;
//             if (Math.Abs(ArterialPressure.Item1 - _startArterialPressure.Item1) <= 10)
//                 BloodInBody += .1f / IterationDays;
//             
//             if (BloodInBody >= 5f)
//                 BloodInBody = 5f;
//         }
//
//         private void UpdateRadiation()
//         {
//             if (Weather.Radiation.Value == 0)
//                 Radiation -= 1000f / IterationDays;
//             else if (Weather.Radiation.Value <= 1000)
//                 Radiation -= (1000f - Weather.Radiation.Value) / IterationDays;
//             else if (Weather.Radiation.Value > 1000)
//                 Radiation += Weather.Radiation.Value / IterationDays;
//
//             if (Radiation <= 0)
//                 Radiation = 0;
//             if (Radiation >= 7000)
//                 Radiation = 7000;
//         }
//
//         private float GetMiddleTemperature()
//         {
//             if (DaysAlive < IterationDays)
//                 return _comfortWeather.TemperatureWeather;
//
//             return (float) Math.Round(_temperatures.Sum() / IterationDays, 1);
//         }
//
//         public void AddTemperature() =>
//             _temperatures[DaysCounter] = Temperature.Value;
//
//         private float GetMiddlePressure()
//         {
//             if (DaysAlive < IterationDays)
//                 return _comfortWeather.Pressure;
//
//             return (float) Math.Round(_pressures.Sum() / IterationDays, 1);
//         }
//
//         public void AddPressure() =>
//             _pressures[DaysCounter] = Pressure.Value;
//
//         public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
//         {
//             if (currentPopulation.IsAlive
//                 && currentPopulation.BodyTemperature > 36.5 && currentPopulation.BodyTemperature < 37.5
//                 && currentPopulation.Radiation is > 500 and < 600
//                 && currentPopulation.ArterialPressure.Item1 > 140 && currentPopulation.ArterialPressure.Item2 > 80
//                 && currentPopulation.ArterialPressure.Item1 < 160 && currentPopulation.ArterialPressure.Item2 < 85)
//             {
//                 population = this;
//                 return true;
//             }
//
//             population = null;
//             return false;
//         }
public string Name { get; }
public IPopulationDescription Description { get; }
public IPopulationParams Parameters { get; }
public IPopulationSprites Sprites { get; }
public bool IsAlive { get; }
public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
{
    throw new NotImplementedException();
}
    }
}