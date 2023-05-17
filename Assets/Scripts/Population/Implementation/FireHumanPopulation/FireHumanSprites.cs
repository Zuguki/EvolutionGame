using UnityEngine;

namespace Population.Implementation.FireHumanPopulation
{
    public class FireHumanSprites : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.FireHumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.LockFireHumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.FireHumanPopulationSprite;
    }
}