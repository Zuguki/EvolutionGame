using System;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanCantBe : IPopulationCantBe
    {
        public float MinTemperature => -10;
        public float MaxTemperature => 55;

        public float MinPressure => 500;
        public float MaxPressure => 850;

        public float MaxRadiation => 10 * (float) Math.Pow(10, 6);
        public float MaxAirQuality => 350;
        public float MinSoilPurity => 0.7f;

        public float MaxNoise => 150;
        
        public float MaxWindSpeed => 50;
    }
}