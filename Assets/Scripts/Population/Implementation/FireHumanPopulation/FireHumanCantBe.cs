using System;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanCantBe : IPopulationCantBe
    {
        public float MinTemperature => -15;
        public float MaxTemperature => 60;

        public float MinPressure => 500;
        public float MaxPressure => 850;

        public float MaxRadiation => 9 * (float) Math.Pow(10, 6);
        public float MaxAirQuality => 350;
        public float MinSoilPurity => 0.7f;

        public float MaxNoise => 150;
        
        public float MaxWindSpeed => 50;
    }
}