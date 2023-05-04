namespace Population
{
    public interface IPopulationParamsUpdater
    {
        float GetBodyTemperature();

        (float, float) GetArterialPressure();

        float GetWaterInBody();

        float GetBloodInBody(int daysAlive, float bloodInBody);

        float GetRadiationInBody(int daysAlive, float comfortRadiation);
    }
}