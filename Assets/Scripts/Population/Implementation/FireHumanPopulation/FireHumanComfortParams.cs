namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanComfortParams : IComfortParams
    {
        public float MinTemperature => 36.2f;
        public float MaxTemperature => 39.5f;

        public (float, float) MinArterialPressure => (81, 60);
        public (float, float) MaxArterialPressure => (103, 71);

        public float MinWaterInBody => .5f;
        public float MaxWaterInBody => .75f;

        public float MinBloodInBody => 4.5f;
        public float MaxBloodInBody => 5f;

        public float MinRadiationInBody => 0f;
        public float MaxRadiationInBody => 25f;
    }
}