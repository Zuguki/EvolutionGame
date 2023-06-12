using System.Collections.Generic;
using Population.ComfortWeather;
using UnityEngine;
using Weather;

namespace Population
{
    public static class PopulationEvent
    {
        public static bool TryAddPopulationCantBeMessage(out List<string> messages, IPopulationCantBe populationCantBe)
        {
            messages = new List<string>();
            if (Temperature.Value <= populationCantBe.MinTemperature)
                messages.Add($"Температура ниже {populationCantBe.MinTemperature}");
            if (Temperature.Value >= populationCantBe.MaxTemperature)
                messages.Add($"Температура выше {populationCantBe.MaxTemperature}");
            
            if (Pressure.Value <= populationCantBe.MinPressure)
                messages.Add($"Давление ниже {populationCantBe.MinPressure}");
            if (Pressure.Value >= populationCantBe.MaxPressure)
                messages.Add($"Давление выше {populationCantBe.MaxPressure}");
            
            if (Radiation.Value >= populationCantBe.MaxRadiation)
                messages.Add($"Радиация выше {populationCantBe.MaxRadiation}");
            
            if (AirQuality.Value >= populationCantBe.MaxAirQuality)
                messages.Add($"Качество воздуха выше {populationCantBe.MaxAirQuality}");
            
            if (SoilPurity.Value <= populationCantBe.MinSoilPurity)
                messages.Add($"Чистота почьвы ниже {populationCantBe.MinSoilPurity}");
            
            if (Noise.Value >= populationCantBe.MaxNoise)
                messages.Add($"Шум выше {populationCantBe.MaxNoise}");
            
            if (WindSpeed.Value >= populationCantBe.MaxWindSpeed)
                messages.Add($"Скорость ветра выше {populationCantBe.MaxWindSpeed}");

            return messages.Count != 0;
        }
        
        public static bool TryAddDeadMessage(out List<string> messages, PopulationParams population,
            IPopulationDeadParams deadParams)
        {
            messages = new List<string>();
            if (population.BodyTemperature <= deadParams.MinTemperature)
                messages.Add($"Температура тела ниже {deadParams.MinTemperature}°C");
            if (population.BodyTemperature >= deadParams.MaxTemperature)
                messages.Add($"Температура тела выше {deadParams.MaxTemperature}°C");

            if (population.ArterialPressure.Item1 <= deadParams.MinArterialPressure.Item1 &&
                population.ArterialPressure.Item2 <= deadParams.MinArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление ниже {deadParams.MinArterialPressure.ToCustomString()}мм рт ст");
            
            if (population.ArterialPressure.Item1 >= deadParams.MaxArterialPressure.Item1 &&
                population.ArterialPressure.Item2 >= deadParams.MaxArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление выше {deadParams.MaxArterialPressure.ToCustomString()}мм рт ст");
            
            if (population.WaterInBody <= deadParams.MinWaterInBody)
                messages.Add($"Объем жидкости ниже {deadParams.MinWaterInBody * 100}%");
            
            if (population.BloodInBody <= deadParams.MinBloodInBody)
                messages.Add($"Объем крови ниже {deadParams.MinBloodInBody}Л");

            if (population.Radiation >= deadParams.MaxRadiationInBody)
                messages.Add($"Количество радиации в организме больше {deadParams.MaxRadiationInBody}мкЗв");

            return messages.Count != 0;
        }

        public static bool TryAddDiscomfortParams(out List<string> messages, PopulationParams population,
            IComfortParams comfortParams)
        {
            messages = new List<string>();
            if (population.BodyTemperature <= comfortParams.MinTemperature)
                messages.Add($"Температура тела ниже {comfortParams.MinTemperature}°C");
            if (population.BodyTemperature >= comfortParams.MaxTemperature)
                messages.Add($"Температура тела выше {comfortParams.MaxTemperature}°C");

            if (population.ArterialPressure.Item1 <= comfortParams.MinArterialPressure.Item1 &&
                population.ArterialPressure.Item2 <= comfortParams.MinArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление ниже {comfortParams.MinArterialPressure.ToCustomString()}мм рт ст");

            if (population.ArterialPressure.Item1 >= comfortParams.MaxArterialPressure.Item1 &&
                population.ArterialPressure.Item2 >= comfortParams.MaxArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давление выше {comfortParams.MaxArterialPressure.ToCustomString()}мм рт ст");

            if (population.WaterInBody <= comfortParams.MinWaterInBody)
                messages.Add($"Объем жидкости ниже {comfortParams.MinWaterInBody * 100}%");

            if (population.BloodInBody <= comfortParams.MinBloodInBody)
                messages.Add($"Объем крови ниже {comfortParams.MinBloodInBody}Л");

            if (population.Radiation / population.DaysAlive >= comfortParams.MaxRadiationInBody)
                messages.Add($"Количество радиации в организме больше {comfortParams.MaxRadiationInBody}мкЗв");
            
            if (messages.Count != 0)
                Debug.Log($"Параметры выходят за рамки: {string.Join(", ", messages)}");
            
            return messages.Count != 0;
        }
    }
}