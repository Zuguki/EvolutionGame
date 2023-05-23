using System;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanCantBe : IPopulationCantBe
    {
        public float MinTemperature => -35;
        public float MaxTemperature => 45;

        public float MinPressure => 670;
        public float MaxPressure => 950;

        public float MaxRadiation => 7 * (float) Math.Pow(10, 6);
        public float MaxAirQuality => 350;
        public float MinSoilPurity => 0.7f;

        public float MaxNoise => 150;
    }
}