using System.Collections.Generic;
using System.Linq;
using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanParameters : IPopulationParams
    {
        public List<string> DeadMessages { get; set; } = new();
        public int DaysAlive { get; set; } = 0;
        public float BodyTemperature { get; set; } = 38f;
        public (float, float) ArterialPressure { get; set; } = (150f, 85f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public long Count { get; set; } = PopulationCount.Value;
        public float Radiation { get; set; } = 200;
        
        private readonly PopulationParamsUpdater _populationParamsUpdater;

        public FireHumanParameters()
        {
            _populationParamsUpdater =
                new PopulationParamsUpdater(this, new FireHumanComfortWeather(), new FireHumanDeadParams());
        }

        public void UpdateParams()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
            ArterialPressure = _populationParamsUpdater.GetArterialPressure();
            WaterInBody = _populationParamsUpdater.GetWaterInBody();
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, new FireHumanDeadParams());
            Radiation = _populationParamsUpdater.GetRadiationInBody(new FireHumanComfortWeather(), Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, new FireHumanDeadParams());
            DeadMessages = DeadMessages.Union(list).ToList();
            
            if (!PopulationEvent.TryAddPopulationCantBeMessage(out list, new FireHumanCantBe())) 
                return;
            DeadMessages = DeadMessages.Union(list).ToList();
            Count = 0;
        }
    }
}