namespace Population.Implementation.HumanPopulation
{
    public class HumanComfortParams : IComfortParams
    {
        public float MinTemperature => 35.5f;
        public float MaxTemperature => 37.5f;

        public (float, float) MinArterialPressure => (114, 77);
        public (float, float) MaxArterialPressure => (136, 88);

        public float MinWaterInBody => .5f;
        public float MaxWaterInBody => .75f;

        public float MinBloodInBody => 4.5f;
        public float MaxBloodInBody => 5f;

        public float MinRadiationInBody => 0f;
        public float MaxRadiationInBody => 20f;
    }
}