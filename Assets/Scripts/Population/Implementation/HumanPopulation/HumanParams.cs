using System.Collections.Generic;
using System.Linq;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.HumanPopulation
{
    public class HumanParams : IPopulationParams
    {
        public List<string> DeadMessages { get; set; } = new();
        public float BodyTemperature { get; set; } = 36.6f;
        public (float, float) ArterialPressure { get; set; } = (120f, 80f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public float Radiation { get; set; } = 100;
        public int DaysAlive { get; set; }
        public long Count { get; set; } = 1_000;

        private readonly PopulationParamsUpdater _populationParamsUpdater;

        public HumanParams()
        {
            _populationParamsUpdater =
                new PopulationParamsUpdater(this, new HumanComfortWeather(), new HumanDeadParams());
        }

        public void UpdateParams()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
            ArterialPressure = _populationParamsUpdater.GetArterialPressure();
            WaterInBody = _populationParamsUpdater.GetWaterInBody();
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, new HumanDeadParams());
            Radiation = _populationParamsUpdater.GetRadiationInBody(new HumanComfortWeather(), Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, new HumanDeadParams());
            DeadMessages = DeadMessages.Union(list).ToList();
        }
    }
}