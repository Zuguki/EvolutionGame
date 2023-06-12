using UnityEngine;

namespace Population.Implementation.RadiationHumanPopulation
{
    public class RadiationHumanSprite : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.RadiationHumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.LockRadiationHumanSprite;
        public Sprite Sprite1 => SpritesManager.RadiationHumanSprite1;
        public Sprite Sprite2_10 => SpritesManager.RadiationHumanPopulationSprite2_10;
        public Sprite Sprite10_100 => SpritesManager.RadiationHumanPopulationSprite10_100;
        public Sprite Sprite100_1000 => SpritesManager.RadiationHumanPopulationSprite100_1000;
        public Sprite Sprite1000_10000 => SpritesManager.RadiationHumanPopulationSprite1000_10000;
        public Sprite Sprite10000_100000 => SpritesManager.RadiationHumanPopulationSprite10000_100000;
        public Sprite Sprite100000_1000000 => SpritesManager.RadiationHumanPopulationSprite100000_1000000;
        public Sprite Sprite1000000_10000000 => SpritesManager.RadiationHumanPopulationSprite1000000_10000000;
        public Sprite Sprite10000000_100000000 => SpritesManager.RadiationHumanPopulationSprite10000000_100000000;
        public Sprite Sprite100000000_1000000000 => SpritesManager.RadiationHumanPopulationSprite100000000_1000000000;
        public Sprite Sprite1000000000_10000000000 => SpritesManager.RadiationHumanPopulationSprite1000000000_10000000000;
    }
}