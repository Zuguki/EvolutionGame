using System;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanDeadParameters : IPopulationDeadParams
    {
        public float MinTemperature => 31;
        public float MaxTemperature => 43;

        public (float, float) MinArterialPressure => (37, 37);
        public (float, float) MaxArterialPressure => (147, 97);

        public float MinWaterInBody => 0.3f;
        public float MaxWaterInBody => 1f;
        
        public float MinBloodInBody => 3;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 9 * (float) Math.Pow(10, 6);
    }
}