using UnityEngine;

namespace Population
{
    public interface IPopulationSprites
    {
        public Sprite SpriteOfMenu { get; }
        public Sprite LockSpriteMenu { get; }
        public Sprite Sprite1 { get; }
        public Sprite Sprite2_10 { get; }
        public Sprite Sprite10_100 { get; }
        public Sprite Sprite100_1000 { get; }
        public Sprite Sprite1000_10000 { get; }
        public Sprite Sprite10000_100000 { get; }
        public Sprite Sprite100000_1000000 { get; }
        public Sprite Sprite1000000_10000000 { get; }
        public Sprite Sprite10000000_100000000 { get; }
        public Sprite Sprite100000000_1000000000 { get; }
        public Sprite Sprite1000000000_10000000000 { get; }
    }
}