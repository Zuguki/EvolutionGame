namespace Population
{
    public interface IPopulationDeadParams
    {
        float MinTemperature { get; }
        float MaxTemperature { get; }
        
        (float, float) MinArterialPressure { get; }
        (float, float) MaxArterialPressure { get; }
        
        float MinWaterInBody { get; }
        float MaxWaterInBody { get; }
        
        float MinRadiationInBody { get; }
        float MaxRadiationInBody { get; }
    }
}