namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHuman : IUnionPopulation
    {
        public string Name => "RadiationHuman";
        public IPopulationDescription Description { get; }
        public IPopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public bool IsAlive => Parameters.Count != 0;

        public RadiationHuman()
        {
            Description = new RadiationHumanDescription();
            Parameters = new RadiationHumanParameters();
            Sprites = new RadiationHumanSprite();
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