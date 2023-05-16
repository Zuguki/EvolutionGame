﻿using System.Collections.Generic;
using ComfortWeather;
using Weather;

namespace Population.Implementation
{
    public static class PopulationEvent
    {
        public static bool TryAddDeadMessage(out List<string> messages, IPopulationParams population,
            IPopulationDeadParams deadParams)
        {
            messages = new List<string>();
            if (population.BodyTemperature < deadParams.MinTemperature)
                messages.Add($"Температура тела должна быть больше чем {deadParams.MinTemperature}");
            if (population.BodyTemperature > deadParams.MaxTemperature)
                messages.Add($"Температура тела должна быть меньше чем {deadParams.MaxTemperature}");

            if (population.ArterialPressure.Item1 < deadParams.MinArterialPressure.Item1 &&
                population.ArterialPressure.Item2 < deadParams.MinArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление должно быть больше чем {deadParams.MinArterialPressure.ToCustomString()}");
            
            if (population.ArterialPressure.Item1 > deadParams.MaxArterialPressure.Item1 &&
                population.ArterialPressure.Item2 > deadParams.MaxArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление должно быть меньше чем {deadParams.MinArterialPressure.ToCustomString()}");
            
            if (population.WaterInBody < deadParams.MinWaterInBody)
                messages.Add($"Объем жидкости должен быть больше чем {deadParams.MinWaterInBody * 100}");
            
            if (population.Radiation >= deadParams.MaxRadiationInBody)
                messages.Add($"Радиации в организме должно быть меньше чем {deadParams.MaxRadiationInBody}");

            return messages.Count != 0;
        }

        public static bool TryAddDiscomfortParams(out List<string> messages, IComfortWeather comfortWeather)
        {
            messages = new List<string>();
            if (Temperature.Value < comfortWeather.MinTemperature)
                messages.Add($"Температура окружающей среды ниже нормы: {comfortWeather.MinTemperature}");
            if (Temperature.Value > comfortWeather.MaxTemperature)
                messages.Add($"Температура окружающей среды выше нормы: {comfortWeather.MaxTemperature}");

            if (Pressure.Value < comfortWeather.MinPressure)
                messages.Add($"Атмосферное давление окружающей среды ниже нормы: {comfortWeather.MinPressure}");
            if (Pressure.Value > comfortWeather.MaxPressure)
                messages.Add($"Атмосферное давление окружающей среды выше нормы: {comfortWeather.MaxPressure}");

            if (Weather.Radiation.Value > comfortWeather.MaxRadiation)
                messages.Add($"Радиация окружающей среды выше нормы: {comfortWeather.MaxRadiation}");

            if (Humidity.Value < comfortWeather.MinHumidity)
                messages.Add($"Влажность окружающей среды ниже нормы: {comfortWeather.MinHumidity}");
            if (Humidity.Value > comfortWeather.MaxHumidity)
                messages.Add($"Влажность окружающей среды выше нормы: {comfortWeather.MaxHumidity}");

            if (WindSpeed.Value < comfortWeather.MinWindSpeed)
                messages.Add($"Скорость ветра окружающей среды ниже нормы: {comfortWeather.MinWindSpeed}");
            if (WindSpeed.Value > comfortWeather.MaxWindSpeed)
                messages.Add($"Скорость ветра окружающей среды выше нормы: {comfortWeather.MaxWindSpeed}");

            if (Preciptiation.Value < comfortWeather.MinPressure)
                messages.Add($"Количество осадков окружающей среды ниже нормы: {comfortWeather.MinPreciptiation}");
            if (Preciptiation.Value > comfortWeather.MaxPreciptiation)
                messages.Add($"Количество осадков окружающей среды выше нормы: {comfortWeather.MaxPreciptiation}");

            if (AirQuality.Value < comfortWeather.MinAirQuality)
                messages.Add($"Качество воздуха окружающей среды ниже нормы: {comfortWeather.MinAirQuality}");
            if (AirQuality.Value > comfortWeather.MaxAirQuality)
                messages.Add($"Качество воздуха окружающей среды выше нормы: {comfortWeather.MaxAirQuality}");

            if (SoilPurity.Value < comfortWeather.MinSoilPurity)
                messages.Add($"Чистота почвы окружающей среды ниже нормы: {comfortWeather.MinSoilPurity}");
            if (SoilPurity.Value > comfortWeather.MaxSoilPurity)
                messages.Add($"Чистота почвы окружающей среды выше нормы: {comfortWeather.MaxSoilPurity}");

            if (Noise.Value < comfortWeather.MinNoise)
                messages.Add($"Влажность окружающей среды ниже нормы: {comfortWeather.MinNoise}");
            if (Noise.Value > comfortWeather.MaxNoise)
                messages.Add($"Влажность окружающей среды выше нормы: {comfortWeather.MaxNoise}");

            return messages.Count != 0;
        }
    }
}