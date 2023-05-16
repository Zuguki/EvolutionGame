namespace Population
{
    public interface IPopulationParamsUpdater
    {
        float GetBodyTemperature();

        (float, float) GetArterialPressure();

        float GetWaterInBody();

        float GetBloodInBody(IPopulationParams populationParams, IPopulationDeadParams deadParams);

        float GetRadiationInBody(float radiation);

        long GetPopulationCount(long count);
    }
}