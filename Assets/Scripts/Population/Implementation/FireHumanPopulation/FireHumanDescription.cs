﻿namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanDescription : IPopulationDescription
    {
        public string Title => "Огненный человек";

        public string Details1 =>
            "Огненный человек - живое существо, обладающее мышлением и речью, приспособленное к выживанию в жаркой среде обитания.";

        public string Details2 => "Две ноги, две руки, прямохождение, волосяной покров практически отсутствует(за исключением головы), пять пальцев на ногах и руках, кожа более темного тона.";

        public string Details3 =>
            $@"1. температура окружающей среды: 20 - 30 °C
2. атмосферное давление: 710-730 мм рт ст
3. радиация: <=25 мкЗв / сутки
4. влажность воздуха: 10-30 %
5. скорость ветра: 0-10 м/с
6. количество осадков: 100 - 350 мм/год
7. качество воздуха: 0 - 100 AQI
8. чистота почвы(санитарное число): 0,85-0,98 С
9. шум: 40-55 дБ";
    }
}