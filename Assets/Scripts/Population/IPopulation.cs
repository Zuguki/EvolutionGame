﻿using System.Collections.Generic;
using UnityEngine;

namespace Population
{
    public interface IPopulation : IPopulationDescription
    {
        public string Name { get; }
        public PopulationEnum PopulationEnum { get; }
        public Sprite SpriteOfMenu { get; }
        public Sprite LockSpriteMenu { get; }
        public Sprite SpriteOfPopulationMenu { get; }
        public List<string> DeadMessages { get; set; }
        public int DaysAlive { get; set; }
        public float BodyTemperature { get; set; }
        public (float, float) ArterialPressure { get; set; }
        public float WaterInBody { get; set; }
        public float Radiation { get; set; }
        public float BloodInBody { get; set; }
        public long Count { get; set; }
        public bool IsAlive { get; }
        public void AddTemperature();
        public void AddPressure();
        
        public void UpdateParams();
    }
}