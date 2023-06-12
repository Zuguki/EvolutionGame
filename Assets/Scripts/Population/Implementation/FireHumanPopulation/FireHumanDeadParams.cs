using System;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 32.8f;
        public float MaxTemperature => 44.5f;

        public (float, float) MinArterialPressure => (100, 60);
        public (float, float) MaxArterialPressure => (180, 120);

        public float MinWaterInBody => 0.45f;
        public float MaxWaterInBody => .75f;
        
        public float MinBloodInBody => 3;
        public float MaxBloodInBody => 5;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 8 * (float) Math.Pow(10, 6);
    }
}