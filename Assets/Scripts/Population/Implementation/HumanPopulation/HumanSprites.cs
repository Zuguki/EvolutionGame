using UnityEngine;

namespace Population.Implementation.HumanPopulation
{
    public class HumanSprites : IPopulationSprites
    {
        public Sprite SpriteOfMenu => SpritesManager.HumanSprite;
        public Sprite LockSpriteMenu => SpritesManager.HumanSprite;
        public Sprite Sprite1 => SpritesManager.HumanSprite1;
        public Sprite Sprite2_10 => SpritesManager.HumanPopulationSprite2_10;
        public Sprite Sprite10_100 => SpritesManager.HumanPopulationSprite10_100;
        public Sprite Sprite100_1000 => SpritesManager.HumanPopulationSprite100_1000;
        public Sprite Sprite1000_10000 => SpritesManager.HumanPopulationSprite1000_10000;
        public Sprite Sprite10000_100000 => SpritesManager.HumanPopulationSprite10000_100000;
        public Sprite Sprite100000_1000000 => SpritesManager.HumanPopulationSprite100000_1000000;
        public Sprite Sprite1000000_10000000 => SpritesManager.HumanPopulationSprite1000000_10000000;
        public Sprite Sprite10000000_100000000 => SpritesManager.HumanPopulationSprite10000000_100000000;
        public Sprite Sprite100000000_1000000000 => SpritesManager.HumanPopulationSprite100000000_1000000000;
        public Sprite Sprite1000000000_10000000000 => SpritesManager.HumanPopulationSprite1000000000_10000000000;
    }
}