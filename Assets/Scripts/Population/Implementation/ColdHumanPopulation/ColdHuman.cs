using Population.ComfortWeather.Implementation;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHuman : IUnionPopulation
    {
        public string Name => "ColdHuman";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }

        public bool IsAlive => Parameters.Count > 0;

        public ColdHuman()
        {
            Description = new ColdHumanDescription();
            Sprites = new ColdHumanSprites();

            var bodyTemperature = 32.8f;
            var arterialPressure = (158f, 99f);
            var waterInBody = .55f;
            var radiation = 0;
            var bloodInBody = 5;

            var deadParams = new ColdHumanDeadParams();
            var comfortWeather = new ColdHumanComfortWeather();
            var populationCantBe = new ColdHumanCantBe();
            Parameters = new ColdHumanParameters(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                deadParams, comfortWeather, populationCantBe);
        }
        
        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.Parameters.BodyTemperature > 34 && currentPopulation.Parameters.BodyTemperature < 35
                && currentPopulation.Parameters.Radiation is > 400 and < 590
                && currentPopulation.Parameters.ArterialPressure.Item1 > 110 && currentPopulation.Parameters.ArterialPressure.Item2 > 75
                && currentPopulation.Parameters.ArterialPressure.Item1 < 130 && currentPopulation.Parameters.ArterialPressure.Item2 < 90)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}