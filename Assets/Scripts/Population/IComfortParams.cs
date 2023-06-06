namespace Population
{
    public interface IComfortParams
    {
        float MinTemperature { get; }
        float MaxTemperature { get; }
        
        (float, float) MinArterialPressure { get; }
        (float, float) MaxArterialPressure { get; }
        
        float MinWaterInBody { get; }
        float MaxWaterInBody { get; }
        
        float MinBloodInBody { get; }
        float MaxBloodInBody { get; }
        
        float MinRadiationInBody { get; }
        float MaxRadiationInBody { get; }
    }
}