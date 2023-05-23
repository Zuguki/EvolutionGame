
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.HumanPopulation
{
    public class Human : IPopulation
    {
        public string Name => "Human";
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }

        public bool IsAlive => Parameters.Count > 0;
        
        public Human()
        {
            Description = new HumanDescription();
            Sprites = new HumanSprites();
            
            var bodyTemperature = 36.5f;
            var arterialPressure = (120f, 80f);
            var waterInBody = .6f;
            var radiation = 0;
            var bloodInBody = 5;

            var deadParams = new HumanDeadParams();
            var comfortWeather = new HumanComfortWeather();
            var populationCantBe = new HumanCantBe();
            Parameters = new HumanParams(bodyTemperature, arterialPressure, waterInBody, radiation, bloodInBody,
                deadParams, comfortWeather, populationCantBe);
        }
    }
}