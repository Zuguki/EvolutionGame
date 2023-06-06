namespace Population
{
    public interface IPopulation 
    {
        public string Name { get; }
        
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        
        public bool IsNew { get; set; }
        
        public bool IsAlive { get; }
    }
}