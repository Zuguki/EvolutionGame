using Population.ComfortWeather;

namespace Population
{
    public interface IPopulationParamsUpdater
    {
        float GetBodyTemperature();

        (float, float) GetArterialPressure();

        float GetWaterInBody(float waterInBody, long square, long count);

        float GetBloodInBody(PopulationParams populationParams, IPopulationDeadParams deadParams);

        float GetRadiationInBody(IComfortWeather comfortWeather, float radiation, int daysAlive);

        long GetPopulationCount(long count);
    }
}