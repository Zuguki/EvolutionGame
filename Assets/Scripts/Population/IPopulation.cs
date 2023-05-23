using System.Collections.Generic;
using UnityEngine;

namespace Population
{
    public interface IPopulation 
    {
        public string Name { get; }
        
        public IPopulationDescription Description { get; }
        public IPopulationParams Parameters { get; }
        public IPopulationSprites Sprites { get; }
        public IPopulationCantBe PopulationCantBe { get; }
        
        public bool IsAlive { get; }
    }

    public interface IPopulationSprites
    {
        public Sprite SpriteOfMenu { get; }
        public Sprite LockSpriteMenu { get; }
        public Sprite SpriteOfPopulationMenu { get; }
    }

    public interface IPopulationParams
    {
        public List<string> DeadMessages { get; set; }
        public float BodyTemperature { get; set; }
        public (float, float) ArterialPressure { get; set; }
        public float WaterInBody { get; set; }
        public float Radiation { get; set; }
        public float BloodInBody { get; set; }
        public int DaysAlive { get; set; }
        public long Count { get; set; }
        public void UpdateParams();
    }
}