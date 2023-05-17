using System.Collections.Generic;
using Population.ComfortWeather;
using Weather;

namespace Population
{
    public static class PopulationEvent
    {
        public static bool TryAddDeadMessage(out List<string> messages, IPopulationParams population,
            IPopulationDeadParams deadParams)
        {
            messages = new List<string>();
            if (population.BodyTemperature < deadParams.MinTemperature)
                messages.Add($"Температура тела ниже {deadParams.MinTemperature}°C");
            if (population.BodyTemperature > deadParams.MaxTemperature)
                messages.Add($"Температура тела выше {deadParams.MaxTemperature}°C");

            if (population.ArterialPressure.Item1 < deadParams.MinArterialPressure.Item1 &&
                population.ArterialPressure.Item2 < deadParams.MinArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давления ниже {deadParams.MinArterialPressure.ToCustomString()}мм рт ст");
            
            if (population.ArterialPressure.Item1 > deadParams.MaxArterialPressure.Item1 &&
                population.ArterialPressure.Item2 > deadParams.MaxArterialPressure.Item2)
                messages.Add(
                    $"Артериальное давления выше {deadParams.MaxArterialPressure.ToCustomString()}мм рт ст");
            
            if (population.WaterInBody < deadParams.MinWaterInBody)
                messages.Add($"Объем жидкости ниже {deadParams.MinWaterInBody * 100}%");
            
            // TODO: Может ли быть ниже? Ниже или равен.
            if (population.BloodInBody < deadParams.MinBloodInBody)
                messages.Add($"Объем крови ниже {deadParams.MinBloodInBody}Л");

            // TODO: Больше? 
            if (population.Radiation > deadParams.MaxRadiationInBody)
                messages.Add($"Количество радиации в организме больше {deadParams.MaxRadiationInBody}мкЗв");

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