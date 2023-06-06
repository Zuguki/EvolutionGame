namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanComfortParams : IComfortParams
    {
        public float MinTemperature => 35.8f;
        public float MaxTemperature => 38.5f;

        public (float, float) MinArterialPressure => (81, 60);
        public (float, float) MaxArterialPressure => (103, 71.5f);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody => .65f;

        public float MinBloodInBody => 4.5f;
        public float MaxBloodInBody => 5f;

        public float MinRadiationInBody => 0f;
        public float MaxRadiationInBody => 30f;
    }
}