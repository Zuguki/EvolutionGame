
namespace Population.Implementation.HumanPopulation
{
    public class Human : IPopulation
    {
        public string Name => "Human";
        public IPopulationDescription Description { get; }
        public IPopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }

        public bool IsAlive => Parameters.Count > 0;
        
        public Human()
        {
            Description = new HumanDescription();
            Parameters = new HumanParams();
            Sprites = new HumanSprites();
        }
    }
}