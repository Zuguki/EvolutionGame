using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHuman : IUnionPopulation
    {
        public string Name => "Огненный человек";
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
                && currentPopulation.Parameters.BodyTemperature >= 36.2 && currentPopulation.Parameters.BodyTemperature <= 39.5
                && currentPopulation.Parameters.ArterialPressure.Item1 >= 81 && currentPopulation.Parameters.ArterialPressure.Item2 >= 60.5
                && currentPopulation.Parameters.ArterialPressure.Item1 <= 103 && currentPopulation.Parameters.ArterialPressure.Item2 <= 71.5
                && currentPopulation.Parameters.WaterInBody >= 0.5 && currentPopulation.Parameters.WaterInBody <= 0.75
                && currentPopulation.Parameters.BloodInBody >= 4.5 && currentPopulation.Parameters.BloodInBody <= 5
                && currentPopulation.Parameters.Radiation >= 15000)
            {
                IsNew = true;
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}