using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHuman : IUnionPopulation
    {
        public string Name => "FireHuman";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public bool IsNew { get; set; } = true;
        public bool IsAlive => Parameters.Count != 0;

        public FireHuman()
        {
            Description = new FireHumanDescription();
            Sprites = new FireHumanSprites();
            
            var bodyTemperature = 37.8f;
            var arterialPressure = (92f, 66f);
            var waterInBody = .6f;
            var radiation = 0;
            var bloodInBody = 5;

            var deadParams = new FireHumanDeadParams();
            var comfortWeather = new FireHumanComfortWeather();
            var populationCantBe = new FireHumanCantBe();
            var comfortParams = new FireHumanComfortParams();
            Parameters = new FireHumanParameters(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                PopulationCount.Value, deadParams, comfortWeather, populationCantBe, comfortParams);
        }
        
        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.Parameters.BodyTemperature > 37.5 && currentPopulation.Parameters.BodyTemperature < 38.5
                && currentPopulation.Parameters.Radiation is > 500 and < 600
                && currentPopulation.Parameters.ArterialPressure.Item1 > 150 && currentPopulation.Parameters.ArterialPressure.Item2 > 85
                && currentPopulation.Parameters.ArterialPressure.Item1 < 170 && currentPopulation.Parameters.ArterialPressure.Item2 < 90)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}