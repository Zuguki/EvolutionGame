namespace Population.Implementation.FireHumanPopulation
{
    public class FireHuman : IUnionPopulation
    {
        public string Name => "FireHuman";
        public IPopulationDescription Description { get; }
        public IPopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public bool IsAlive => Parameters.Count != 0;

        public FireHuman()
        {
            Description = new FireHumanDescription();
            Parameters = new FireHumanParameters();
            Sprites = new FireHumanSprites();
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