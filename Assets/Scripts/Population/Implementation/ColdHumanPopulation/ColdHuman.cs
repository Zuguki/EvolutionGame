using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHuman : IUnionPopulation
    {
        public string Name => "Ледяной человек";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public bool IsNew { get; set; } = true;

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
            var comfortParams = new ColdHumanComfortParams();
            Parameters = new ColdHumanParameters(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                PopulationCount.Value, deadParams, comfortWeather, populationCantBe, comfortParams);
        }
        
        public bool TryOpen(IPopulation currentPopulation, out IPopulation population)
        {
            if (currentPopulation.IsAlive
                && currentPopulation.Parameters.BodyTemperature >= 29.5 && currentPopulation.Parameters.BodyTemperature <= 35.5
                && currentPopulation.Parameters.ArterialPressure.Item1 >= 147 && currentPopulation.Parameters.ArterialPressure.Item2 >= 93.5
                && currentPopulation.Parameters.ArterialPressure.Item1 <= 169 && currentPopulation.Parameters.ArterialPressure.Item2 <= 104.5
                && currentPopulation.Parameters.WaterInBody >= 0.45 && currentPopulation.Parameters.WaterInBody <= 0.75
                && currentPopulation.Parameters.BloodInBody >= 4.5 && currentPopulation.Parameters.BloodInBody <= 5
                && currentPopulation.Parameters.Radiation >= 5000)
            {
                population = this;
                return true;
            }

            population = null;
            return false;
        }
    }
}