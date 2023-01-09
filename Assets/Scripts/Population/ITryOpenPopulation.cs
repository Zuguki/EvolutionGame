namespace Population
{
    public interface ITryOpenPopulation
    {
        public bool TryOpen(IPopulation currentPopulation, out IPopulation population);
    }
}