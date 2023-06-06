namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanComfortParams : IComfortParams
    {
        public float MinTemperature => 29.5f;
        public float MaxTemperature => 35.5f;

        public (float, float) MinArterialPressure => (147, 93.5f);
        public (float, float) MaxArterialPressure => (169, 104.5f);

        public float MinWaterInBody => .45f;
        public float MaxWaterInBody => .75f;

        public float MinBloodInBody => 4.5f;
        public float MaxBloodInBody => 5f;

        public float MinRadiationInBody => 0f;
        public float MaxRadiationInBody => 15f;
    }
}