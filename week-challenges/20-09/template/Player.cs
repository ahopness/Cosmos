using System.Numerics;
using Raylib_CSharp.Textures;

namespace Platformer
{
    public class Player : Sprite
    {
        public int[] anmIdle = { 0 };
        public int[] anmJump = { 1 };
        public int[] anmWalk = { 2, 0, 3, 0 };

        public override void Create()
        {
            sprite = Texture2D.Load("Content/Sprites/char.png");
            origin = new Vector2( 4, 8 );
            animated = true;
            anmSlices = 4;
            anmSpeed = 10;
            anm = anmIdle;

            base.Create();
        }
    }
}