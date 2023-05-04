using System;

namespace Population.Implementation
{
    public class HumanDeadParams : IPopulationDeadParams
    {
        public float MinTemperature => 26;
        public float MaxTemperature => 42;

        public (float, float) MinArterialPressure => (100, 60);
        public (float, float) MaxArterialPressure => (180, 120);

        public float MinWaterInBody => .4f;
        public float MaxWaterInBody { get; }
        
        public float MinRadiationInBody { get; }
        public float MaxRadiationInBody => 7 * (float) Math.Pow(10, 6);
    }
}