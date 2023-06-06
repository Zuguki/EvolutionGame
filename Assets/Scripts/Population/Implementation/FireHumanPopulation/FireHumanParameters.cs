﻿using Population.ComfortWeather;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanParameters : PopulationParams
    {
        public FireHumanParameters(float bodyTemperature, (float, float) arterialPressure, float waterInBody,
            float radiation, float bloodInBody, long populationSquare, IPopulationDeadParams deadParams,
            IComfortWeather comfortWeather, IPopulationCantBe populationCantBe, IComfortParams comfortParams) : base(
            bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody, populationSquare, deadParams,
            comfortWeather, populationCantBe, comfortParams)
        {
        }
    }
}