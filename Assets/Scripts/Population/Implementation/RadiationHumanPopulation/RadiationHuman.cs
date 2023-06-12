using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHuman : IUnionPopulation
    {
        public string Name => "Радиационный человек";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public bool IsNew { get; set; } = true;
        public bool IsAlive => Parameters.Count != 0;

        public RadiationHuman()
        {
            Description = new RadiationHumanDescription();
            Sprites = new RadiationHumanSprite();
            
            var bodyTemperature = 37.2f;
            var arterialPressure = (92f, 66f);
            var waterInBody = .5f;
            var radiation = 0;
            var bloodInBody = 5;

            var deadParams = new RadiationHumanDeadParameters();
            var comfortWeather = new RadiationHumanComfortWeather();
            var populationCantBe = new RadiationHumanCantBe();
            var comfortParams = new RadiationHumanComfortParams();
            Parameters = new RadiationHumanParameters(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                PopulationCount.Value, deadParams, comfortWeather, populationCantBe, comfortParams);
        }

        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.Parameters.BodyTemperature >= 35.8 && currentPopulation.Parameters.BodyTemperature <= 38.5
                && currentPopulation.Parameters.ArterialPressure.Item1 >= 81 && currentPopulation.Parameters.ArterialPressure.Item2 >= 60.5
                && currentPopulation.Parameters.ArterialPressure.Item1 <= 103 && currentPopulation.Parameters.ArterialPressure.Item2 <= 71.5
                && currentPopulation.Parameters.WaterInBody >= 0.4 && currentPopulation.Parameters.WaterInBody <= 0.65
                && currentPopulation.Parameters.BloodInBody >= 4.5 && currentPopulation.Parameters.BloodInBody <= 5
                && currentPopulation.Parameters.Radiation >= 25000)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}