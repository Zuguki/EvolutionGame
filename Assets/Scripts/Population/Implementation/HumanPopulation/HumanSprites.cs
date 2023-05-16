using UnityEngine;

namespace Population.Implementation.HumanPopulation
{
    public class HumanSprites : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.HumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.HumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.HumanPopulationSprite;
    }
}