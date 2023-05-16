using System;
using ComfortWeather;
using UnityEditor.Experimental;
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

        private double bnr = 0;
        private double dnr = 0;
        private readonly IComfortWeather comfortWeather;
        private readonly IPopulationDeadParams deadParams;
        private readonly IPopulationParams populationParams;

        public PopulationParamsUpdater(IPopulationParams populationParams, IComfortWeather comfortWeather, IPopulationDeadParams deadParams)
        {
            this.populationParams = populationParams;
            this.comfortWeather = comfortWeather;
            this.deadParams = deadParams;
        }

        // T.T = Квл* Tокр + t
        public float GetBodyTemperature() => 
            InfluenceCoefficient * Temperature.Value + ThermalBalancingCoefficient;

        public (float, float) GetArterialPressure()
        {
            // Закон, формула по которому изменяется параметр:
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
            //
            //
            //     если siastArterialPressure < 50, то siastArterialPressure = diastArterialPressure 
            //
            // siastArterialPressure = K * P - Kрег
            // где
            //
            //     K = 11/10 - коэффициент динамики давления
            //     Kрег = 705 - коэффициент регуляции давления 

            return (0, 0);
        }

        public float GetWaterInBody()
        {
            // Кол-во жидкости = ⅗ * (ВЗ / КП^2) * 100
            // где:
            // ВЗ - водный запас 
            // НВЗ - начальный водный запас 
            //
            //
            //     ВЗ = НВЗ- t(Кпв*КП – S*((КО*kн/365 + ВВ*kвл.вв/100))
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

            return 0;
        }

        public float GetBloodInBody(IPopulationParams populationParams, IPopulationDeadParams deadParams)
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
                : populationParams.BloodInBody * (1 * BloodCoeff);
        }
        
        public float GetRadiationInBody(float radiation)
        {
            var r = Radiation.Value * 1 * (RadiationCoeff +
                                           ((Preciptiation.MaxValue - Preciptiation.Value) *
                                            ((SoilPurity.MaxValue - SoilPurity.Value) / SoilPurityCoeff)) /
                                           RegulationCoeff);

            return radiation + r;

            // R =  Rокр * t * (kвоз.р + ((MAXос - КО) * ((MAXчист.п - ЧП)/kвоз.п))/kрег)
            // Радиация организма = HR + R, если (HR + R)/t >  MAXд.р. (мкЗв/с), иначе равна 0

            // HR = 0 - начальная радиация (при первой итерации)
            // R- действительная радиация
            //     MAXос = 8000 - максимальное количество осадков
            // MAXд.р.(внедрено) - максимальная допустимая радиация для популяции(брать из параметра популяции)
            // kвоз.р = 0,96 - коэффициент воздействия радиации
            // Rокр - радиация окружающей среды
            // КО - количество осадков
            // MAXчист.п = 0,98 - максимальная чистота почвы 
            //     kрег = 50 - коэффициент регуляции
            // kвоз.п = 16 - коэффицент воздействия почвы
            // ЧП - чистота почвы
            // t - время итерации
        }

        public long GetPopulationCount(long count)
        {
            UpdateBnrDnr();
            return (long) (count * Math.Pow(Math.E, (bnr - dnr) / 365));
        }
        
        private void UpdateBnrDnr()
        {
            if (PopulationEvent.TryAddDeadMessage(out var list, populationParams, deadParams) && list.Count == 4)
            {
                bnr = 0;
                dnr = 1_000;
            }
            else if (PopulationEvent.TryAddDeadMessage(out _, populationParams, deadParams))
            {
                bnr = 0.01;
                dnr = 100;
            }
            else if (PopulationEvent.TryAddDiscomfortParams(out _, comfortWeather))
            {
                bnr = 0.015;
                dnr = 0.015;
            }
            else
            {
                bnr = 0.025;
                dnr = 0.015;
            }
        }
    }
}