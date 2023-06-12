using System;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanDeadParameters : IPopulationDeadParams
    {
        public float MinTemperature => 29.5f;
        public float MaxTemperature => 42.8f;

        public (float, float) MinArterialPressure => (37, 37);
        public (float, float) MaxArterialPressure => (147, 97);

        public float MinWaterInBody => 0.3f;
        public float MaxWaterInBody => .75f;
        
        public float MinBloodInBody => 3;
        public float MaxBloodInBody => 5;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 9 * (float) Math.Pow(10, 6);
    }
}