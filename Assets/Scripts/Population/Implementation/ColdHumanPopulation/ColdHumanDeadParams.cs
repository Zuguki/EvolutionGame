using System;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 24;
        public float MaxTemperature => 40;

        public (float, float) MinArterialPressure => (103, 53);
        public (float, float) MaxArterialPressure => (213, 163);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody => 1;
        
        public float MinBloodInBody => 3;

        public float MinRadiationInBody => 0;
        public float MaxRadiationInBody => 6 * (float) Math.Pow(10, 6);
    }
}