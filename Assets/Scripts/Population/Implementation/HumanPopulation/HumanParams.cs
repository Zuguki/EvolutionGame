using Population.ComfortWeather;

namespace Population.Implementation.HumanPopulation
{
    public class HumanParams : PopulationParams
    {
        public HumanParams(float bodyTemperature, (float, float) arterialPressure, float waterInBody, float radiation,
            float bloodInBody, IPopulationDeadParams deadParams, IComfortWeather comfortWeather,
            IPopulationCantBe populationCantBe) : base(bodyTemperature, arterialPressure, waterInBody, radiation,
            bloodInBody, deadParams, comfortWeather, populationCantBe)

        {
        }
    }
}