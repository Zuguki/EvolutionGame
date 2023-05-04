using Weather;

namespace Population.Implementation
{
    public class PopulationParamsUpdater : IPopulationParamsUpdater
    {
        private const float InfluenceCoefficient = 1 / (float) 3;
        private const float ThermalBalancingCoefficient = 266 / (float) 9;

        private const float RadiationExposureCoefficient = 0.95f;
        private const int RegulationCoefficient = 1000;
        
        
        // T.T = Квл* Tокр + t
        public float GetBodyTemperature() => 
            InfluenceCoefficient * Temperature.Value + ThermalBalancingCoefficient;

        public (float, float) GetArterialPressure()
        {
            throw new System.NotImplementedException();
        }

        public float GetWaterInBody()
        {
            // var waterSupply = 
            
            // Кол-во жидкости = ⅗ * (ВЗ / КП^2) * 100
            // где:
            // ВЗ - водный запас 
            // НВЗ - начальный водный запас 
            //
            //
            //     ВЗ = КП^2 - t(Кпв*КП + S(floor(КО/360; 1) + ВВ*к))
            // где:
            // НВЗ - начальный водный запас
            // S - площадь, которую использует популяция 
            // КП - количество популяции 
            //     КП ~ S
            // КО - количество осадков
            // ВВ - влажность воздуха
            //     К = ½ - коэффициент влияния
            //     Кпв = 3 - потребление воды на 1 индивида
            return 0;
        }

        public float GetBloodInBody(int daysAlive, float bloodInBody) =>
            bloodInBody * (1 - 0.01f * daysAlive);

        public float GetRadiationInBody(int daysAlive, float comfortRadiation)
        {
            if (Radiation.Value <= comfortRadiation)
                return 0;

            return Radiation.Value *
                   (RadiationExposureCoefficient +
                    ((Preciptiation.MaxValue - Preciptiation.Value) / RegulationCoefficient) *
                    (SoilPurity.MaxValue - SoilPurity.Value)) * daysAlive;
            
            // Если радиация < = комфортной для популяции, то радиация = 0 иначе:
            //
            // Радиация в организме = Rокр * (Квоз.р + ((MAXос - КО) /Крег) * (MAXчист.п - ЧП)) * t
            //
            // MAXос = 8000 - максимальное количество осадков
            // Квоз.р = 0,95 - коэффициент воздействия радиации
            // Rокр - радиация окружающей среды
            // КО - количество осадков
            // MAXчист.п = 0,98 - максимальная чистота почвы 
            //     Крег = 1000 - коэффициент регуляции
            // ЧП - чистота почвы
            // t - время итерации
        }
    }
}