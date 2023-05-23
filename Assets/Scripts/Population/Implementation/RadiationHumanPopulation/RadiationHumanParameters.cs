using System.Collections.Generic;
using System.Linq;
using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanParameters : IPopulationParams
    {
        public List<string> DeadMessages { get; set; } = new();
        public int DaysAlive { get; set; } = 0;
        public float BodyTemperature { get; set; } = 37f;
        public (float, float) ArterialPressure { get; set; } = (110f, 75f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public long Count { get; set; } = PopulationCount.Value;
        public float Radiation { get; set; } = 70;
        
        private readonly PopulationParamsUpdater _populationParamsUpdater;

        public RadiationHumanParameters()
        {
            _populationParamsUpdater =
                new PopulationParamsUpdater(this, new RadiationHumanComfortWeather(), new RadiationHumanDeadParameters());
        }

        public void UpdateParams()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
            ArterialPressure = _populationParamsUpdater.GetArterialPressure();
            WaterInBody = _populationParamsUpdater.GetWaterInBody();
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, new RadiationHumanDeadParameters());
            Radiation = _populationParamsUpdater.GetRadiationInBody(new RadiationHumanComfortWeather(), Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, new RadiationHumanDeadParameters());
            DeadMessages = DeadMessages.Union(list).ToList();
        }
    }
}