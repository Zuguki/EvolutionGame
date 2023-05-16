using UnityEngine;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanSprites : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.ColdHumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.LockColdHumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.ColdHumanPopulationSprite;
    }
}