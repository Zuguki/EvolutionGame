using System;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 22.8f;
        public float MaxTemperature => 36.2f;

        public (float, float) MinArterialPressure => (0, 0);
        public (float, float) MaxArterialPressure => (300, 300);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody => .75f;
        
        public float MinBloodInBody => 3;
        public float MaxBloodInBody => 5;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 6 * (float) Math.Pow(10, 6);
    }
}