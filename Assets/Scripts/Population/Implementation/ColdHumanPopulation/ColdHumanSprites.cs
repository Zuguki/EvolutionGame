using UnityEngine;

namespace Population.Implementation.ColdHumanPopulation
{
    public class ColdHumanSprites : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.ColdHumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.LockColdHumanSprite;
        public Sprite Sprite1 => SpritesManager.ColdHumanSprite1;
        public Sprite Sprite2_10 => SpritesManager.ColdHumanPopulationSprite2_10;
        public Sprite Sprite10_100 => SpritesManager.ColdHumanPopulationSprite10_100;
        public Sprite Sprite100_1000 => SpritesManager.ColdHumanPopulationSprite100_1000;
        public Sprite Sprite1000_10000 => SpritesManager.ColdHumanPopulationSprite1000_10000;
        public Sprite Sprite10000_100000 => SpritesManager.ColdHumanPopulationSprite10000_100000;
        public Sprite Sprite100000_1000000 => SpritesManager.ColdHumanPopulationSprite100000_1000000;
        public Sprite Sprite1000000_10000000 => SpritesManager.ColdHumanPopulationSprite1000000_10000000;
        public Sprite Sprite10000000_100000000 => SpritesManager.ColdHumanPopulationSprite10000000_100000000;
        public Sprite Sprite100000000_1000000000 => SpritesManager.ColdHumanPopulationSprite100000000_1000000000;
        public Sprite Sprite1000000000_10000000000 => SpritesManager.ColdHumanPopulationSprite1000000000_10000000000;
    }
}