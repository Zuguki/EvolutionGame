using UnityEngine;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanSprite : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.RadiationHumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.LockRadiationHumanSprite;
        public Sprite SpriteOfPopulationMenu => SpritesManager.RadiationHumanPopulationSprite;
    }
}