using System.Collections.Generic;
using System.Linq;
using ComfortWeather.Implementation;
using Parameters;
using Population.Implementation.HumanPopulation;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanParameters : IPopulationParams
    {
        public List<string> DeadMessages { get; set; }
        public float BodyTemperature { get; set; } = 34f;
        public (float, float) ArterialPressure { get; set; } = (110f, 75f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public long Count { get; set; } = PopulationCount.Value;
        public float Radiation { get; set; } = 70;
        public int DaysAlive { get; set; } = 0;
        
        private readonly PopulationParamsUpdater _populationParamsUpdater;

        public ColdHumanParameters()
        {
            _populationParamsUpdater =
                new PopulationParamsUpdater(this, new ColdHumanComfortWeather(), new ColdHumanDeadParams());
        }

        public void UpdateParams()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
            ArterialPressure = _populationParamsUpdater.GetArterialPressure();
            WaterInBody = _populationParamsUpdater.GetWaterInBody();
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, new HumanDeadParams());
            Radiation = _populationParamsUpdater.GetRadiationInBody(Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, new HumanDeadParams());
            DeadMessages = DeadMessages.Union(list).ToList();
        }
    }
}