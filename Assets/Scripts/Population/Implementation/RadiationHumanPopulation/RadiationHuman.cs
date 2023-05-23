using Population.ComfortWeather.Implementation;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHuman : IUnionPopulation
    {
        public string Name => "RadiationHuman";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
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
            Parameters = new RadiationHumanParameters(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                deadParams, comfortWeather, populationCantBe);
        }

        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.Parameters.BodyTemperature > 36.5 && currentPopulation.Parameters.BodyTemperature < 37.5
                && currentPopulation.Parameters.Radiation is > 500 and < 600
                && currentPopulation.Parameters.ArterialPressure.Item1 > 140 && currentPopulation.Parameters.ArterialPressure.Item2 > 80
                && currentPopulation.Parameters.ArterialPressure.Item1 < 160 && currentPopulation.Parameters.ArterialPressure.Item2 < 85)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}