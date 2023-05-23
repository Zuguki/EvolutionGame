using System;
using Parameters;
using Population.ComfortWeather;
using Weather;

namespace Population.Implementation
{
    public class PopulationParamsUpdater : IPopulationParamsUpdater
    {
        private const float InfluenceCoefficient = 1 / (float) 3;
        private const float ThermalBalancingCoefficient = 266 / (float) 9;
        
        private const float RadiationCoeff = 0.96f;
        private const float SoilPurityCoeff = 16;
        private const float RegulationCoeff = 50;

        private const float PressureCoeff = 11 / (float) 10;
        private const float PressureRegularCoeff = 705;

        private const float BloodCoeff = 0.01f;

        private double _bnr = 0;
        private double _dnr = 0;
        private readonly IComfortWeather _comfortWeather;
        private readonly IPopulationDeadParams _deadParams;
        private readonly PopulationParams _populationParams;

        // private double _hbz = Math.Pow(PopulationCount.Value, 2);
        private double _hbz = PopulationCount.Value;

        public PopulationParamsUpdater(PopulationParams populationParams, IComfortWeather comfortWeather, IPopulationDeadParams deadParams)
        {
            _populationParams = populationParams;
            _comfortWeather = comfortWeather;
            _deadParams = deadParams;
        }

        // T.T = Квл* Tокр + t
        public float GetBodyTemperature() => 
            InfluenceCoefficient * Temperature.Value + ThermalBalancingCoefficient;

        public (float, float) GetArterialPressure()
        {
            // Возможно допустимые значения(минимальное, максимальное):
            //
            // minArterialPressure = 70/60 мм рт ст
            //
            //     ArterialPressure = 120/80 мм рт ст
            //
            //     maxArterialPressure = 180/130 мм рт ст
            //
            //
            //     Закон, формула по которому изменяется параметр:
            //
            // ArterialPressure = siastArterialPressure / diastArterialPressure , где 
            //
            // siastArterialPressure - систолическое артериальное давление
            // diastArterialPressure  - диастолическое артериальное давление 
            //
            //     diastArterialPressure  = siastArterialPressure - d
            //
            // 40 <= d <= 50 - диапазон расчета систолического давления
            //
            //     если siastArterialPressure < 50, то siastArterialPressure = diastArterialPressure 
            //
            // siastArterialPressure = K * P - Kрег
            // где
            //
            //     K = 11/10 - коэффициент динамики давления
            //     Kрег = 700 - коэффициент регуляции давления 

            var k = 11 / (float) 10;
            var kreg = 700;
            var sistAt = 120;
            var diastAt = 80;
            var siastArterialPressure = k * Pressure.Value - kreg;

            var diastArterialPressure = (siastArterialPressure - sistAt) / 2f + diastAt;
            return (siastArterialPressure, diastArterialPressure);
        }

        public float GetWaterInBody()
        {
            var kpv = 3;
            var kn = 0.99;
            var daysInYear = 365;
            var kvl = 1 / (float) 2;
            var s = PopulationCount.Value;
            // Кол-во жидкости = ⅗ * (ВЗ / КП^2) * 100
            // где:
            // ВЗ - водный запас 
            // НВЗ - начальный водный запас 
            //
            //
            // ВЗ = НВЗ- t(Кпв*КП – S*((КО*kн/365 + ВВ*kвл.вв/100))
            // где:             
            // НВЗ - начальный водный запас ПРИ ПЕРВОЙ ИТТЕРАЦИИ = КП^2
            // S - площадь, которую использует популяция 
            // КП - количество популяции 
            //     КП ~ S
            // КО - количество осадков
            // ВВ - влажность воздуха
            //     kн= 0,99 - коэффициент нормирования
            // kвл.вв = ½ - коэффициент влияния
            //     Кпв = 3 - потребление воды на 1 индивида
            // t - время итерации

            var vz = _hbz - (kpv * PopulationCount.Value - PopulationCount.Value *
                (Preciptiation.Value * kn / (float) daysInYear + Humidity.Value * kvl / 100));
            // 21 500
            
            var result = (float) ((3 / (float) 5) * (vz / (float) _hbz));
            _hbz = vz;
            return result;
        }

        public float GetBloodInBody(PopulationParams populationParams, IPopulationDeadParams deadParams)
        {
            // Формула начинает работать, когда хоть один параметр находится в критическом положении.
            // Уменьшение: 
            // Количество Крови = КН*(1-n*t)
            //
            // Все параметры популяции в норме и когда КН < 5
            // Увеличение:
            // Количество Крови = КН*(1+n*t) <= 5
            //
            // где:
            // n = 0,01 - коэффициент потери
            //     КН = 5 - начальное количество крови
            // t - время итерации

            return PopulationEvent.TryAddDeadMessage(out _, populationParams, deadParams)
                ? populationParams.BloodInBody * (1 - BloodCoeff)
                : populationParams.BloodInBody * (1 + BloodCoeff);
        }

        public float GetRadiationInBody(IComfortWeather comfortWeather, float radiation)
        {
            var r = Radiation.Value * (RadiationCoeff +
                                           ((Preciptiation.MaxValue - Preciptiation.Value) *
                                            ((SoilPurity.MaxValue - SoilPurity.Value) / SoilPurityCoeff)) /
                                           RegulationCoeff);

            return radiation + (r > comfortWeather.MaxRadiation ? r : 0);
        }

        public long GetPopulationCount(long count)
        {
            UpdateBnrDnr();
            return (long) (count * Math.Pow(Math.E, (_bnr - _dnr) / 365));
        }
        
        private void UpdateBnrDnr()
        {
            if (PopulationEvent.TryAddDeadMessage(out var list, _populationParams, _deadParams) && list.Count == 4)
            {
                _bnr = 0;
                _dnr = 1_000;
            }
            else if (PopulationEvent.TryAddDeadMessage(out _, _populationParams, _deadParams))
            {
                _bnr = 0.01;
                _dnr = 100;
            }
            else if (PopulationEvent.TryAddDiscomfortParams(out _, _comfortWeather))
            {
                _bnr = 0.015;
                _dnr = 0.015;
            }
            else
            {
                _bnr = 0.025;
                _dnr = 0.015;
            }
        }
    }
}