using System;

namespace Population.Implementation.HumanPopulation
{
    public class HumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 26.2f;
        public float MaxTemperature => 41.8f;

        public (float, float) MinArterialPressure => (0, 0);
        public (float, float) MaxArterialPressure => (300, 300);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody => .75f;
        
        public float MinBloodInBody => 3;
        public float MaxBloodInBody => 5;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 7 * (float) Math.Pow(10, 6);
    }
}