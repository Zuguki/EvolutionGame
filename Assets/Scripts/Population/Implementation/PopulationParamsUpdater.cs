using System;
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

        private const float BloodCoeff = 0.01f;

        private double _bnr = 0;
        private double _dnr = 0;
        private readonly IComfortParams _comfortParams;
        private readonly IPopulationDeadParams _deadParams;
        private readonly PopulationParams _populationParams;

        public PopulationParamsUpdater(PopulationParams populationParams, IComfortParams comfortParams, IPopulationDeadParams deadParams)
        {
            _populationParams = populationParams;
            _comfortParams = comfortParams;
            _deadParams = deadParams;
        }

        // T.T = Квл* Tокр + t
        public float GetBodyTemperature() => 
            InfluenceCoefficient * Temperature.Value + ThermalBalancingCoefficient;

        public (float, float) GetArterialPressure()
        {
            // siastArterialPressure - систолическое артериальное давление
            // diastArterialPressure  - диастолическое артериальное давление 
            //
            //     diastArterialPressure  = 
            //         ((siastArterialPressure - goodSiastArterialPressure) / 2 ) + goodDiastArterialPressure, где 
            //
            // goodSiastArterialPressure = 120 - эталонное систолическое артериальное давление
            //     goodDiastArterialPressure = 80 - эталонное диастолическое артериальное давление
            //
            //
            //
            // если  < 50, то diastArterialPressure  = siastArterialPressure
            //
            // siastArterialPressure = K * P - Kрег
            // где
            //
            //     K = 11/10 - коэффициент динамики давления
            //     Kрег = 700 - коэффициент регуляции давления 
            // P - атмосферное давление 

            var k = 11 / (float) 10;
            var kreg = 700;
            var sistAt = 120;
            var diastAt = 80;
            var siastArterialPressure = k * Pressure.Value - kreg;

            var diastArterialPressure = (siastArterialPressure - sistAt) / 2f + diastAt;
            return (siastArterialPressure, diastArterialPressure);
        }

        public float GetWaterInBody(float waterInBody, long square, long populationCount)
        {
            var kn = 0.99f;
            var kpv = 3;
            var daysPerYear = 365;
            var kvl = 0.5f;
            var constEqual = 17328.76712328801;
            
            var d = kpv * populationCount -
                    square * (Preciptiation.Value * kn / daysPerYear + (Humidity.Value + 1) * kvl / 100);
            return (float) (((waterInBody * 100) - (d * 0.01 / constEqual)) / 100);
            
            // Кол-во жидкости = V -= D * 0,01 / const
            //     где:
            // ВЗ - водный запас 
            // НВЗ - начальный водный запас 
            //
            //
            //     D = Кпв*КП – S*(КО*kн/365 + (ВВ + 1)*kвл.вв/100) - изменение объема жидкости за одну итерацию 
            // где:             
            // В = 60 - объем жидкости человека
            // S - площадь, которую использует популяция 
            // КП - количество популяции 
            //     КП ~ S
            // КО - количество осадков
            // ВВ - влажность воздуха
            //     kн= 0,99 - коэффициент нормирования
            // kвл.вв = ½ - коэффициент влияния
            //     Кпв = 3 - потребление воды на 1 индивида
            // const - 17328,76712328801  - уравнивающая константа
            // t - время итерации
        }

        public float GetBloodInBody(PopulationParams populationParams, IPopulationDeadParams deadParams)
        {
            // Уменьшение: 
            // Количество Крови = КН*(1-n*t)
            //
            // Все параметры популяции в норме и когда КН < 5
            // Увеличение:
            // Количество Крови = КН*(1+n*t) <= 5
            //
            // где:
            //
            // n = 0,01 - коэффициент потери
            //     КН = 5 - начальное количество крови
            // t - время итерации

            return PopulationEvent.TryAddDeadMessage(out _, populationParams, deadParams)
                ? populationParams.BloodInBody * (1 - BloodCoeff)
                : populationParams.BloodInBody * (1 + BloodCoeff);
        }

        public float GetRadiationInBody(IComfortWeather comfortWeather, float radiation, int daysAlive)
        {
            // R =  Rокр  * (kвоз.р + 
            //     +((MAXос - КО) * ((MAXчист.п - ЧП)/kвоз.п))/kрег^2)
            //
            //
            // Радиация организма = R, если R / d >  MAXд.р. (мкЗв/с), иначе равна 0
            //
            //
            //
            // HR = 0 - начальная радиация (при первой итерации)
            // MAXос = 8000 - максимальное количество осадков
            // MAXд.р. = 20(внедрено) - максимальная допустимая радиация для популяции(брать из параметра популяции)
            // kвоз.р = 0,96 - коэффициент воздействия радиации
            // Rокр - радиация окружающей среды
            // КО - количество осадков
            // MAXчист.п = 0,98 - максимальная чистота почвы 
            //     kрег = 50 - коэффициент регуляции
            // kвоз.п = 16 - коэффицент воздействия почвы
            // ЧП - чистота почвы
            // t - время итерации
            //     d = t - счетчик итераций
            // R - суммирование радиации в организме
 
            var r = Radiation.Value * (RadiationCoeff +
                                           ((Preciptiation.MaxValue - Preciptiation.Value) *
                                            ((SoilPurity.MaxValue - SoilPurity.Value) / SoilPurityCoeff)) /
                                           (float) Math.Pow(RegulationCoeff, 2));
            
            return radiation + (r / daysAlive > comfortWeather.MaxRadiation ? r : 0);
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
            else if (PopulationEvent.TryAddDiscomfortParams(out _, _populationParams, _comfortParams))
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