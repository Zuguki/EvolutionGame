using System.Collections.Generic;
using System.Linq;
using Population.ComfortWeather;
using Population.Implementation;

namespace Population
{
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
        private readonly long _populationSquare;
        
        protected PopulationParams(float bodyTemperature, (float, float) arterialPressure, float waterInBody,
            float radiation, float bloodInBody, long populationSquare, IPopulationDeadParams deadParams, IComfortWeather comfortWeather,
            IPopulationCantBe populationCantBe, IComfortParams comfortParams)
        {
            BodyTemperature = bodyTemperature;
            ArterialPressure = arterialPressure;
            WaterInBody = waterInBody;
            Radiation = radiation;
            BloodInBody = bloodInBody;
            
            _deadParams = deadParams;
            _comfortWeather = comfortWeather;
            _populationCantBe = populationCantBe;
            _populationSquare = populationSquare;
            _populationParamsUpdater = new PopulationParamsUpdater(this, comfortParams, _deadParams);
            // _populationParamsUpdater = paramsUpdater;
        }

        public List<string> DeadMessages { get; set; } = new();
        public float BodyTemperature
        {
            get => _bodyTemperature;
            set
            {
                if (_deadParams is null)
                {
                    _bodyTemperature = value;
                    return;
                }
                
                if (value >= _deadParams.MaxTemperature)
                    _bodyTemperature = _deadParams.MaxTemperature;
                else if (value <= _deadParams.MinTemperature)
                    _bodyTemperature = _deadParams.MinTemperature;
                else
                    _bodyTemperature = value;
            }
        }
        
        public (float, float) ArterialPressure
        {
            get => _arterialPressure;
            set
            {
                if (_deadParams is null)
                {
                    _arterialPressure = value;
                    return;
                }
                
                if (value.Item1 >= _deadParams.MaxArterialPressure.Item1 ||
                    value.Item2 >= _deadParams.MaxArterialPressure.Item2)
                    _arterialPressure = _deadParams.MaxArterialPressure;
                else if (value.Item1 <= _deadParams.MinArterialPressure.Item1 ||
                         value.Item2 <= _deadParams.MinArterialPressure.Item2)
                    _arterialPressure = _deadParams.MinArterialPressure;
                else
                    _arterialPressure = value;
            }
        }

        public float WaterInBody
        {
            get => _waterInBody;
            set
            {
                if (_deadParams is null)
                {
                    _waterInBody = value;
                    return;
                }
                
                if (value >= _deadParams.MaxWaterInBody)
                    _waterInBody = _deadParams.MaxWaterInBody;
                else if (value <= _deadParams.MinWaterInBody)
                    _waterInBody = _deadParams.MinWaterInBody;
                else
                    _waterInBody = value;
            }
        }

        public float Radiation
        {
            get => _radiation;
            set
            {
                if (_deadParams is null)
                {
                    _radiation = value;
                    return;
                }
                
                if (value >= _deadParams.MaxRadiationInBody)
                    _radiation = _deadParams.MaxRadiationInBody;
                else if (value <= _deadParams.MinRadiationInBody)
                    _radiation = _deadParams.MinRadiationInBody;
                else
                    _radiation = value;
            }
        }

        public float BloodInBody
        {
            get => _bloodInBody;
            set
            {
                if (_deadParams is null)
                {
                    _bloodInBody = value;
                    return;
                }
                
                if (value >= _deadParams.MaxBloodInBody)
                    _bloodInBody = _deadParams.MaxBloodInBody;
                else if (value <= _deadParams.MinBloodInBody)
                    _bloodInBody = _deadParams.MinBloodInBody;
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
            WaterInBody = _populationParamsUpdater.GetWaterInBody(WaterInBody, _populationSquare, Count);
            BloodInBody = _populationParamsUpdater.GetBloodInBody(this, _deadParams);
            Radiation = _populationParamsUpdater.GetRadiationInBody(_comfortWeather, Radiation, DaysAlive);
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