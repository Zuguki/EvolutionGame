using System;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 32;
        public float MaxTemperature => 44;

        public (float, float) MinArterialPressure => (37, 37);
        public (float, float) MaxArterialPressure => (147, 97);

        public float MinWaterInBody => 0.45f;
        public float MaxWaterInBody => .75f;
        
        public float MinBloodInBody => 3;
        public float MaxBloodInBody => 5;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 8 * (float) Math.Pow(10, 6);
    }
}