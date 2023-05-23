using System.Collections.Generic;
using System.Linq;
using Population.ComfortWeather;
using Population.Implementation;
using UnityEngine;

namespace Population
{
    public interface IPopulation 
    {
        public string Name { get; }
        
        public IPopulationDescription Description { get; }
        public PopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        
        public bool IsAlive { get; }
    }

    public interface IPopulationSprites
    {
        public Sprite SpriteOfMenu { get; }
        public Sprite LockSpriteMenu { get; }
        public Sprite SpriteOfPopulationMenu { get; }
    }

    public abstract class PopulationParams
    {
        private float _bodyTemperature = 34f;
        private (float, float) _arterialPressure = (110f, 75f);
        private float _waterInBody = .6f;
        private float _radiation = 70;
        private float _bloodInBody = 5;

        private readonly IPopulationDeadParams _deadParams;
        private readonly IComfortWeather _comfortWeather;
        private readonly IPopulationCantBe _populationCantBe;
        private readonly IPopulationParamsUpdater _populationParamsUpdater;

        protected PopulationParams(float bodyTemperature, (float, float) arterialPressure, float waterInBody,
            float radiation, float bloodInBody, IPopulationDeadParams deadParams, IComfortWeather comfortWeather,
            IPopulationCantBe populationCantBe)
        {
            BodyTemperature = bodyTemperature;
            ArterialPressure = arterialPressure;
            WaterInBody = waterInBody;
            Radiation = radiation;
            BloodInBody = bloodInBody;
            
            _deadParams = deadParams;
            _comfortWeather = comfortWeather;
            _populationCantBe = populationCantBe;
            _populationParamsUpdater = new PopulationParamsUpdater(this, _comfortWeather, _deadParams);
            // _populationParamsUpdater = paramsUpdater;
        }

        public List<string> DeadMessages { get; set; } = new();
        public float BodyTemperature
        {
            get => _bodyTemperature;
            set
            {
                if (value >= Parameters.BodyTemperature.MaxValue)
                    _bodyTemperature = Parameters.BodyTemperature.MaxValue;
                else if (value <= Parameters.BodyTemperature.MinValue)
                    _bodyTemperature = Parameters.BodyTemperature.MinValue;
                else
                    _bodyTemperature = value;
            }
        }
        
        public (float, float) ArterialPressure
        {
            get => _arterialPressure;
            set
            {
                if (value.Item1 >= Parameters.ArterialPressure.MaxValue.Item1 ||
                    value.Item2 >= Parameters.ArterialPressure.MaxValue.Item2)
                    _arterialPressure = Parameters.ArterialPressure.MaxValue;
                else if (value.Item1 <= Parameters.ArterialPressure.MinValue.Item1 ||
                         value.Item2 <= Parameters.ArterialPressure.MinValue.Item2)
                    _arterialPressure = Parameters.ArterialPressure.MinValue;
                else
                    _arterialPressure = value;
            }
        }

        public float WaterInBody
        {
            get => _waterInBody;
            set
            {
                if (value >= Parameters.WaterInBody.MaxValue)
                    _waterInBody = Parameters.WaterInBody.MaxValue;
                else if (value <= Parameters.WaterInBody.MinValue)
                    _waterInBody = Parameters.WaterInBody.MinValue;
                else
                    _waterInBody = value;
            }
        }

        public float Radiation
        {
            get => _radiation;
            set
            {
                if (value >= Parameters.RadiationInBody.MaxValue)
                    _radiation = Parameters.RadiationInBody.MaxValue;
                else if (value <= Parameters.RadiationInBody.MinValue)
                    _radiation = Parameters.RadiationInBody.MinValue;
                else
                    _radiation = value;
            }
        }

        public float BloodInBody
        {
            get => _bloodInBody;
            set
            {
                if (value >= Parameters.BloodInBody.MaxValue)
                    _bloodInBody = Parameters.BloodInBody.MaxValue;
                else if (value <= Parameters.BloodInBody.MinValue)
                    _bloodInBody = Parameters.BloodInBody.MinValue;
                else
                    _bloodInBody = value;
            }
        }
        public int DaysAlive { get; set; }
        public long Count { get; set; } = 1_000_000;

        public virtual void UpdateParams()
        {
            BodyTemperature = _populationParamsUpdater.GetBodyTemperature();
            ArterialPressure = _populationParamsUpdater.GetArterialPressure();
            WaterInBody = _populationParamsUpdater.GetWaterInBody();
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, _deadParams);
            Radiation = _populationParamsUpdater.GetRadiationInBody(_comfortWeather, Radiation);
            Count = _populationParamsUpdater.GetPopulationCount(Count);
            
            PopulationEvent.TryAddDeadMessage(out var list, this, _deadParams);
            DeadMessages = DeadMessages.Union(list).ToList();
            
            if (!PopulationEvent.TryAddPopulationCantBeMessage(out list, _populationCantBe))
                return;
            DeadMessages = DeadMessages.Union(list).ToList();
            Count = 0;
        }
    }
}