using System;

namespace Population.Implementation.HumanPopulation
{
    public class HumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 26;
        public float MaxTemperature => 42;

        public (float, float) MinArterialPressure => (100, 60);
        public (float, float) MaxArterialPressure => (180, 120);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody => 1;
        
        public float MinBloodInBody => 3;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 7 * (float) Math.Pow(10, 6);
    }
}