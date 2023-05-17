using System.Collections.Generic;
using System.Linq;
using Parameters;
using Population.ComfortWeather.Implementation;

namespace Population.Implementation.HumanPopulation
{
    public class HumanParams : IPopulationParams
    {
        public List<string> DeadMessages { get; set; } = new();

        // public float BodyTemperature { get; set; }
        // {
        //     get => bodyTemperature;
        //     set
        //     {
        //         if (value <= 35.5)
        //             bodyTemperature = 35.5f;
        //         else if (value >= 37.5)
        //             bodyTemperature = 37.5f;
        //         else
        //             bodyTemperature = value;
        //     }
        // }

        // public (float, float) ArterialPressure { get; set; }
        // {
        //     get => arterialPressuere;
        //     set
        //     {
        //         if (value.Item1 <= 114 || value.Item2 <= 74)
        //         {
        //             arterialPressuere.Item1 = 114;
        //             arterialPressuere.Item2 = 74;
        //         }
        //         else if (value.Item1 >= 136 || value.Item2 >= 86)
        //         {
        //             arterialPressuere.Item1 = 136;
        //             arterialPressuere.Item2 = 86;
        //         }
        //         else
        //             arterialPressuere = value;
        //     }
        // } 
        
        public float BodyTemperature { get; set; } = 36.6f;
        public (float, float) ArterialPressure { get; set; } = (120f, 80f);
        public float WaterInBody { get; set; } = .6f;
        public float BloodInBody { get; set; } = 5;
        public float Radiation { get; set; } = 100;
        public int DaysAlive { get; set; }
        public long Count { get; set; } = PopulationCount.Value;

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
            Radiation = _populationParamsUpdater.GetRadiationInBody(Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, new HumanDeadParams());
            DeadMessages = DeadMessages.Union(list).ToList();
        }
    }
}