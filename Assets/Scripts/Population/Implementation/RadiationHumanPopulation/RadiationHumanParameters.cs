using Population.ComfortWeather;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanParameters : PopulationParams
    {
        public RadiationHumanParameters(float bodyTemperature, (float, float) arterialPressure, float waterInBody,
            float radiation, float bloodInBody, IPopulationDeadParams deadParams, IComfortWeather comfortWeather,
            IPopulationCantBe populationCantBe) : base(bodyTemperature, arterialPressure, waterInBody, radiation,
            bloodInBody, deadParams, comfortWeather, populationCantBe)

        {
        }
    }
}