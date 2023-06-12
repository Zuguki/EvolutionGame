using System;

namespace Population.Implementation.HumanPopulation
{
    public class HumanCantBe : IPopulationCantBe
    {
        public float MinTemperature => -25;
        public float MaxTemperature => 50;

        public float MinPressure => 600;
        public float MaxPressure => 900;

        public float MaxRadiation => 10 * (float) Math.Pow(10, 6);
        public float MaxAirQuality => 350;
        public float MinSoilPurity => 0.7f;

        public float MaxNoise => 150;

        public float MaxWindSpeed => 50;
    }
}